using System;

namespace BerryCore.EventBus
{
    /// <summary>
    /// 功能描述    ：定义事件源，所有事件都需要实现
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 10:58:52 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 10:58:52 
    /// </summary>
    public interface IEventData
    {
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的对象
        /// </summary>
        object EventSource { get; set; }
    }
}
