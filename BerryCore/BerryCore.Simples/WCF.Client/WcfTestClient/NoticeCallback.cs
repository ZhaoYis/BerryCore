using System;
using System.Diagnostics;
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
            Trace.WriteLine(msg);
        }
    }
}