#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.AutomaticTask
* 项目描述 ：
* 类 名 称 ：HelloJobRunnable
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.AutomaticTask
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 11:43:29
* 更新时间 ：2019-06-15 11:43:29
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Threading.Tasks;
using BerryCore.AutomaticTask.Base;
using BerryCore.AutomaticTask.Jobs;
using BerryCore.Utilities.Quartz;
using Quartz;

namespace BerryCore.AutomaticTask
{
    /// <summary>
    /// 功能描述    ：HelloJobRunnable  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 11:43:29 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 11:43:29 
    /// </summary>
    public class HelloJobRunnable : IJobRunnable
    {
        private readonly IQuartzScheduleJobManager _quartzScheduleJobManager;

        public HelloJobRunnable()
        {
            _quartzScheduleJobManager = new QuartzScheduleJobManager();
        }

        /// <summary>
        /// 执行任务
        /// </summary>
        /// <returns></returns>
        public async Task RunJob()
        {
            await _quartzScheduleJobManager.ScheduleAsync<HelloWorldJob>(
                job =>
                {
                    job.WithDescription("HelloJobDescription")
                        .WithIdentity("HelloJobKey");
                },
                trigger =>
                {
                    trigger.WithIdentity("HelloJobTrigger")
                        .WithDescription("HelloJobTriggerDescription")
                        .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(10).WithRepeatCount(10));
                });

            //开启任务
            this.Start();
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        public void Start()
        {
            _quartzScheduleJobManager.Start();
        }

        /// <summary>
        /// 暂停所有Job
        /// </summary>
        public void PauseAll()
        {
            _quartzScheduleJobManager.PauseAll();
        }

        /// <summary>
        /// 恢复所有Job
        /// </summary>
        public void ResumeAll()
        {
            _quartzScheduleJobManager.ResumeAll();
        }

        /// <summary>
        /// 暂停某个任务
        /// </summary>
        /// <param name="jobName"></param>
        public void PauseJob(string jobName)
        {
            _quartzScheduleJobManager.PauseJob(jobName);
        }

        /// <summary>
        /// 恢复指定的Job
        /// </summary>
        /// <param name="jobName"></param>
        public void ResumeJob(string jobName)
        {
            _quartzScheduleJobManager.ResumeJob(jobName);
        }

        /// <summary>
        /// 删除Job
        /// </summary>
        /// <param name="jobName"></param>
        public void DeleteJob(string jobName)
        {
            _quartzScheduleJobManager.DeleteJob(jobName);
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        public void Stop()
        {
            _quartzScheduleJobManager.Stop();
        }

        /// <summary>
        /// 等待服务停止
        /// </summary>
        public void WaitToStop()
        {
            _quartzScheduleJobManager.WaitToStop();
        }
    }
}
