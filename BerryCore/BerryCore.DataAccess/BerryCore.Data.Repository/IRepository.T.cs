#region << 版 本 注 释 >>

/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data.Repository
* 项目描述 ：
* 类 名 称 ：IRepository
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data.Repository
* 机器名称 ：MRZHAOYI
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 14:50:58
* 更新时间 ：2019/5/3 14:50:58
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/

#endregion << 版 本 注 释 >>

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using BerryCore.Entity.Base;
using BerryCore.Entity.Protocol;

namespace BerryCore.Data.Repository
{
    /// <summary>
    /// 功能描述    ：仓储模型中的数据标准操作接口
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 14:50:58
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 14:50:58
    /// </summary>
    public interface IRepository<T> where T : IEntity, new()
    {
        /// <summary>
        /// 返回仓储对象，并开始数据库事务
        /// </summary>
        /// <returns></returns>
        IRepository<T> BeginTrans();

        /// <summary>
        /// 返回仓储对象，不使用数据库事务
        /// </summary>
        /// <returns></returns>
        IRepository<T> Instance();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();

        #region 执行 SQL 语句

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql);

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql, object parameters);

        /// <summary>
        /// 执行 SQL 语句返回集合
        /// </summary>
        /// <typeparam name="TR">动态类型</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters) where TR : class, new();

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        TR ExecuteBySqlAndReturnObject<TR>(string strSql, object parameters) where TR : class, new();

        #endregion 执行 SQL 语句

        #region 执行存储过程

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
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteByProc<TR>(string procName) where TR : class, new();

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteByProc<TR>(string procName, object parameters) where TR : class, new();

        #endregion 执行存储过程

        #region 新增

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        /// 实体批量插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        int BatchInsert(List<T> entities);

        #endregion 新增

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        int Delete();

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        int Delete(T entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        int BatchDelete(List<T> entities);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        int Delete(object keyValue);

        #endregion 删除

        #region 查询

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        T FindEntity(object keyValue);

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        T FindEntity(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        IQueryable<T> IQueryable();

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        IQueryable<T> IQueryable(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        IEnumerable<T> FindList();

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition);

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql);

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql, object parameters);

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(string strSql, object parameters, PaginationEntity pagination);

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> condition, PaginationEntity pagination);

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        DataTable FindTable(Expression<Func<T, bool>> condition);

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

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        int Count(string strSql, object parameters);
        #endregion 查询

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <returns></returns>
        int Update(object entity);

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        int Update(object entity, Expression<Func<T, bool>> condition);

        #endregion 更新
    }
}