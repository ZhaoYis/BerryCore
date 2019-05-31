using BerryCore.MQ.Base;

namespace BerryCore.MQ.RabbitMqModel
{
    /// <summary>
    /// 测试消息模型
    /// </summary>
    [RabbitMq("RabbitMq.Direct.QueueName.Test", ExchangeName = "RabbitMq.Direct.ExchangeName.Test", RoutingKey = "RabbitMq.Direct.RoutingKey.Test", IsProperties = false)]
    public class TestMessageEntity : BaseMqMessageEntity
    {

    }
}