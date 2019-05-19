using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// 自定义配置
    /// </summary>
    public class CustomServerConfig : ServerConfig
    {
        public CustomServerConfig()
        {
            //服务器实例的名称
            this.Name = "SuperSocketServer";
            //服务器实例的类型的完整名称
            this.ServerType = "SurperSocket.Core.Service.AppBase.CustomServer, SurperSocket.Core.Service";
            //服务器监听的ip地址。你可以设置具体的地址，也可以设置为下面的值 Any - 所有的IPv4地址 IPv6Any - 所有的IPv6地址
            this.Ip = "Any";
            //服务器监听的端口
            this.Port = 9005;
            //监听队列的大小，默认值100
            this.ListenBacklog = 100;
            //Socket服务器运行的模式, Tcp (默认) 或者 Udp
            this.Mode = SocketMode.Tcp;
            //服务器实例是否禁用了
            this.Disabled = false;
            //服务器实例启动顺序, bootstrap 将按照此值的顺序来启动多个服务器实例
            this.StartupOrder = 0;
            //发送数据超时时间
            this.SendTimeOut = 1000 * 30;
            //发送队列最大长度, 默认值为5
            this.SendingQueueSize = 10;
            //可允许连接的最大连接数
            this.MaxConnectionNumber = 5000;
            //接收缓冲区大小
            this.ReceiveBufferSize = 1024;
            //发送缓冲区大小
            this.SendBufferSize = 1024;
            //是否启用同步发送模式, 默认值: false
            this.SyncSend = false;
            //是否记录命令执行的记录
            this.LogCommand = true;
            //是否记录session的基本活动，如连接和断开
            this.LogBasicSessionActivity = true;
            //是否记录所有Socket异常和错误
            this.LogAllSocketException = true;
            //是否定时清空空闲会话，默认值是 false
            this.ClearIdleSession = false;
            //清空空闲会话的时间间隔, 默认值是120, 单位：秒
            this.ClearIdleSessionInterval = 120;
            //会话空闲超时时间; 当此会话空闲时间超过此值，同时clearIdleSession被配置成true时，此会话将会被关闭; 默认值为300，单位：秒
            this.IdleSessionTimeOut = 300;
            //Tls, Ssl3。Socket服务器所采用的传输层加密协议，默认值为空; 可以设置多个值，如 "Tls11,Tls12"
            this.Security = "";
            //最大允许的请求长度，默认值为1024
            this.MaxRequestLength = 1024 * 10;
            //文本的默认编码，默认值是 ASCII
            this.TextEncoding = "UTF-8";
            //是否禁用会话快照, 默认值为 false
            this.DisableSessionSnapshot = false;
            //会话快照时间间隔, 默认值是 5, 单位：秒
            this.SessionSnapshotInterval = 5;
            //网络连接正常情况下的keep alive数据的发送间隔, 默认值为 600, 单位：秒
            this.KeepAliveTime = 600;
            //Keep alive失败之后, keep alive探测包的发送间隔，默认值为 60, 单位：秒
            this.KeepAliveInterval = 60;
            //各节点用于定义用于此服务器实例的X509Certificate证书的信息
            //this.Certificate = new CertificateConfig();
            //定义该实例所使用的连接过滤器的名字，多个过滤器用 ',' 或者 ';' 分割开来
            this.ConnectionFilter = "";
            //定义该实例所使用的命令加载器的名字，多个过滤器用 ',' 或者 ';' 分割开来
            this.CommandLoader = "";
            //定义该实例所使用的日志工厂(LogFactory)的名字。 
            //可用的日志工厂(LogFactory)定义在根节点的一个子节点内，将会在下面的文档中做更多介绍; 
            //如果你不设置该属性，定义在根节点的日志工厂(LogFactory)将会被使用，如果根节点也未定义日志工厂(LogFactory)，该实例将会使用内置的 log4net 日志工厂(LogFactory)
            this.LogFactory = "ConsoleLogFactory";
            //用于支持一个服务器实例监听多个IP/端口组合
            //this.Listeners = new List<IListenerConfig>();
            //定义该实例所使用的接收过滤器工厂的名字
            this.ReceiveFilterFactory = "";
        }
    }
}