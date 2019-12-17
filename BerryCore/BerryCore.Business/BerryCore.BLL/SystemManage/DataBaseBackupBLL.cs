#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.SystemManage
* 项目描述 ：
* 类 名 称 ：DataBaseBackupBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:32:26
* 更新时间 ：2019-12-17 18:32:26
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using BerryCore.Entity.SystemManage;
using BerryCore.IBLL.SystemManage;
using BerryCore.IService.SystemManage;
using BerryCore.Service.SystemManage;
using System.Collections.Generic;

namespace BerryCore.BLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：DataBaseBackupBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:32:26 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:32:26 
    /// </summary>
    public class DataBaseBackupBLL : IDataBaseBackupBLL
    {
        private readonly IDataBaseBackupService service = new DataBaseBackupService();

        /// <summary>
        /// 库备份列表
        /// </summary>
        /// <param name="dataBaseLinkId">连接库Id</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<DataBaseBackupEntity> GetDataBaseBackupList(string dataBaseLinkId, string queryJson)
        {
            return service.GetDataBaseBackupList(dataBaseLinkId, queryJson);
        }

        /// <summary>
        /// 库备份文件路径列表
        /// </summary>
        /// <param name="databaseBackupId">计划Id</param>
        /// <returns></returns>
        public IEnumerable<DataBaseBackupEntity> GetDataBaseBackupPathList(string databaseBackupId)
        {
            return service.GetDataBaseBackupPathList(databaseBackupId);
        }

        /// <summary>
        /// 库备份实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataBaseBackupEntity GetDataBaseBackupEntity(string keyValue)
        {
            return service.GetDataBaseBackupEntity(keyValue);
        }

        /// <summary>
        /// 删除库备份
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveByKey(string keyValue)
        {
            service.RemoveByKey(keyValue);
        }

        /// <summary>
        /// 保存库备份表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataBaseBackupEntity">库备份实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataBaseBackupEntity dataBaseBackupEntity)
        {
            service.SaveForm(keyValue, dataBaseBackupEntity);
        }
    }
}
