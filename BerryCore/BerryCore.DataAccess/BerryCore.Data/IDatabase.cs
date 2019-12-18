#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data
* 项目描述 ：
* 类 名 称 ：IDatabase
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.15319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 14:13:37
* 更新时间 ：2019/5/3 14:13:37
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Entity.Protocol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace BerryCore.Data
{
    /// <summary>
    /// 功能描述    ：通用数据操作方法  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 14:13:37 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 14:13:37 
    /// </summary>
    public interface IDatabase
    {
        #region 数据库对象
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// 获取基础数据库连接
        /// </summary>
        /// <returns></returns>
        IDbConnection BaseDbConnection { get; }

        /// <summary>
        /// 数据库事务
        /// </summary>
        IDbTransaction BaseDbTransaction { get; set; }

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <returns></returns>
        IDatabase BeginTrans();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();

        #endregion

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
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int ExecuteBySql(string strSql, object parameters, int? timeout = 15);

        /// <summary>
        /// 执行 SQL 语句返回集合
        /// </summary>
        /// <typeparam name="TR">动态类型</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters, int? timeout = 15);

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        TR ExecuteBySqlAndReturnObject<TR>(string strSql, object parameters, int? timeout = 15);

        #endregion

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
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int ExecuteByProc(string procName, object parameters, int? timeout = 15);

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteByProc<TR>(string procName) where TR : class;

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<TR> ExecuteByProc<TR>(string procName, object parameters, int? timeout = 15) where TR : class;

        #endregion

        #region 新增

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Insert<T>(T entity, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 实体批量插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int BatchInsert<T>(List<T> entities, int? timeout = 15) where T : IEntity;

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        int Delete<T>(int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Delete<T>(T entity, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int BatchDelete<T>(List<T> entities, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Delete<T>(Expression<Func<T, bool>> condition, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Delete<T>(object keyValue, int? timeout = 15);

        #endregion

        #region 查询

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        T FindEntity<T>(object keyValue, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        T FindEntity<T>(Expression<Func<T, bool>> condition, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IQueryable<T> IQueryable<T>(int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string strSql, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string strSql, object parameters, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 执行sql语句，获取分页数据
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总页数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(string strSql, object parameters, string orderField, bool isAsc, int pageSize, int pageIndex, out int total, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="orderField">排序字段，多个用英文逗号隔开，类似：Id Asc,Name Desc</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总页数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        DataTable FindTable<T>(Expression<Func<T, bool>> condition, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, object parameters, int? timeout = 15);

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总页数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total, int? timeout = 15);

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="pageIndex">索引</param>
        /// <param name="total">总页数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        DataTable FindTable(string strSql, object parameters, string orderField, bool isAsc, int pageSize, int pageIndex, out int total, int? timeout = 15);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Count(string strSql, object parameters, int? timeout = 15);
        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Update<T>(object entity, int? timeout = 15) where T : IEntity;

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Update<T>(object entity, Expression<Func<T, bool>> condition, int? timeout = 15) where T : IEntity;

        #endregion

    }
}
