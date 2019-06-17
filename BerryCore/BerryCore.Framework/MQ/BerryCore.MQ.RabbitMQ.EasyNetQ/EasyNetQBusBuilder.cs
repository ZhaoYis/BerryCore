#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.RabbitMQ.EasyNetQ
* 项目描述 ：
* 类 名 称 ：EasyNetQBusBuilder
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.RabbitMQ.EasyNetQ
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-31 12:43:25
* 更新时间 ：2019-05-31 12:43:25
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.IO;
using EasyNetQ;

namespace BerryCore.MQ.RabbitMQ.EasyNetQ
{
    /// <summary>
    /// 功能描述    ：EasyNetQBusBuilder  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-31 12:43:25 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-31 12:43:25 
    /// </summary>
    public class EasyNetQBusBuilder
    {
        /// <summary>
        /// 默认连接信息
        /// </summary>
        private const string DefaultConnection = "host=localhost:5672;virtualHost=test_queue_vir;username=test_queue;password=123456";

        /// <summary>
        /// 创建连接。默认配置
        /// </summary>
        /// <returns></returns>
        public static IBus CreateMessageBus()
        {
            IBus bus = RabbitHutch.CreateBus(DefaultConnection);
            return bus;
        }

        /// <summary>
        /// 创建连接。自定义配置
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IBus CreateMessageBus(ConnectionConfiguration configuration)
        {
            IBus bus = RabbitHutch.CreateBus(configuration, reg =>
            {

            });
            return bus;
        }

        /// <summary>
        /// 创建连接。自定义配置
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <returns></returns>
        public static IBus CreateMessageBus(string connectionStr)
        {
            if (string.IsNullOrEmpty(connectionStr))
            {
                connectionStr = DefaultConnection;
            }

            IBus bus = RabbitHutch.CreateBus(connectionStr);
            return bus;
        }
    }
}
