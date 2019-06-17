#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.Quartz.Base
* 项目描述 ：
* 类 名 称 ：JobConfigEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.Quartz.Base
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-15 10:31:38
* 更新时间 ：2019-06-15 10:31:38
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

namespace BerryCore.Utilities.Quartz.Base
{
    /// <summary>
    /// 功能描述    ：Job配置文件实体  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-15 10:31:38 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-15 10:31:38 
    /// </summary>
    public class JobConfigEntity
    {
        /// <summary>
        /// 设置项名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 作业名称(唯一标识)
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 作业分组名称
        /// </summary>
        public string JobGroup { get; set; }
        /// <summary>
        /// 作业身份名称
        /// </summary>
        public string JobIdentityName { get; set; }
        /// <summary>
        /// 触发器身份名称
        /// </summary>
        public string TriggerIdentityName { get; set; }
        /// <summary>
        /// 复杂任务Cron表达式
        /// </summary>
        public string CronExpression { get; set; }
        /// <summary>
        /// 跳过日期,格式：yyyyMMdd
        /// </summary>
        public string SkipDate { get; set; }
        /// <summary>
        /// 重复执行次数
        /// </summary>
        public string RepeatCount { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsEnabled { get; set; }
    }
}
