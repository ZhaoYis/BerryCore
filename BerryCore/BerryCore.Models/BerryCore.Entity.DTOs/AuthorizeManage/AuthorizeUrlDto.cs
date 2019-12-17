﻿#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Entity.DTOs.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：AuthorizeUrlDto
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Entity.DTOs.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 15:54:19
* 更新时间 ：2019-12-17 15:54:19
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

namespace BerryCore.Entity.DTOs.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：授权功能Url、操作Url  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 15:54:19 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 15:54:19 
    /// </summary>
    public class AuthorizeUrlDto
    {
        /// <summary>
        /// 功能主键
        /// </summary>
        public string ModuleId { set; get; }

        /// <summary>
        /// Url地址
        /// </summary>
        public string UrlAddress { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string FullName { set; get; }
    }
}
