using System;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SurperSocket.Core.Service.AppBase;

namespace SurperSocket.Core.Service.Tools
{
    /// <summary>
    /// /服务端
    /// </summary>
    public class SocketServiceEasyClient
    {
        #region 基础实例
        private IBootstrap _bootstrap = null;
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitEasyClient()
        {
            //通过读取配置文件启动
            _bootstrap = BootstrapFactory.CreateBootstrap();
            
            bool isSucc = _bootstrap.Initialize();
            if (isSucc)
            {
                var result = _bootstrap.Start();
                foreach (var server in _bootstrap.AppServers)
                {
                    switch (server.State)
                    {
                        case ServerState.Running:
                            Console.WriteLine($"{server.Name} 运行中");
                            break;

                        case ServerState.NotInitialized:
                            break;

                        case ServerState.Initializing:
                            break;

                        case ServerState.NotStarted:
                            break;

                        case ServerState.Starting:
                            break;

                        case ServerState.Stopping:
                            break;

                        default:
                            Console.WriteLine($"{server.Name} 启动失败");
                            break;
                    }
                }

                switch (result)
                {
                    case StartResult.Failed:
                        Console.WriteLine("无法启动服务，更多错误信息请查看日志");
                        break;

                    case StartResult.None:
                        Console.WriteLine("没有服务器配置，请检查你的配置！");
                        break;

                    case StartResult.PartialSuccess:
                        Console.WriteLine("一些服务启动成功，但是还有一些启动失败，更多错误信息请查看日志");
                        break;

                    case StartResult.Success:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                Console.WriteLine("初始化失败！");
            }
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            _bootstrap.Stop();
        }
    }
}