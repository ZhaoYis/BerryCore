#region << 版 本 注 释 >>

/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Entity.Base
* 项目描述 ：
* 类 名 称 ：Pagination
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Entity.Base
* 机器名称 ：MRZHAOYI
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 19:47:14
* 更新时间 ：2019/5/3 19:47:14
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/

#endregion << 版 本 注 释 >>

namespace BerryCore.Entity.Base
{
    /// <summary>
    /// 功能描述    ：分页参数
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 19:47:14
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 19:47:14
    /// </summary>
    public class PaginationEntity
    {
        /// <summary>
        /// 每页行数
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 排序列
        /// </summary>
        public string sidx { get; set; }

        /// <summary>
        /// 排序类型，DESC或者ASC，默认DESC
        /// </summary>
        public string sord { get; set; } = "DESC";

        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int total
        {
            get
            {
                if (records > 0)
                {
                    return records % this.rows == 0 ? records / this.rows : records / this.rows + 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 查询条件Json
        /// </summary>
        public string conditionJson { get; set; }
    }
}