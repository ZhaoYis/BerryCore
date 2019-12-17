#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Code
* 项目描述 ：
* 类 名 称 ：LoggerCategoryType
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Code
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:32:36
* 更新时间 ：2019-12-17 16:32:36
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

namespace BerryCore.Code
{
    /// <summary>
    /// 功能描述    ：LoggerCategoryType
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:32:36
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:32:36
    /// </summary>
    public enum LoggerCategoryType
    {
        /// <summary>
        /// 登陆
        /// </summary>
        Login = 1,

        /// <summary>
        /// 访问
        /// </summary>
        Visit = 2,

        /// <summary>
        /// 操作
        /// </summary>
        Operate = 3,

        /// <summary>
        /// 异常
        /// </summary>
        Exception = 4
    }
}