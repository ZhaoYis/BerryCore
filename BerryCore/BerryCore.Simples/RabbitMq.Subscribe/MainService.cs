#region << 版 本 注 释 >>
/*
* 项目名称 ：RabbitMq.Subscribe
* 项目描述 ：
* 类 名 称 ：MainService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：RabbitMq.Subscribe
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 14:06:03
* 更新时间 ：2019-05-30 14:06:03
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Extensions;
using BerryCore.MQ.Base;
using BerryCore.MQ.RabbitMQ;
using BerryCore.MQ.RabbitMQ.EasyNetQ;
using BerryCore.MQ.RabbitMqModel;
using System;

namespace RabbitMq.Subscribe
{
    /// <summary>
    /// 功能描述    ：MainService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 14:06:03 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 14:06:03 
    /// </summary>
    public class MainService
    {
        private readonly RabbitMQSubscriber subscriber;

        private readonly EasyNetQSubscriber easyNetQSubscriber;

        public MainService()
        {
            //subscriber = new RabbitMQSubscriber();
            easyNetQSubscriber = new EasyNetQSubscriber();
        }

        public bool Start()
        {
            //subscriber.Subscribe<TestMessageEntity>(msg =>
            //{
            //    var json = msg.TryToJson();
            //    Console.WriteLine(json);
            //    Console.WriteLine();
            //}, () =>
            //{
            //    Console.WriteLine("消息订阅失败");
            //}, ExchangeTypeCode.Direct);
            
            easyNetQSubscriber.Subscribe<TestMessageEntity>(msg =>
            {
                var json = msg.TryToJson();
                Console.WriteLine(json);
                Console.WriteLine();
            }, () =>
            {
                Console.WriteLine("消息订阅失败");
            });

            return true;
        }

        public bool Stop()
        {
            subscriber.Stop();
            return true;
        }
    }
}
