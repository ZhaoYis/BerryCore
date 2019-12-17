#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.DTOs.BaseManage
* 项目描述 ：
* 类 名 称 ：DepartmentEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.DTOs.BaseManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:07:04
* 更新时间 ：2019-12-17 15:07:04
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
    /// 功能描述    ：部门
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:07:04
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:07:04
    /// </summary>
    [Table("Base_Department")]
    public class DepartmentEntity : FullAuditedEntity
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
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 部门代码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 部门简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 部门类型
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// 负责人主键
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 外线电话
        /// </summary>
        public string OuterPhone { get; set; }

        /// <summary>
        /// 内线电话
        /// </summary>
        public string InnerPhone { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 部门传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        public int? Layer { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}