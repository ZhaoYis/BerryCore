#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IService.SystemManage
* 项目描述 ：
* 类 名 称 ：ILoggerService
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IService.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:09:47
* 更新时间 ：2019-12-17 17:09:47
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.Base;
using BerryCore.Entity.SystemManage;
using System.Collections.Generic;

namespace BerryCore.IService.SystemManage
{
    /// <summary>
    /// 功能描述    ：ILoggerService
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:09:47
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:09:47
    /// </summary>
    public interface ILoggerService
    {
        #region 获取数据

        /// <summary>
        /// 日志列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<LoggerEntity> GetLoggerPageList(PaginationEntity pagination, string queryJson);

        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        LoggerEntity GetLoggerEntity(string keyValue);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        void RemoveLog(int categoryId, string keepTime);

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">对象</param>
        void WriteLog(LoggerEntity logEntity);

        #endregion 提交数据
    }
}