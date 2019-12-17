#region << 版 本 注 释 >>

/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Entity.Test
* 项目描述 ：
* 类 名 称 ：UserEntity
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Entity.Test
* 机器名称 ：MRZHAOYI
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 8:35:58
* 更新时间 ：2019/5/4 8:35:58
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.Protocol;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.Test
{
    /// <summary>
    /// 功能描述    ：用于测试的用户实体
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 8:35:58
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 8:35:58
    /// </summary>
    [Table("B_Users")]
    public class UserTestEntity : FullAuditedEntity
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.DeleteMark = false;
            this.EnabledMark = true;
            this.CreateDate = DateTime.Now;
        }

        #endregion

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

    }
}