#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.BaseManage
* 项目描述 ：
* 类 名 称 ：IRoleBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.BaseManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:30:17
* 更新时间 ：2019-12-17 17:30:17
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.Base;
using BerryCore.Entity.BaseManage;
using System.Collections.Generic;

namespace BerryCore.IBLL.BaseManage
{
    /// <summary>
    /// 功能描述    ：IRoleBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:30:17
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:30:17
    /// </summary>
    public interface IRoleBLL
    {
        #region 获取数据

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetRoleList();

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetRolePageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 角色列表all
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetAllRoleList();

        /// <summary>
        /// 角色实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleEntity GetRoleEntity(string keyValue);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 角色编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 角色名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string fullName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存角色表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        void SaveRole(string keyValue, RoleEntity roleEntity);

        #endregion 提交数据
    }
}