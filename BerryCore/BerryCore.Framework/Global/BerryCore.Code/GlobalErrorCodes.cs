using System.ComponentModel;

namespace BerryCore.Code
{
    /// <summary>
    /// 全局错误码枚举
    /// </summary>
    public enum GlobalErrorCodes
    {
        #region 系统保留

        /// <summary>
        /// 默认,无实际意义。
        /// </summary>
        Default = 1000,

        /// <summary>
        /// 弃用接口
        /// </summary>
        [Description("当前接口已弃用")]
        Obsolete = 1001,

        #endregion

        #region 系统

        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Description("处理成功")]
        Success = 2000,

        /// <summary>
        /// 内部请求出错
        /// </summary>
        [Description("内部请求出错")]
        Error = 2001,

        /// <summary>
        /// 操作失败
        /// </summary>
        [Description("操作失败")]
        Fail = 2002,

        /// <summary>
        /// 服务器异常
        /// </summary>
        [Description("服务器异常")]
        Exception = 2003,

        /// <summary>
        /// 记录（资源）已经存在
        /// </summary>
        [Description("记录（资源）已经存在")]
        RecordAlreadyExists = 2004,

        /// <summary>
        /// 记录（资源）不存在
        /// </summary>
        [Description("记录（资源）不存在")]
        RecordNotExists = 2005,

        /// <summary>
        /// 记录（资源）存在多条
        /// </summary>
        [Description("记录（资源）存在多条")]
        MultipleRecords = 2006,

        #endregion

        #region TOKEN验证相关

        /// <summary>
        /// 授权参数不完整或不正确
        /// </summary>
        [Description("授权参数不完整或不正确")]
        AuthParameterError = 3001,

        /// <summary>
        /// TOKEN失效
        /// </summary>
        [Description("TOKEN失效")]
        TokenInvalid = 3002,

        /// <summary>
        /// 签名有误
        /// </summary>
        [Description("签名有误")]
        SignError = 3003,

        /// <summary>
        /// 无权执行当前操作
        /// </summary>
        [Description("无权执行当前操作")]
        NoPermission = 3004,

        #endregion

        #region 业务相关

        #region 微信授权相关

        /// <summary>
        /// 授权回调地址不能为空
        /// </summary>
        [Description("授权回调地址不能为空")]
        CallbackUrlIsNull = 4000,

        /// <summary>
        /// 授权状态验证失败
        /// </summary>
        [Description("授权状态验证失败")]
        AuthStateValidationFailure = 4001,

        /// <summary>
        /// 用户拒绝授权
        /// </summary>
        [Description("用户拒绝授权")]
        UserRefuseAuth = 4002,

        /// <summary>
        /// 获取AccessToken失败
        /// </summary>
        [Description("获取AccessToken失败")]
        OAuthAccessTokenFail = 4003,

        #endregion

        #region Token相关



        #endregion

        #endregion
    }
}