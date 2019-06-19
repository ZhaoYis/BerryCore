using System.Net.Security;
using System.ServiceModel;

namespace BerryCore.WCF.ServiceContract.Test
{
    [ServiceContract(ProtectionLevel = ProtectionLevel.None, CallbackContract = typeof(INoticeCallback))]
    public interface INoticeOperatorContract
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void Register(string id);

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void UnRegister(string id);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        [OperationContract]
        void SendMessage(string from, string to, string message);
    }

    /// <summary>
    /// 回调协议
    /// </summary>
    public interface INoticeCallback
    {
        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="msg"></param>
        [OperationContract(IsOneWay = true)]
        void Notice(string msg);
    }
}