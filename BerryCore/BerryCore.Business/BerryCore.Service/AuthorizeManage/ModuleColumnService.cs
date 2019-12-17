#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleColumnService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:55:32
* 更新时间 ：2019-12-17 17:55:32
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
using BerryCore.Entity.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.Base;

namespace BerryCore.Service.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleColumnService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:55:32 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:55:32 
    /// </summary>
    public class ModuleColumnService : BaseService<ModuleColumnEntity>, IModuleColumnService
    {
        /// <summary>
        /// 根据用户ID获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnListByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 视图列表
        /// </summary>
        /// <param name="moduleId">功能Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnListByModuleId(string moduleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 视图实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleColumnEntity GetModuleColumnEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有授权功能视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleColumnEntity> GetModuleColumnList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <param name="moduleColumnEntity">视图实体</param>
        public void AddEntity(ModuleColumnEntity moduleColumnEntity)
        {
            throw new NotImplementedException();
        }
    }
}
