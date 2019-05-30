#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.CustomEvent
* 项目描述 ：
* 类 名 称 ：MQMsgEventListener
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.CustomEvent
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 11:43:39
* 更新时间 ：2019-05-30 11:43:39
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
    /// 功能描述    ：事件监听器  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 11:43:39 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 11:43:39 
    /// </summary>
    public class MQEventListener<T> where T : class, IBaseMqMessage
    {
        private readonly IMQMsgHandler _msgHandler;

        public MQEventListener(IMQMsgHandler msgHandler)
        {
            _msgHandler = msgHandler;
        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subscribe(MQEventSource<T> eventSource)
        {
            eventSource.NewMsgEventHandler += _msgHandler.OnNewMsgHandler;
            eventSource.ErrorMsgEventHandler += _msgHandler.OnErrorMsgHandler;
        }

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        public void UnSubscribe(MQEventSource<T> eventSource)
        {
            eventSource.NewMsgEventHandler -= _msgHandler.OnNewMsgHandler;
            eventSource.ErrorMsgEventHandler -= _msgHandler.OnErrorMsgHandler;
        }
    }
}
