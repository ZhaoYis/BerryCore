#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Log
* 项目描述 ：
* 类 名 称 ：LogHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Log
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 22:10:40
* 更新时间 ：2019/5/3 22:10:40
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using log4net;
using System;
using System.Reflection;

namespace BerryCore.Log
{
    /// <summary>
    /// 功能描述    ：日志操作帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 22:10:40 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 22:10:40 
    /// </summary>
    public sealed class LogHelper
    {
        #region 构造函数
        /// <summary>
        /// 日志对象
        /// </summary>
        private static ILog _log;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="type">日志對象</param>
        public LogHelper(Type type)
        {
            _log = LogManager.GetLogger(type);
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="typeName"></param>
        public LogHelper(string typeName)
        {
            _log = LogManager.GetLogger(typeName);
        }
        #endregion

        #region 初始化配置

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void InitLog4net()
        {
            ////log4net配置
            //[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

            Assembly assembly = Assembly.GetExecutingAssembly();
            var config = assembly.GetManifestResourceStream("BerryCore.Log.Config.log4net.config");
            log4net.Config.XmlConfigurator.Configure(config);
        }

        #endregion

        #region 获取日志对象
        /// <summary>
        /// 通过name得到日志对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ILog GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }

        /// <summary>
        /// 通过type得到日志对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        #endregion

        #region 基础操作

        #region 1、Info
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            _log.Info(info);
        }

        /// <summary>
        /// 普通日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }
        #endregion

        #region 2、Error
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="info"></param>
        public void Error(string info)
        {
            _log.Error(info);
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="exception"></param>
        public void Error(string info, Exception exception)
        {
            _log.Error(info, exception);
        }

        /// <summary>
        /// 错误日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        #endregion

        #region 3、Debug
        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="info"></param>
        public void Debug(string info)
        {
            _log.Debug(info);
        }

        /// <summary>
        /// 调试日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }
        #endregion

        #region 4、Warn
        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="info"></param>
        public void Warn(string info)
        {
            _log.Warn(info);
        }

        /// <summary>
        /// 警告日志，带参数
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }
        #endregion

        #endregion

        #region 利用Action委托封装Log4net对日志的处理

        /// <summary>
        /// 利用Action委托封装Log4net对日志的处理，无返回值
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="desc">描述</param>
        /// <param name="tryHandel">调试代码</param>
        /// <param name="catchHandel">异常处理方式</param>
        /// <param name="finallHandel">最终处理方式</param>
        public static void Logger(Type type, string desc, Action tryHandel, Action<Exception> catchHandel = null, Action finallHandel = null)
        {
            ILog log = LogManager.GetLogger(type);
            try
            {
                //记录调试日志
                log.Debug(desc + "\r\n");

                tryHandel.Invoke();
            }
            catch (Exception e)
            {
                //记录异常日志
                log.Error(desc, e);

                if (catchHandel != null)
                {
                    catchHandel.Invoke(e);
                }
            }
            finally
            {
                if (finallHandel != null)
                {
                    finallHandel.Invoke();
                }
            }
        }
        #endregion
    }
}
