#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.Code
* 项目描述 ：
* 类 名 称 ：AuthorizeTypeEnum
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Code
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 16:31:37
* 更新时间 ：2019-12-17 16:31:37
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using System.ComponentModel;

namespace BerryCore.Code
{
    /// <summary>
    /// 功能描述    ：AuthorizeTypeEnum
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 16:31:37
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 16:31:37
    /// </summary>
    public enum AuthorizeTypeEnum
    {
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Department = 1,

        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        Role = 2,

        /// <summary>
        /// 岗位
        /// </summary>
        [Description("岗位")]
        Post = 3,

        /// <summary>
        /// 职位
        /// </summary>
        [Description("职位")]
        Job = 4,

        /// <summary>
        /// 用户
        /// </summary>
        [Description("用户")]
        User = 5,

        /// <summary>
        /// 用户组
        /// </summary>
        [Description("用户组")]
        UserGroup = 6
    }
}