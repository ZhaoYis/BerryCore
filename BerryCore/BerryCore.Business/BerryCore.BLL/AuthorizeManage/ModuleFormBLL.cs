#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleFormBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:53:08
* 更新时间 ：2019-12-17 18:53:08
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
using BerryCore.IBLL.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.AuthorizeManage;

namespace BerryCore.BLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleFormBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:53:08 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:53:08 
    /// </summary>
    public class ModuleFormBLL : IModuleFormBLL
    {
        private readonly IModuleFormService server = new ModuleFormService();

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public DataTable GetModuleFormPageList(PaginationEntity pagination, string queryJson)
        {
            return server.GetModuleFormPageList(pagination, queryJson);
        }

        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public ModuleFormEntity GetModuleFormEntity(string keyValue)
        {
            return server.GetModuleFormEntity(keyValue);
        }

        /// <summary>
        /// 通过模块Id获取系统表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public ModuleFormEntity GetModuleFormEntityByModuleId(string moduleId)
        {
            return server.GetModuleFormEntityByModuleId(moduleId);
        }

        /// <summary>
        /// 判断模块是否已经有系统表单
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public bool IsExistModuleId(string keyValue, string moduleId)
        {
            return server.IsExistModuleId(keyValue, moduleId);
        }

        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormEntity entity)
        {
            return server.SaveEntity(keyValue, entity);
        }

        /// <summary>
        /// 虚拟删除一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public int VirtualDelete(string keyValue)
        {
            return server.VirtualDelete(keyValue);
        }
    }
}
