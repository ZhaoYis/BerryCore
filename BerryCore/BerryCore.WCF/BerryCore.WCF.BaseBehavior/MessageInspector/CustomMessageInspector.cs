using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace BerryCore.WCF.BaseBehavior.MessageInspector
{
    /// <summary>
    /// 自定义消息拦截
    /// </summary>
    public class CustomMessageInspector : IDispatchMessageInspector, IClientMessageInspector
    {
        #region 服务端
        /// <summary>在已接收入站消息后将消息调度到应发送到的操作之前调用。</summary>
        /// <param name="request">请求消息。</param>
        /// <param name="channel">传入通道。</param>
        /// <param name="instanceContext">当前服务实例。</param>
        object IDispatchMessageInspector.AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //Console.WriteLine("\r\n=====================服务器 接收消息=====================\r\n");
            //Console.WriteLine(request.ToString());

            //string user = request.Headers.GetHeader<string>("u", "identity_verification");
            //string pwd = request.Headers.GetHeader<string>("p", "identity_verification");
            //if (user == "admin" && pwd == "123")
            //{
            //    Console.WriteLine("用户名和密码正确。");
            //}
            //else
            //{
            //    throw new Exception("用户名和密码错误！");
            //}

            return request;
        }

        /// <summary>在操作已返回后发送回复消息之前调用。</summary>
        /// <param name="reply">回复消息。 如果操作是单向的,则此值为 null。</param>
        /// <param name="correlationState"></param>
        void IDispatchMessageInspector.BeforeSendReply(ref Message reply, object correlationState)
        {
            //Console.WriteLine("\r\n=====================服务器 回复消息=====================\r\n");
            //Console.WriteLine(reply.ToString());
        }
        #endregion

        #region 客户端

        /// <summary>在将请求消息发送到服务之前,启用消息的检查或修改。</summary>
        /// <param name="request">要发送给服务的消息。</param>
        /// <param name="channel">WCF 客户端对象通道。</param>
        object IClientMessageInspector.BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Console.WriteLine("\r\n=====================客户端 请求前消息=====================\r\n");
            Console.WriteLine(request.ToString());

            //MessageHeader user = MessageHeader.CreateHeader("u", "identity_verification", "admin");
            //MessageHeader pwd = MessageHeader.CreateHeader("p", "identity_verification", "123");
            //request.Headers.Add(user);
            //request.Headers.Add(pwd);

            return request;
        }

        /// <summary>在收到回复消息之后将它传递回客户端应用程序之前,启用消息的检查或修改。</summary>
        /// <param name="reply">要转换为类型并交回给客户端应用程序的消息。</param>
        /// <param name="correlationState">关联状态数据。</param>
        void IClientMessageInspector.AfterReceiveReply(ref Message reply, object correlationState)
        {
            Console.WriteLine("\r\n=====================客户端 收到回复=====================\r\n");
            Console.WriteLine(reply.ToString());
        } 
        #endregion
    }
}