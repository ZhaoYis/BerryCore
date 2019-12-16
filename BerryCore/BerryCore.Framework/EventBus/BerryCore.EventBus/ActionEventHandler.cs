using System;

namespace BerryCore.EventBus
{
    /// <summary>
    /// 功能描述    ：ActionEventHandler  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 11:47:47 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 11:47:47 
    /// </summary>
    public class ActionEventHandler<TEventData> : IEventHandler<TEventData> where TEventData : IEventData
    {
        public Action<TEventData> Action { get; private set; }

        public ActionEventHandler(Action<TEventData> handler)
        {
            Action = handler;
        }

        /// <summary>
        /// 事件处理器实现该方法来处理事件
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(TEventData eventData)
        {
            Action(eventData);
        }
    }
}
