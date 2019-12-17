#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:56:23
* 更新时间 ：2019-12-17 17:56:23
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
    /// 功能描述    ：ModuleService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:56:23 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:56:23 
    /// </summary>
    public class ModuleService : BaseService<ModuleEntity>, IModuleService
    {
        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleListByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 功能列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleListByParentId(string parentId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetModuleEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除系统功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonList">按钮实体列表</param>
        /// <param name="moduleColumnList">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, List<ModuleButtonEntity> moduleButtonList, List<ModuleColumnEntity> moduleColumnList)
        {
            throw new NotImplementedException();
        }
    }
}
