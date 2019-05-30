#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.CustomEvent
* 项目描述 ：
* 类 名 称 ：MQEventSource
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.CustomEvent
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 11:36:36
* 更新时间 ：2019-05-30 11:36:36
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.MQ.Base;

namespace BerryCore.MQ.CustomEvent
{
    /// <summary>
    /// 功能描述    ：事件中心  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 11:36:36 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 11:36:36 
    /// </summary>
    public class MQEventSource<T> where T : class, IBaseMqMessage
    {
        #region 新消息处理

        /// <summary>
        /// 新消息处理委托
        /// </summary>
        /// <param name="msg"></param>
        public delegate void NewMsgHandler(T msg);
        /// <summary>
        /// 新消息处理事件
        /// </summary>
        public event NewMsgHandler NewMsgEventHandler;

        /// <summary>
        /// 引发新消息处理事件的方法
        /// </summary>
        /// <param name="msg"></param>
        public void RaiseNewMsgEvent(T msg)
        {
            if (NewMsgEventHandler != null && msg != null)
            {
                NewMsgEventHandler.Invoke(msg);
            }
        }

        #endregion

        #region 错误消息处理

        /// <summary>
        /// 错误消息处理委托
        /// </summary>
        /// <param name="error"></param>
        public delegate void ErrorMsgHandler(string error);
        /// <summary>
        /// 错误消息处理事件
        /// </summary>
        public event ErrorMsgHandler ErrorMsgEventHandler;

        /// <summary>
        /// 引发错误消息处理事件的方法
        /// </summary>
        /// <param name="error"></param>
        public void RaiseErrorMsgEvent(string error)
        {
            if (ErrorMsgEventHandler != null && !string.IsNullOrEmpty(error))
            {
                ErrorMsgEventHandler.Invoke(error);
            }
        }
        #endregion

    }
}
