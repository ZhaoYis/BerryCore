#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleButtonService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:55:12
* 更新时间 ：2019-12-17 17:55:12
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Entity.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.Base;
using System;
using System.Collections.Generic;

namespace BerryCore.Service.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleButtonService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:55:12 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:55:12 
    /// </summary>
    public class ModuleButtonService : BaseService<ModuleButtonEntity>, IModuleButtonService
    {
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonListByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有功能按钮
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleButtonEntity> GetModuleButtonListByModuleId(string moduleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按钮实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleButtonEntity GetModuleButtonEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="moduleButtonEntity">按钮实体</param>
        public void AddEntity(ModuleButtonEntity moduleButtonEntity)
        {
            throw new NotImplementedException();
        }
    }
}
