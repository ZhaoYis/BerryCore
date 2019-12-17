#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.BaseManage
* 项目描述 ：
* 类 名 称 ：JobBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.BaseManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:10:54
* 更新时间 ：2019-12-17 18:10:54
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Entity.Base;
using BerryCore.Entity.BaseManage;
using BerryCore.IBLL.BaseManage;
using BerryCore.IService.BaseManage;
using BerryCore.Service.BaseManage;
using System.Collections.Generic;

namespace BerryCore.BLL.BaseManage
{
    /// <summary>
    /// 功能描述    ：JobBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:10:54 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:10:54 
    /// </summary>
    public class JobBLL : IJobBLL
    {
        private readonly IJobService _service = new JobService();

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetJobList()
        {
            return _service.GetJobList();
        }

        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetJobPageList(PaginationEntity pagination, string queryJson)
        {
            return _service.GetJobPageList(pagination, queryJson);
        }

        /// <summary>
        /// 职位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetJobEntity(string keyValue)
        {
            return _service.GetJobEntity(keyValue);
        }

        /// <summary>
        /// 职位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _service.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 职位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            return _service.ExistFullName(fullName, keyValue);
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            _service.RemoveByKey(keyValue);
        }

        /// <summary>
        /// 保存职位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="jobEntity">职位实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, RoleEntity jobEntity)
        {
            _service.SaveForm(keyValue, jobEntity);
        }
    }
}
