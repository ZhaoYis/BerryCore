#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.BaseManage
* 项目描述 ：
* 类 名 称 ：DepartmentService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.BaseManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:45:34
* 更新时间 ：2019-12-17 17:45:34
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Entity.BaseManage;
using BerryCore.IService.BaseManage;
using BerryCore.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BerryCore.Service.BaseManage
{
    /// <summary>
    /// 功能描述    ：DepartmentService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:45:34 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:45:34 
    /// </summary>
    public class DepartmentService : BaseService<DepartmentEntity>, IDepartmentService
    {
        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetDepartmentList()
        {
            IEnumerable<DepartmentEntity> res = null;
            this.Logger(this.GetType(), "GetDepartmentList-部门列表", () =>
            {
                res = this.UseTransaction<IEnumerable<DepartmentEntity>>((repository) =>
                {
                    IEnumerable<DepartmentEntity> data = repository.FindList(d => d.DeleteMark == false && d.EnabledMark == true);
                    return data;
                });
            }, e =>
            {

            });
            return res;
        }

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DepartmentEntity GetDepartmentEntity(string keyValue)
        {
            DepartmentEntity res = null;
            this.Logger(this.GetType(), "GetDepartmentEntity-部门实体", () =>
            {
                res = this.UseTransaction<DepartmentEntity>((repository) =>
                {
                    DepartmentEntity data = repository.FindEntity(d => d.Id == keyValue && d.DeleteMark == false && d.EnabledMark == true);
                    return data;
                });
            }, e =>
            {

            });
            return res;
        }

        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="departmentName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string departmentName, string keyValue)
        {
            bool res = false;
            this.Logger(this.GetType(), "ExistFullName-部门名称不能重复", () =>
            {
                res = this.UseTransaction<bool>((repository) =>
                {
                    IEnumerable<DepartmentEntity> data = repository.FindList(d => d.FullName == departmentName);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }

                    return data.Any();
                });
            }, e =>
            {

            });
            return res;
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            bool res = false;
            this.Logger(this.GetType(), "ExistEnCode-外文名称不能重复", () =>
            {
                res = this.UseTransaction<bool>((repository) =>
                {
                    IEnumerable<DepartmentEntity> data = repository.FindList(d => d.EnCode == enCode);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }

                    return data.Any();
                });
            }, e =>
            {

            });
            return res;
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            bool res = false;
            this.Logger(this.GetType(), "ExistShortName-中文名称不能重复", () =>
            {
                res = this.UseTransaction<bool>((repository) =>
                {
                    IEnumerable<DepartmentEntity> data = repository.FindList(d => d.ShortName == shortName);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        data = data.Where(t => t.Id != keyValue).ToList();
                    }

                    return data.Any();
                });
            }, e =>
            {

            });
            return res;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            this.Logger(this.GetType(), "RemoveByKey-删除部门", () =>
            {
                this.UseTransaction((repository) =>
                {
                    int count = repository.FindList(d => d.ParentId == keyValue).Count();
                    if (count > 0)
                    {
                        throw new Exception("当前所选数据有子节点数据！");
                    }

                    int res = repository.Delete(keyValue);
                });
            }, e =>
            {

            });
        }

        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void AddDepartment(string keyValue, DepartmentEntity departmentEntity)
        {
            this.Logger(this.GetType(), "AddDepartment-保存部门表单（新增、修改）", () =>
            {
                this.UseTransaction((repository) =>
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        departmentEntity.Modify(keyValue);

                        int res = repository.Update(departmentEntity, d => d.Id == keyValue);
                    }
                    else
                    {
                        departmentEntity.Create();

                        int res = repository.Insert(departmentEntity);
                    }
                });
            }, e =>
            {

            });
        }
    }
}
