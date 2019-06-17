#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.AutomaticTask.Jobs
* 项目描述 ：
* 类 名 称 ：HelloWorldJob
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.AutomaticTask.Jobs
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 11:34:01
* 更新时间 ：2019-06-15 11:34:01
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BerryCore.Utilities.Quartz.Base;
using Quartz;

namespace BerryCore.AutomaticTask.Jobs
{
    /// <summary>
    /// 功能描述    ：HelloWorldJob  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 11:34:01 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 11:34:01 
    /// </summary>
    [DisallowConcurrentExecution]
    [PersistJobDataAfterExecution]
    public class HelloWorldJob : BaseJob
    {
        /// <summary>
        /// 任务执行入口
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task Execute(IJobExecutionContext context)
        {
            this.Logger(this.GetType(), "HelloWorldJob-Execute", () =>
            {
                Trace.WriteLine("执行了HelloWorldJob任务，" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }, e =>
            {

            });
            return Task.CompletedTask;
        }
    }
}
