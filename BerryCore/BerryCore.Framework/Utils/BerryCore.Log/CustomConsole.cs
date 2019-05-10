using System;
using System.Diagnostics;

namespace BerryCore.Log
{
    /// <summary>
    /// 自定义Console输出
    /// </summary>
    public abstract class CustomConsole : BaseLogger
    {
        private static LogHelper helper = new LogHelper(typeof(CustomConsole));

        /// <summary>
        /// 消息打印,并且记录日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        protected virtual void WriteInfo(Type type, string msg)
        {
            var logger = LogHelper.GetLogger(type);
            logger.Info(msg + Environment.NewLine);
            Trace.WriteLine(msg + Environment.NewLine);
            Console.WriteLine(msg + Environment.NewLine);
        }

        /// <summary>
        /// 记录日志,并且执行自定义操作
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="handler"></param>
        protected virtual void WriteInfo(string msg, Action handler)
        {
            helper.Info(msg + Environment.NewLine);
            if (handler != null) handler.Invoke();
        }
    }
}