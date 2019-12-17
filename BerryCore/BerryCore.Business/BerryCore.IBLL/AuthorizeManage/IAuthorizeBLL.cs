#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IAuthorizeBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:35:54
* 更新时间 ：2019-12-17 17:35:54
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Code.Operator;
using BerryCore.Entity.DTOs.AuthorizeManage;
using System.Collections.Generic;

namespace BerryCore.IBLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：IAuthorizeBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:35:54
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:35:54
    /// </summary>
    public interface IAuthorizeBLL
    {
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="operators">当前登陆用户信息</param>
        /// <param name="isWrite">可写入</param>
        /// <returns></returns>
        string GetDataAuthor(OperatorEntity operators, bool isWrite = false);

        /// <summary>
        /// Action执行权限认证
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="moduleId">模块Id</param>
        /// <param name="action">请求地址</param>
        /// <returns></returns>
        bool ActionAuthorize(string userId, string moduleId, string action);

        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeUrlDto> GetUrlList(string userId);
    }
}