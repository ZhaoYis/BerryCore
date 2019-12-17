#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Entity.DTOs.SystemManage
* 项目描述 ：
* 类 名 称 ：DataBaseTableFieldDto
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.DTOs.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:21:22
* 更新时间 ：2019-12-17 16:21:22
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

namespace BerryCore.Entity.DTOs.SystemManage
{
    /// <summary>
    /// 功能描述    ：数据库表字段
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:21:22
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:21:22
    /// </summary>
    public class DataBaseTableFieldDto
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string column { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string datatype { get; set; }

        /// <summary>
        /// 数据长度
        /// </summary>
        public int? length { get; set; }

        /// <summary>
        /// 允许空
        /// </summary>
        public string isnullable { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public string identity { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string defaults { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string remark { get; set; }
    }
}