#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Entity.Protocol
* 项目描述 ：
* 类 名 称 ：FullAuditedOfCreator
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.Protocol
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 14:47:02
* 更新时间 ：2019-12-17 14:47:02
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.   *
***********************************************************************
*/
#endregion

using System;
using BerryCore.Entity.Base;

namespace BerryCore.Entity.Protocol
{
    /// <summary>
    /// 功能描述    ：FullAuditedOfCreator  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 14:47:02 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 14:47:02 
    /// </summary>
    public class FullAuditedOfCreator : BaseEntity<string>, IEntity, IEntityOfCreator<string>
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
    }
}
