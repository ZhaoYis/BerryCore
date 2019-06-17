#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz.Listener
* 项目描述 ：
* 类 名 称 ：SchedulerListener
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz.Listener
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 10:53:08
* 更新时间 ：2019-06-15 10:53:08
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace BerryCore.Utilities.Quartz.Listener
{
    /// <summary>
    /// 功能描述    ：SchedulerListener  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 10:53:08 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 10:53:08 
    /// </summary>
    public class SchedulerListener : ISchedulerListener
    {
        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// is scheduled.
        /// </summary>
        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// is unscheduled.
        /// </summary>
        /// <seealso cref="M:Quartz.ISchedulerListener.SchedulingDataCleared(System.Threading.CancellationToken)" />
        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// has reached the condition in which it will never fire again.
        /// </summary>
        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> a <see cref="T:Quartz.ITrigger" />s has been paused.
        /// </summary>
        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> a group of
        /// <see cref="T:Quartz.ITrigger" />s has been paused.
        /// </summary>
        /// <remarks>
        /// If a all groups were paused, then the <see param="triggerName" /> parameter
        /// will be null.
        /// </remarks>
        /// <param name="triggerGroup">The trigger group.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// has been un-paused.
        /// </summary>
        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a
        /// group of <see cref="T:Quartz.ITrigger" />s has been un-paused.
        /// </summary>
        /// <remarks>
        /// If all groups were resumed, then the <see param="triggerName" /> parameter
        /// will be null.
        /// </remarks>
        /// <param name="triggerGroup">The trigger group.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// has been added.
        /// </summary>
        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// has been deleted.
        /// </summary>
        public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// has been  paused.
        /// </summary>
        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// has been interrupted.
        /// </summary>
        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a
        /// group of <see cref="T:Quartz.IJobDetail" />s has been  paused.
        /// <para>
        /// If all groups were paused, then the <see param="jobName" /> parameter will be
        /// null. If all jobs were paused, then both parameters will be null.
        /// </para>
        /// </summary>
        /// <param name="jobGroup">The job group.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// has been  un-paused.
        /// </summary>
        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.IJobDetail" />
        /// has been  un-paused.
        /// </summary>
        /// <param name="jobGroup">The job group.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a serious error has
        /// occurred within the scheduler - such as repeated failures in the <see cref="T:Quartz.Spi.IJobStore" />,
        /// or the inability to instantiate a <see cref="T:Quartz.IJob" /> instance when its
        /// <see cref="T:Quartz.ITrigger" /> has fired.
        /// </summary>
        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
        /// that it has move to standby mode.
        /// </summary>
        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
        /// that it has started.
        /// </summary>
        public Task SchedulerStarted(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener that it is starting.
        /// </summary>
        public Task SchedulerStarting(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
        /// that it has Shutdown.
        /// </summary>
        public Task SchedulerShutdown(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
        /// that it has begun the shutdown sequence.
        /// </summary>
        public Task SchedulerShuttingdown(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> to inform the listener
        /// that all jobs, triggers and calendars were deleted.
        /// </summary>
        public Task SchedulingDataCleared(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }
    }
}
