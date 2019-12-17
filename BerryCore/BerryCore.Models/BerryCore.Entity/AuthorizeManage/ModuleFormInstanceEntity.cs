#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleFormInstanceEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:59:55
* 更新时间 ：2019-12-17 15:59:55
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.Base;
using BerryCore.Entity.Protocol;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：系统表单实例
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:59:55
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:59:55
    /// </summary>
    [Table("Base_ModuleFormInstance")]
    public class ModuleFormInstanceEntity : BaseEntity, IEntityOfSort<int>
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            base.Create();
        }

        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            base.Modify(keyValue);
        }

        #endregion 扩展操作

        /// <summary>
        /// 表单主键
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// 表单实例Json
        /// </summary>
        public string FormInstanceJson { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
    }
}