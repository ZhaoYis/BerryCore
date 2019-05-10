using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace BerryCore.WCF.BaseBehavior.ErrorHandler
{
    /// <summary>
    /// 自定义错误处理
    /// </summary>
    public class CustomErrorContractBehaviorAttribute : Attribute, IContractBehavior
    {
        /// <summary>实现此方法可以确认协定和终结点是否支持协定行为。</summary>
        /// <param name="contractDescription">要验证的协定。</param>
        /// <param name="endpoint">要验证的终结点。</param>
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {

        }

        /// <summary>在协定范围内执行客户端的修改或扩展。</summary>
        /// <param name="contractDescription">要修改的协定说明。</param>
        /// <param name="endpoint">公开协定的终结点。</param>
        /// <param name="dispatchRuntime">控制服务执行的调度运行时。</param>
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint,
            DispatchRuntime dispatchRuntime)
        {
            CustomServiceErrorHandler errorHandler = new CustomServiceErrorHandler();
            dispatchRuntime.ChannelDispatcher.ErrorHandlers.Add(errorHandler);
        }

        /// <summary>在协定范围内执行客户端的修改或扩展。</summary>
        /// <param name="contractDescription">要实现扩展的协定说明。</param>
        /// <param name="endpoint">终结点。</param>
        /// <param name="clientRuntime">客户端运行时。</param>
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint,
            ClientRuntime clientRuntime)
        {

        }

        /// <summary>配置所有绑定元素以支持协定行为。</summary>
        /// <param name="contractDescription">要修改的协定说明。</param>
        /// <param name="endpoint">要修改的终结点。</param>
        /// <param name="bindingParameters">绑定元素支持该行为所需的对象。</param>
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint,
            BindingParameterCollection bindingParameters)
        {

        }
    }
}