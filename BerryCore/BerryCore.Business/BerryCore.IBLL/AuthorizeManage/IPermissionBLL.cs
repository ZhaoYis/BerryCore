#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IPermissionBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:37:45
* 更新时间 ：2019-12-17 17:37:45
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Code;
using BerryCore.Entity.AuthorizeManage;
using BerryCore.Entity.BaseManage;
using System.Collections.Generic;

namespace BerryCore.IBLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：IPermissionBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:37:45
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:37:45
    /// </summary>
    public interface IPermissionBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<UserRelationEntity> GetMemberList(string objectId);

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<UserRelationEntity> GetObjectList(string userId);

        /// <summary>
        /// 获取对象特征字符串
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetObjectString(string userId);

        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeEntity> GetModuleList(string objectId);

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeEntity> GetModuleButtonList(string objectId);

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeEntity> GetModuleColumnList(string objectId);

        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        IEnumerable<AuthorizeDataEntity> GetAuthorizeDataList(string objectId);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id</param>
        void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string userIds);

        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        void SaveAuthorize(AuthorizeTypeEnum authorizeType, string objectId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson);

        #endregion 提交数据
    }
}