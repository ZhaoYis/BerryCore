#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz.Base
* 项目描述 ：
* 类 名 称 ：BaseJob
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz.Base
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 10:29:48
* 更新时间 ：2019-06-15 10:29:48
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System.Reflection;
using System.Threading.Tasks;
using BerryCore.Log;
using Quartz;

namespace BerryCore.Utilities.Quartz.Base
{
    /// <summary>
    /// 功能描述    ：BaseJob  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 10:29:48 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 10:29:48 
    /// </summary>
    public abstract class BaseJob : BaseLogger, IJob
    {
        /// <summary>
        /// 任务执行入口
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract Task Execute(IJobExecutionContext context);

        /// <summary>
        /// 从作业数据地图中获取配置信息
        /// </summary>
        /// <param name="context">作业数据地图</param>
        /// <returns></returns>
        protected static JobConfigEntity GetConfigFromDataMap(IJobExecutionContext context)
        {
            JobConfigEntity config = new JobConfigEntity();

            //获取JobDataMap
            JobDataMap datamap = context.JobDetail.JobDataMap;
            //获取JobConfigEntity公共属性
            PropertyInfo[] properties = typeof(JobConfigEntity).GetProperties();
            foreach (PropertyInfo info in properties)
            {
                if (info.PropertyType == typeof(string))
                {
                    info.SetValue(config, datamap.GetString(info.Name), null);
                }
                else if (info.PropertyType == typeof(int))
                {
                    info.SetValue(config, datamap.GetInt(info.Name), null);
                }
            }
            return config;
        }

        /// <summary>
        /// 设置JobDataMap
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="context">上下文对象</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        protected void SetJobDataMap<T>(IJobExecutionContext context, string key, T value) where T : class
        {
            context.JobDetail.JobDataMap[key] = value;
        }

        /// <summary>
        /// 获取JobDataMap
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="context">上下文对象</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        protected T GetJobDataMap<T>(IJobExecutionContext context, string key) where T : class
        {
            return context.JobDetail.JobDataMap[key] as T;
        }

    }
}
