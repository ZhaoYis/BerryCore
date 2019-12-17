#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleColumnBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:51:50
* 更新时间 ：2019-12-17 18:51:50
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
using BerryCore.Code.Operator;
using BerryCore.Entity.AuthorizeManage;
using BerryCore.IBLL.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.AuthorizeManage;

namespace BerryCore.BLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleColumnBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:51:50 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:51:50 
    /// </summary>
    public class ModuleColumnBLL : IModuleColumnBLL
    {
        private readonly IModuleColumnService moduleColumnService = new ModuleColumnService();

        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnListByUserId(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return moduleColumnService.GetModuleColumnList();
            }
            else
            {
                return moduleColumnService.GetModuleColumnListByUserId(userId);
            }
        }

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnListByModuleId(string moduleId)
        {
            return moduleColumnService.GetModuleColumnListByModuleId(moduleId);
        }

        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetModuleColumnEntity(string keyValue)
        {
            return moduleColumnService.GetModuleColumnEntity(keyValue);
        }

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList()
        {
            return moduleColumnService.GetModuleColumnList();
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleColumnEntity">视图实体</param>
        public void AddEntity(ModuleColumnEntity moduleColumnEntity)
        {
            moduleColumnService.AddEntity(moduleColumnEntity);
        }
    }
}
