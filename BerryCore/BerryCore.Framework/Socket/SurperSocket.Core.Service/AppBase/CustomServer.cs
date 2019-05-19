using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SurperSocket.Core.Service.Commands;
using SurperSocket.Core.Service.Tools;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// 自定义监听客户端连接，承载TCP连接的服务器实例
    /// </summary>
    [CheckCommandFilter]
    public sealed class CustomServer : AppServer<CustomSession, CustomRequestInfo>
    {
        /// <summary>
        /// 业务处理中心
        /// </summary>
        private readonly ServiceHandlerCenter _serviceHandlerCenter = new ServiceHandlerCenter();

        /// <summary>
        /// 通过配置文件安装服务从这里启动
        /// </summary>
        public CustomServer() :
            base(new DefaultReceiveFilterFactory<CustomReceiveFilter, CustomRequestInfo>())
        {
            //保存当前服务器对象
            SocketServiceObject.SocketService = this;

            this.NewSessionConnected += OnNewSessionConnected;
            this.SessionClosed += OnSessionClosed;
            //this.NewRequestReceived += OnNewRequestReceived;
        }

        /// <summary>
        /// 启动成功
        /// </summary>
        protected override void OnStarted()
        {
            if (_serviceHandlerCenter.OnStartedHandler != null)
            {
                _serviceHandlerCenter.OnStartedHandler.Invoke();
            }
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStopped()
        {
            if (_serviceHandlerCenter.OnStoppedHandler != null)
            {
                _serviceHandlerCenter.OnStoppedHandler.Invoke();
            }
        }

        /// <summary>
        /// 新的客户端已经连接
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(CustomSession session)
        {
            if (_serviceHandlerCenter.OnNewSessionConnectedHandler != null)
            {
                _serviceHandlerCenter.OnNewSessionConnectedHandler.Invoke(session);
            }
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        /// <param name="session"></param>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CustomSession session, CloseReason reason)
        {
            if (_serviceHandlerCenter.OnSessionClosedHandler != null)
            {
                _serviceHandlerCenter.OnSessionClosedHandler.Invoke(session, reason);
            }
        }

        /// <summary>
        /// 新请求到达
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestinfo"></param>
        private void OnNewRequestReceived(CustomSession session, CustomRequestInfo requestinfo)
        {
            string key = requestinfo.Key;

            Console.WriteLine("新的请求到达");
        }

    }
}