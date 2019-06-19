using System;
using System.Text;
using System.Web.Mvc;
using BerryCore.Code;
using BerryCore.Entity.Base;
using BerryCore.Extensions;
using BerryCore.Log;

namespace BerryCore.SOA.API.Attributes
{
    /// <summary>
    /// 自定义全局异常处理
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomHandlerErrorAttribute : HandleErrorAttribute
    {
        private static LogHelper _logHelper = new LogHelper(typeof(CustomHandlerErrorAttribute));

        /// <summary>在发生异常时调用。</summary>
        /// <param name="filterContext">操作筛选器上下文。</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="filterContext" /> 参数为 null。</exception>
        public override void OnException(ExceptionContext filterContext)
        {
            var context = filterContext.HttpContext;
            var exception = filterContext.Exception;

            if (!filterContext.ExceptionHandled)
            {
                LogMessage logMessage = new LogMessage
                {
                    OperationTime = DateTime.Now,
                    Url = context.Request.RawUrl,
                    Ip = context.Request.UserHostAddress,
                    Host = context.Request.UserHostName,
                    Browser = context.Request.Browser.Browser,
                    UserAgent = context.Request.UserAgent,
                    ExceptionInfo = exception.InnerException == null ? exception.Message : exception.InnerException.Message,
                    ExceptionSource = exception.Source,
                    ExceptionRemark = exception.StackTrace
                };
                string strMessage = LoggerFormat.ExceptionFormat(logMessage);
                _logHelper.Error(strMessage, exception);

                filterContext.ExceptionHandled = true;
            }

            filterContext.Result = new ContentResult
            {
                Content = new BaseJsonResult<string>
                {
                    Status = GlobalErrorCodes.Exception,
                    Message = exception.Message
                }.TryToJson(true),
                ContentEncoding = Encoding.UTF8,
                ContentType = "application/json"
            };

            base.OnException(filterContext);
        }
    }
}