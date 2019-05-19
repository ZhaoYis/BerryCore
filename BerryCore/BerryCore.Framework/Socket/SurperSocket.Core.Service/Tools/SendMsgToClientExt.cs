using SurperSocket.Core.Service.AppBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SurperSocket.Core.Models;

namespace SurperSocket.Core.Service.Tools
{
    /// <summary>
    /// 服务器向客户端发送消息扩展方法
    /// </summary>
    public static class SendMsgToClientExt
    {
        /// <summary>
        /// 向指定会话对象推送消息
        /// </summary>
        /// <param name="session">当前会话</param>
        /// <param name="command">命令</param>
        /// <param name="msg">数据包</param>
        public static void Send(this CustomSession session, SocketCommand command, string msg)
        {
            if (session != null && session.Connected)
            {
                byte[] data = GetMsgBytes(msg, command);

                session.Send(data, 0, data.Length);
            }
        }

        /// <summary>
        /// 向所有会话对象推送消息
        /// </summary>
        /// <param name="command">命令</param>
        /// <param name="msg">数据包</param>
        public static void SendToAll(SocketCommand command, string msg)
        {
            CustomServer server = SocketServiceObject.SocketService;
            if (server != null && server.SessionCount > 0)
            {
                IEnumerable<CustomSession> allSessions = server.GetAllSessions();
                foreach (CustomSession session in allSessions)
                {
                    if (session != null && session.Connected)
                    {
                        session.Send(command, msg);
                    }
                }
            }
        }

        /// <summary>
        /// 根据SessionId获取连接对象
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public static CustomSession GetSessionById(this string sessionId)
        {
            CustomServer server = SocketServiceObject.SocketService;
            if (server != null && server.SessionCount > 0)
            {
                return server.GetSessionByID(sessionId);
            }
            return null;
        }

        /// <summary>
        /// 连接数
        /// </summary>
        /// <returns></returns>
        public static int SessionCount()
        {
            return SocketServiceObject.SocketService.SessionCount;
        }

        /// <summary>
        /// 组装自定义数据包
        /// </summary>
        /// <typeparam name="T">数据包类型</typeparam>
        /// <param name="msg">数据</param>
        /// <param name="command">命令</param>
        /// <param name="platform">目标平台</param>
        /// <param name="clientId">客户端唯一标识</param>
        /// <param name="info">普通消息</param>
        /// <returns></returns>
        public static string GetTransmitPackets<T>(this T msg, SocketCommand command, string platform = "", string clientId = "", string info = "") where T : class
        {
            TransmitPackets<T> transmit = new TransmitPackets<T>
            {
                Command = (int)command,
                Data = msg,
                Platform = platform,
                ClientId = clientId,
                Message = info
            };
            return transmit.TryToJson(true);
        }

        /// <summary>
        /// 组装消息协议
        /// </summary>
        /// <param name="msg">数据包</param>
        /// <param name="command">命令</param>
        /// <returns></returns>
        private static byte[] GetMsgBytes(string msg, SocketCommand command)
        {
            //协议: 头部包含 4 个字节, 前 2 个字节用于存储请求的名字（命令值）, 后 2 个字节用于代表请求体的长度
            List<byte> response = new List<byte>();
            if (!string.IsNullOrEmpty(msg))
            {
                //命令值
                response = BitConverter.GetBytes((ushort)command).Reverse().ToList();
                //数据包
                byte[] data = Encoding.UTF8.GetBytes(msg);
                //包长度
                response.AddRange(BitConverter.GetBytes((ushort)data.Length).Reverse().ToArray());

                response.AddRange(data);
            }
            return response.ToArray();
        }
    }
}