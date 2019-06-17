#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Entity.Protocol
* 项目描述 ：
* 类 名 称 ：ISortProperty
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Entity.Protocol
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-12 17:04:19
* 更新时间 ：2019-06-12 17:04:19
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

namespace BerryCore.Entity.Protocol
{
    /// <summary>
    /// 功能描述    ：IEntityOfSort  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-12 17:04:19 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-12 17:04:19 
    /// </summary>
    public interface IEntityOfSort<TSort>
    {
        /// <summary>
        /// 排序码
        /// </summary>
        TSort Sort { get; set; }
    }
}
