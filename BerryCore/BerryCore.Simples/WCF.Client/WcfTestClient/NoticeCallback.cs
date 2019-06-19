using System;
using BerryCore.WCF.ServiceContract.Test;

namespace WcfTestClient
{
    public class NoticeCallback : INoticeCallback
    {
        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="msg"></param>
        public void Notice(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}