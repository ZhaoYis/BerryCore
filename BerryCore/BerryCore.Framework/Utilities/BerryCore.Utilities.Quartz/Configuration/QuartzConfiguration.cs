#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz.Configuration
* 项目描述 ：
* 类 名 称 ：QuartzConfiguration
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz.Configuration
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 11:03:34
* 更新时间 ：2019-06-15 11:03:34
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using Quartz;
using Quartz.Impl;

namespace BerryCore.Utilities.Quartz.Configuration
{
    /// <summary>
    /// 功能描述    ：QuartzConfiguration  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 11:03:34 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 11:03:34 
    /// </summary>
    public class QuartzConfiguration : IQuartzConfiguration
    {
        public IScheduler Scheduler => StdSchedulerFactory.GetDefaultScheduler().Result;
    }
}
