#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Service.Base
* 项目描述 ：
* 类 名 称 ：BaseService
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Service.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 9:27:15
* 更新时间 ：2019/5/4 9:27:15
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Data.Repository;
using BerryCore.Entity.Base;
using BerryCore.IService.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BerryCore.Service.Base
{
    /// <summary>
    /// 功能描述    ：BaseService  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 9:27:15 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 9:27:15 
    /// </summary>
    public class BaseService<T> : RepositoryFactory<T>, IBaseService<T> where T : class, new()
    {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加实体</param>
        /// <returns></returns>
        public int Add(T entity)
        {
            int res = 0;
            this.Logger(this.GetType(), "Add-添加一条记录", () =>
            {
                if (entity != null)
                {
                    res = this.UseTransaction<int>((repository) =>
                    {
                        return repository.Insert(entity);
                    });
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys">待添加实体集合</param>
        /// <returns></returns>
        public int AddList(List<T> entitys)
        {
            int res = 0;
            this.Logger(this.GetType(), "AddList-批量添加", () =>
            {
                if (entitys != null && entitys.Count > 0)
                {
                    res = this.UseTransaction<int>((repository) =>
                    {
                        return repository.BatchInsert(entitys);
                    });
                }
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件获取一条记录
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public T GetEntity(Expression<Func<T, bool>> condition)
        {
            T res = default(T);
            this.Logger(this.GetType(), "GetEntity-根据条件获取一条记录", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindEntity(condition);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件获取多条记录
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public IEnumerable<T> GetList(Expression<Func<T, bool>> condition)
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            this.Logger(this.GetType(), "GetEntity-根据条件获取一条记录", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindList(condition);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 删除表所有数据
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            int res = 0;
            this.Logger(this.GetType(), "Delete-删除表所有数据", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.Delete();
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> condition)
        {
            int res = 0;
            this.Logger(this.GetType(), "Delete-根据条件删除数据", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.Delete(condition);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="entity">要修改的列及修改后列的值集合</param>
        /// <param name="condition">筛选条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update(object entity, Expression<Func<T, bool>> condition)
        {
            int res = 0;
            this.Logger(this.GetType(), "Update-根据条件更新", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.Update(entity, condition);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行T-SQL语句
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            int res = 0;
            this.Logger(this.GetType(), "ExecuteBySql-执行T-SQL语句", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteBySql(strSql);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, object parameters)
        {
            int res = 0;
            this.Logger(this.GetType(), "ExecuteBySql-执行T-SQL语句", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteBySql(strSql, parameters);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行T-SQL语句并返回集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters) where TR : class, new()
        {
            IEnumerable<TR> res = default(IEnumerable<TR>);
            this.Logger(this.GetType(), "ExecuteBySqlAndReturnList-执行T-SQL语句并返回集合", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteBySqlAndReturnList<TR>(strSql, parameters);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行 SQL 语句返回对象
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public TR ExecuteBySqlAndReturnObject<TR>(string strSql, object parameters) where TR : class, new()
        {
            TR res = default(TR);
            this.Logger(this.GetType(), "ExecuteBySqlAndReturnObject-执行T-SQL语句返回对象", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteBySqlAndReturnObject<TR>(strSql, parameters);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
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
            int res = 0;
            this.Logger(this.GetType(), "ExecuteByProc-执行存储过程", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteByProc(procName);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, object parameters)
        {
            int res = 0;
            this.Logger(this.GetType(), "ExecuteByProc-执行存储过程", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteByProc(procName, parameters);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 执行存储过程，返回集合
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteByProc<TR>(string procName, object parameters) where TR : class, new()
        {
            IEnumerable<TR> res = default(IEnumerable<TR>);
            this.Logger(this.GetType(), "ExecuteByProc-执行存储过程，返回集合", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.ExecuteByProc<TR>(procName, parameters);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public DataTable FindTable<TR>(Expression<Func<T, bool>> condition) where TR : class, new()
        {
            DataTable res = new DataTable(typeof(TR).Name);
            this.Logger(this.GetType(), "FindTable-根据条件查询一个DataTable", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindTable(condition);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters)
        {
            DataTable res = new DataTable("DefaultTable");
            this.Logger(this.GetType(), "FindTable-查询一个DataTable", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindTable(strSql, parameters);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
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
            DataTable res = new DataTable("DefaultPageTable");
            this.Logger(this.GetType(), "FindTable-获取分页DataTable", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindTable(strSql, parameters, pagination);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, Pagination pagination)
        {
            DataTable res = new DataTable("DefaultPageTable");
            this.Logger(this.GetType(), "FindTable-获取分页DataTable", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindTable(strSql, pagination);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList(Expression<Func<T, bool>> condition, Pagination pagination)
        {
            IEnumerable<T> res = default(IEnumerable<T>);
            this.Logger(this.GetType(), "FindList-根据条件获取分页数据", () =>
            {
                this.UseTransaction((repository) =>
                {
                    res = repository.FindList(condition, pagination);
                });
            }, e =>
            {
                Trace.WriteLine(e.Message);
            });
            return res;
        }
    }
}
