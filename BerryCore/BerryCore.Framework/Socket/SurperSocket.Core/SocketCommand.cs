using System.ComponentModel;

namespace SurperSocket.Core
{
    /// <summary>
    /// 自定义命令
    /// </summary>
    public enum SocketCommand : ushort
    {
        #region 基础命令
        /// <summary>
        /// 连接成功
        /// </summary>
        [Description("连接成功")]
        ConnectionSuccess = 100,
        /// <summary>
        /// 认证成功
        /// </summary>
        [Description("认证成功")]
        CertificationSuccess = 101,
        /// <summary>
        /// 认证失败
        /// </summary>
        [Description("认证失败")]
        CertificationFail = 102,
        /// <summary>
        /// 收到心跳包
        /// </summary>
        [Description("收到心跳包")]
        ReceiveHeartbeat = 103,
        /// <summary>
        /// 发送心跳包
        /// </summary>
        [Description("发送心跳包")]
        SendHeartbeat = 104,
        #endregion
        
        #region 业务命令

        /// <summary>
        /// 客户端认证
        /// </summary>
        [Description("客户端认证")]
        ClientAuthentication = 200,

        #endregion

        #region 系统保留命令

        /// <summary>
        /// 自定义普通消息
        /// </summary>
        [Description("自定义普通消息")]
        CustomMsg = 998,
        /// <summary>
        /// 系统消息
        /// </summary>
        [Description("系统消息")]
        SystemMessage = 999,

        #endregion
    }
}