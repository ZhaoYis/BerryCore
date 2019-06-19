#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Logger
* 项目描述 ：
* 类 名 称 ：LoggerFormat
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Logger
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-05 10:31:56
* 更新时间 ：2019-06-05 10:31:56
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 成都任我行软件股份有限公司 2019. All rights reserved.   *
***********************************************************************
*/
#endregion

using System.Text;

namespace BerryCore.Log
{
    /// <summary>
    /// 功能描述    ：日志格式器  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-05 10:31:56 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-05 10:31:56 
    /// </summary>
    public class LoggerFormat
    {
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string ErrorFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\r\n1. 错误: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址  : " + logMessage.Url + "\r\n");
            strInfo.Append("3. 类名  : " + logMessage.Class + "\r\n");
            strInfo.Append("4. IP    : " + logMessage.Ip + "\r\n");
            strInfo.Append("5. 主机  : " + logMessage.Host + "\r\n");
            strInfo.Append("6. 浏览器: " + logMessage.Browser + "\r\n");
            strInfo.Append("5. 内容  : " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成警告
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string WarnFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\r\n1. 警告: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址  : " + logMessage.Url + "\r\n");
            strInfo.Append("3. 类名  : " + logMessage.Class + "\r\n");
            strInfo.Append("4. IP    : " + logMessage.Ip + "\r\n");
            strInfo.Append("5. 主机  : " + logMessage.Host + "\r\n");
            strInfo.Append("6. 浏览器: " + logMessage.Browser + "\r\n");
            strInfo.Append("5. 内容  : " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成信息
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string InfoFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\r\n1. 信息: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址  : " + logMessage.Url + "\r\n");
            strInfo.Append("3. 类名  : " + logMessage.Class + "\r\n");
            strInfo.Append("4. IP    : " + logMessage.Ip + "\r\n");
            strInfo.Append("5. 主机  : " + logMessage.Host + "\r\n");
            strInfo.Append("6. 浏览器: " + logMessage.Browser + "\r\n");
            strInfo.Append("5. 内容  : " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成调试
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string DebugFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\r\n1. 调试: >> 操作时间: " + logMessage.OperationTime + "   操作人: " + logMessage.UserName + " \r\n");
            strInfo.Append("2. 地址  : " + logMessage.Url + "\r\n");
            strInfo.Append("3. 类名  : " + logMessage.Class + "\r\n");
            strInfo.Append("4. IP    : " + logMessage.Ip + "\r\n");
            strInfo.Append("5. 主机  : " + logMessage.Host + "\r\n");
            strInfo.Append("6. 浏览器: " + logMessage.Browser + "\r\n");
            strInfo.Append("5. 内容  : " + logMessage.Content + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }

        /// <summary>
        /// 生成异常信息
        /// </summary>
        /// <param name="logMessage">对象</param>
        /// <returns></returns>
        public static string ExceptionFormat(LogMessage logMessage)
        {
            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\r\n1. 调试: >> 操作时间: " + logMessage.OperationTime + "   描述: " + logMessage.Content + " \r\n");
            strInfo.Append("2. 地址  : " + logMessage.Url + "    \r\n");
            strInfo.Append("3. 类名  : " + logMessage.Class + " \r\n");
            strInfo.Append("4. IP    : " + logMessage.Ip + "\r\n");
            strInfo.Append("5. 主机  : " + logMessage.Host + "\r\n");
            strInfo.Append("6. 浏览器: " + logMessage.Browser + "\r\n"); ;
            strInfo.Append("7. 异常  : " + logMessage.ExceptionInfo + "\r\n");
            strInfo.Append("8. 来源  : " + logMessage.ExceptionSource + "\r\n");
            strInfo.Append("9. 实例  : " + logMessage.ExceptionRemark + "\r\n");
            strInfo.Append("-----------------------------------------------------------------------------------------------------------------------------\r\n");
            return strInfo.ToString();
        }
    }
}
