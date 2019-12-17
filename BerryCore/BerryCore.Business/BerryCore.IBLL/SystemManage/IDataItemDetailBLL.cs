#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.SystemManage
* 项目描述 ：
* 类 名 称 ：IDataItemDetailBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:33:58
* 更新时间 ：2019-12-17 17:33:58
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.SystemManage;
using BerryCore.Entity.VOs.SystemManage;
using System.Collections.Generic;

namespace BerryCore.IBLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：IDataItemDetailBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:33:58
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:33:58
    /// </summary>
    public interface IDataItemDetailBLL
    {
        #region 获取数据

        /// <summary>
        /// 明细列表
        /// </summary>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        IEnumerable<DataItemDetailEntity> GetDataItemDetailList(string itemId);

        /// <summary>
        /// 明细实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataItemDetailEntity GetDataItemDetailEntity(string keyValue);

        /// <summary>
        /// 获取数据字典列表（给绑定下拉框提供的）
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataItemViewModel> GetDataItemList();

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 项目值不能重复
        /// </summary>
        /// <param name="itemValue">项目值</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        bool ExistItemValue(string itemValue, string keyValue, string itemId);

        /// <summary>
        /// 项目名不能重复
        /// </summary>
        /// <param name="itemName">项目名</param>
        /// <param name="keyValue">主键</param>
        /// <param name="itemId">分类Id</param>
        /// <returns></returns>
        bool ExistItemName(string itemName, string keyValue, string itemId);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存明细表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemDetailEntity">明细实体</param>
        /// <returns></returns>
        void SaveDataItemDetail(string keyValue, DataItemDetailEntity dataItemDetailEntity);

        #endregion 提交数据
    }
}