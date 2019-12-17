#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.BaseManage
* 项目描述 ：
* 类 名 称 ：OrganizeBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.BaseManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:13:06
* 更新时间 ：2019-12-17 18:13:06
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
using BerryCore.Entity.BaseManage;
using BerryCore.IBLL.BaseManage;
using BerryCore.IService.BaseManage;
using BerryCore.Service.BaseManage;

namespace BerryCore.BLL.BaseManage
{
    /// <summary>
    /// 功能描述    ：OrganizeBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:13:06 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:13:06 
    /// </summary>
    public class OrganizeBLL : IOrganizeBLL
    {
        private readonly IOrganizeService _organizeService = new OrganizeService();

        /// <summary>
        /// 机构列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizeEntity> GetOrganizeList()
        {
            return _organizeService.GetOrganizeList();
        }

        /// <summary>
        /// 机构实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public OrganizeEntity GetOrganizeEntity(string keyValue)
        {
            return _organizeService.GetOrganizeEntity(keyValue);
        }

        /// <summary>
        /// 公司名称不能重复
        /// </summary>
        /// <param name="organizeName">公司名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistFullName(string organizeName, string keyValue)
        {
            return _organizeService.ExistFullName(organizeName, keyValue);
        }

        /// <summary>
        /// 外文名称不能重复
        /// </summary>
        /// <param name="enCode">外文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistEnCode(string enCode, string keyValue)
        {
            return _organizeService.ExistEnCode(enCode, keyValue);
        }

        /// <summary>
        /// 中文名称不能重复
        /// </summary>
        /// <param name="shortName">中文名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistShortName(string shortName, string keyValue)
        {
            return _organizeService.ExistShortName(shortName, keyValue);
        }

        /// <summary>
        /// 删除机构
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            _organizeService.RemoveByKey(keyValue);
        }

        /// <summary>
        /// 保存机构表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="organizeEntity">机构实体</param>
        /// <returns></returns>
        public void AddOrganize(string keyValue, OrganizeEntity organizeEntity)
        {
            _organizeService.AddOrganize(keyValue, organizeEntity);
        }
    }
}
