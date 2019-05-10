using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace BerryCore.WCF.BaseBehavior.ParameterInspector
{
    /// <summary>
    /// 自定义参数拦截
    /// </summary>
    public class CustomParameterBehaviorAttribute : Attribute, IOperationBehavior
    {
        /// <summary>实现此方法可以确定操作是否满足某些设定条件。</summary>
        /// <param name="operationDescription">正在检查的操作。 仅用于检查。 如果修改了操作说明,则结果将不确定。</param>
        public void Validate(OperationDescription operationDescription)
        {

        }

        /// <summary>在操作范围内执行服务的修改或扩展。</summary>
        /// <param name="operationDescription">正在检查的操作。 仅用于检查。 如果修改了操作说明,则结果将不确定。</param>
        /// <param name="dispatchOperation">公开 <paramref name="operationDescription" /> 所描述的操作的自定义属性的运行时对象。</param>
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            dispatchOperation.ParameterInspectors.Add(new CustomParameterInspector());
        }

        /// <summary>在操作范围内执行客户端的修改或扩展。</summary>
        /// <param name="operationDescription">正在检查的操作。 仅用于检查。 如果修改了操作说明,则结果将不确定。</param>
        /// <param name="clientOperation">公开 <paramref name="operationDescription" /> 所描述的操作的自定义属性的运行时对象。</param>
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {

        }

        /// <summary>实现此方法可以在运行时将数据传递给绑定,从而支持自定义行为。</summary>
        /// <param name="operationDescription">正在检查的操作。 仅用于检查。 如果修改了操作说明,则结果将不确定。</param>
        /// <param name="bindingParameters">绑定元素支持该行为所需的对象的集合。</param>
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {

        }
    }
}