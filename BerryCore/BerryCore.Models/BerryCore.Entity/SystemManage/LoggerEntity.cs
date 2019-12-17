#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.SystemManage
* 项目描述 ：
* 类 名 称 ：LoggerEntity
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:24:07
* 更新时间 ：2019-12-17 16:24:07
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.Base;
using BerryCore.Entity.Protocol;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerryCore.Entity.SystemManage
{
    /// <summary>
    /// 功能描述    ：系统日志
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:24:07
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:24:07
    /// </summary>
    [Table("Base_Log")]
    public class LoggerEntity : BaseEntity, ISoftDelete, ISoftClose
    {
        #region 扩展操作

        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
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
            base.Modify(keyValue);
        }

        #endregion 扩展操作

        /// <summary>
        /// 分类Id 1-登陆2-访问3-操作4-异常
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// 来源对象主键
        /// </summary>
        public string SourceObjectId { get; set; }

        /// <summary>
        /// 来源日志内容
        /// </summary>
        public string SourceContentJson { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime { get; set; }

        /// <summary>
        /// 操作用户Id
        /// </summary>
        public string OperateUserId { get; set; }

        /// <summary>
        /// 操作用户
        /// </summary>
        public string OperateAccount { get; set; }

        /// <summary>
        /// 操作类型Id
        /// </summary>
        public string OperateTypeId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateType { get; set; }

        /// <summary>
        /// 系统功能主键
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// 系统功能
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// IP地址所在城市
        /// </summary>
        public string IPAddressName { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 执行结果状态
        /// </summary>
        public int? ExecuteResult { get; set; }

        /// <summary>
        /// 执行结果信息
        /// </summary>
        public string ExecuteResultJson { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 删除标识。默认false
        /// </summary>
        public bool DeleteMark { get; set; }

        /// <summary>
        /// 无效标识。默认false
        /// </summary>
        public bool EnabledMark { get; set; }
    }
}