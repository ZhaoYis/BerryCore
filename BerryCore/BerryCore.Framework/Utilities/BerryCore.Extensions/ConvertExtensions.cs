#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Extensions
* 项目描述 ：
* 类 名 称 ：ConvertExtensions
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Extensions
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/4 8:40:33
* 更新时间 ：2019/5/4 8:40:33
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection;
using System.Text;
using System.Xml;

namespace BerryCore.Extensions
{
    /// <summary>
    /// 功能描述    ：类型转换扩展  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/4 8:40:33 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/4 8:40:33 
    /// </summary>
    public static class ConvertExtensions
    {
        #region 将XML内容转换成目标对象实体集合

        /// <summary>
        /// 将XML内容转换成目标对象实体集合
        /// </summary>
        /// <typeparam name="T">目标对象实体</typeparam>
        /// <param name="doc">XML文档对象</param>
        /// <param name="rootNodeName">根节点名称</param>
        /// <returns></returns>
        public static List<T> ConvertXmlToObject<T>(this XmlDocument doc, string rootNodeName)
        {
            List<T> result = new List<T>();

            Type type = typeof(T);
            XmlNodeList nodeList = doc.ChildNodes;
            if (!string.IsNullOrEmpty(rootNodeName))
            {
                foreach (XmlNode node in doc.ChildNodes)
                {
                    if (node.Name != rootNodeName)
                    {
                        continue;
                    }

                    nodeList = node.ChildNodes;
                    break;
                }
            }

            object obj = null;
            foreach (XmlNode node in nodeList)
            {
                if (node.NodeType == XmlNodeType.Comment || node.NodeType == XmlNodeType.XmlDeclaration)
                {
                    continue;
                }

                if (type.FullName != null)
                {
                    obj = type.Assembly.CreateInstance(type.FullName);
                }

                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.NodeType == XmlNodeType.Comment)
                    {
                        continue;
                    }

                    PropertyInfo property = type.GetProperty(item.Name);
                    if (property != null)
                    {
                        property.SetValue(obj, Convert.ChangeType(item.InnerText, property.PropertyType), null);
                    }
                }
                result.Add((T)obj);
            }
            return result;
        }

        #endregion

        #region 数据类型转换扩展方法

        /// <summary>
        /// object 转换成string 包括为空的情况
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>返回值不含空格</returns>
        public static string ToStringEx(this object obj)
        {
            return obj == null ? string.Empty : obj.ToString().Trim();
        }

        /// <summary>
        /// 时间object 转换成格式化的string 包括为空的情况
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format"></param>
        /// <returns>返回值不含空格</returns>
        public static string TryToDateTimeToString(this object obj, string format)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            DateTime dt;
            if (DateTime.TryParse(obj.ToString(), out dt))
            {
                return dt.ToString(format);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 字符转Int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>成功:返回对应Int值;失败:返回0</returns>
        public static int TryToInt32(this object obj)
        {
            int rel = 0;

            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                int.TryParse(obj.ToStringEx(), out rel);
            }
            return rel;
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int? TryToInt32OrNull(this object data)
        {
            if (data == null)
            {
                return null;
            }

            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 字符转Int64
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Int64 TryToInt64(this object obj)
        {
            Int64 rel = 0;
            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                Int64.TryParse(obj.ToStringEx(), out rel);
            }
            return rel;
        }

        /// <summary>
        /// 字符转DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>成功:返回对应Int值;失败:时间初始值</returns>
        public static DateTime TryToDateTime(this object obj)
        {
            DateTime rel = new DateTime();
            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                DateTime.TryParse(obj.ToStringEx(), out rel);
            }
            return rel;
        }

        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double TryToDouble(this object data)
        {
            if (data == null)
            {
                return 0;
            }

            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static double TryToDouble(this object data, int digits)
        {
            return Math.Round(TryToDouble(data), digits);
        }

        /// <summary>
        /// 转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double? TryToDoubleOrNull(this object data)
        {
            if (data == null)
            {
                return null;
            }

            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 转换为高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal TryToDecimal(this object data)
        {
            if (data == null)
            {
                return 0;
            }

            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal TryToDecimal(this object data, int digits)
        {
            return Math.Round(TryToDecimal(data), digits);
        }

        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? TryToDecimalOrNull(this object data)
        {
            if (data == null)
            {
                return null;
            }

            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? TryToDecimalOrNull(this object data, int digits)
        {
            var result = TryToDecimalOrNull(data);
            if (result == null)
            {
                return null;
            }

            return Math.Round(result.Value, digits);
        }

        /// <summary>
        /// 转成Char
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static char TryToChar(this object data)
        {
            if (data == null)
            {
                return new char();
            }

            return Convert.ToChar(data);
        }

        /// <summary>
        /// 转换成bool类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool TryToBoolean(this object obj)
        {
            bool rel = false;
            if (!string.IsNullOrEmpty(obj.ToStringEx()))
            {
                string s = obj.ToStringEx();

                if (s.Equals("true") || s.Equals("1") || s.Equals("是"))
                {
                    rel = true;
                }
                else
                {
                    bool.TryParse(obj.ToStringEx(), out rel);
                }
            }
            return rel;
        }

        #endregion 数据类型转换扩展方法

        #region 数据源转换

        #region DataTable转换成List集合

        /// <summary>
        /// DataTable转换成List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(this DataTable dt) where T : new()
        {
            // 定义集合
            List<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);

            // 获得此模型的公共属性
            PropertyInfo[] propertys = type.GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                foreach (PropertyInfo pi in propertys)
                {
                    string tempName = pi.Name;

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite)
                        {
                            continue;
                        }

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                ts.Add(t);
            }
            //return ts.CastTo<List<T>>();
            return ts;
        }

        #endregion DataTable转换成List集合

        #region DataTable转换成对象

        /// <summary>
        /// DataTable转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T DataTableToObject<T>(this DataTable dt) where T : new()
        {
            T t = new T();
            // 获得此模型的类型
            Type type = typeof(T);
            // 获得此模型的公共属性
            PropertyInfo[] propertys = type.GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                foreach (PropertyInfo pi in propertys)
                {
                    string tempName = pi.Name;

                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite)
                        {
                            continue;
                        }

                        object value = dr[tempName];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
            }
            return t;
        }

        #endregion DataTable转换成对象

        #region List转换DataTable

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="entitys">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(this List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }

        #endregion List转换DataTable

        #region IList转成List<T>

        /// <summary>
        /// IList转成List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> IListToList<T>(this IList list)
        {
            T[] array = new T[list.Count];
            list.CopyTo(array, 0);
            return new List<T>(array);
        }

        #endregion IList转成List<T>

        #region DataTable根据条件过滤表的内容

        /// <summary>
        /// 根据条件过滤表的内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static DataTable DataFilter(this DataTable dt, string condition)
        {
            if (IsExistRows(dt))
            {
                if (condition.Trim() == "")
                {
                    return dt;
                }
                else
                {
                    DataTable newdt = new DataTable();
                    newdt = dt.Clone();
                    DataRow[] dr = dt.Select(condition);
                    for (int i = 0; i < dr.Length; i++)
                    {
                        newdt.ImportRow(dr[i]);
                    }
                    return newdt;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件过滤表的内容
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition">条件</param>
        /// <param name="sort">排序字段</param>
        /// <returns></returns>
        public static DataTable DataFilter(this DataTable dt, string condition, string sort)
        {
            if (IsExistRows(dt))
            {
                DataTable newdt = dt.Clone();
                DataRow[] dr = dt.Select(condition, sort);
                for (int i = 0; i < dr.Length; i++)
                {
                    newdt.ImportRow(dr[i]);
                }
                return newdt;
            }
            else
            {
                return null;
            }
        }

        #endregion DataTable根据条件过滤表的内容

        #region 检查DataTable 是否有数据行

        /// <summary>
        /// 检查DataTable 是否有数据行
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static bool IsExistRows(this DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        #endregion 检查DataTable 是否有数据行

        #region DataTable 转 DataTableToHashtable

        /// <summary>
        /// DataTable 转 DataTableToHashtable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Hashtable DataTableToHashtable(this DataTable dt)
        {
            Hashtable ht = new Hashtable();
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string key = dt.Columns[i].ColumnName;
                    ht[key] = dr[key];
                }
            }
            return ht;
        }

        #endregion DataTable 转 DataTableToHashtable

        #region DataTable/DataSet 转 XML

        /// <summary>
        /// DataTable 转 XML
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToXml(this DataTable dt)
        {
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    System.IO.StringWriter writer = new System.IO.StringWriter();
                    dt.WriteXml(writer);
                    return writer.ToString();
                }
            }
            return String.Empty;
        }

        /// <summary>
        /// DataSet 转 XML
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string DataSetToXml(this DataSet ds)
        {
            if (ds != null)
            {
                System.IO.StringWriter writer = new System.IO.StringWriter();
                ds.WriteXml(writer);
                return writer.ToString();
            }
            return String.Empty;
        }

        #endregion DataTable/DataSet 转 XML

        #region DataRow  转  HashTable

        /// <summary>
        /// DataRow  转  HashTable
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Hashtable DataRowToHashTable(this DataRow dr)
        {
            Hashtable htReturn = new Hashtable(dr.ItemArray.Length);
            foreach (DataColumn dc in dr.Table.Columns)
            {
                htReturn.Add(dc.ColumnName, dr[dc.ColumnName]);
            }

            return htReturn;
        }

        #endregion DataRow  转  HashTable

        #region 使用指定字符集将string转换成byte[]

        /// <summary>
        /// 使用指定字符集将string转换成byte[]
        /// </summary>
        /// <param name="text">要转换的字符串</param>
        /// <param name="encoding">字符编码</param>
        public static byte[] StringToBytes(this string text, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding.GetBytes(text);
        }

        #endregion 使用指定字符集将string转换成byte[]

        #region 使用指定字符集将byte[]转换成string

        /// <summary>
        /// 使用指定字符集将byte[]转换成string
        /// </summary>
        /// <param name="bytes">要转换的字节数组</param>
        /// <param name="encoding">字符编码</param>
        public static string BytesToString(this byte[] bytes, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return encoding.GetString(bytes);
        }

        #endregion 使用指定字符集将byte[]转换成string

        #region 将byte[]转换成int

        /// <summary>
        /// 将byte[]转换成int
        /// </summary>
        /// <param name="data">需要转换成整数的byte数组</param>
        public static int BytesToInt32(this byte[] data)
        {
            //如果传入的字节数组长度小于4,则返回0
            if (data.Length < 4)
            {
                return 0;
            }

            //定义要返回的整数
            int num = 0;

            //如果传入的字节数组长度大于4,需要进行处理
            if (data.Length >= 4)
            {
                //创建一个临时缓冲区
                byte[] tempBuffer = new byte[4];

                //将传入的字节数组的前4个字节复制到临时缓冲区
                Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);

                //将临时缓冲区的值转换成整数，并赋给num
                num = BitConverter.ToInt32(tempBuffer, 0);
            }

            //返回整数
            return num;
        }

        #endregion 将byte[]转换成int

        #region IDataReader转换

        /// <summary>
        /// 将IDataReader转换为 集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static List<T> IDataReaderToList<T>(this IDataReader reader)
        {
            using (reader)
            {
                List<string> field = new List<string>(reader.FieldCount);
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    field.Add(reader.GetName(i).ToLower());
                }
                List<T> list = new List<T>();
                while (reader.Read())
                {
                    T model = Activator.CreateInstance<T>();
                    foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (field.Contains(property.Name.ToLower()))
                        {
                            if (!IsNullOrDbNull(reader[property.Name]))
                            {
                                property.SetValue(model, HackType(reader[property.Name], property.PropertyType), null);
                            }
                        }
                    }
                    list.Add(model);
                }
                reader.Close();
                reader.Dispose();
                return list;
            }
        }

        /// <summary>
        ///  将IDataReader转换为DataTable
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DataTable IDataReaderToDataTable(this IDataReader reader)
        {
            using (reader)
            {
                DataTable objDataTable = new DataTable("Table");
                int intFieldCount = reader.FieldCount;
                for (int intCounter = 0; intCounter < intFieldCount; ++intCounter)
                {
                    objDataTable.Columns.Add(reader.GetName(intCounter).ToLower(), reader.GetFieldType(intCounter));
                }
                objDataTable.BeginLoadData();
                object[] objValues = new object[intFieldCount];
                while (reader.Read())
                {
                    reader.GetValues(objValues);
                    objDataTable.LoadDataRow(objValues, true);
                }
                reader.Close();
                reader.Dispose();
                objDataTable.EndLoadData();
                return objDataTable;
            }
        }

        //这个类对可空类型进行判断转换，要不然会报错
        private static object HackType(object value, Type conversionType)
        {
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                System.ComponentModel.NullableConverter nullableConverter = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            //if (value is System.DateTime)
            //{
            //    value = Convert.ToDateTime(value).ToString("yyyyMMddHHmmss");
            //}
            return Convert.ChangeType(value, conversionType);
        }

        private static bool IsNullOrDbNull(object obj)
        {
            return ((obj is DBNull) || string.IsNullOrEmpty(obj.ToString())) ? true : false;
        }

        #endregion IDataReader转换

        #endregion 数据源转换

        #region 将对象属性转换为Key-Value键值对

        /// <summary>
        /// 将对象属性转换为Key-Value键值对
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Dictionary<string, object> Object2Dictionary(this object o)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            Type t = o.GetType();
            if (t.IsClass)
            {
                PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo p in pi)
                {
                    MethodInfo mi = p.GetGetMethod();

                    if (mi != null && mi.IsPublic)
                    {
                        map.Add(p.Name, mi.Invoke(o, new object[] { }));
                    }
                }
            }
            return map;
        }

        #endregion 将对象属性转换为Key-Value键值对

        #region 把对象类型转换成指定的类型，转化失败时返回指定默认值

        /// <summary>
        /// 把对象类型转换成指定的类型，转化失败时返回指定默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转换的原对象</param>
        /// <param name="detaultValue">转换失败时返回的默认值</param>
        /// <returns>转化后指定类型对象，转化失败时返回指定默认值</returns>
        public static T CastTo<T>(this object value, T detaultValue)
        {
            object result;
            Type t = typeof(T);
            try
            {
                result = t.IsEnum ? System.Enum.Parse(t, value.ToString()) : Convert.ChangeType(value, t);
            }
            catch (Exception)
            {
                return detaultValue;
            }

            return (T)result;
        }

        #endregion 把对象类型转换成指定的类型，转化失败时返回指定默认值

        #region 把对象类型转换成指定的类型，转化失败时返回类型默认值

        /// <summary>
        /// 把对象类型转换成指定的类型，转化失败时返回类型默认值
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转换的原对象</param>
        /// <returns>转化后指定类型对象，转化失败时返回类型默认值</returns>
        public static T CastTo<T>(this object value)
        {
            object result;
            Type t = typeof(T);
            try
            {
                if (t.IsEnum)
                {
                    result = System.Enum.Parse(t, value.ToString());
                }
                else if (t == typeof(Guid))
                {
                    result = Guid.Parse(value.ToString());
                }
                else
                {
                    result = Convert.ChangeType(value, t);
                }
            }
            catch (Exception)
            {
                result = default(T);
            }

            return (T)result;
        }

        #endregion 把对象类型转换成指定的类型，转化失败时返回类型默认值

        #region 字节序列
        /// <summary>
        /// 字符串序列化成字节序列
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] SerializeUtf8(this string str)
        {
            return str == null ? null : Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 字节序列序列化成字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string DeserializeUtf8(this byte[] stream)
        {
            return stream == null ? null : Encoding.UTF8.GetString(stream);
        }
        #endregion

        #region 补足位数

        /// <summary>
        /// 指定字符串的固定长度，如果字符串小于固定长度，
        /// 则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        public static string RepairZero(this string text, int limitedLength)
        {
            //补足0的字符串
            string temp = "";

            //补足0
            for (int i = 0; i < limitedLength - text.Length; i++)
            {
                temp += "0";
            }

            //连接text
            temp += text;

            //返回补足0的字符串
            return temp;
        }

        /// <summary>
        /// 小时、分钟、秒小于10补足0
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <returns></returns>
        public static string RepairZero(this int text)
        {
            string res = string.Empty;
            if (text >= 0 && text < 10)
            {
                res += "0" + text;
            }
            else
            {
                res = text.ToString();
            }
            return res;
        }

        #endregion 补足位数

        #region 判断指定类型是否为数字类型

        /// <summary>
        /// 判断指定类型是否为数字类型
        /// </summary>
        /// <param name="t">要检查的类型</param>
        /// <returns>是否是数字类型</returns>
        public static bool IsNumeric(this Type t)
        {
            return t == typeof(Byte)
                   || t == typeof(Int16)
                   || t == typeof(Int32)
                   || t == typeof(Int64)
                   || t == typeof(SByte)
                   || t == typeof(UInt16)
                   || t == typeof(UInt32)
                   || t == typeof(UInt64)
                   || t == typeof(Decimal)
                   || t == typeof(Double)
                   || t == typeof(Single);
        }

        #endregion 判断指定类型是否为数字类型

        #region 检验参数合法性，数值类型不小于0，引用类型不能为null，否则抛出异常

        /// <summary>
        /// 检验参数合法性，数值类型不小于0，引用类型不能为null，否则抛出异常
        /// </summary>
        /// <param name="arg">待检参数</param>
        /// <param name="argName">待检参数名称</param>
        /// <param name="canZero">数值类型是否可以为0</param>
        public static bool CheckArgument(this object arg, string argName, bool canZero = false)
        {
            try
            {
                if (arg == null)
                {
                    ArgumentNullException argumentNullException = new ArgumentNullException(argName);
                    throw new Exception(String.Format("参数{0}为空，引发异常", argName), argumentNullException);
                }

                //参数类型
                Type t = arg.GetType();

                if (t.IsValueType && t.IsNumeric())
                {
                    bool flag = !canZero ? arg.CastTo(0.0) <= 0.0 : arg.CastTo(0.0) < 0.0;
                    if (flag)
                    {
                        ArgumentOutOfRangeException argumentOutOfRangeException = new ArgumentOutOfRangeException(argName);
                        throw new Exception(String.Format("参数{0}不在有效范围内，引发异常", argName), argumentOutOfRangeException);
                    }
                }

                if (t == typeof(Guid) && (Guid)arg == Guid.Empty)
                {
                    ArgumentNullException argumentNullException1 = new ArgumentNullException(argName);
                    throw new Exception(String.Format("参数{0}为空引发GUID异常", argName), argumentNullException1);
                }

                if (t == typeof(DateTime))
                {
                    DateTime dateTime = (DateTime)arg;
                    bool isSucc = dateTime != DateTime.MinValue || dateTime != DateTime.MaxValue || dateTime != SqlDateTime.MinValue.Value || dateTime != SqlDateTime.MaxValue.Value;

                    if (!isSucc)
                    {
                        ArgumentOutOfRangeException argumentOutOfRangeException = new ArgumentOutOfRangeException(argName);
                        throw new Exception(String.Format("参数{0}不在有效范围内，引发异常", argName), argumentOutOfRangeException);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion 检验参数合法性，数值类型不小于0，引用类型不能为null，否则抛出异常
    }
}
