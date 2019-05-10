using System;
using System.ServiceModel.Dispatcher;
using System.Text;
using BerryCore.Extensions;

namespace BerryCore.WCF.BaseBehavior.ParameterInspector
{
    /// <summary>
    /// 自定义参数检查器实现的协定,有了该协定,就可在客户端或服务进行调用之前或紧接着其调用,检查或修改信息。
    /// </summary>
    public class CustomParameterInspector : IParameterInspector
    {
        /// <summary>在发送客户端调用之前、服务响应返回之后调用。</summary>
        /// <returns>
        /// <param name="operationName">操作的名称。</param>
        /// <param name="inputs">客户端传递到方法的对象。</param>
        public object BeforeCall(string operationName, object[] inputs)
        {
            Console.WriteLine("\r\n************************参数拦截（{0}） 开始************************", operationName);
            StringBuilder builder = new StringBuilder(string.Format("操作方法：{0} \r\n", operationName));
            for (int i = 1; i < inputs.Length + 1; i++)
            {
                builder.Append(string.Format("参数{0},值：{1}\r\n", i, (inputs[i - 1]).TryToJson()));
            }

            Console.WriteLine("\r\n{0}\r\n", builder.ToString());
            return null;
        }

        /// <summary>在客户端调用返回之后、服务响应发送之前调用。</summary>
        /// <param name="operationName">所调用的操作的名称。</param>
        /// <param name="outputs">任何输出对象。</param>
        /// <param name="returnValue">操作的返回值。</param>
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            Console.WriteLine("操作方法：{0}\r\n返回：{1}\r\n", operationName, returnValue.TryToJson());
            Console.WriteLine("************************参数拦截（{0}） 结束************************\r\n", operationName);
        }
    }
}