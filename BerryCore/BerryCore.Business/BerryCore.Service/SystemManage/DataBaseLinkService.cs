#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.SystemManage
* 项目描述 ：
* 类 名 称 ：DataBaseLinkService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:52:48
* 更新时间 ：2019-12-17 17:52:48
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
using BerryCore.Entity.SystemManage;
using BerryCore.IService.SystemManage;
using BerryCore.Service.Base;

namespace BerryCore.Service.SystemManage
{
    /// <summary>
    /// 功能描述    ：DataBaseLinkService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:52:48 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:52:48 
    /// </summary>
    public class DataBaseLinkService : BaseService<DataBaseLinkEntity>, IDataBaseLinkService
    {
        /// <summary>
        /// 库连接列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataBaseLinkEntity> GetDataBaseLinkList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 库连接实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseLinkEntity GetDataBaseLinkEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除库连接
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存库连接表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="databaseLinkEntity">库连接实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseLinkEntity databaseLinkEntity)
        {
            throw new NotImplementedException();
        }
    }
}
