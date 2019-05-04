#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data
* 项目描述 ：
* 类 名 称 ：DbTypeContainer
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 22:05:52
* 更新时间 ：2019/5/3 22:05:52
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryCore.Data
{
    /// <summary>
    /// 功能描述    ：DbTypeContainer  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 22:05:52 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 22:05:52 
    /// </summary>
    public class DbTypeContainer
    {
        public DbTypeContainer()
        {
            DbType = DatabaseType.SqlServer;
        }

        /// <summary>
        /// 当前操作的数据库类型
        /// </summary>
        public static DatabaseType DbType { get; set; }
    }
}
