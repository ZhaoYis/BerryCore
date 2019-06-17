#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz.Listener
* 项目描述 ：
* 类 名 称 ：JobListener
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz.Listener
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 10:32:57
* 更新时间 ：2019-06-15 10:32:57
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Threading;
using System.Threading.Tasks;
using BerryCore.Log;
using Quartz;

namespace BerryCore.Utilities.Quartz.Listener
{
    /// <summary>
    /// 功能描述    ：自定义Job监听器  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 10:32:57 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 10:32:57 
    /// </summary>
    public class JobListener : BaseLogger, IJobListener
    {
        public virtual string Name => "JobListener";

        /// <summary>
        /// 准备监听器执行完毕
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// 监听器拒绝
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// 准备监听器执行完毕
        /// </summary>
        /// <param name="context"></param>
        /// <param name="jobException"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = new CancellationToken())
        {
            if (jobException == null)
            {

            }
            else
            {
                this.Logger(this.GetType(), "JobWasExecuted:发生异常：" + jobException.ToString(), LoggerLevel.Error);
            }

            return Task.FromResult(0);
        }

    }
}
