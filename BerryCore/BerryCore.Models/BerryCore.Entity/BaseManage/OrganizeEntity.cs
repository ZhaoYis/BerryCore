#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.BaseManage
* 项目描述 ：
* 类 名 称 ：OrganizeEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.BaseManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:30:31
* 更新时间 ：2019-12-17 15:30:31
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
    /// 功能描述    ：机构
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:30:31
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:30:31
    /// </summary>
    [Table("Base_Organize")]
    public class OrganizeEntity : FullAuditedEntity
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
        /// 机构分类
        /// </summary>
        public int? Category { get; set; }

        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 机构代码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 机构简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 机构性质
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// 外线电话
        /// </summary>
        public string OuterPhone { get; set; }

        /// <summary>
        /// 内线电话
        /// </summary>
        public string InnerPhone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string Postalcode { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 负责人主键
        /// </summary>
        public string ManagerId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// 省主键
        /// </summary>
        public string ProvinceId { get; set; }

        /// <summary>
        /// 市主键
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// 县/区主键
        /// </summary>
        public string CountyId { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 公司主页
        /// </summary>
        public string WebAddress { get; set; }

        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime? FoundedTime { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        public string BusinessScope { get; set; }

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