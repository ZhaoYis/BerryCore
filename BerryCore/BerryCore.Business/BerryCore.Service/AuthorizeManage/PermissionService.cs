#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：PermissionService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:56:40
* 更新时间 ：2019-12-17 17:56:40
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Code;
using BerryCore.Entity.AuthorizeManage;
using BerryCore.Entity.BaseManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.Base;
using System;
using System.Collections.Generic;

namespace BerryCore.Service.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：PermissionService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:56:40 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:56:40 
    /// </summary>
    public class PermissionService : BaseService, IPermissionService
    {
        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetMemberList(string objectId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetObjectList(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取对象特征字符串
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetObjectString(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleList(string objectId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleButtonList(string objectId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleColumnList(string objectId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeDataEntity> GetAuthorizeDataList(string objectId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id</param>
        public void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string[] userIds)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataList">数据权限</param>
        public void SaveAuthorize(AuthorizeTypeEnum authorizeType, string objectId, string[] moduleIds, string[] moduleButtonIds,
            string[] moduleColumnIds, IEnumerable<AuthorizeDataEntity> authorizeDataList)
        {
            throw new NotImplementedException();
        }
    }
}
