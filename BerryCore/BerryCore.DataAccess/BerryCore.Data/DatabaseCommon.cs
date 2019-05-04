#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data
* 项目描述 ：
* 类 名 称 ：DatabaseCommon
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 22:25:23
* 更新时间 ：2019/5/3 22:25:23
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;
using System.Text;

namespace BerryCore.Data
{
    /// <summary>
    /// 功能描述    ：组装增删查改T-SQL语句  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 22:25:23 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 22:25:23 
    /// </summary>
    public static class DatabaseCommon
    {
        #region 拼接 Insert SQL语句

        /// <summary>
        /// 哈希表生成Insert语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">Hashtable</param>
        /// <returns>int</returns>
        public static StringBuilder InsertSql(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(tableName);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sbPrame = new StringBuilder();
            foreach (string key in ht.Keys)
            {
                if (ht[key] != null)
                {
                    sbPrame.Append(",[" + key + "]");
                    sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + key);
                }
            }
            sb.Append(sbPrame.ToString().Substring(1, sbPrame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成InsertSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>int</returns>
        public static StringBuilder InsertSql<T>(T entity)
        {
            Type type = entity.GetType();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            //获取不做映射的字段
            List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<T>();

            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(table);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sbPrame = new StringBuilder();
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (!notMappedField.Contains(prop.Name))
                {
                    object value = prop.GetValue(entity, null);
                    if (value != null)
                    {
                        if (value.GetType() == typeof(DateTime))
                        {
                            var time = (DateTime)value;
                            if (time.Ticks != 0 && time != DateTime.MinValue && time != SqlDateTime.MinValue.Value)
                            {
                                sbPrame.Append(",[" + prop.Name + "]");
                                sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + (prop.Name));
                            }
                        }
                        else
                        {
                            sbPrame.Append(",[" + prop.Name + "]");
                            sp.Append("," + DbParameters.CreateDbParmCharacter() + "" + (prop.Name));
                        }
                    }
                }
            }
            sb.Append(sbPrame.ToString().Substring(1, sbPrame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return sb;
        }

        #endregion 拼接 Insert SQL语句

        #region 拼接 Update SQL语句

        /// <summary>
        /// 哈希表生成UpdateSql语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">Hashtable</param>
        /// <param name="pkName">主键</param>
        /// <returns></returns>
        public static StringBuilder UpdateSql(string tableName, Hashtable ht, string pkName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Update ");
            sb.Append(tableName);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (string key in ht.Keys)
            {
                if (ht[key] != null && pkName != key)
                {
                    if (isFirstValue)
                    {
                        isFirstValue = false;
                        sb.Append("[" + key + "]");
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + key);
                    }
                    else
                    {
                        sb.Append(",[" + key + "]");
                        sb.Append("=");
                        sb.Append(DbParameters.CreateDbParmCharacter() + key);
                    }
                }
            }
            sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成UpdateSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <param name="pkName">主键</param>
        /// <param name="where">自定义条件</param>
        /// <returns>int</returns>
        public static StringBuilder UpdateSql<T>(T entity, string pkName = "", string where = "")
        {
            Type type = entity.GetType();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            //主键
            string keyField = EntityAttributeHelper.GetEntityKey<T>();
            //获取不做映射的字段
            List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<T>();

            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder();

            sb.Append(" Update ");
            sb.Append(table);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (PropertyInfo prop in props)
            {
                if (!notMappedField.Contains(prop.Name))
                {
                    object value = prop.GetValue(entity, null);
                    if (value != null && keyField != prop.Name)
                    {
                        if (value.GetType() == typeof(DateTime))
                        {
                            var time = (DateTime)value;
                            if (time.Ticks != 0 && time != DateTime.MinValue && time != SqlDateTime.MinValue.Value)
                            {
                                if (isFirstValue)
                                {
                                    isFirstValue = false;
                                    sb.Append("[" + prop.Name + "]");
                                    sb.Append("=");
                                    sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                                }
                                else
                                {
                                    sb.Append(",[" + prop.Name + "]");
                                    sb.Append("=");
                                    sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                                }
                            }
                        }
                        else
                        {
                            if (isFirstValue)
                            {
                                isFirstValue = false;
                                sb.Append("[" + prop.Name + "]");
                                sb.Append("=");
                                sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                            }
                            else
                            {
                                sb.Append(",[" + prop.Name + "]");
                                sb.Append("=");
                                sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(pkName))
            {
                sb.Append(" Where ").Append(pkName).Append("=").Append(DbParameters.CreateDbParmCharacter() + pkName);
            }
            else if (!string.IsNullOrEmpty(where))
            {
                sb.Append(" " + where);
            }
            return sb;
        }

        /// <summary>
        /// 泛型方法，反射生成UpdateSql语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>int</returns>
        public static StringBuilder UpdateSql<T>(T entity)
        {
            Type type = entity.GetType();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            //主键
            string keyField = EntityAttributeHelper.GetEntityKey<T>();
            //获取不做映射的字段
            List<string> notMappedField = EntityAttributeHelper.GetNotMappedFields<T>();

            PropertyInfo[] props = type.GetProperties();
            StringBuilder sb = new StringBuilder();

            sb.Append("Update ");
            sb.Append(table);
            sb.Append(" Set ");
            bool isFirstValue = true;
            foreach (PropertyInfo prop in props)
            {
                if (!notMappedField.Contains(prop.Name))
                {
                    object value = prop.GetValue(entity, null);
                    if (value != null && keyField != prop.Name)
                    {
                        if (value.GetType() == typeof(DateTime))
                        {
                            var time = (DateTime)value;
                            if (time.Ticks != 0 && time != DateTime.MinValue && time != SqlDateTime.MinValue.Value)
                            {
                                if (isFirstValue)
                                {
                                    isFirstValue = false;
                                    sb.Append("[" + prop.Name + "]");
                                    sb.Append("=");
                                    sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                                }
                                else
                                {
                                    sb.Append(",[" + prop.Name + "]");
                                    sb.Append("=");
                                    sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                                }
                            }
                        }
                        else
                        {
                            if (isFirstValue)
                            {
                                isFirstValue = false;
                                sb.Append("[" + prop.Name + "]");
                                sb.Append("=");
                                sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                            }
                            else
                            {
                                sb.Append(",[" + prop.Name + "]");
                                sb.Append("=");
                                sb.Append(DbParameters.CreateDbParmCharacter() + prop.Name);
                            }
                        }
                    }
                }
            }
            sb.Append(" Where ").Append(keyField).Append("=").Append(DbParameters.CreateDbParmCharacter() + keyField);
            return sb;
        }

        #endregion 拼接 Update SQL语句

        #region 拼接 Delete SQL语句

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName)
        {
            return new StringBuilder("Delete From " + tableName);
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="where">删除条件</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql<T>(string where)
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            if (string.IsNullOrWhiteSpace(where))
            {
                where = "1 = 1";
            }

            return new StringBuilder("Delete From " + table + " " + where);
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="pkName">字段主键</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName, string pkName)
        {
            return new StringBuilder("Delete From " + tableName + " Where " + pkName + " = " + DbParameters.CreateDbParmCharacter() + pkName + "");
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="ht">多参数</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder("Delete From " + tableName + " Where 1=1");
            foreach (string key in ht.Keys)
            {
                sb.Append(" AND " + key + " = " + DbParameters.CreateDbParmCharacter() + "" + key + "");
            }
            return sb;
        }

        /// <summary>
        /// 拼接删除SQL语句
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static StringBuilder DeleteSql<T>(T entity)
        {
            Type type = entity.GetType();
            PropertyInfo[] props = type.GetProperties();
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            StringBuilder sb = new StringBuilder("Delete From " + table + " Where 1=1");
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(entity, null) != null)
                {
                    sb.Append(" AND " + prop.Name + " = " + DbParameters.CreateDbParmCharacter() + "" + prop.Name + "");
                }
            }
            return sb;
        }

        #endregion 拼接 Delete SQL语句

        #region 拼接 Select SQL语句

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>() where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            PropertyInfo[] props = EntityAttributeHelper.GetProperties(typeof(T));
            StringBuilder sbColumns = new StringBuilder();

            foreach (PropertyInfo prop in props)
            {
                //string propertytype = prop.PropertyType.ToString();
                sbColumns.Append(prop.Name + ",");
            }

            if (sbColumns.Length > 0)
            {
                sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            }

            string strSql = string.Format("SELECT {0} FROM {1} WHERE 1=1 ", sbColumns, table);
            return new StringBuilder(strSql);
        }

        /// <summary>
        /// 拼接 查询 SQL语句，自定义条件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <param name="allFieid">是否查询所有字段</param>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>(string where, bool allFieid = false) where T : class
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            PropertyInfo[] props = EntityAttributeHelper.GetProperties(typeof(T));
            StringBuilder sbColumns = new StringBuilder();
            if (allFieid)
            {
                sbColumns.Append(" * ");
            }
            else
            {
                foreach (PropertyInfo prop in props)
                {
                    //string propertytype = prop.PropertyType.ToString();
                    sbColumns.Append("[" + prop.Name + "],");
                }
                if (sbColumns.Length > 0)
                {
                    sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
                }
            }

            if (string.IsNullOrWhiteSpace(where))
            {
                where = " WHERE 1 = 1";
            }

            string strSql = string.Format("SELECT {0} FROM {1} {2}", sbColumns.ToString(), table, where);
            return new StringBuilder(strSql);
        }

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="top">显示条数</param>
        /// <returns></returns>
        public static StringBuilder SelectSql<T>(int top) where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            PropertyInfo[] props = EntityAttributeHelper.GetProperties(typeof(T));
            StringBuilder sbColumns = new StringBuilder();
            foreach (PropertyInfo prop in props)
            {
                sbColumns.Append(prop.Name + ",");
            }
            if (sbColumns.Length > 0)
            {
                sbColumns.Remove(sbColumns.ToString().Length - 1, 1);
            }

            string strSql = string.Format("SELECT TOP {0} {1} FROM {2} WHERE 1=1 ", top, sbColumns.ToString(), table);
            return new StringBuilder(strSql);
        }

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static StringBuilder SelectSql(string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1 ");
            return strSql;
        }

        /// <summary>
        /// 拼接 查询 SQL语句
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="top">显示条数</param>
        /// <returns></returns>
        public static StringBuilder SelectSql(string tableName, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP " + top + " * FROM " + tableName + " WHERE 1=1 ");
            return strSql;
        }

        /// <summary>
        /// 拼接 查询条数 SQL语句
        /// </summary>
        /// <returns></returns>
        public static StringBuilder SelectCountSql<T>() where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            return new StringBuilder("SELECT Count(1) FROM " + table + " WHERE 1=1 ");
        }

        /// <summary>
        /// 拼接 查询条数 SQL语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public static StringBuilder SelectCountSql<T>(string where) where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();
            if (!string.IsNullOrEmpty(where))
            {
                if (!where.ToLower().Contains("where"))
                {
                    where = " WHERE " + where;
                }
            }
            return new StringBuilder("SELECT Count(1) FROM " + table + " " + where);
        }

        /// <summary>
        /// 拼接 查询最大数 SQL语句
        /// </summary>
        /// <param name="propertyName">属性字段</param>
        /// <returns></returns>
        public static StringBuilder SelectMaxSql<T>(string propertyName) where T : new()
        {
            //表名
            string table = EntityAttributeHelper.GetEntityTable<T>();

            return new StringBuilder("SELECT MAX(" + propertyName + ") FROM " + table + "  WHERE 1=1 ");
        }

        #endregion 拼接 Select SQL语句
    }
}
