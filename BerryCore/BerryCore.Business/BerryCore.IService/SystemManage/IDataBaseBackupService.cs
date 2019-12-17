#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IService.SystemManage
* 项目描述 ：
* 类 名 称 ：IDataBaseBackupService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IService.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:03:48
* 更新时间 ：2019-12-17 17:03:48
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
    /// 功能描述    ：IDataBaseBackupService
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:03:48
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:03:48
    /// </summary>
    public interface IDataBaseBackupService
    {
        #region 获取数据

        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<DataBaseBackupEntity> GetDataBaseBackupList(string dataBaseLinkId, string queryJson);

        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        IEnumerable<DataBaseBackupEntity> GetDataBaseBackupPathList(string databaseBackupId);

        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        DataBaseBackupEntity GetDataBaseBackupEntity(string keyValue);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveByKey(string keyValue);

        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataBaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DataBaseBackupEntity dataBaseBackupEntity);

        #endregion 提交数据
    }
}