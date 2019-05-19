using System;
using System.Linq;
using SuperSocket.ProtoBase;

namespace SurperSocket.Core.Client.AppBase
{
    public class CustomReceiveFilter : FixedHeaderReceiveFilter<CustomPackageInfo>
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

        public override CustomPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            //第三个参数用0,1都可以

            //头
            byte[] header = bufferStream.Buffers[0].ToArray();
            //数据包
            byte[] bodyBuffer = bufferStream.Buffers[1].ToArray();
            //所有
            //byte[] allBuffer = bufferStream.Buffers[0].Array.CloneRange(0, (int)bufferStream.Length);

            return new CustomPackageInfo(header, bodyBuffer);
        }

        protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
        {
            ArraySegment<byte> buffers = bufferStream.Buffers[0];
            byte[] array = buffers.ToArray();
            int len = array[length - 2] * 256 + array[length - 1];

            //int len = (int)array[buffers.Offset + 2] * 256 + (int)array[buffers.Offset + 3];
            return len;
        }
    }
}