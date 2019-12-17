#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IModuleColumnBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:37:08
* 更新时间 ：2019-12-17 17:37:08
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.AuthorizeManage;
using System.Collections.Generic;

namespace BerryCore.IBLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：IModuleColumnBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:37:08
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:37:08
    /// </summary>
    public interface IModuleColumnBLL
    {
        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnListByUserId(string userId);

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnListByModuleId(string moduleId);

        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleColumnEntity GetModuleColumnEntity(string keyValue);

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleColumnEntity> GetModuleColumnList();

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleColumnEntity">视图实体</param>
        void AddEntity(ModuleColumnEntity moduleColumnEntity);
    }
}