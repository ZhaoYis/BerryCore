#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Entity.Protocol
* 项目描述 ：
* 类 名 称 ：FullAuditedEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.Protocol
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 14:50:49
* 更新时间 ：2019-12-17 14:50:49
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.   *
***********************************************************************
*/
#endregion

using BerryCore.Entity.Base;
using System;

namespace BerryCore.Entity.Protocol
{
    /// <summary>
    /// 功能描述    ：FullAuditedEntity  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 14:50:49 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 14:50:49 
    /// </summary>
    public class FullAuditedEntity : BaseEntity<string>, IEntity, IEntityOfCreator<string>, IEntityOfUpdater<string>, ISoftClose, ISoftDelete, IEntityOfSort<int>
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CreateUserId { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifyDate { get; set; }

        /// <summary>
        /// 更新人ID
        /// </summary>
        public string ModifyUserId { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public string ModifyUserName { get; set; }

        /// <summary>
        /// 无效标识。默认false
        /// </summary>
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 删除标识。默认false
        /// </summary>
        public bool DeleteMark { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
    }
}
