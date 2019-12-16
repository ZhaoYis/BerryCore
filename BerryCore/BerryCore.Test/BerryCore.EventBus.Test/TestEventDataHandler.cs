using System;

namespace BerryCore.EventBus.Test
{
    /// <summary>
    /// 功能描述    ：TestEventDataHandler  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 11:23:56 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 11:23:56 
    /// </summary>
    public class TestEventDataHandler : IEventHandler<TestEventData>
    {
        /// <summary>
        /// 事件处理器实现该方法来处理事件
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(TestEventData eventData)
        {
            Console.WriteLine(eventData.Message);
        }
    }
}
