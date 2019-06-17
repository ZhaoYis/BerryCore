#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Data.Repository
* 项目描述 ：
* 类 名 称 ：DbFactory
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Data.Repository
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-04 17:09:06
* 更新时间 ：2019-06-04 17:09:06
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Runtime.Remoting.Messaging;
using BerryCore.IOC;
using BerryCore.Log;
using BerryCore.Utilities;
using Microsoft.Practices.Unity;

namespace BerryCore.Data.Repository
{
    /// <summary>
    /// 功能描述    ：数据库建立工厂  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-04 17:09:06 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-04 17:09:06 
    /// </summary>
    public class DbFactory : BaseLogger
    {
        /// <summary>
        /// 默认连接字符串配置项名称
        /// </summary>
        private const string BaseMsSqlConnStringConfigName = "MsSqlBaseDbConnectionString";
        /// <summary>
        /// IDatabase实现类的构造函数参数名（不要更改，需要修改的话每个IDatabase具体实现的构造函数的参数名称都需要修改）
        /// </summary>
        private const string BaseParameterName = "connConfigName";

        /// <summary>
        /// 获取默认连接字符串配置项名称
        /// </summary>
        /// <param name="type">数据库类型</param>
        /// <returns></returns>
        [Obsolete]
        public string GetDefaultBaseConnStringConfigName(DatabaseType type)
        {
            switch (type)
            {
                case DatabaseType.SqlServer:
                    return BaseMsSqlConnStringConfigName;
                case DatabaseType.MySql:
                    return "";
                case DatabaseType.Oracle:
                    return "";
                case DatabaseType.SQLite:
                    return "SQLiteBaseDbConnectionString";
                default:
                    return BaseMsSqlConnStringConfigName;
            }
        }

        /// <summary>
        /// 动态计算出当前需要使用哪一个数据库
        /// </summary>
        /// <returns></returns>
        public string GetUsedDbConfigKey()
        {
            //string res = string.Empty;
            //string keyList = ConfigHelper.GetValue("DbConnectionKeyList");
            //if (!string.IsNullOrEmpty(keyList))
            //{
            //    List<string> list = keyList.Split(';').ToList();

            //}
            //else
            //{
            //    res = BaseMsSqlConnStringConfigName;
            //}
            //return res;

            //TODO 后续进行调整
            return BaseMsSqlConnStringConfigName;
        }

        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="connConfigName">连接字符串配置项名称</param>
        /// <returns></returns>
        public IDatabase GetDatabase(string connConfigName)
        {
            string cacheKey = string.Format("{0}:{1}", this.GetType().Name, string.Format("{0}_{1}", connConfigName, BaseParameterName).GetMd5Code());
            IDatabase database = CallContext.GetData(cacheKey) as IDatabase;
            this.Logger(typeof(DbFactory), "连接数据库，带参-GetDatabase", () =>
            {
                if (database == null)
                {
                    UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                    //特别注意：此处的 connConfigName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                    ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, connConfigName);

                    string mapToName = UnityIocHelper.GetMapToValue("DbContainer", "DatabaseType");
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
        /// 连接数据库
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connConfigName">连接字符串配置项名称</param>
        /// <returns></returns>
        public IDatabase GetDatabase(DatabaseType dbType, string connConfigName)
        {
            string cacheKey = string.Format("{0}:{1}", this.GetType().Name, string.Format("{0}_{1}_{2}", connConfigName, BaseParameterName, dbType.ToString()).GetMd5Code());
            IDatabase database = CallContext.GetData(cacheKey) as IDatabase;
            this.Logger(typeof(DbFactory), "连接数据库，带参-GetDatabase", () =>
            {
                if (database == null)
                {
                    UnityIocHelper helper = UnityIocHelper.UnityIocInstance;
                    //特别注意：此处的 connConfigName 参数名称必须与IDatabase实现类的构造函数参数名称一致
                    ResolverOverride parm = UnityIocHelper.GetParameterOverride(BaseParameterName, connConfigName);

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
