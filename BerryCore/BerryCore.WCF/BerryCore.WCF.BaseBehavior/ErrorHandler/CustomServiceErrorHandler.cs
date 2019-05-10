using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using BerryCore.Code;
using BerryCore.Extensions;
using BerryCore.WCF.DataContract.Base;

namespace BerryCore.WCF.BaseBehavior.ErrorHandler
{
    /// <summary>
    /// 自定义异常处理
    /// </summary>
    public class CustomServiceErrorHandler : IErrorHandler
    {
        /// <summary>启用创建从服务方法过程中的异常返回的自定义 <see cref="T:System.ServiceModel.FaultException`1" />。</summary>
        /// <param name="error">服务操作过程中引发的 <see cref="T:System.Exception" /> 对象。</param>
        /// <param name="version">消息的 SOAP 版本。</param>
        /// <param name="fault">双工情况下,返回到客户端或服务的 <see cref="T:System.ServiceModel.Channels.Message" /> 对象。</param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            //要修改返回内容注意这里
            BaseSoapResult<string> res = new BaseSoapResult<string>
            {
                Status = JsonObjectStatus.Exception,
                Data = error.TargetSite.Name,
                Msg = error.Message.ToString()
            };

            FaultException newEx = new FaultException(res.TryToJson());
            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);

            //fault = Message.CreateMessage(version, "http://tempuri.org/svfault", res, new DataContractJsonSerializer(typeof(BaseJsonResult4API<string>)));
        }

        /// <summary>启用错误相关处理并返回一个值,该值指示调度程序在某些情况下是否中止会话和实例上下文。</summary>
        /// <returns>如果 Windows Communication Foundation (WCF) 不应中止会话（如果有一个）和实例上下文（如果实例上下文不是 <see cref="F:System.ServiceModel.InstanceContextMode.Single" />）,则为 true；否则为 false。 默认值为 false。</returns>
        /// <param name="error">处理过程中引发的异常。</param>
        public bool HandleError(Exception error)
        {
            return true;
        }
    }
}