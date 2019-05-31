#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.RabbitMQ.EasyNetQ
* 项目描述 ：
* 类 名 称 ：EasyNetQSubscriber
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.RabbitMQ.EasyNetQ
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-31 13:10:16
* 更新时间 ：2019-05-31 13:10:16
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
    /// 功能描述    ：EasyNetQSubscriber
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-31 13:10:16 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-31 13:10:16 
    /// </summary>
    public class EasyNetQSubscriber : BaseLogger
    {
        #region 构造函数

        private readonly IBus bus = null;

        /// <summary>
        /// 默认配置
        /// </summary>
        public EasyNetQSubscriber()
        {
            bus = EasyNetQBusBuilder.CreateMessageBus();
        }

        /// <summary>
        /// 自定义连接
        /// </summary>
        /// <param name="connectionStr"></param>
        public EasyNetQSubscriber(string connectionStr)
        {
            bus = EasyNetQBusBuilder.CreateMessageBus(connectionStr);
        }

        /// <summary>
        /// 自定义配置
        /// </summary>
        /// <param name="configuration"></param>
        public EasyNetQSubscriber(ConnectionConfiguration configuration)
        {
            bus = EasyNetQBusBuilder.CreateMessageBus(configuration);
        }

        #endregion

        #region Topic

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="work">消息处理方式</param>
        /// <param name="subscriptionId">订阅者ID</param>
        /// <param name="fail">失败处理方式</param>
        public void Subscribe<T>(Action<T> work, Action fail = null, string subscriptionId = "topic_subid") where T : class, IBaseMqMessage
        {
            this.Logger(this.GetType(), "订阅消息-Subscribe", () =>
            {
                ISubscriptionResult result = bus.Subscribe<T>(subscriptionId, work);
            }, e =>
            {
                if (fail != null)
                {
                    fail.Invoke();
                }
            });
        }

        /// <summary>
        /// 订阅消息。自定义主题
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="work">消息处理方式</param>
        /// <param name="subscriptionId">订阅者ID</param>
        /// <param name="fail">失败处理方式</param>
        /// <param name="topics">主题</param>
        public void Subscribe<T>(Action<T> work, Action fail = null, string subscriptionId = "topic_subid", params string[] topics) where T : class, IBaseMqMessage
        {
            this.Logger(this.GetType(), "订阅消息。自定义主题-Subscribe", () =>
            {
                if (topics != null && topics.Length > 0)
                {
                    ISubscriptionResult result = bus.Subscribe<T>(subscriptionId, work, c =>
                    {
                        foreach (string topic in topics)
                        {
                            c.WithTopic(topic);
                        }
                    });
                }
                else
                {
                    ISubscriptionResult result = bus.Subscribe<T>(subscriptionId, work);
                }
            }, e =>
            {
                if (fail != null)
                {
                    fail.Invoke();
                }
            });
        }

        /// <summary>
        /// 订阅消息。自定义主题、交换机名称。EasyNetQ高级API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="work">消息处理方式</param>
        /// <param name="subscriptionId">订阅者ID</param>
        /// <param name="fail">失败处理方式</param>
        /// <param name="exchangeName">交换机名称</param>
        /// <param name="topics">主题</param>
        public void Subscribe<T>(Action<T> work, Action fail = null, string subscriptionId = "topic_subid", string exchangeName = "default_exchange", params string[] topics) where T : class, IBaseMqMessage
        {
            this.Logger(this.GetType(), "订阅消息。自定义主题、交换机名称-Subscribe", () =>
            {
                IAdvancedBus advanced = bus.Advanced;
                IExchange exchange = advanced.ExchangeDeclare(exchangeName, ExchangeType.Topic);
                IQueue queue = advanced.QueueDeclare(subscriptionId);
                foreach (var item in topics)
                {
                    advanced.Bind(exchange, queue, item);
                }

                advanced.Consume(queue, registration =>
                {
                    registration.Add<T>((message, info) =>
                    {
                        work(message.Body);
                    });
                });

            }, e =>
            {
                if (fail != null)
                {
                    fail.Invoke();
                }
            });
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
