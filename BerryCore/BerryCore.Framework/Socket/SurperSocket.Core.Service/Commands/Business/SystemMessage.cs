using System;
using SuperSocket.SocketBase.Command;
using SurperSocket.Core.Service.AppBase;
using SurperSocket.Core.Service.Tools;

namespace SurperSocket.Core.Service.Commands.Business
{
    /// <summary>
    /// 系统消息
    /// </summary>
    public class SystemMessage : CommandBase<CustomSession, CustomRequestInfo>
    {
        private SocketCommand command = SocketCommand.SystemMessage;

        /// <summary>Gets the name.</summary>
        public override string Name
        {
            get { return ((int)command).ToString(); }
        }

        /// <summary>
        /// 上行（来自客户端的信息）
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        public override void ExecuteCommand(CustomSession session, CustomRequestInfo requestInfo)
        {
            string key = requestInfo.Key;

            Console.WriteLine($"[{command.GetDescription()}]命令被执行");
            Console.WriteLine("内容是：" + requestInfo.Body);

            string jsonData = "收到消息".GetTransmitPackets(SocketCommand.CustomMsg);
            session.Send(SocketCommand.CustomMsg, jsonData);
        }
    }
}