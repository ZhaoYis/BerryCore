#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.BaseManage
* 项目描述 ：
* 类 名 称 ：IJobBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.BaseManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:29:32
* 更新时间 ：2019-12-17 17:29:32
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
    /// 功能描述    ：IJobBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:29:32
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:29:32
    /// </summary>
    public interface IJobBLL
    {
        #region 获取数据

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetJobList();

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<RoleEntity> GetJobPageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 职位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        RoleEntity GetJobEntity(string keyValue);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 职位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistEnCode(string enCode, string keyValue);

        /// <summary>
        /// 职位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistFullName(string fullName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存职位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="jobEntity">职位实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, RoleEntity jobEntity);

        #endregion 提交数据
    }
}