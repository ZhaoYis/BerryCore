#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.SystemManage
* 项目描述 ：
* 类 名 称 ：DataBaseBackupEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:07:58
* 更新时间 ：2019-12-17 16:07:58
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
    /// 功能描述    ：数据库备份
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:07:58
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:07:58
    /// </summary>
    [Table("Base_DatabaseBackup")]
    public class DataBaseBackupEntity : FullAuditedEntity
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
        /// 数据库连接主键
        /// </summary>
        public string DatabaseLinkId { get; set; }

        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 计划编号
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 计划名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 执行方式
        /// </summary>
        public int? ExecuteMode { get; set; }

        /// <summary>
        /// 执行时间
        /// </summary>
        public string ExecuteTime { get; set; }

        /// <summary>
        /// 备份路径
        /// </summary>
        public string BackupPath { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
}