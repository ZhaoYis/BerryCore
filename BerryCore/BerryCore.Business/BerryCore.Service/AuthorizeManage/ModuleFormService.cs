#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleFormService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:56:06
* 更新时间 ：2019-12-17 17:56:06
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerryCore.Entity.AuthorizeManage;
using BerryCore.Entity.Base;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.Base;

namespace BerryCore.Service.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleFormService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:56:06 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:56:06 
    /// </summary>
    public class ModuleFormService : BaseService<ModuleFormEntity>, IModuleFormService
    {
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetModuleFormPageList(PaginationEntity pagination, string queryJson)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ModuleFormEntity GetModuleFormEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public ModuleFormEntity GetModuleFormEntityByModuleId(string moduleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public bool IsExistModuleId(string keyValue, string moduleId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int VirtualDelete(string keyValue)
        {
            throw new NotImplementedException();
        }
    }
}
