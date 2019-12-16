namespace BerryCore.EventBus
{
    /// <summary>
    /// 功能描述    ：定义事件处理器公共接口，所有的事件处理都要实现该接口  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-02 11:02:54 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-02 11:02:54 
    /// </summary>
    public interface IEventHandler
    {

    }

    /// <summary>
    /// 泛型事件处理器接口
    /// </summary>
    /// <typeparam name="TEventData"></typeparam>
    public interface IEventHandler<in TEventData> : IEventHandler where TEventData : IEventData
    {
        /// <summary>
        /// 事件处理器实现该方法来处理事件
        /// </summary>
        /// <param name="eventData"></param>
        void HandleEvent(TEventData eventData);
    }
}
