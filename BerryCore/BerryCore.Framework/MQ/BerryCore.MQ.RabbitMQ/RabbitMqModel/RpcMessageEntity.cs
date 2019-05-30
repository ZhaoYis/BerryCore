#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.RabbitMQ.RabbitMqModel
* 项目描述 ：
* 类 名 称 ：RpcMessageEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.RabbitMQ.RabbitMqModel
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 16:09:20
* 更新时间 ：2019-05-30 16:09:20
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
using BerryCore.MQ.Base;
using BerryCore.MQ.RabbitMQ.RabbitMqProxyConfig;

namespace BerryCore.MQ.RabbitMQ.RabbitMqModel
{
    /// <summary>
    /// 功能描述    ：RpcMessageEntity  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 16:09:20 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 16:09:20 
    /// </summary>
    [RabbitMq("RabbitMq.Rpc.QueueName", ExchangeName = "RabbitMq.Rpc.ExchangeName", RoutingKey = "RabbitMq.Rpc.RoutingKey", IsProperties = false)]
    public class RpcMessageEntity : BaseMqMessageEntity
    {

    }
}
