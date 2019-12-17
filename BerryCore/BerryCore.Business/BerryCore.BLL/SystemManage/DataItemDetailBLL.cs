#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.SystemManage
* 项目描述 ：
* 类 名 称 ：DataItemDetailBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:42:03
* 更新时间 ：2019-12-17 18:42:03
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
using BerryCore.IBLL.SystemManage;
using BerryCore.IService.SystemManage;
using BerryCore.Service.SystemManage;

namespace BerryCore.BLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：DataItemDetailBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:42:03 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:42:03 
    /// </summary>
    public class DataItemDetailBLL : IDataItemDetailBLL
    {
        private readonly IDataItemDetailService _dataItemDetailService = new DataItemDetailService();

        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        public IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId)
        {
            return _dataItemDetailService.GetDataItemDetailList(itemId);
        }

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemDetailEntity GetDataItemDetailEntity(string keyValue)
        {
            return _dataItemDetailService.GetDataItemDetailEntity(keyValue);
        }

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemViewModel> GetDataItemList()
        {
            return _dataItemDetailService.GetDataItemList();
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
            return _dataItemDetailService.ExistItemValue(itemValue, keyValue, itemId);
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
            return _dataItemDetailService.ExistItemName(itemName, keyValue, itemId);
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            _dataItemDetailService.RemoveByKey(keyValue);
        }

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        public void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity)
        {
            _dataItemDetailService.SaveDataItemDetail(keyValue, dataItemDetailEntity);
        }
    }
}
