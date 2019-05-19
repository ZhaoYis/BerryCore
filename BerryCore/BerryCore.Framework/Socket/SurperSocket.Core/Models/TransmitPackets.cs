using System;

namespace SurperSocket.Core.Models
{
    /// <summary>
    /// 通用基础通讯结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class TransmitPackets<T> : BaseTransmitPackets where T : class
    {
        public TransmitPackets()
        {
            this.Sign = this.GetSign(this.ToString());
        }

        /// <summary>
        /// 目标平台
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 客户端唯一标识
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 状态码或者命令值
        /// </summary>
        public int Command { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>返回表示当前对象的字符串。</summary>
        /// <returns>表示当前对象的字符串。</returns>
        public sealed override string ToString()
        {
            string sign = this.Platform + this.Data + this.ClientId + this.Command + this.CreateTime;
            return sign;
        }
    }
}