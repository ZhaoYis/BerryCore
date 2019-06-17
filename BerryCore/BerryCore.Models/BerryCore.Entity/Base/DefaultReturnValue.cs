#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Entity.Base
* 项目描述 ：
* 类 名 称 ：DefaultReturnValue
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Entity.Base
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-11 15:56:29
* 更新时间 ：2019-06-11 15:56:29
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion


using System;

namespace BerryCore.Entity.Base
{
    /// <summary>
    /// 功能描述    ：用于通用方法返回值  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-11 15:56:29 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-11 15:56:29 
    /// </summary>
    public class DefaultReturnValue
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 附带数据
        /// </summary>
        public Object Data { get; set; }

        /// <summary>
        /// 附带消息
        /// </summary>
        public string Error { get; set; }
    }
}
