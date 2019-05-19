using System;
using SuperSocket.SocketBase;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// 自定义一个和客户端的逻辑连接，基于连接的操作应该定于在该类之中
    /// </summary>
    public class CustomSession : AppSession<CustomSession, CustomRequestInfo>
    {
        /// <summary>
        /// 自定义字段
        /// </summary>
        //public string SN { get; set; }

        /// <summary>
        /// 会话开始
        /// </summary>
        protected override void OnSessionStarted()
        {
            Console.WriteLine("会话开始");
            base.OnSessionStarted();
        }

        /// <summary>
        /// 未知命令请求
        /// </summary>
        /// <param name="requestInfo"></param>
        protected override void HandleUnknownRequest(CustomRequestInfo requestInfo)
        {
            Console.WriteLine($"未知命令：[{requestInfo.Key}]");
            base.HandleUnknownRequest(requestInfo);
        }

        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            Console.WriteLine($"服务器发生异常，异常信息：{e.Message}");
            base.HandleException(e);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }

    }
}