using BerryCore.WCF.ServiceContract.Test;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace BerryCore.WCF.ServiceBehavior.TestImpl
{
    public class NoticeOperatorContract : INoticeOperatorContract
    {
        private static List<ClientDto> clientList = new List<ClientDto>();

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="id"></param>
        public void Register(string id)
        {
            Console.WriteLine("有新用户注册，ID为：{0}", id);

            INoticeCallback callback = OperationContext.Current.GetCallbackChannel<INoticeCallback>();
            clientList.Add(new ClientDto
            {
                Id = id,
                NoticeCallback = callback
            });
        }

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="id"></param>
        public void UnRegister(string id)
        {
            Console.WriteLine("有用户取消注册，ID为：{0}", id);

            ClientDto client = clientList.Find(c => c.Id == id);
            if (client != null)
            {
                clientList.Remove(client);
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        public void SendMessage(string @from, string to, string message)
        {
            ClientDto client = clientList.Find(c => c.Id == to);
            if (client != null)
            {
                string msg = string.Format("用户【{0}】向用户【{1}】发送消息：{2}，发送时间：{3}", from, to, message, DateTime.Now);
                Console.WriteLine(msg);
                client.NoticeCallback.Notice(msg);
            }
        }
    }

    public class ClientDto
    {
        public string Id { get; set; }

        public INoticeCallback NoticeCallback { get; set; }
    }
}