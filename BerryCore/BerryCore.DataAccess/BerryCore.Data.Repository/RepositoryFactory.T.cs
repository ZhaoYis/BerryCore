#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data.Repository
* 项目描述 ：
* 类 名 称 ：RepositoryFactory
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data.Repository
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 21:48:36
* 更新时间 ：2019/5/3 21:48:36
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion


using BerryCore.Log;
using System;

namespace BerryCore.Data.Repository
{
    /// <summary>
    /// 功能描述    ：仓储模型工厂  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 21:48:36 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 21:48:36 
    /// </summary>
    public class RepositoryFactory<T> : BaseLogger where T : class, new()
    {
        private static readonly DbFactory dbFactory = new DbFactory();

        /// <summary>
        /// 定义仓储（默认适用MSSQL的基础库）
        /// </summary>
        /// <param name="databaseType">数据库类型，默认SqlServer数据库</param>
        /// <param name="connConfigName">连接字符串配置项名称</param>
        /// <returns></returns>
        [Obsolete("建议不用这个方法，不能灵活指定数据库类型，请使用重载方法BaseRepository(string connConfigName)")]
        private IRepository<T> BaseRepository(DatabaseType databaseType, string connConfigName = "")
        {
            if (string.IsNullOrEmpty(connConfigName))
            {
                connConfigName = dbFactory.GetDefaultBaseConnStringConfigName(databaseType);
            }
            return new Repository<T>(dbFactory.GetDatabase(databaseType, connConfigName));
        }

        /// <summary>
        /// 定义仓储
        /// </summary>
        /// <param name="connConfigName">连接字符串配置项名称</param>
        /// <returns></returns>
        private IRepository<T> BaseRepository(string connConfigName)
        {
            return new Repository<T>(dbFactory.GetDatabase(connConfigName));
        }

        #region 扩展操作方法

        /// <summary>
        /// 使用数据库事务，无返回值
        /// </summary>
        /// <param name="action"></param>
        protected virtual void UseTransaction(Action<IRepository<T>> action)
        {
            this.Logger(this.GetType(), "使用数据库事务，无返回值-UseTransaction", () =>
            {
                IRepository<T> repository = this.BaseRepository(dbFactory.GetUsedDbConfigKey()).BeginTrans();

                action.Invoke(repository);

                repository.Commit();
            }, e =>
            {

            });
        }

        /// <summary>
        /// 不使用数据库事务，无返回值
        /// </summary>
        /// <param name="action"></param>
        protected virtual void NotUseTransaction(Action<IRepository<T>> action)
        {
            this.Logger(this.GetType(), "不使用数据库事务，无返回值-NotUseTransaction", () =>
            {
                IRepository<T> repository = this.BaseRepository(dbFactory.GetUsedDbConfigKey()).Instance();

                action.Invoke(repository);

            }, e =>
            {

            });
        }

        /// <summary>
        /// 使用数据库事务，有返回值
        /// </summary>
        /// <param name="action"></param>
        protected virtual TR UseTransaction<TR>(Func<IRepository<T>, TR> action)
        {
            TR res = default(TR);
            this.Logger(this.GetType(), "使用数据库事务，有返回值-UseTransaction", () =>
            {
                IRepository<T> repository = this.BaseRepository(dbFactory.GetUsedDbConfigKey()).BeginTrans();

                res = action.Invoke(repository);

                repository.Commit();
            }, e =>
            {

            });
            return res;
        }

        /// <summary>
        /// 不使用数据库事务，有返回值
        /// </summary>
        /// <param name="action"></param>
        protected virtual TR NotUseTransaction<TR>(Func<IRepository<T>, TR> action)
        {
            TR res = default(TR);
            this.Logger(this.GetType(), "不使用数据库事务，有返回值-NotUseTransaction", () =>
            {
                IRepository<T> repository = this.BaseRepository(dbFactory.GetUsedDbConfigKey()).Instance();

                res = action.Invoke(repository);

            }, e =>
            {

            });
            return res;
        }

        #endregion

    }
}
