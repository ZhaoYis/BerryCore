#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IService.SystemManage
* 项目描述 ：
* 类 名 称 ：IDataItemService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IService.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:08:24
* 更新时间 ：2019-12-17 17:08:24
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.SystemManage;
using System.Collections.Generic;

namespace BerryCore.IService.SystemManage
{
    /// <summary>
    /// 功能描述    ：IDataItemService
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:08:24
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:08:24
    /// </summary>
    public interface IDataItemService
    {
        #region 获取数据

        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<DataItemEntity> GetDataItemList();

        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataItemEntity GetEntityByKey(string keyValue);

        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <returns></returns>
        DataItemEntity GetEntityByCode(string itemCode);

        #endregion 获取数据

        #region 验证数据

        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistItemCode(string itemCode, string keyValue);

        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        bool ExistItemName(string itemName, string keyValue);

        #endregion 验证数据

        #region 提交数据

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        void SaveDataItem(string keyValue, DataItemEntity dataItemEntity);

        #endregion 提交数据
    }
}