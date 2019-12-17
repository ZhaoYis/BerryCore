#region << 版 本 注 释 >>
/*
* 项目名称 ：BerryCore.BLL.SystemManage
* 项目描述 ：
* 类 名 称 ：LoggerBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.BLL.SystemManage
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 18:43:30
* 更新时间 ：2019-12-17 18:43:30
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
using BerryCore.Entity.Base;
using BerryCore.Entity.SystemManage;
using BerryCore.IBLL.SystemManage;
using BerryCore.IService.SystemManage;
using BerryCore.Service.SystemManage;

namespace BerryCore.BLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：LoggerBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 18:43:30 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 18:43:30 
    /// </summary>
    public class LoggerBLL : ILoggerBLL
    {
        private readonly ILoggerService _logService = new LoggerService();

        /// <summary>
        /// 日志列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<LoggerEntity> GetLoggerPageList(PaginationEntity pagination, string queryJson)
        {
            return _logService.GetLoggerPageList(pagination, queryJson);
        }

        /// <summary>
        /// 日志实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public LoggerEntity GetLoggerEntity(string keyValue)
        {
            return _logService.GetLoggerEntity(keyValue);
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="categoryId">日志分类Id</param>
        /// <param name="keepTime">保留时间段内</param>
        public void RemoveLog(int categoryId, string keepTime)
        {
            _logService.RemoveLog(categoryId, keepTime);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">对象</param>
        public void WriteLog(LoggerEntity logEntity)
        {
            _logService.WriteLog(logEntity);
        }
    }
}
