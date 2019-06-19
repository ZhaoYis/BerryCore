using System;
using System.Web.Http;
using BerryCore.Code;
using BerryCore.Entity.Base;
using BerryCore.Extensions;
using BerryCore.Log;
using BerryCore.SOA.API.Attributes;
using BerryCore.SOA.API.Filters;

namespace BerryCore.SOA.API.Base
{
    /// <summary>
    /// 基Api控制器
    /// </summary>
    [TimingActionFilter]
    public class BaseApiController : ApiController, ILogger
    {
        #region 系统日志

        /// <summary>
        /// 日志处理
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc">描述</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallyHandel">最终处理方式</param>
        [IgnoreAction]
        public virtual void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallyHandel = null)
        {
            LogHelper.Logger(type, desc, tryHandel, catchHandel, finallyHandel);
        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="desc"></param>
        /// <param name="level"></param>
        [IgnoreAction]
        public void Logger(Type type, string desc, LoggerLevel level = LoggerLevel.Info)
        {
            LogHelper.Logger(type, desc, level);
        }

        #endregion 系统日志

        #region 公共方法

        /// <summary>
        /// 获取公共返回消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据</param>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual BaseJsonResult<T> GetBaseJsonResult<T>(T data = default(T), GlobalErrorCodes status = GlobalErrorCodes.Error, string message = "") where T : class
        {
            message = string.Format("{0}{1}", status.GetEnumDescription(), string.IsNullOrEmpty(message) ? "" : "," + message);
            BaseJsonResult<T> resultMsg = new BaseJsonResult<T>
            {
                Status = status,
                Message = message,
                Data = data
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
        protected virtual BaseJsonResult<T> GetBaseJsonResult<T>(GlobalErrorCodes status = GlobalErrorCodes.Error, string message = "") where T : class
        {
            message = status == GlobalErrorCodes.Success
                ? status.GetEnumDescription()
                : string.Format("{0}{1}", status.GetEnumDescription(), string.IsNullOrEmpty(message) ? "" : "," + message);
            BaseJsonResult<T> resultMsg = new BaseJsonResult<T>
            {
                Status = status,
                Message = message
            };
            return resultMsg;
        }

        #endregion 公共方法

    }
}