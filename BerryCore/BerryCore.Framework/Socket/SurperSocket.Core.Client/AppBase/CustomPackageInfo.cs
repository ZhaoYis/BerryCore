using System.Text;
using SuperSocket.ProtoBase;

namespace SurperSocket.Core.Client.AppBase
{
    /// <summary>
    /// 自定义消息
    /// </summary>
    public class CustomPackageInfo : IPackageInfo
    {
        public CustomPackageInfo(byte[] header, byte[] bodyBuffer)
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
        /// 服务器返回的字节数据
        /// </summary>
        private byte[] Data { get; }

        /// <summary>
        /// 协议号对应自定义命令Name,会触发自定义命令
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// 服务器返回的字符串数据
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