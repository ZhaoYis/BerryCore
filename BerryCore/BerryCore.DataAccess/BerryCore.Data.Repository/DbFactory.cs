#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data.Repository
* 项目描述 ：
* 类 名 称 ：DbFactory
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data.Repository
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 21:50:01
* 更新时间 ：2019/5/3 21:50:01
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using BerryCore.IOC;
using BerryCore.Log;
using BerryCore.Utilities;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.Remoting.Messaging;

namespace BerryCore.Data.Repository
{
    /// <summary>
    /// 功能描述    ：数据库建立工厂  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 21:50:01 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 21:50:01 
    /// </summary>
    public class DbFactory : BaseLogger
    {
        /// <summary>
        /// 默认连接字符串配置项名称
        /// </summary>
        private const string BaseConnStringName = "MsSqlBaseDbConnectionString";
        /// <summary>
        /// IDatabase实现类的构造函数参数名
        /// </summary>
        private const string BaseParameterName = "connStringName";

        /// <summary>
        /// 连接基础库，默认
        /// </summary>
        /// <returns></returns>
        public IDatabase Base()
        {
            string cacheKey = string.Format("{0}:{1}", this.GetType().Name, string.Format("{0}_{1}", BaseConnStringName, BaseParameterName).GetMd5Code());
            IDatabase database = CallContext.GetData(cacheKey) as IDatabase;
            this.Logger(typeof(DbFactory), "连接基础库，默认-Base", () =>
            {
                if (database == null)
                {
                    UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                    //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                    ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, BaseConnStringName);

                    string mapToName = UnityIocHelper.GetmapToByName("DbContainer", "DatabaseType");
                    DatabaseType dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), mapToName, true);
                    DbTypeContainer.DbType = dbType;

                    database = helper.GetService<IDatabase>(parm);
                }
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 连接数据库，带参
        /// </summary>
        /// <param name="connStringName">连接字符串配置项名称</param>
        /// <returns></returns>
        public IDatabase Base(string connStringName)
        {
            string cacheKey = string.Format("{0}:{1}", this.GetType().Name, string.Format("{0}_{1}", connStringName, BaseParameterName).GetMd5Code());
            IDatabase database = CallContext.GetData(cacheKey) as IDatabase;
            this.Logger(typeof(DbFactory), "连接数据库，带参-Base", () =>
            {
                if (database == null)
                {
                    UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                    //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                    ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, connStringName);

                    string mapToName = UnityIocHelper.GetmapToByName("DbContainer", "DatabaseType");
                    DatabaseType dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), mapToName, true);
                    DbTypeContainer.DbType = dbType;

                    database = helper.GetService<IDatabase>(parm);
                }
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 连接数据库，带参
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <returns></returns>
        public IDatabase Base(DatabaseType dbType)
        {
            string cacheKey = string.Format("{0}:{1}", this.GetType().Name, string.Format("{0}_{1}_{2}", BaseConnStringName, BaseParameterName, dbType.ToString()).GetMd5Code());
            IDatabase database = CallContext.GetData(cacheKey) as IDatabase;
            this.Logger(typeof(DbFactory), "连接数据库，带参-Base", () =>
            {
                if (database == null)
                {
                    UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                    //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                    ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, BaseConnStringName);

                    DbTypeContainer.DbType = dbType;

                    database = helper.GetService<IDatabase>(parm);
                }
            }, e =>
            {

            });
            return database;
        }

        /// <summary>
        /// 连接数据库，带参
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connStringName">连接字符串配置项名称</param>
        /// <returns></returns>
        public IDatabase Base(DatabaseType dbType, string connStringName)
        {
            string cacheKey = string.Format("{0}:{1}", this.GetType().Name, string.Format("{0}_{1}_{2}", connStringName, BaseParameterName, dbType.ToString()).GetMd5Code());
            IDatabase database = CallContext.GetData(cacheKey) as IDatabase;
            this.Logger(typeof(DbFactory), "连接数据库，带参-Base", () =>
            {
                if (database == null)
                {
                    UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                    //特别注意：此处的 connStringName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                    ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, connStringName);

                    DbTypeContainer.DbType = dbType;

                    database = helper.GetService<IDatabase>(parm);
                }
            }, e =>
            {

            });
            return database;
        }

    }
}
