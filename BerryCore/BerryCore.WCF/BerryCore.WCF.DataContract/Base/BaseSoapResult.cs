using System.Runtime.Serialization;
using BerryCore.Code;

namespace BerryCore.WCF.DataContract.Base
{
    /// <summary>
    /// SOAP协议传输基础实体
    /// </summary>
    /// <typeparam name="T">数据包具体类型</typeparam>
    [DataContract(Name = "BaseSoapResult")]
    public class BaseSoapResult<T> where T : class
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [DataMember(IsRequired = true)]
        public JsonObjectStatus Status { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [DataMember(IsRequired = true)]
        public T Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [DataMember(IsRequired = true)]
        public string Msg { get; set; }
    }
}