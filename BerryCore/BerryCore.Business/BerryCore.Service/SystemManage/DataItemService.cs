#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.SystemManage
* 项目描述 ：
* 类 名 称 ：DataItemService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:53:59
* 更新时间 ：2019-12-17 17:53:59
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
    /// 功能描述    ：DataItemService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:53:59 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:53:59 
    /// </summary>
    public class DataItemService : BaseService<DataItemEntity>, IDataItemService
    {
        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetDataItemList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByCode(string itemCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemCode(string itemCode, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        public void SaveDataItem(string keyValue, DataItemEntity dataItemEntity)
        {
            throw new NotImplementedException();
        }
    }
}
