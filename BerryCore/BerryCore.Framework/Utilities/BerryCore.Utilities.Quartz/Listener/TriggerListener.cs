#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz.Listener
* 项目描述 ：
* 类 名 称 ：TriggerListener
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz.Listener
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 10:54:53
* 更新时间 ：2019-06-15 10:54:53
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
    /// 功能描述    ：TriggerListener  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 10:54:53 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 10:54:53 
    /// </summary>
    public class TriggerListener : ITriggerListener
    {
        /// <summary>
        /// Get the name of the <see cref="T:Quartz.ITriggerListener" />.
        /// </summary>
        public string Name { get; } = "TriggerListener";

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// has fired, and it's associated <see cref="T:Quartz.IJobDetail" />
        /// is about to be executed.
        /// <para>
        /// It is called before the <see cref="M:Quartz.ITriggerListener.VetoJobExecution(Quartz.ITrigger,Quartz.IJobExecutionContext,System.Threading.CancellationToken)" /> method of this
        /// interface.
        /// </para>
        /// </summary>
        /// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that has fired.</param>
        /// <param name="context">
        ///     The <see cref="T:Quartz.IJobExecutionContext" /> that will be passed to the <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.
        /// </param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// has fired, and it's associated <see cref="T:Quartz.IJobDetail" />
        /// is about to be executed.
        /// <para>
        /// It is called after the <see cref="M:Quartz.ITriggerListener.TriggerFired(Quartz.ITrigger,Quartz.IJobExecutionContext,System.Threading.CancellationToken)" /> method of this
        /// interface.  If the implementation vetoes the execution (via
        /// returning <see langword="true" />), the job's execute method will not be called.
        /// </para>
        /// </summary>
        /// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that has fired.</param>
        /// <param name="context">The <see cref="T:Quartz.IJobExecutionContext" /> that will be passed to
        /// the <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        /// <returns>Returns true if job execution should be vetoed, false otherwise.</returns>
        public Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// has misfired.
        /// <para>
        /// Consideration should be given to how much time is spent in this method,
        /// as it will affect all triggers that are misfiring.  If you have lots
        /// of triggers misfiring at once, it could be an issue it this method
        /// does a lot.
        /// </para>
        /// </summary>
        /// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that has misfired.</param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// has fired, it's associated <see cref="T:Quartz.IJobDetail" />
        /// has been executed, and it's <see cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" /> method has been
        /// called.
        /// </summary>
        /// <param name="trigger">The <see cref="T:Quartz.ITrigger" /> that was fired.</param>
        /// <param name="context">
        /// The <see cref="T:Quartz.IJobExecutionContext" /> that was passed to the
        /// <see cref="T:Quartz.IJob" />'s<see cref="M:Quartz.IJob.Execute(Quartz.IJobExecutionContext)" /> method.
        /// </param>
        /// <param name="triggerInstructionCode">
        /// The result of the call on the <see cref="T:Quartz.ITrigger" />'s<see cref="M:Quartz.Spi.IOperableTrigger.Triggered(Quartz.ICalendar)" />  method.
        /// </param>
        /// <param name="cancellationToken">The cancellation instruction.</param>
        public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }
    }
}
