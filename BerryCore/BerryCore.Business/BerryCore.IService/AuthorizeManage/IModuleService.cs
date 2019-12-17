#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IService.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IModuleService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IService.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:18:19
* 更新时间 ：2019-12-17 17:18:19
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace BerryCore.IService.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：IModuleService
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:18:19
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:18:19
    /// </summary>
    public interface IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetModuleListByUserId(string userId);

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetModuleList();

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        int GetSortCode();

        /// <summary>
        /// 功能列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleEntity> GetModuleListByParentId(string parentId);

        /// <summary>
        /// 功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleEntity GetModuleEntity(string keyValue);

        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string fullName, string keyValue);

        /// <summary>
        /// 删除系统功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        void SaveForm(string keyValue, ModuleEntity moduleEntity, List<ModuleButtonEntity> moduleButtonList, List<ModuleColumnEntity> moduleColumnList);
    }
}