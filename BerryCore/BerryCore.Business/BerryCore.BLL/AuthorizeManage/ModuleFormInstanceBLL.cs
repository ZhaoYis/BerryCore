#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleFormInstanceBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:54:11
* 更新时间 ：2019-12-17 18:54:11
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
using BerryCore.IBLL.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.AuthorizeManage;

namespace BerryCore.BLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleFormInstanceBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:54:11 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:54:11 
    /// </summary>
    public class ModuleFormInstanceBLL : IModuleFormInstanceBLL
    {
        private readonly IModuleFormInstanceService server = new ModuleFormInstanceService();

        /// <summary>
        /// 获取一个实体类
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public ModuleFormInstanceEntity GetModuleFormInstanceEntityByObjectId(string objectId)
        {
            return server.GetModuleFormInstanceEntityByObjectId(objectId);
        }

        /// <summary>
        /// 保存一个实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SaveEntity(string keyValue, ModuleFormInstanceEntity entity)
        {
            return server.SaveEntity(keyValue, entity);
        }
    }
}
