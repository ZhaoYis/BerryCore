using System;

namespace BerryCore.EventBus
{
    /// <summary>
    /// 功能描述    ：事件源  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 11:01:44 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 11:01:44 
    /// </summary>
    [Serializable]
    public class EventData : IEventData
    {
        protected EventData()
        {
            EventTime = DateTime.Now;
        }

        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的对象
        /// </summary>
        public object EventSource { get; set; }
    }
}
