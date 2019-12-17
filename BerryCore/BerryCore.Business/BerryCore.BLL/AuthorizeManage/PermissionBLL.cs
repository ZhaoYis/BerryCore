#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：PermissionBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:55:03
* 更新时间 ：2019-12-17 18:55:03
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
using BerryCore.Code;
using BerryCore.Entity.AuthorizeManage;
using BerryCore.Entity.BaseManage;
using BerryCore.Extensions;
using BerryCore.IBLL.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.AuthorizeManage;

namespace BerryCore.BLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：PermissionBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:55:03 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:55:03 
    /// </summary>
    public class PermissionBLL : IPermissionBLL
    {
        private readonly IPermissionService permissionService = new PermissionService();

        /// <summary>
        /// 获取成员列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetMemberList(string objectId)
        {
            return permissionService.GetMemberList(objectId);
        }

        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<UserRelationEntity> GetObjectList(string userId)
        {
            return permissionService.GetObjectList(userId);
        }

        /// <summary>
        /// 获取对象特征字符串
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetObjectString(string userId)
        {
            return permissionService.GetObjectString(userId);
        }

        /// <summary>
        /// 获取功能列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleList(string objectId)
        {
            return permissionService.GetModuleList(objectId);
        }

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleButtonList(string objectId)
        {
            return permissionService.GetModuleButtonList(objectId);
        }

        /// <summary>
        /// 获取视图列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeEntity> GetModuleColumnList(string objectId)
        {
            return permissionService.GetModuleColumnList(objectId);
        }

        /// <summary>
        /// 获取数据权限列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns></returns>
        public IEnumerable<AuthorizeDataEntity> GetAuthorizeDataList(string objectId)
        {
            return permissionService.GetAuthorizeDataList(objectId);
        }

        /// <summary>
        /// 添加成员
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="userIds">成员Id</param>
        public void SaveMember(AuthorizeTypeEnum authorizeType, string objectId, string userIds)
        {
            string[] arrayUserId = userIds.Split(',');
            permissionService.SaveMember(authorizeType, objectId, arrayUserId);
        }

        /// <summary>
        /// 添加授权
        /// </summary>
        /// <param name="authorizeType">权限分类</param>
        /// <param name="objectId">对象Id</param>
        /// <param name="moduleIds">功能Id</param>
        /// <param name="moduleButtonIds">按钮Id</param>
        /// <param name="moduleColumnIds">视图Id</param>
        /// <param name="authorizeDataJson">数据权限</param>
        public void SaveAuthorize(AuthorizeTypeEnum authorizeType, string objectId, string moduleIds, string moduleButtonIds, string moduleColumnIds, string authorizeDataJson)
        {
            List<AuthorizeDataEntity> authorize = new List<AuthorizeDataEntity>();
            if (!string.IsNullOrEmpty(authorizeDataJson))
            {
                authorize = authorizeDataJson.JsonToList<AuthorizeDataEntity>();
            }
            string[] arrayModuleId = moduleIds.Split(',');
            string[] arrayModuleButtonId = moduleButtonIds.Split(',');
            string[] arrayModuleColumnId = moduleColumnIds.Split(',');

            permissionService.SaveAuthorize(authorizeType, objectId, arrayModuleId, arrayModuleButtonId, arrayModuleColumnId, authorize);
        }
    }
}
