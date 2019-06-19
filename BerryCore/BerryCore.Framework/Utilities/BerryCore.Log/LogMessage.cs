#region << 版 本 注 释 >>

/*
* 项目名称 ：GCP.Logger
* 项目描述 ：
* 类 名 称 ：LogMessage
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Logger
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-05 10:30:50
* 更新时间 ：2019-06-05 10:30:50
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using System;

namespace BerryCore.Log
{
    /// <summary>
    /// 功能描述    ：日志信息实体
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-05 10:30:50
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-05 10:30:50
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }

        /// <summary>
        /// Url地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ExceptionInfo { get; set; }

        /// <summary>
        /// 异常来源
        /// </summary>
        public string ExceptionSource { get; set; }

        /// <summary>
        /// 异常信息备注
        /// </summary>
        public string ExceptionRemark { get; set; }
    }
}