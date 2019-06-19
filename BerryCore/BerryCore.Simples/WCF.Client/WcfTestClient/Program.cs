using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BerryCore.WCF.ServiceContract.Test;

namespace WcfTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new NoticeCallback());
            using (ChannelFactory<INoticeOperatorContract> factory = new DuplexChannelFactory<INoticeOperatorContract>(context, new NetTcpBinding(), "net.tcp://127.0.0.1:8801/NoticeOperatorContract"))
            {
                INoticeOperatorContract proxy = factory.CreateChannel();

                Console.WriteLine("请输入您的ID：");
                String selfId = Console.ReadLine();

                Console.WriteLine("请输入您朋友的ID：");
                String friendId = Console.ReadLine();

                proxy.Register(selfId);
                Console.WriteLine("----------Register------------");

                while (true)
                {
                    String message = Console.ReadLine();
                    if (message == "q")
                    {
                        proxy.UnRegister(selfId);
                        break;
                    }
                    else
                    {
                        proxy.SendMessage(selfId, friendId, message);
                    }
                }
            }
        }
    }
}
