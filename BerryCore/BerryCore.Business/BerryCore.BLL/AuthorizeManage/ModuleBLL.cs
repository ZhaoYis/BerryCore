#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.AuthorizeManage
* 项目描述 ：
* 类 名 称 ：ModuleBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.AuthorizeManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:45:56
* 更新时间 ：2019-12-17 18:45:56
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Code.Operator;
using BerryCore.Entity.AuthorizeManage;
using BerryCore.Extensions;
using BerryCore.IBLL.AuthorizeManage;
using BerryCore.IService.AuthorizeManage;
using BerryCore.Service.AuthorizeManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BerryCore.BLL.AuthorizeManage
{
    /// <summary>
    /// 功能描述    ：ModuleBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:45:56 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:45:56 
    /// </summary>
    public class ModuleBLL : IModuleBLL
    {
        private readonly IModuleService _moduleService = new ModuleService();

        /// <summary>
        /// 获取授权功能
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleListByUserId(string userId)
        {
            bool isSystem = OperatorProvider.Provider.Current().IsSystem;
            if (isSystem)
            {
                return _moduleService.GetModuleList();
            }
            else
            {
                return _moduleService.GetModuleListByUserId(userId);
            }
        }

        /// <summary>
        /// 获取所有授权功能
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleList()
        {
            return _moduleService.GetModuleList();
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetSortCode()
        {
            return _moduleService.GetSortCode();
        }

        /// <summary>
        /// 功能列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntity> GetModuleListByParentId(string parentId)
        {
            var data = _moduleService.GetModuleListByParentId("").ToList();
            if (!string.IsNullOrEmpty(parentId))
            {
                data = data.FindAll(t => t.ParentId == parentId);
            }
            return data;
        }

        /// <summary>
        /// 功能实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ModuleEntity GetModuleEntity(string keyValue)
        {
            return _moduleService.GetModuleEntity(keyValue);
        }

        /// <summary>
        /// 功能编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _moduleService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 功能名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return _moduleService.ExistFullName(fullName, keyValue);
        }

        /// <summary>
        /// 删除系统功能
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            //判断是否存在子级
            List<ModuleEntity> moduleList = _moduleService.GetModuleListByParentId(keyValue).ToList();
            if (moduleList.Count > 1)
            {
                //遍历删除
                foreach (ModuleEntity entity in moduleList)
                {
                    if (!string.IsNullOrEmpty(entity.Id))
                    {
                        _moduleService.RemoveByKey(entity.Id);
                    }
                }
            }
            else
            {
                _moduleService.RemoveByKey(keyValue);
            }
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="moduleEntity">功能实体</param>
        /// <param name="moduleButtonListJson">按钮实体列表</param>
        /// <param name="moduleColumnListJson">视图实体列表</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ModuleEntity moduleEntity, string moduleButtonListJson, string moduleColumnListJson)
        {
            var moduleButtonList = moduleButtonListJson.JsonToList<ModuleButtonEntity>();
            var moduleColumnList = moduleColumnListJson.JsonToList<ModuleColumnEntity>();

            _moduleService.SaveForm(keyValue, moduleEntity, moduleButtonList, moduleColumnList);
        }
    }
}
