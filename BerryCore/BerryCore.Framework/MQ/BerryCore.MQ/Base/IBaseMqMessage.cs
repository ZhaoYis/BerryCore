#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.MQ.Base
* 项目描述 ：
* 类 名 称 ：IBaseMqMessage
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.MQ.Base
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-05-30 11:04:28
* 更新时间 ：2019-05-30 11:04:28
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

namespace BerryCore.MQ.Base
{
    /// <summary>
    /// 功能描述    ：IBaseMqMessage  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-05-30 11:04:28 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-05-30 11:04:28 
    /// </summary>
    public interface IBaseMqMessage
    {
        /// <summary>
        /// 目标平台
        /// </summary>
        string Platform { get; set; }

        /// <summary>
        /// 客户端唯一标识
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        /// 状态码或者命令值
        /// </summary>
        int Command { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        object Data { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        long CreateTime { get; set; }

        /// <summary>
        /// 消息签名
        /// </summary>
        string Sign { get; set; }
    }
}
