#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.RabbitMQ.RPC
* 项目描述 ：
* 类 名 称 ：RabbitMQRpcService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.RabbitMQ.RPC
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 16:11:03
* 更新时间 ：2019-05-30 16:11:03
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerryCore.Log;
using BerryCore.MQ.CustomEvent;
using BerryCore.MQ.RabbitMQ.RabbitMqProxyConfig;

namespace BerryCore.MQ.RabbitMQ.RPC
{
    /// <summary>
    /// 功能描述    ：RabbitMQRpcService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 16:11:03 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 16:11:03 
    /// </summary>
    public class RabbitMQRpcService : BaseLogger
    {
        private readonly RabbitMqService rabbitMqService = null;

        private readonly IMQMsgHandler mqMsgHandler = null;

        /// <summary>
        /// 默认配置
        /// </summary>
        public RabbitMQRpcService()
        {
            //默认MQ配置
            this.rabbitMqService = new RabbitMqService(new RabbitMqConfig
            {
                AutomaticRecoveryEnabled = true,
                HeartBeat = 60,
                NetworkRecoveryInterval = new TimeSpan(60),
                Host = "localhost",
                UserName = "guest",
                Password = "guest"
            });

            //使用默认消息处理方式
            this.mqMsgHandler = new DefaultMQMsgHandler();
        }

        /// <summary>
        /// 自定义配置
        /// </summary>
        /// <param name="config"></param>
        public RabbitMQRpcService(RabbitMqConfig config)
        {
            //自定义MQ配置
            this.rabbitMqService = new RabbitMqService(config);

            //使用默认消息处理方式
            this.mqMsgHandler = new DefaultMQMsgHandler();
        }

        /// <summary>
        /// 自定义配置和消息处理方式
        /// </summary>
        /// <param name="config"></param>
        /// <param name="handler"></param>
        public RabbitMQRpcService(RabbitMqConfig config, IMQMsgHandler handler)
        {
            //自定义MQ配置
            this.rabbitMqService = new RabbitMqService(config);

            //自定义消息处理方式
            this.mqMsgHandler = handler;
        }


    }
}
