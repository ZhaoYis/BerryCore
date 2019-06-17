#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz
* 项目描述 ：
* 类 名 称 ：IQuartzScheduleJobManager
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 11:07:30
* 更新时间 ：2019-06-15 11:07:30
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Threading.Tasks;
using Quartz;

namespace BerryCore.Utilities.Quartz
{
    /// <summary>
    /// 功能描述    ：IQuartzScheduleJobManager  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 11:07:30 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 11:07:30 
    /// </summary>
    public interface IQuartzScheduleJobManager : IQuartzRunnable
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configureJob"></param>
        /// <param name="configureTrigger"></param>
        /// <returns></returns>
        Task ScheduleAsync<T>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger) where T : IJob;

        /// <summary>
        /// 添加Job 并且以定点的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName">任务名称</param>
        /// <param name="cronTime">Cron表达式</param>
        /// <param name="jobDataMap">传递的参数</param>
        /// <returns></returns>
        Task<DateTimeOffset> ScheduleAsync<T>(string jobName, string cronTime, JobDataMap jobDataMap) where T : IJob;

        /// <summary>
        /// 开启一个简单任务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName">任务名称</param>
        /// <param name="repeatCount">重复次数</param>
        /// <param name="jobDataMap">传递的参数</param>
        /// <param name="repeatInterval">重复间隔</param>
        /// <returns></returns>
        Task<DateTimeOffset> ScheduleAsync<T>(string jobName, int repeatCount, JobDataMap jobDataMap, TimeSpan repeatInterval) where T : IJob;
    }
}
