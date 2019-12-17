#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.BaseManage
* 项目描述 ：
* 类 名 称 ：UserGroupService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.BaseManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:50:53
* 更新时间 ：2019-12-17 17:50:53
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
using BerryCore.Entity.Base;
using BerryCore.Entity.BaseManage;
using BerryCore.IService.BaseManage;
using BerryCore.Service.Base;

namespace BerryCore.Service.BaseManage
{
    /// <summary>
    /// 功能描述    ：UserGroupService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:50:53 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:50:53 
    /// </summary>
    public class UserGroupService : BaseService<RoleEntity>, IUserGroupService
    {
        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetUserGroupList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPageList(PaginationEntity pagination, string queryJson)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 用户组列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllUserGroupList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 用户组实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetUserGroupEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 组编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 组名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存用户组表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="userGroupEntity">用户组实体</param>
        /// <returns></returns>
        public void SaveUserGroup(string keyValue, RoleEntity userGroupEntity)
        {
            throw new NotImplementedException();
        }
    }
}
