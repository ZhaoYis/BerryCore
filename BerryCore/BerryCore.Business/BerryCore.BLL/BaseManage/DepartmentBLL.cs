#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.BaseManage
* 项目描述 ：
* 类 名 称 ：DepartmentBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.BaseManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:42:43
* 更新时间 ：2019-12-17 17:42:43
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Entity.BaseManage;
using BerryCore.IBLL.BaseManage;
using BerryCore.IService.BaseManage;
using BerryCore.Service.BaseManage;
using System.Collections.Generic;

namespace BerryCore.BLL.BaseManage
{
    /// <summary>
    /// 功能描述    ：DepartmentBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:42:43 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:42:43 
    /// </summary>
    public class DepartmentBLL : IDepartmentBLL
    {
        private readonly IDepartmentService _departmentService = new DepartmentService();

        /// <summary>
        /// 部门列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DepartmentEntity> GetDepartmentList()
        {
            return _departmentService.GetDepartmentList();
        }

        /// <summary>
        /// 部门实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DepartmentEntity GetDepartmentEntity(string keyValue)
        {
            return _departmentService.GetDepartmentEntity(keyValue);
        }

        /// <summary>
        /// 部门名称不能重复
        /// </summary>
        /// <param name="departmentName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string departmentName, string keyValue)
        {
            return _departmentService.ExistFullName(departmentName, keyValue);
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _departmentService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            return _departmentService.ExistShortName(shortName, keyValue);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            _departmentService.RemoveByKey(keyValue);
        }

        /// <summary>
        /// 保存部门表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">机构实体</param>
        /// <returns></returns>
        public void AddDepartment(string keyValue, DepartmentEntity departmentEntity)
        {
            _departmentService.AddDepartment(keyValue, departmentEntity);
        }
    }
}
