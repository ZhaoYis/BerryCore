#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：AuthorizeEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:52:30
* 更新时间 ：2019-12-17 15:52:30
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Code.Operator;
using BerryCore.Entity.Base;
using BerryCore.Entity.Protocol;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：AuthorizeEntity
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:52:30
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:52:30
    /// </summary>
    [Table("Base_Authorize")]
    public class AuthorizeEntity : BaseEntity, IEntityOfCreator<string>, IEntityOfSort<int>
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
        /// 对象分类:1-部门 2-角色 3-岗位 4-职位 5-工作组
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 项目类型:1-菜单 2-按钮 3-视图 4-表单
        /// </summary>
        public int ItemType { get; set; }

        /// <summary>
        /// 项目主键
        /// </summary>
        public string ItemId { get; set; }

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
        /// 排序码
        /// </summary>
        public int SortCode { get; set; }
    }
}