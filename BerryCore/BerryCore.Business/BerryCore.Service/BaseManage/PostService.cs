﻿#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.BaseManage
* 项目描述 ：
* 类 名 称 ：PostService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.BaseManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:50:12
* 更新时间 ：2019-12-17 17:50:12
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
    /// 功能描述    ：PostService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:50:12 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:50:12 
    /// </summary>
    public class PostService : BaseService<RoleEntity>, IPostService
    {
        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 岗位列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetPostPageList(PaginationEntity pagination, string queryJson)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 岗位列表(ALL)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetAllPostList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 岗位实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public RoleEntity GetPostEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 岗位编号不能重复
        /// </summary>
        /// <param name="enCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 岗位名称不能重复
        /// </summary>
        /// <param name="fullName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string fullName, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除岗位
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存岗位表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="postEntity">岗位实体</param>
        /// <returns></returns>
        public void SavePost(string keyValue, RoleEntity postEntity)
        {
            throw new NotImplementedException();
        }
    }
}
