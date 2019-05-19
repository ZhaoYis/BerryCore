using System.Text;
using SuperSocket.SocketBase.Protocol;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// 自定义消息
    /// </summary>
    public class CustomRequestInfo : IRequestInfo
    {
        public CustomRequestInfo(byte[] header, byte[] bodyBuffer)
        {
            Key = (header[0] * 256 + header[1]).ToString();
            Header = header;
            Data = bodyBuffer;
        }

        /// <summary>
        /// 服务器返回的字节数据头部
        /// </summary>
        private byte[] Header { get; }

        /// <summary>
        /// 正文字节码
        /// </summary>
        private byte[] Data { get; }

        /// <summary>
        /// 协议号对应自定义命令Name,会触发自定义命令
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// 数据包
        /// </summary>
        public string Body
        {
            get
            {
                if (this.Data.Length > 0)
                {
                    return Encoding.UTF8.GetString(this.Data);
                }
                else
                {
                    return "";
                }
            }
        }
    }
}