#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IService.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IModuleFormService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IService.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:17:37
* 更新时间 ：2019-12-17 17:17:37
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.AuthorizeManage;
using BerryCore.Entity.Base;
using System.Data;

namespace BerryCore.IService.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：IModuleFormService
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:17:37
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:17:37
    /// </summary>
    public interface IModuleFormService
    {
        #region 获取数据

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        DataTable GetModuleFormPageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        ModuleFormEntity GetModuleFormEntity(string keyValue);

        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        ModuleFormEntity GetModuleFormEntityByModuleId(string moduleId);

        /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        bool IsExistModuleId(string keyValue, string moduleId);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int SaveEntity(string keyValue, ModuleFormEntity entity);

        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        int VirtualDelete(string keyValue);

        #endregion 提交数据
    }
}