#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.RabbitMQ
* 项目描述 ：
* 类 名 称 ：RabbitMQPublisher
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.RabbitMQ
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 10:52:13
* 更新时间 ：2019-05-30 10:52:13
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Log;
using BerryCore.MQ.Base;
using BerryCore.MQ.RabbitMQ.RabbitMqProxyConfig;
using System;

namespace BerryCore.MQ.RabbitMQ
{
    /// <summary>
    /// 功能描述    ：RabbitMQ消息生产者  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 10:52:13 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 10:52:13 
    /// </summary>
    public class RabbitMQPublisher : BaseLogger
    {
        private readonly RabbitMqService rabbitMqService = null;

        /// <summary>
        /// 默认配置
        /// </summary>
        public RabbitMQPublisher()
        {
            this.rabbitMqService = new RabbitMqService(new RabbitMqConfig
            {
                AutomaticRecoveryEnabled = true,
                HeartBeat = 60,
                NetworkRecoveryInterval = new TimeSpan(60),
                Host = "localhost",
                UserName = "guest",
                Password = "guest"
            });
        }

        /// <summary>
        /// 自定义配置
        /// </summary>
        /// <param name="config"></param>
        public RabbitMQPublisher(RabbitMqConfig config)
        {
            this.rabbitMqService = new RabbitMqService(config);
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">消息包</param>
        /// <param name="exchange">交换机类型</param>
        public bool Publish<T>(T message, string exchange = ExchangeTypeCode.Direct) where T : class, IBaseMqMessage
        {
            bool res = false;
            this.Logger(this.GetType(), "发布消息-Publish", () =>
            {
                if (message != null)
                {
                    res = rabbitMqService.Publish<T>(message, exchange);
                    if (!res)
                    {
                        //TODO 处理消息发布失败的情况
                    }
                }
            }, e =>
            {
                res = false;
            });
            return res;
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            rabbitMqService.Dispose();
        }
    }
}
