#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleButtonBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:49:51
* 更新时间 ：2019-12-17 18:49:51
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
    /// 功能描述    ：ModuleButtonBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:49:51 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:49:51 
    /// </summary>
    public class ModuleButtonBLL : IModuleButtonBLL
    {
        private readonly IModuleButtonService moduleButtonService = new ModuleButtonService();

        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonListByUserId(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return moduleButtonService.GetModuleButtonList();
            }
            else
            {
                return moduleButtonService.GetModuleButtonListByUserId(userId);
            }
        }

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList()
        {
            return moduleButtonService.GetModuleButtonList();
        }

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonListByModuleId(string moduleId)
        {
            return moduleButtonService.GetModuleButtonListByModuleId(moduleId);
        }

        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButtonEntity GetModuleButtonEntity(string keyValue)
        {
            return moduleButtonService.GetModuleButtonEntity(keyValue);
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        public void AddEntity(ModuleButtonEntity moduleButtonEntity)
        {
            moduleButtonService.AddEntity(moduleButtonEntity);
        }
    }
}
