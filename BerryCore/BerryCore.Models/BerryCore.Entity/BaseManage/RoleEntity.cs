#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.BaseManage
* 项目描述 ：
* 类 名 称 ：RoleEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.BaseManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:32:32
* 更新时间 ：2019-12-17 15:32:32
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.   *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Code.Operator;
using BerryCore.Entity.Protocol;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.BaseManage
{
    /// <summary>
    /// 功能描述    ：系统角色
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:32:32
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:32:32
    /// </summary>
    [Table("Base_Role")]
    public class RoleEntity : FullAuditedEntity
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.DeleteMark = false;
            this.EnabledMark = true;

            base.Create();
        }

        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;

            base.Modify(keyValue);
        }

        #endregion 扩展操作

        /// <summary>
        /// 机构主键
        /// </summary>
        public string OrganizeId { get; set; }

        /// <summary>
        /// 分类1-角色 2-岗位 3-职位 4-工作组
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 公共角色
        /// </summary>
        public int? IsPublic { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? OverdueTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}