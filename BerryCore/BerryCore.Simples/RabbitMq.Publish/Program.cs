using BerryCore.MQ.RabbitMQ;
using BerryCore.MQ.RabbitMQ.RabbitMqModel;
using BerryCore.MQ.RabbitMQ.RabbitMqProxyConfig;
using System;

namespace RabbitMq.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new RabbitMQPublisher();

            var input = Input();
            while (input != "exit")
            {
                var log = new TestMessageEntity
                {
                    Platform = "test",
                    ClientId = "test_cli",
                    Command = 100,
                    Data = input,
                    Message = "测试消息"
                };
                publisher.Publish(log, ExchangeTypeCode.Direct);
                input = Input();
            }

            publisher.Stop();
        }

        private static string Input()
        {
            Console.WriteLine("请输入信息：");
            var input = Console.ReadLine();
            return input;
        }
    }
}
