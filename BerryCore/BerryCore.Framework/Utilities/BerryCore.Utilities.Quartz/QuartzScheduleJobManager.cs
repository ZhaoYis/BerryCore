#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz
* 项目描述 ：
* 类 名 称 ：QuartzScheduleJobManager
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 11:08:43
* 更新时间 ：2019-06-15 11:08:43
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Threading.Tasks;
using BerryCore.Log;
using BerryCore.Utilities.Quartz.Configuration;
using Quartz;
using Quartz.Impl.Triggers;

namespace BerryCore.Utilities.Quartz
{
    /// <summary>
    /// 功能描述    ：QuartzScheduleJobManager  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 11:08:43 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 11:08:43 
    /// </summary>
    public class QuartzScheduleJobManager : BaseLogger, IQuartzScheduleJobManager
    {
        /**
         * await _quartzScheduleJobManager.ScheduleAsync<HelloWorldJob>(
                job =>
                {
                    job.WithDescription("HelloJobDescription")
                       .WithIdentity("HelloJobKey");
                },
                trigger =>
                {
                    trigger.WithIdentity("HelloJobTrigger")
                           .WithDescription("HelloJobTriggerDescription")
                           .WithSimpleSchedule(schedule => schedule.WithRepeatCount(5).WithInterval(TimeSpan.FromSeconds(1)))
                           .StartNow();
                });
         */

        private readonly IQuartzConfiguration _quartzConfiguration;

        public QuartzScheduleJobManager()
        {
            _quartzConfiguration = new QuartzConfiguration();
        }

        public QuartzScheduleJobManager(IQuartzConfiguration quartzConfiguration)
        {
            _quartzConfiguration = quartzConfiguration;
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <typeparam name="TJob"></typeparam>
        /// <param name="configureJob"></param>
        /// <param name="configureTrigger"></param>
        /// <returns></returns>
        public async Task ScheduleAsync<TJob>(Action<JobBuilder> configureJob, Action<TriggerBuilder> configureTrigger) where TJob : IJob
        {
            JobBuilder jobToBuild = JobBuilder.Create<TJob>();
            configureJob(jobToBuild);
            IJobDetail job = jobToBuild.Build();

            TriggerBuilder triggerToBuild = TriggerBuilder.Create();
            configureTrigger(triggerToBuild);
            ITrigger trigger = triggerToBuild.Build();

            await _quartzConfiguration.Scheduler.ScheduleJob(job, trigger);
        }

        /// <summary>
        /// 添加Job 并且以定点的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName">任务名称</param>
        /// <param name="cronTime">Cron表达式</param>
        /// <param name="jobDataMap">传递的参数</param>
        /// <returns></returns>
        public async Task<DateTimeOffset> ScheduleAsync<T>(string jobName, string cronTime, JobDataMap jobDataMap) where T : IJob
        {
            IJobDetail jobCheck = JobBuilder.Create<T>().WithIdentity(jobName, jobName + "_Group").SetJobData(jobDataMap).Build();
            ICronTrigger cronTrigger = new CronTriggerImpl(jobName + "_CronTrigger", jobName + "_TriggerGroup", cronTime);

            return await _quartzConfiguration.Scheduler.ScheduleJob(jobCheck, cronTrigger);
        }

        /// <summary>
        /// 开启一个简单任务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName">任务名称</param>
        /// <param name="repeatCount">重复次数</param>
        /// <param name="jobDataMap">传递的参数</param>
        /// <param name="repeatInterval">重复间隔</param>
        /// <returns></returns>
        public async Task<DateTimeOffset> ScheduleAsync<T>(string jobName, int repeatCount, JobDataMap jobDataMap, TimeSpan repeatInterval) where T : IJob
        {
            IJobDetail jobDetail = JobBuilder.Create<T>().WithIdentity(jobName, jobName + "_Group").SetJobData(jobDataMap).Build();
            ISimpleTrigger simpleTrigger = new SimpleTriggerImpl(jobName + "_SimpleTrigger", repeatCount, repeatInterval);

            return await _quartzConfiguration.Scheduler.ScheduleJob(jobDetail, simpleTrigger);
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        public void Start()
        {
            if (!_quartzConfiguration.Scheduler.IsStarted)
            {
                _quartzConfiguration.Scheduler.Start();
            }
        }

        /// <summary>
        /// 暂停所有Job
        /// </summary>
        public void PauseAll()
        {
            if (_quartzConfiguration.Scheduler != null)
            {
                _quartzConfiguration.Scheduler.PauseAll();
            }
        }

        /// <summary>
        /// 恢复所有Job
        /// </summary>
        public void ResumeAll()
        {
            if (_quartzConfiguration.Scheduler != null)
            {
                _quartzConfiguration.Scheduler.ResumeAll();
            }
        }

        /// <summary>
        /// 暂停某个任务
        /// </summary>
        /// <param name="jobName"></param>
        public void PauseJob(string jobName)
        {
            if (_quartzConfiguration.Scheduler != null)
            {
                JobKey jk = new JobKey(jobName);
                _quartzConfiguration.Scheduler.PauseJob(jk);
            }
        }

        /// <summary>
        /// 恢复指定的Job
        /// </summary>
        /// <param name="jobName"></param>
        public void ResumeJob(string jobName)
        {
            if (_quartzConfiguration.Scheduler != null)
            {
                JobKey jk = new JobKey(jobName);
                _quartzConfiguration.Scheduler.ResumeJob(jk);
            }
        }

        /// <summary>
        /// 删除Job
        /// </summary>
        /// <param name="jobName"></param>
        public void DeleteJob(string jobName)
        {
            if (_quartzConfiguration.Scheduler != null)
            {
                JobKey jk = new JobKey(jobName);
                _quartzConfiguration.Scheduler.DeleteJob(jk);
            }
        }

        /// <summary>
        /// 停止服务（不等待任务执行完成）
        /// </summary>
        public void Stop()
        {
            this.Logger(this.GetType(), "停止服务-Stop", () =>
            {
                if (_quartzConfiguration.Scheduler != null)
                {
                    _quartzConfiguration.Scheduler.Shutdown(false);
                }
            }, e =>
            {

            });
        }

        /// <summary>
        /// 等待服务停止
        /// </summary>
        public void WaitToStop()
        {
            this.Logger(this.GetType(), "等待服务停止-WaitToStop", () =>
            {
                if (_quartzConfiguration.Scheduler != null)
                {
                    _quartzConfiguration.Scheduler.Shutdown(true);
                }
            }, e =>
            {

            });
        }
    }
}
