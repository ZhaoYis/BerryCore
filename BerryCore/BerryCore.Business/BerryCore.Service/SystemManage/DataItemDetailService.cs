#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.Service.SystemManage
* 项目描述 ：
* 类 名 称 ：DataItemDetailService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.Service.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:06:39
* 更新时间 ：2019-12-17 18:06:39
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
using BerryCore.Entity.VOs.SystemManage;
using BerryCore.IService.SystemManage;
using BerryCore.Service.Base;

namespace BerryCore.Service.SystemManage
{
    /// <summary>
    /// 功能描述    ：DataItemDetailService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:06:39 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:06:39 
    /// </summary>
    public class DataItemDetailService : BaseService<DataItemDetailEntity>, IDataItemDetailService
    {
        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemDetailEntity GetDataItemDetailEntity(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 项目值不能重复
        /// </summary>
        /// <param name="itemValue">项目值</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public bool ExistItemValue(string itemValue, string keyValue, string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 项目名不能重复
        /// </summary>
        /// <param name="itemName">项目名</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue, string itemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        public void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity)
        {
            throw new NotImplementedException();
        }
    }
}
