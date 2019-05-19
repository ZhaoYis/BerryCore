using System;
using System.Linq;
using SuperSocket.Facility.Protocol;

namespace SurperSocket.Core.Service.AppBase
{
    /// <summary>
    /// 自定义协议模板
    /// http://docs.supersocket.net/v1-6/zh-CN/The-Built-in-Common-Format-Protocol-Implementation-Templates
    /// </summary>
    public class CustomReceiveFilter : FixedHeaderReceiveFilter<CustomRequestInfo>
    {
        //TerminatorReceiveFilter， 结束符协议
        //CountSpliterReceiveFilter，固定数量分隔符协议
        //FixedSizeReceiveFilter，固定请求大小的协议
        //BeginEndMarkReceiveFilter，带起止符的协议
        //FixedHeaderReceiveFilter，头部格式固定并且包含内容长度的协议

        /// +-------+---+-------------------------------+
        /// |request| l |                               |
        /// | name  | e |    request body               |
        /// |  (2)  | n |                               |
        /// |       |(2)|                               |
        /// +-------+---+-------------------------------+
        public CustomReceiveFilter() : base(4)
        {
            //协议: 头部包含 4 个字节, 前 2 个字节用于存储请求的名字（命令值）, 后 2 个字节用于代表请求体的长度
            //00 02 00 06 01 ...   
            //功能:00 02
            //字节数:00 06
            //数据:01 02 03 04 05 06
        }

        /// <summary>
        /// 获取数据域和结尾字节长度
        /// </summary>
        /// <param name="header"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            int res = (int)header[offset + 2] * 256 + (int)header[offset + 3];
            return res;
        }
        
        /// <summary>
        /// 实现帧内容解析
        /// </summary>
        /// <param name="header"></param>
        /// <param name="bodyBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected override CustomRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            byte[] body = bodyBuffer.Skip(offset).Take(length).ToArray();

            CustomRequestInfo request = new CustomRequestInfo(header.Array, body);

            return request;
        }
    }
}