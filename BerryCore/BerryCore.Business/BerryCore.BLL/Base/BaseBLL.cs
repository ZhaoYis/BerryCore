#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.BLL.Base
* 项目描述 ：
* 类 名 称 ：BaseBLL
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.BLL.Base
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 11:45:46
* 更新时间 ：2019/5/4 11:45:46
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.Entity.Base;
using BerryCore.IBLL.Base;
using BerryCore.IService.Base;
using BerryCore.Service.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace BerryCore.BLL.Base
{
    /// <summary>
    /// 功能描述    ：BaseBLL  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 11:45:46 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 11:45:46 
    /// </summary>
    public class BaseBLL : IBaseBLL
    {
        /// <summary>
        /// 通用操作
        /// </summary>
        private IBaseService service = new BaseService();

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity">待添加实体</param>
        /// <returns></returns>
        public int Add<T>(T entity) where T : class, new()
        {
            return service.Add(entity);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys">待添加实体集合</param>
        /// <returns></returns>
        public int AddList<T>(List<T> entitys) where T : class, new()
        {
            return service.AddList(entitys);
        }

        /// <summary>
        /// 根据条件获取一条记录
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public T GetEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return service.GetEntity(condition);
        }

        /// <summary>
        /// 根据条件获取多条记录
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return service.GetList(condition);
        }

        /// <summary>
        /// 删除表所有数据
        /// </summary>
        /// <returns></returns>
        public int Delete<T>() where T : class, new()
        {
            return service.Delete<T>();
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return service.Delete(condition);
        }

        /// <summary>
        /// 根据条件更新
        /// </summary>
        /// <param name="entity">要修改的列及修改后列的值集合</param>
        /// <param name="condition">筛选条件</param>
        /// <returns>返回受影响行数</returns>
        public int Update<T>(T entity, Expression<Func<T, bool>> condition) where T : class, new()
        {
            return service.Update(entity, condition);
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql)
        {
            return service.ExecuteBySql(strSql);
        }

        /// <summary>
        /// 执行T-SQL
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteBySql(string strSql, object parameters)
        {
            return service.ExecuteBySql(strSql, parameters);
        }

        /// <summary>
        /// 执行T-SQL并返回集合
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public IEnumerable<TR> ExecuteBySqlAndReturnList<TR>(string strSql, object parameters) where TR : class, new()
        {
            return service.ExecuteBySqlAndReturnList<TR>(strSql, parameters);
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
            return service.ExecuteBySqlAndReturnObject<TR>(strSql, parameters);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName)
        {
            return service.ExecuteByProc(procName);
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public int ExecuteByProc(string procName, object parameters)
        {
            return service.ExecuteByProc(procName, parameters);
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
            return service.ExecuteByProc<TR>(procName, parameters);
        }

        /// <summary>
        /// 根据条件查询一个DataTable
        /// </summary>
        /// <typeparam name="TR"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">筛选条件</param>
        /// <returns></returns>
        public DataTable FindTable<TR, T>(Expression<Func<T, bool>> condition) where TR : class, new() where T : class, new()
        {
            return service.FindTable<TR, T>(condition);
        }

        /// <summary>
        /// 查询一个DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, object parameters)
        {
            return service.FindTable(strSql, parameters);
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
            return service.FindTable(strSql, parameters, pagination);
        }

        /// <summary>
        /// 获取分页DataTable
        /// </summary>
        /// <param name="strSql">T-SQL语句</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable FindTable(string strSql, Pagination pagination)
        {
            return service.FindTable(strSql, pagination);
        }

        /// <summary>
        /// 根据条件获取分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">筛选条件</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public IEnumerable<T> FindList<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new()
        {
            return service.FindList(condition, pagination);
        }
    }
}
