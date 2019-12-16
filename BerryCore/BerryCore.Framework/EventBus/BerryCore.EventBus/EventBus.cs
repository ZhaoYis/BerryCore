using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BerryCore.EventBus
{
    /// <summary>
    /// 功能描述    ：事件总线  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 11:07:24 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 11:07:24 
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly ConcurrentDictionary<Type, List<Type>> _eventAndHandlerMapping;

        public static EventBus Default { get; } = new EventBus();

        private EventBus()
        {
            _eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>>();

            //自动处理事件源与事件绑定
            this.MapEventToHandler();
        }

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventHandler"></param>
        /// <returns></returns>
        public void Register(Type eventType, IEventHandler eventHandler)
        {
            List<Type> handlerTypes = _eventAndHandlerMapping[eventType];
            if (!handlerTypes.Contains(eventHandler.GetType()))
            {
                handlerTypes.Add(eventHandler.GetType());
                _eventAndHandlerMapping[eventType] = handlerTypes;
            }
        }

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        public void Register<TEventData>(IEventHandler eventHandler) where TEventData : IEventData
        {
            Register(typeof(TEventData), eventHandler);
        }

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public void Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            Register(typeof(TEventData), new ActionEventHandler<TEventData>(action));
        }

        /// <summary>
        /// 手动解除事件源与事件处理的绑定
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventHandler"></param>
        public void UnRegister(Type eventType, IEventHandler eventHandler)
        {
            List<Type> handlerTypes = _eventAndHandlerMapping[eventType];
            if (handlerTypes.Contains(eventHandler.GetType()))
            {
                handlerTypes.Remove(eventHandler.GetType());
                _eventAndHandlerMapping[eventType] = handlerTypes;
            }
        }

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            Trigger((object)null, eventData);
        }

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventSource"></param>
        /// <param name="eventData"></param>
        public void Trigger<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData
        {
            Trigger(typeof(TEventData), eventSource, eventData);
        }

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventData"></param>
        public void Trigger(Type eventType, IEventData eventData)
        {
            Trigger(eventType, null, eventData);
        }

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventSource"></param>
        /// <param name="eventData"></param>
        public void Trigger(Type eventType, object eventSource, IEventData eventData)
        {
            eventData.EventSource = eventSource;

            List<Type> handlers = _eventAndHandlerMapping[eventType];

            if (handlers != null && handlers.Count > 0)
            {
                foreach (Type handler in handlers)
                {
                    MethodInfo methodInfo = handler.GetMethod("HandleEvent");
                    if (methodInfo != null)
                    {
                        object obj = Activator.CreateInstance(handler);
                        methodInfo.Invoke(obj, new object[] { eventData });
                    }
                }
            }
        }

        #region 私有方法

        /// <summary>
        /// 自动处理事件源与事件绑定
        /// </summary>
        private void MapEventToHandler()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IEventHandler).IsAssignableFrom(type))
                    {
                        Type handler = type.GetInterface("IEventHandler`1");
                        if (handler != null)
                        {
                            Type eventDataType = handler.GetGenericArguments().First();
                            if (eventDataType != null && _eventAndHandlerMapping.ContainsKey(eventDataType))
                            {
                                List<Type> handlerTypes = _eventAndHandlerMapping[eventDataType];
                                handlerTypes.Add(type);

                                _eventAndHandlerMapping[eventDataType] = handlerTypes;
                            }
                            else
                            {
                                if (eventDataType != null)
                                {
                                    List<Type> handlerTypes = new List<Type> { type };
                                    _eventAndHandlerMapping[eventDataType] = handlerTypes;
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
