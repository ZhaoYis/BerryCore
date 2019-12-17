#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:57:40
* 更新时间 ：2019-12-17 15:57:40
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Code.Operator;
using BerryCore.Entity.Protocol;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：系统功能（功能模块）
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:57:40
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:57:40
    /// </summary>
    [Table("Base_Module")]
    public class ModuleEntity : FullAuditedEntity
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
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 导航地址
        /// </summary>
        public string UrlAddress { get; set; }

        /// <summary>
        /// 导航目标
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 菜单选项
        /// </summary>
        public bool? IsMenu { get; set; }

        /// <summary>
        /// 允许展开
        /// </summary>
        public bool? AllowExpand { get; set; }

        /// <summary>
        /// 是否公开
        /// </summary>
        public bool? IsPublic { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public bool? AllowDelete { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}