#region << 版 本 注 释 >>

/*
* 项目名称 ：BerryCore.IBLL.SystemManage
* 项目描述 ：
* 类 名 称 ：IDataBaseTableBLL
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：BerryCore.IBLL.SystemManage
* 机器名称 ：DASHIXIONG
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-12-17 17:33:33
* 更新时间 ：2019-12-17 17:33:33
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/

#endregion << 版 本 注 释 >>

using BerryCore.Entity.Base;
using BerryCore.Entity.DTOs.SystemManage;
using System.Collections.Generic;
using System.Data;

namespace BerryCore.IBLL.SystemManage
{
    /// <summary>
    /// 功能描述    ：IDataBaseTableBLL
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-12-17 17:33:33
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-12-17 17:33:33
    /// </summary>
    public interface IDataBaseTableBLL
    {
        #region 获取数据

        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        List<SystemTableInfoDto> GetTableList(string dataBaseLinkId, string tableName);

        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns></returns>
        IEnumerable<DataBaseTableFieldDto> GetTableFiledList(string dataBaseLinkId, string tableName);

        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, PaginationEntity pagination);

        #endregion 获取数据

        #region 提交数据

        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDescription">表说明</param>
        /// <param name="fieldList">字段列表</param>
        void SaveForm(string dataBaseLinkId, string tableName, string tableDescription, string fieldList);

        #endregion 提交数据
    }
}