#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.AutomaticTask
* 项目描述 ：
* 类 名 称 ：IJobRunnable
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.AutomaticTask
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 11:41:22
* 更新时间 ：2019-06-15 11:41:22
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Threading.Tasks;

namespace BerryCore.AutomaticTask.Base
{
    /// <summary>
    /// 功能描述    ：IJobRunnable  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 11:41:22 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 11:41:22 
    /// </summary>
    public interface IJobRunnable
    {
        /// <summary>
        /// 执行任务
        /// </summary>
        /// <returns></returns>
        Task RunJob();
        
        /// <summary>
        /// 开启服务
        /// </summary>
        void Start();

        /// <summary>
        /// 暂停所有Job
        /// </summary>
        void PauseAll();

        /// <summary>
        /// 恢复所有Job
        /// </summary>
        void ResumeAll();

        /// <summary>
        /// 暂停某个任务
        /// </summary>
        /// <param name="jobName"></param>
        void PauseJob(string jobName);

        /// <summary>
        /// 恢复指定的Job
        /// </summary>
        /// <param name="jobName"></param>
        void ResumeJob(string jobName);

        /// <summary>
        /// 删除Job
        /// </summary>
        /// <param name="jobName"></param>
        void DeleteJob(string jobName);

        /// <summary>
        /// 停止服务
        /// </summary>
        void Stop();

        /// <summary>
        /// 等待服务停止
        /// </summary>
        void WaitToStop();
    }
}
