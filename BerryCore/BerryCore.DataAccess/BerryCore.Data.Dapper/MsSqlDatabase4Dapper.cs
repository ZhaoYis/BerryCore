#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data.Dapper
* 项目描述 ：
* 类 名 称 ：MsSqlDatabase4Dapper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data.Dapper
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 22:47:10
* 更新时间 ：2019/5/3 22:47:10
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Data.ExMessage;
using BerryCore.Log;
using BerryCore.Utilities;
using BerryCore.Utilities.Lambda2SQL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BerryCore.Data.Dapper
{
    /// <summary>
    /// 功能描述    ：MsSqlDatabase4Dapper  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 22:47:10 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 22:47:10 
    /// </summary>
    public class MsSqlDatabase4Dapper : BaseLogger, IDatabase
    {
        #region 构造函数

        /// <summary>
        /// 对象锁🔒
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// 超时时间
        /// </summary>
        private const int Timeout = 30;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connStringName">连接字符串配置项名称</param>
        public MsSqlDatabase4Dapper(string connStringName)
        {
            lock (_lock)
            {
                this.ConnectionString = ConfigHelper.GetConnectionString(connStringName);
            }
        }

        #endregion

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 获取基础数据库连接
        /// </summary>
        /// <returns></returns>
        public IDbConnection BaseDbConnection
        {
            get
            {
                IDbConnection dbconnection = new SqlConnection(this.ConnectionString);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                return dbconnection;
            }
        }

        /// <summary>
        /// 数据库事务
        /// </summary>
        public IDbTransaction BaseDbTransaction { get; set; }

        /// <summary>
        /// 开始数据库事务
        /// </summary>
        /// <returns></returns>
        public IDatabase BeginTrans()
        {
            IDbConnection dbConnection = this.BaseDbConnection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            this.BaseDbTransaction = dbConnection.BeginTransaction();
            return this;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            int res = -1;
            this.Logger(this.GetType(), "提交事务-Commit", () =>
             {
                 if (this.BaseDbTransaction != null)
                 {
                     this.BaseDbTransaction.Commit();
                     this.Close();
                 }
                 res = 1;
             }, e =>
            {
                if (e.InnerException != null && e is CustomException)
                {
                    SqlException sqlEx = e.InnerException.InnerException as SqlException;
                    if (sqlEx != null)
                    {
                        string msg = DataAccessExMessage.GetSqlExceptionMessage(sqlEx.Number);
                        throw CustomException.ThrowDataAccessException(sqlEx, msg);
                    }
                }
                else
                {
                    throw new Exception("提交事务发生异常-Commit", e.InnerException);
                }
            }, () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    this.Close();
                }
            });
            return res;
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            if (this.BaseDbTransaction != null)
            {
                this.BaseDbTransaction.Rollback();
                this.BaseDbTransaction.Dispose();
                this.Close();
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            IDbConnection dbConnection = this.BaseDbConnection;
            if (dbConnection != null && dbConnection.State != ConnectionState.Closed)
            {
                dbConnection.Close();
            }
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            return this.ExecuteBySql(strSql, null);
        }

        /// <summary>
        /// 执行 SQL 语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, object parameters, int? timeout = Timeout)
        {
            int res = 0;
            this.Logger(this.GetType(), "执行 SQL 语句-ExecuteBySql", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Execute(strSql, parameters, null, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Execute(strSql, parameters, this.BaseDbTransaction, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 执行 SQL 语句返回集合
        /// </summary>
        /// <typeparam name="TR">动态类型</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters, int? timeout = Timeout)
        {
            IEnumerable<TR> res = default(IEnumerable<TR>);
            this.Logger(this.GetType(), "执行 SQL 语句返回集合-ExecuteBySqlAndReturnList", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<TR>(strSql, parameters, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<TR>(strSql, parameters, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public TR ExecuteBySqlAndReturnObject<TR>(string strSql, object parameters, int? timeout = Timeout)
        {
            TR res = default(TR);
            this.Logger(this.GetType(), "执行 SQL 语句返回对象-ExecuteBySqlAndReturnObject", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<TR>(strSql, parameters, null, true, timeout, CommandType.Text).FirstOrDefault();
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<TR>(strSql, parameters, this.BaseDbTransaction, true, timeout, CommandType.Text).FirstOrDefault();
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            return this.ExecuteByProc(procName, null);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, object parameters, int? timeout = Timeout)
        {
            int res = 0;
            this.Logger(this.GetType(), "执行存储过程-ExecuteByProc", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Execute(procName, parameters, null, timeout, CommandType.StoredProcedure);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Execute(procName, parameters, this.BaseDbTransaction, timeout, CommandType.StoredProcedure);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(string procName) where TR : class
        {
            return this.ExecuteByProc<TR>(procName, null);
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR">动态对象</typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(string procName, object parameters, int? timeout = Timeout) where TR : class
        {
            IEnumerable<TR> res = default(IEnumerable<TR>);
            this.Logger(this.GetType(), "执行存储过程，返回集合-ExecuteByProc", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<TR>(procName, parameters, null, true, timeout, CommandType.StoredProcedure);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<TR>(procName, parameters, this.BaseDbTransaction, true, timeout, CommandType.StoredProcedure);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 实体插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int Insert<T>(T entity, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "实体插入-Insert", () =>
            {
                if (entity != null)
                {
                    string sql = DatabaseCommon.InsertSql<T>(entity).ToString();

                    if (this.BaseDbTransaction == null)
                    {
                        using (IDbConnection connection = this.BaseDbConnection)
                        {
                            res = connection.Execute(sql, entity, null, timeout, CommandType.Text);
                        }
                    }
                    else
                    {
                        res = this.BaseDbTransaction.Connection.Execute(sql, entity, this.BaseDbTransaction, timeout, CommandType.Text);
                    }
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 实体批量插入
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int BatchInsert<T>(List<T> entities, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "实体批量插入-BatchInsert", () =>
            {
                if (entities != null && entities.Count > 0)
                {
                    string sql = DatabaseCommon.InsertSql<T>(entities.First()).ToString();

                    if (this.BaseDbTransaction == null)
                    {
                        using (IDbConnection connection = this.BaseDbConnection)
                        {
                            res = connection.Execute(sql, entities, null, timeout, CommandType.Text);
                        }
                    }
                    else
                    {
                        res = this.BaseDbTransaction.Connection.Execute(sql, entities, this.BaseDbTransaction, timeout, CommandType.Text);
                    }
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <returns></returns>
        public int Delete<T>(int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "删除-Delete", () =>
            {
                string tableName = EntityAttributeHelper.GetEntityTable<T>();
                string sql = DatabaseCommon.DeleteSql(tableName).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Execute(sql, null, null, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Execute(sql, null, this.BaseDbTransaction, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">实体</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int Delete<T>(T entity, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "删除-Delete", () =>
            {
                if (entity != null)
                {
                    string sql = DatabaseCommon.DeleteSql<T>(entity).ToString();

                    if (this.BaseDbTransaction == null)
                    {
                        using (IDbConnection connection = this.BaseDbConnection)
                        {
                            res = connection.Execute(sql, entity, null, timeout, CommandType.Text);
                        }
                    }
                    else
                    {
                        res = this.BaseDbTransaction.Connection.Execute(sql, entity, this.BaseDbTransaction, timeout, CommandType.Text);
                    }
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entities">实体集合</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int BatchDelete<T>(List<T> entities, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "批量删除-BatchDelete", () =>
            {
                if (entities != null && entities.Count > 0)
                {
                    string sql = DatabaseCommon.DeleteSql<T>(entities.First()).ToString();

                    if (this.BaseDbTransaction == null)
                    {
                        using (IDbConnection connection = this.BaseDbConnection)
                        {
                            res = connection.Execute(sql, entities, null, timeout, CommandType.Text);
                        }
                    }
                    else
                    {
                        res = this.BaseDbTransaction.Connection.Execute(sql, entities, this.BaseDbTransaction, timeout, CommandType.Text);
                    }
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "根据条件删除-Delete", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.DeleteSql<T>(where).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Execute(sql, null, null, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Execute(sql, null, this.BaseDbTransaction, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int Delete<T>(object keyValue, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "根据主键删除-Delete", () =>
            {
                Type type = keyValue.GetType();
                string key = EntityAttributeHelper.GetEntityKey<T>();
                string whereStr = string.Format(type == typeof(int) ? " WHERE {0} = {1}" : " WHERE {0} = '{1}'", key, keyValue);

                string sql = DatabaseCommon.DeleteSql<T>(whereStr).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Execute(sql, null, null, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Execute(sql, null, this.BaseDbTransaction, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 根据主键查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="keyValue">主键</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public T FindEntity<T>(object keyValue, int? timeout = Timeout) where T : class
        {
            T res = default(T);
            this.Logger(this.GetType(), "根据主键查询一个实体-FindEntity", () =>
            {
                Type type = keyValue.GetType();
                string key = EntityAttributeHelper.GetEntityKey<T>();
                string whereStr = string.Format(type == typeof(int) ? " WHERE {0} = {1}" : " WHERE {0} = '{1}'", key, keyValue);

                string sql = DatabaseCommon.SelectSql<T>(whereStr, true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(sql, null, null, true, timeout, CommandType.Text).FirstOrDefault();
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(sql, null, this.BaseDbTransaction, true, timeout, CommandType.Text).FirstOrDefault();
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 根据条件查询一个实体
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public T FindEntity<T>(Expression<Func<T, bool>> condition, int? timeout = Timeout) where T : class
        {
            T res = default(T);
            this.Logger(this.GetType(), "根据条件查询一个实体-FindEntity", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(sql, null, null, true, timeout, CommandType.Text).FirstOrDefault();
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(sql, null, this.BaseDbTransaction, true, timeout, CommandType.Text).FirstOrDefault();
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(int? timeout = Timeout) where T : class
        {
            IQueryable<T> res = default(IQueryable<T>);
            this.Logger(this.GetType(), "获取IQueryable对象-IQueryable", () =>
            {
                string sql = DatabaseCommon.SelectSql<T>("", true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(sql, null, null, true, timeout, CommandType.Text).AsQueryable();
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(sql, null, this.BaseDbTransaction, true, timeout, CommandType.Text).AsQueryable();
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition, int? timeout = Timeout) where T : class
        {
            IQueryable<T> res = default(IQueryable<T>);
            this.Logger(this.GetType(), "获取IQueryable对象-IQueryable", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();
                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(sql, null, null, true, timeout, CommandType.Text).AsQueryable();
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(sql, null, this.BaseDbTransaction, true, timeout, CommandType.Text).AsQueryable();
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            this.Logger(this.GetType(), "得到一个集合-FindList", () =>
            {
                string sql = DatabaseCommon.SelectSql<T>("", true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(sql, null, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(sql, null, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 根据条件查询出一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            this.Logger(this.GetType(), "根据条件查询出一个集合-FindList", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();
                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(sql, null, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(sql, null, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            this.Logger(this.GetType(), "执行sql语句，得到一个集合-FindList", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(strSql, null, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(strSql, null, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 执行sql语句，得到一个集合
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(string strSql, object parameters, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            this.Logger(this.GetType(), "执行sql语句，得到一个集合-FindList", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        res = connection.Query<T>(strSql, parameters, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    res = this.BaseDbTransaction.Connection.Query<T>(strSql, parameters, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

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
        public IEnumerable<T> FindList<T>(string strSql, object parameters, string orderField, bool isAsc, int pageSize, int pageIndex,
            out int total, int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            int temp = 0;
            this.Logger(this.GetType(), "执行sql语句，获取分页数据-FindList", () =>
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string orderBy = "";

                //表名
                string table = EntityAttributeHelper.GetEntityTable<T>();

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + orderField;
                    }
                    else
                    {
                        orderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + orderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

                //查询总记录数
                string selectCountSql = "Select Count(*) From " + table + " WHERE 1 = 1";

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        temp = (int)connection.ExecuteScalar(selectCountSql);
                        res = connection.Query<T>(sb.ToString(), parameters, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    temp = (int)this.BaseDbTransaction.Connection.ExecuteScalar(selectCountSql, null, this.BaseDbTransaction);
                    res = this.BaseDbTransaction.Connection.Query<T>(sb.ToString(), parameters, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            total = temp;
            return res;
        }

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
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, string orderField, bool isAsc, int pageSize, int pageIndex, out int total,
            int? timeout = Timeout) where T : class
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            int temp = 0;
            this.Logger(this.GetType(), "执行sql语句，获取分页数据-FindList", () =>
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string orderBy = "";

                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                //表名
                string table = EntityAttributeHelper.GetEntityTable<T>();
                string strSql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + orderField;
                    }
                    else
                    {
                        orderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + orderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

                //查询总记录数
                string selectCountSql = "Select Count(*) From " + table + " WHERE 1 = 1";

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        temp = (int)connection.ExecuteScalar(selectCountSql);
                        res = connection.Query<T>(sb.ToString(), null, null, true, timeout, CommandType.Text);
                    }
                }
                else
                {
                    temp = (int)this.BaseDbTransaction.Connection.ExecuteScalar(selectCountSql, null, this.BaseDbTransaction);
                    res = this.BaseDbTransaction.Connection.Query<T>(sb.ToString(), null, this.BaseDbTransaction, true, timeout, CommandType.Text);
                }
            }, e =>
            {
                this.Rollback();
            });
            total = temp;
            return res;
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public DataTable FindTable<T>(Expression<Func<T, bool>> condition, int? timeout = Timeout) where T : class
        {
            DataTable res = new DataTable(typeof(T).Name);
            this.Logger(this.GetType(), "根据条件查询一个DataTable-FindTable", () =>
            {
                LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                lambda.AddAndWhere(condition);
                string where = lambda.Where();

                string sql = DatabaseCommon.SelectSql<T>(where, true).ToString();

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        var reader = connection.ExecuteReader(sql, null, null, timeout, CommandType.Text);
                        res.Load(reader);
                    }
                }
                else
                {
                    var reader = this.BaseDbTransaction.Connection.ExecuteReader(sql, null, this.BaseDbTransaction, timeout, CommandType.Text);
                    res.Load(reader);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters, int? timeout = Timeout)
        {
            DataTable res = new DataTable("DefaultTable");
            this.Logger(this.GetType(), "查询一个DataTable-FindTable", () =>
            {
                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        var reader = connection.ExecuteReader(strSql, parameters, null, timeout, CommandType.Text);
                        res.Load(reader);
                    }
                }
                else
                {
                    var reader = this.BaseDbTransaction.Connection.ExecuteReader(strSql, parameters, this.BaseDbTransaction, timeout, CommandType.Text);
                    res.Load(reader);
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

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
        public DataTable FindTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int total,
            int? timeout = Timeout)
        {
            DataTable res = new DataTable("DefaultPageTable");
            int temp = 0;
            this.Logger(this.GetType(), "获取分页DataTable-FindTable", () =>
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string orderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + orderField;
                    }
                    else
                    {
                        orderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + orderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

                //查询总记录数
                string selectCountSql = "Select Count(*) From (" + strSql + ") AS t";

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        temp = (int)connection.ExecuteScalar(selectCountSql);
                        var reader = connection.ExecuteReader(sb.ToString(), null, null, timeout, CommandType.Text);
                        res.Load(reader);
                    }
                }
                else
                {
                    temp = (int)this.BaseDbTransaction.Connection.ExecuteScalar(selectCountSql, null, this.BaseDbTransaction);
                    var reader = this.BaseDbTransaction.Connection.ExecuteReader(sb.ToString(), null, this.BaseDbTransaction, timeout, CommandType.Text);
                    res.Load(reader);
                }
            }, e =>
            {
                this.Rollback();
            });
            total = temp;
            return res;
        }

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
        public DataTable FindTable(string strSql, object parameters, string orderField, bool isAsc, int pageSize, int pageIndex,
            out int total, int? timeout = Timeout)
        {
            DataTable res = new DataTable("DefaultPageTable");
            int temp = 0;
            this.Logger(this.GetType(), "获取分页DataTable-FindTable", () =>
            {
                StringBuilder sb = new StringBuilder();
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                int num = (pageIndex - 1) * pageSize;
                int num1 = (pageIndex) * pageSize;
                string orderBy = "";

                if (!string.IsNullOrEmpty(orderField))
                {
                    if (orderField.ToUpper().IndexOf("ASC", StringComparison.Ordinal) + orderField.ToUpper().IndexOf("DESC", StringComparison.Ordinal) > 0)
                    {
                        orderBy = "Order By " + orderField;
                    }
                    else
                    {
                        orderBy = "Order By " + orderField + " " + (isAsc ? "ASC" : "DESC");
                    }
                }
                else
                {
                    orderBy = "Order By (Select 0)";
                }
                sb.Append("Select * From (Select ROW_NUMBER() Over (" + orderBy + ")");
                sb.Append(" As rowNum, * From (" + strSql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");

                //查询总记录数
                string selectCountSql = "Select Count(*) From (" + strSql + ") AS t";

                if (this.BaseDbTransaction == null)
                {
                    using (IDbConnection connection = this.BaseDbConnection)
                    {
                        temp = (int)connection.ExecuteScalar(selectCountSql);
                        var reader = connection.ExecuteReader(sb.ToString(), parameters, null, timeout, CommandType.Text);
                        res.Load(reader);
                    }
                }
                else
                {
                    temp = (int)this.BaseDbTransaction.Connection.ExecuteScalar(selectCountSql, null, this.BaseDbTransaction);
                    var reader = this.BaseDbTransaction.Connection.ExecuteReader(sb.ToString(), parameters, this.BaseDbTransaction, timeout, CommandType.Text);
                    res.Load(reader);
                }
            }, e =>
            {
                this.Rollback();
            });
            total = temp;
            return res;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int Update<T>(object entity, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "更新-Update", () =>
            {
                if (entity != null)
                {
                    string sql = DatabaseCommon.UpdateSql<T>(entity).ToString();

                    if (this.BaseDbTransaction == null)
                    {
                        using (IDbConnection connection = this.BaseDbConnection)
                        {
                            res = connection.Execute(sql, entity, null, timeout, CommandType.Text);
                        }
                    }
                    else
                    {
                        res = this.BaseDbTransaction.Connection.Execute(sql, entity, this.BaseDbTransaction, timeout, CommandType.Text);
                    }
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }

        /// <summary>
        /// 根据条件以及指定属性名称更新
        /// </summary>
        /// <typeparam name="T">动态对象</typeparam>
        /// <param name="entity">待更新实体</param>
        /// <param name="condition">筛选条件</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public int Update<T>(object entity, Expression<Func<T, bool>> condition, int? timeout = Timeout) where T : class
        {
            int res = 0;
            this.Logger(this.GetType(), "根据条件以及指定属性名称更新-Update", () =>
            {
                if (entity != null)
                {
                    LambdaExpConditions<T> lambda = new LambdaExpConditions<T>();
                    lambda.AddAndWhere(condition);
                    string where = lambda.Where();
                    string sql = DatabaseCommon.UpdateSql<T>(entity, "", where).ToString();

                    if (this.BaseDbTransaction == null)
                    {
                        using (IDbConnection connection = this.BaseDbConnection)
                        {
                            res = connection.Execute(sql, entity, null, timeout, CommandType.Text);
                        }
                    }
                    else
                    {
                        res = this.BaseDbTransaction.Connection.Execute(sql, entity, this.BaseDbTransaction, timeout, CommandType.Text);
                    }
                }
            }, e =>
            {
                this.Rollback();
            });
            return res;
        }
    }
}
