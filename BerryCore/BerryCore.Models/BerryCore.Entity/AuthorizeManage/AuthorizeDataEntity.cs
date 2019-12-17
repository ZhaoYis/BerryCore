#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：AuthorizeDataEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:50:47
* 更新时间 ：2019-12-17 15:50:47
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
    /// 功能描述    ：授权数据范围
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:50:47
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:50:47
    /// </summary>
    [Table("Base_AuthorizeData")]
    public class AuthorizeDataEntity : BaseEntity, IEntityOfCreator<string>, IEntityOfSort<int>
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
        /// 1-仅限本人2-仅限本人及下属3-所在部门4-所在公司5-按明细设置
        /// </summary>
        public int? AuthorizeType { get; set; }

        /// <summary>
        /// 对象分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// 对象主键
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// 只读
        /// </summary>
        public int? IsRead { get; set; }

        /// <summary>
        /// 约束表达式
        /// </summary>
        public string AuthorizeConstraint { get; set; }

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