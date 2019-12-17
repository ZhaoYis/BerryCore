﻿#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.SystemManage
* 项目描述 ：
* 类 名 称 ：DataItemEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:22:56
* 更新时间 ：2019-12-17 16:22:56
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

namespace BerryCore.Entity.SystemManage
{
    /// <summary>
    /// 功能描述    ：字典
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:22:56
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:22:56
    /// </summary>
    [Table("Base_DataItem")]
    public class DataItemEntity : FullAuditedEntity
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
        /// 分类编码
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 树型结构
        /// </summary>
        public int? IsTree { get; set; }

        /// <summary>
        /// 导航标记
        /// </summary>
        public int? IsNav { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}