#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：IModuleButtonBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.AuthorizeManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:36:56
* 更新时间 ：2019-12-17 17:36:56
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
    /// 功能描述    ：IModuleButtonBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:36:56
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:36:56
    /// </summary>
    public interface IModuleButtonBLL
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonListByUserId(string userId);

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonList();

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        IEnumerable<ModuleButtonEntity> GetModuleButtonListByModuleId(string moduleId);

        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ModuleButtonEntity GetModuleButtonEntity(string keyValue);

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        void AddEntity(ModuleButtonEntity moduleButtonEntity);
    }
}