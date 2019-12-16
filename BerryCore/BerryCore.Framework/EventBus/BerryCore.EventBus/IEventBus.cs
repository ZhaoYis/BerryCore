using System;

namespace BerryCore.EventBus
{
    /// <summary>
    /// 功能描述    ：事件总线  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 11:05:37 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 11:05:37 
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventHandler"></param>
        /// <returns></returns>
        void Register(Type eventType, IEventHandler eventHandler);

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventHandler"></param>
        void Register<TEventData>(IEventHandler eventHandler) where TEventData : IEventData;

        /// <summary>
        /// 手动绑定事件源与事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        void Register<TEventData>(Action<TEventData> action) where TEventData : IEventData;
        
        /// <summary>
        /// 手动解除事件源与事件处理的绑定
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventHandler"></param>
        void UnRegister(Type eventType, IEventHandler eventHandler);

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventData"></param>
        void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData;

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="eventSource"></param>
        /// <param name="eventData"></param>
        void Trigger<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData;

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventData"></param>
        void Trigger(Type eventType, IEventData eventData);

        /// <summary>
        /// 根据事件源触发绑定的事件处理
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="eventSource"></param>
        /// <param name="eventData"></param>
        void Trigger(Type eventType, object eventSource, IEventData eventData);
    }
}
