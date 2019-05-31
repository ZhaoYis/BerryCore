#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.RabbitMQ.EasyNetQ
* 项目描述 ：
* 类 名 称 ：EasyNetQPublisher
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.RabbitMQ.EasyNetQ
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-31 13:09:39
* 更新时间 ：2019-05-31 13:09:39
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Log;
using BerryCore.MQ.Base;
using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Reflection;

namespace BerryCore.MQ.RabbitMQ.EasyNetQ
{
    /// <summary>
    /// 功能描述    ：EasyNetQPublisher（Topic方式）
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-31 13:09:39 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-31 13:09:39 
    /// </summary>
    public class EasyNetQPublisher : BaseLogger
    {
        #region 构造函数

        private readonly IBus bus = null;

        /// <summary>
        /// 默认配置
        /// </summary>
        public EasyNetQPublisher()
        {
            bus = EasyNetQBusBuilder.CreateMessageBus();
        }

        /// <summary>
        /// 自定义连接
        /// </summary>
        /// <param name="connectionStr"></param>
        public EasyNetQPublisher(string connectionStr)
        {
            bus = EasyNetQBusBuilder.CreateMessageBus(connectionStr);
        }

        /// <summary>
        /// 自定义配置
        /// </summary>
        /// <param name="configuration"></param>
        public EasyNetQPublisher(ConnectionConfiguration configuration)
        {
            bus = EasyNetQBusBuilder.CreateMessageBus(configuration);
        }

        #endregion

        #region Topic

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Publish<T>(T message) where T : class, IBaseMqMessage
        {
            bool res = false;
            this.Logger(this.GetType(), "发布消息-Publish", () =>
            {
                if (message != null)
                {
                    bus.Publish(message);
                    res = true;
                }
            }, e =>
            {
                res = false;
            });
            return res;
        }

        /// <summary>
        /// 发布消息。自定义主题
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        public bool Publish<T>(T message, string topic) where T : class, IBaseMqMessage
        {
            bool res = false;
            this.Logger(this.GetType(), "发布消息。自定义主题-Publish", () =>
            {
                if (message != null)
                {
                    if (!string.IsNullOrEmpty(topic))
                    {
                        bus.Publish(message, topic);
                    }
                    else
                    {
                        bus.Publish(message);
                    }
                    res = true;
                }
            }, e =>
            {
                res = false;
            });
            return res;
        }

        /// <summary>
        /// 发布消息。自定义主题、交换机。EasyNetQ高级API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <param name="topic"></param>
        /// <param name="exchangeName"></param>
        /// <returns></returns>
        public bool Publish<T>(T message, string topic, string exchangeName) where T : class, IBaseMqMessage
        {
            bool res = false;
            this.Logger(this.GetType(), "发布消息。自定义主题、交换机-Publish", () =>
            {
                if (message != null)
                {
                    if (!string.IsNullOrEmpty(topic))
                    {
                        IAdvancedBus advanced = bus.Advanced;
                        IExchange exchange = advanced.ExchangeDeclare(exchangeName, ExchangeType.Topic);
                        advanced.Publish(exchange, topic, false, new Message<T>(message));
                    }
                    else
                    {
                        bus.Publish(message);
                    }
                    res = true;
                }
            }, e =>
            {
                res = false;
            });
            return res;
        }

        #endregion

        #region Direct



        #endregion

        #region Fanout



        #endregion

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            bus.Dispose();
        }

        /// <summary>
        /// 获取自定义的RabbitMq队列信息实体特性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private RabbitMqAttribute GetRabbitMqAttribute<T>()
        {
            Type typeOfT = typeof(T);
            RabbitMqAttribute rabbitMqAttribute = typeOfT.GetCustomAttribute<RabbitMqAttribute>();

            return rabbitMqAttribute;
        }
    }
}
