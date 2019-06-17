#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.JWT
* 项目描述 ：
* 类 名 称 ：JWTPlayloadInfo
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.JWT
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-04 15:40:52
* 更新时间 ：2019-06-04 15:40:52
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using BerryCore.Extensions;

namespace BerryCore.Utilities.JWT
{
    /// <summary>
    /// 功能描述    ：JWT载荷实体  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-04 15:40:52 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-04 15:40:52 
    /// </summary>
    public sealed class JWTPlayloadInfo
    {
        /// <summary>
        /// 系统默认接收jwt的一方
        /// </summary>
        public const string DefaultAud = "guset";
        /// <summary>
        /// 系统默认的jwt签发者
        /// </summary>
        public const string DefaultIss = "管家婆零售通";
        /// <summary>
        /// 系统默认面向用户群体
        /// </summary>
        public const string DefaultSub = "ALL";

        /// <summary>
        /// jwt签发者
        /// </summary>
        public string iss { get; set; } = DefaultIss;

        /// <summary>
        /// jwt所面向的用户
        /// </summary>
        public string sub { get; set; } = DefaultSub;

        /// <summary>
        /// 接收jwt的一方
        /// </summary>
        public string aud { get; set; } = DefaultAud;

        /// <summary>
        /// jwt的签发时间
        /// </summary>
        public string iat { get; set; } = DateTime.Now.DateTime2TimeStamp().ToString();

        /// <summary>
        /// jwt的过期时间，这个过期时间必须要大于签发时间.默认60分钟
        /// </summary>
        public string exp { get; set; }

        /// <summary>
        /// 定义在什么时间之前，该jwt都是不可用的.
        /// </summary>
        public int nbf { get; set; }

        /// <summary>
        /// jwt的唯一身份标识，主要用来作为一次性token,从而回避重放攻击。
        /// </summary>
        public string jti { get; set; } = CommonHelper.GetGuid();

        ///// <summary>
        ///// 用户ID。自定义字段
        ///// </summary>
        //public string userid { get; set; }

        /// <summary>
        /// 扩展字段。自定义字段
        /// </summary>
        public string extend { get; set; }
    }
}
