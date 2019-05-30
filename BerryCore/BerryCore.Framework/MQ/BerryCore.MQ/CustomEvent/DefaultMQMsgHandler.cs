#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.CustomEvent
* 项目描述 ：
* 类 名 称 ：DefaultMQMsgHandler
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.CustomEvent
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 11:47:27
* 更新时间 ：2019-05-30 11:47:27
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Extensions;
using System.Diagnostics;

namespace BerryCore.MQ.CustomEvent
{
    /// <summary>
    /// 功能描述    ：DefaultMQMsgHandler  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 11:47:27 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 11:47:27 
    /// </summary>
    public class DefaultMQMsgHandler : IMQMsgHandler
    {
        /// <summary>
        /// 处理新消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        public void OnNewMsgHandler<T>(T msg)
        {
            Trace.WriteLine(string.Format("新消息到达，数据包：{0}", msg.TryToJson()));
        }

        /// <summary>
        /// 处理错误消息
        /// </summary>
        /// <param name="error">错误码</param>
        public void OnErrorMsgHandler(string error)
        {
            Trace.WriteLine(string.Format("处理错误消息，错误：{0}", error));
        }
    }
}
