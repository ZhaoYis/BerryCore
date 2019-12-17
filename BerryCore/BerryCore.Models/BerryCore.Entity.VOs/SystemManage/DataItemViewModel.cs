#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Entity.VOs.SystemManage
* 项目描述 ：
* 类 名 称 ：DataItemViewModel
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.VOs.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:07:44
* 更新时间 ：2019-12-17 17:07:44
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

namespace BerryCore.Entity.VOs.SystemManage
{
    /// <summary>
    /// 功能描述    ：DataItemViewModel  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:07:44 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:07:44 
    /// </summary>
    public class DataItemViewModel
    {
        /// <summary>
        /// 分类主键
        /// </summary>
        public string ItemId { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 明细主键
        /// </summary>
        public string ItemDetailId { get; set; }

        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 项目名
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 项目值
        /// </summary>
        public string ItemValue { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        public string SimpleSpelling { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public bool EnabledMark { get; set; }
    }
}
