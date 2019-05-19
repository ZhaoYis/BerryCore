using System;
using SuperSocket.SocketBase;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// 业务处理中心
    /// </summary>
    public class ServiceHandlerCenter
    {
        public delegate void OnStartedHandled();
        public delegate void OnStoppedHandled();
        public delegate void OnNewSessionConnectedHandled(CustomSession session);
        public delegate void OnSessionClosedHandled(CustomSession session, CloseReason reason);

        /// <summary>
        /// 服务开启时执行
        /// </summary>
        public readonly OnStartedHandled OnStartedHandler = new OnStartedHandled(OnStarted);
        /// <summary>
        /// 服务关闭时执行
        /// </summary>
        public readonly OnStoppedHandled OnStoppedHandler = new OnStoppedHandled(OnStopped);
        /// <summary>
        /// 有新客户端连接时执行
        /// </summary>
        public readonly OnNewSessionConnectedHandled OnNewSessionConnectedHandler = new OnNewSessionConnectedHandled(OnNewSessionConnected);
        /// <summary>
        /// 客户端断开连接时执行
        /// </summary>
        public readonly OnSessionClosedHandled OnSessionClosedHandler = new OnSessionClosedHandled(OnSessionClosed);

        /// <summary>
        /// 服务开启
        /// </summary>
        private static void OnStarted()
        {
            Console.WriteLine("服务器启动成功");
        }

        /// <summary>
        /// 服务关闭
        /// </summary>
        private static void OnStopped()
        {
            Console.WriteLine("服务停止");
        }

        /// <summary>
        /// 有新客户端连接
        /// </summary>
        /// <param name="session"></param>
        private static void OnNewSessionConnected(CustomSession session)
        {
            Console.WriteLine($"新的客户端已经连接,{session.RemoteEndPoint.Address}:{session.RemoteEndPoint.Port}");
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        private static void OnSessionClosed(CustomSession session, CloseReason reason)
        {
            switch (reason)
            {
                case CloseReason.Unknown:
                    break;
                case CloseReason.ServerShutdown:
                    break;
                case CloseReason.ClientClosing:
                    break;
                case CloseReason.ServerClosing:
                    break;
                case CloseReason.ApplicationError:
                    break;
                case CloseReason.SocketError:
                    break;
                case CloseReason.TimeOut:
                    break;
                case CloseReason.ProtocolError:
                    break;
                case CloseReason.InternalError:
                    break;
            }
            Console.WriteLine($"客户端[{session.RemoteEndPoint.Address}:{session.RemoteEndPoint.Port}]关闭,原因：{reason.ToString()}");
        }
    }
}