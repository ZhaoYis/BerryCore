using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using BerryCore.Code;
using BerryCore.Extensions;
using BerryCore.Log;
using BerryCore.WCF.BaseBehavior.ErrorHandler;
using BerryCore.WCF.DataContract.Base;

namespace BerryCore.WCF.BaseBehavior
{
    /// <summary>
    /// 服务协议基类
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(Namespace = GlobalConstCode.DEFAULT_WSDL_NAMESPACE, IncludeExceptionDetailInFaults = true)]
    [CustomErrorContractBehavior]
    public class BaseServiceBehavior : BaseLogger, IBaseServiceBehavior
    {
        #region 公共方法

        /// <summary>
        /// 获取公共返回消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据</param>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual BaseSoapResult<string> GetBaseSoapResult<T>(T data = default(T), JsonObjectStatus status = JsonObjectStatus.Error, string message = "") where T : class
        {
            message = string.Format("{0}{1}", status.GetEnumDescription(), string.IsNullOrEmpty(message) ? "" : "," + message);
            BaseSoapResult<string> resultMsg = new BaseSoapResult<string>
            {
                Status = status,
                Msg = message,
                Data = data == null ? "" : data.TryToJson()
            };
            return resultMsg;
        }

        /// <summary>
        /// 获取公共返回消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual BaseSoapResult<string> GetBaseSoapResult<T>(JsonObjectStatus status = JsonObjectStatus.Error, string message = "") where T : class
        {
            message = status == JsonObjectStatus.Success
                ? status.GetEnumDescription()
                : string.Format("{0}{1}", status.GetEnumDescription(), string.IsNullOrEmpty(message) ? "" : "," + message);
            BaseSoapResult<string> resultMsg = new BaseSoapResult<string>
            {
                Status = status,
                Msg = message,
            };
            return resultMsg;
        }

        #endregion 公共方法

    }
}