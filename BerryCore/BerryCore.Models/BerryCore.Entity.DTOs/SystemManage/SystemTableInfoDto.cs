#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Entity.DTOs.SystemManage
* 项目描述 ：
* 类 名 称 ：SystemTableInfoDto
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.DTOs.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:06:17
* 更新时间 ：2019-12-17 17:06:17
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.Entity.DTOs.SystemManage
{
    /// <summary>
    /// 功能描述    ：系统表信息  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:06:17 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:06:17 
    /// </summary>
    public class SystemTableInfoDto
    {
        /// <summary>
        /// 主键名称
        /// </summary>
        public string pk { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 数据行数
        /// </summary>
        public string sumrows { get; set; }
        /// <summary>
        /// 空间占用大小
        /// </summary>
        public string reserved { get; set; }
        /// <summary>
        /// 数据大小
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 索引
        /// </summary>
        public string index_size { get; set; }
        /// <summary>
        /// 未使用
        /// </summary>
        public string unused { get; set; }
    }
}
