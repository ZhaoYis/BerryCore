#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.IService.Base
* 项目描述 ：
* 类 名 称 ：IBaseService
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.IService.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 9:19:20
* 更新时间 ：2019/5/4 9:19:20
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using BerryCore.Entity.Base;

namespace BerryCore.IService.Base
{
    /// <summary>
    /// 功能描述    ：IBaseService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 9:19:20 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 9:19:20 
    /// </summary>
    public interface IBaseService<T> where T : class, new()
    {
        #region 公共操作方法

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加实体</param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys">待添加实体集合</param>
        /// <returns></returns>
        int AddList(List<T> entitys);

        /// <summary>
        /// 根据条件获取一条记录
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        T GetEntity(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据条件获取多条记录
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        IEnumerable<T> GetList(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 删除表所有数据
        /// </summary>
        /// <returns></returns>
        int Delete();

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="entity">要修改的列及修改后列的值集合</param>
        /// <param name="condition">筛选条件</param>
        /// <returns>返回受影响行数</returns>
        int Update(object entity, Expression<Func<T, bool>> condition);

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql);

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql, object parameters);

        /// <summary>
        /// 执行T-SQL并返回集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters) where TR : class, new();

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        TR ExecuteBySqlAndReturnObject<TR>(string strSql, object parameters) where TR : class, new();

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        int ExecuteByProc(string procName);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExecuteByProc(string procName, object parameters);

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteByProc<TR>(string procName, object parameters) where TR : class, new();

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition, PaginationEntity pagination);

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        DataTable FindTable<TR>(Expression<Func<T, bool>> condition) where TR : class, new();

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, object parameters);

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, PaginationEntity pagination);

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, object parameters, PaginationEntity pagination);

        #endregion
    }
}
