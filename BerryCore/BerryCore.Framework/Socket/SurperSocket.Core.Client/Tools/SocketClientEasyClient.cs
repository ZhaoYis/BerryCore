using System;
using System.Net;
using System.Threading;
using SuperSocket.ClientEngine;
using SurperSocket.Core.Client.AppBase;

namespace SurperSocket.Core.Client.Tools
{
    /// <summary>
    /// 自定义客户端
    /// </summary>
    public class SocketClientEasyClient
    {
        private EasyClient<CustomPackageInfo> _client = null;

        /// <summary>
        /// 服务器IP地址+端口
        /// </summary>
        private IPEndPoint ServiceIP { get; set; }

        public SocketClientEasyClient(IPEndPoint ip)
        {
            this.ServiceIP = ip;
        }

        /// <summary>
        /// 默认初始化方式
        /// </summary>
        /// <returns></returns>
        public EasyClient<CustomPackageInfo> InitEasyClient()
        {
            _client = new EasyClient<CustomPackageInfo>();
            _client.Initialize(new CustomReceiveFilter());

            _client.Connected += OnClientConnected;
            _client.NewPackageReceived += OnPagckageReceived;
            _client.Error += OnClientError;
            _client.Closed += OnClientClosed;

            var connected = _client.ConnectAsync(this.ServiceIP);

            return _client;
        }

        /// <summary>
        /// 自定义初始化
        /// </summary>
        /// <param name="onPagckageReceived"></param>
        /// <returns></returns>
        public EasyClient<CustomPackageInfo> InitEasyClient(EventHandler<PackageEventArgs<CustomPackageInfo>> onPagckageReceived)
        {
            _client = new EasyClient<CustomPackageInfo>();
            _client.Initialize(new CustomReceiveFilter());

            _client.Connected += OnClientConnected;
            _client.NewPackageReceived += onPagckageReceived;
            _client.Error += OnClientError;
            _client.Closed += OnClientClosed;

            var connected = _client.ConnectAsync(this.ServiceIP);

            return _client;
        }
        
        /// <summary>
        /// 自定义初始化
        /// </summary>
        /// <param name="onClientConnected"></param>
        /// <param name="onPagckageReceived"></param>
        /// <param name="onClientError"></param>
        /// <param name="onClientClosed"></param>
        /// <returns></returns>
        public EasyClient<CustomPackageInfo> InitEasyClient(EventHandler onClientConnected, EventHandler<PackageEventArgs<CustomPackageInfo>> onPagckageReceived, EventHandler<ErrorEventArgs> onClientError, EventHandler onClientClosed)
        {
            _client = new EasyClient<CustomPackageInfo>();
            _client.Initialize(new CustomReceiveFilter());

            _client.Connected += onClientConnected;
            _client.NewPackageReceived += onPagckageReceived;
            _client.Error += onClientError;
            _client.Closed += onClientClosed;

            var connected = _client.ConnectAsync(this.ServiceIP);

            return _client;
        }

        #region 私有方法

        /// <summary>
        /// 掉线重连
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClientClosed(object sender, EventArgs e)
        {
            do
            {
                Console.WriteLine("连接已断开...");
                Console.WriteLine("等待5秒中后重新连接");
                Thread.Sleep(5000);

                InitEasyClient();

            } while (!_client.IsConnected);
        }

        /// <summary>
        /// 客户端错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClientError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("客户端错误：" + e.Exception.Message);
        }

        /// <summary>
        /// 收到消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPagckageReceived(object sender, PackageEventArgs<CustomPackageInfo> e)
        {
            Console.WriteLine("收到消息：" + e.Package.Body);
        }

        /// <summary>
        /// 已连接到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClientConnected(object sender, EventArgs e)
        {
            Console.WriteLine("已连接到服务器");
        } 
        #endregion
    }
}