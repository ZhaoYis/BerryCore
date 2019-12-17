#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Code
* 项目描述 ：
* 类 名 称 ：PermissionMode
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Code
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:31:04
* 更新时间 ：2019-12-17 16:31:04
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

namespace BerryCore.Code
{
    /// <summary>
    /// 功能描述    ：权限认证模式
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:31:04
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:31:04
    /// </summary>
    public enum PermissionMode
    {
        /// <summary>
        /// 执行
        /// </summary>
        Enforce,

        /// <summary>
        /// 忽略
        /// </summary>
        Ignore
    }
}