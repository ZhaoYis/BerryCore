#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data.Repository
* 项目描述 ：
* 类 名 称 ：Repository
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data.Repository
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 11:24:01
* 更新时间 ：2019/5/4 11:24:01
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Entity.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace BerryCore.Data.Repository
{
    /// <summary>
    /// 功能描述    ：仓储模型中的数据标准操作  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 11:24:01 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 11:24:01 
    /// </summary>
    public class Repository : IRepository
    {
        #region 构造

        private readonly IDatabase _db;

        public Repository(IDatabase database)
        {
            this._db = database;
        }

        #endregion

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <returns></returns>
        public IRepository BeginTrans()
        {
            _db.BeginTrans();
            return this;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return _db.Commit();
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            _db.Rollback();
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            return _db.ExecuteBySql(strSql);
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, object parameters)
        {
            return _db.ExecuteBySql(strSql, parameters);
        }

        /// <summary>
        /// 执行 SQL 语句返回集合
        /// </summary>
        /// <typeparam name="TR">动态类型</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters) where TR : class, new()
        {
            return _db.ExecuteBySqlAndReturnList<TR>(strSql, parameters);
        }

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public TR ExecuteBySqlAndReturnObject<TR>(string strSql, object parameters) where TR : class, new()
        {
            return _db.ExecuteBySqlAndReturnObject<TR>(strSql, parameters);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            return _db.ExecuteByProc(procName);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, object parameters)
        {
            return _db.ExecuteByProc(procName, parameters);
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(string procName) where TR : class, new()
        {
            return _db.ExecuteByProc<TR>(procName);
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(string procName, object parameters) where TR : class, new()
        {
            return _db.ExecuteByProc<TR>(procName, parameters);
        }

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Insert<T>(T entity) where T : class, new()
        {
            return _db.Insert<T>(entity);
        }

        /// <summary>
        /// 实体批量插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        public int BatchInsert<T>(List<T> entities) where T : class, new()
        {
            return _db.BatchInsert<T>(entities);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        public int Delete<T>() where T : class, new()
        {
            return _db.Delete<T>();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class, new()
        {
            return _db.Delete<T>(entity);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        public int BatchDelete<T>(List<T> entities) where T : class, new()
        {
            return _db.BatchDelete<T>(entities);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return _db.Delete<T>(condition);
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public int Delete(object keyValue)
        {
            return _db.Delete(keyValue);
        }

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue) where T : class, new()
        {
            return _db.FindEntity<T>(keyValue);
        }

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return _db.FindEntity<T>(condition);
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>() where T : class, new()
        {
            return _db.IQueryable<T>();
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return _db.IQueryable<T>(condition);
        }

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>() where T : class, new()
        {
            return _db.FindList<T>();
        }

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return _db.FindList<T>(condition);
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql) where T : class, new()
        {
            return _db.FindList<T>(strSql);
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, object parameters) where T : class, new()
        {
            return _db.FindList<T>(strSql, parameters);
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, object parameters, Pagination pagination) where T : class, new()
        {
            int total = pagination.TotalRecords;
            var data = _db.FindList<T>(strSql, parameters, pagination.Sidx, pagination.Sord.ToLower() == "asc", pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new()
        {
            int total = pagination.TotalRecords;
            var data = _db.FindList<T>(condition, pagination.Sidx, pagination.Sord.ToLower() == "asc", pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public DataTable FindTable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return _db.FindTable<T>(condition);
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters)
        {
            return _db.FindTable(strSql, parameters);
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, Pagination pagination)
        {
            int total = pagination.TotalRecords;
            var data = _db.FindTable(strSql, pagination.Sidx, pagination.Sord.ToLower() == "asc", pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters, Pagination pagination)
        {
            int total = pagination.TotalRecords;
            var data = _db.FindTable(strSql, parameters, pagination.Sidx, pagination.Sord.ToLower() == "asc", pagination.PageSize, pagination.PageIndex, out total);
            pagination.TotalRecords = total;
            return data;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class, new()
        {
            return _db.Update<T>(entity);
        }

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public int Update<T>(T entity, Expression<Func<T, bool>> condition) where T : class, new()
        {
            return _db.Update<T>(entity, condition);
        }
    }
}
