using BerryCore.MQ.RabbitMQ.EasyNetQ;
using BerryCore.MQ.RabbitMqModel;
using System;

namespace RabbitMq.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            //var publisher = new RabbitMQPublisher();

            //var input = Input();
            //while (input != "exit")
            //{
            //    var log = new TestMessageEntity
            //    {
            //        Platform = "test",
            //        ClientId = "test_cli",
            //        Command = 100,
            //        Data = input,
            //        Message = "测试消息"
            //    };
            //    publisher.Publish(log, ExchangeTypeCode.Direct);
            //    input = Input();
            //}

            //publisher.Stop();

            EasyNetQPublisher easyNetQPublisher = new EasyNetQPublisher();
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
                easyNetQPublisher.Publish(log);
                input = Input();
            }
            easyNetQPublisher.Stop();
        }

        private static string Input()
        {
            Console.WriteLine("请输入信息：");
            var input = Console.ReadLine();
            return input;
        }
    }
}
