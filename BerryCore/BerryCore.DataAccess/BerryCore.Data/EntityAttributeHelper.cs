#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Data
* 项目描述 ：
* 类 名 称 ：EntityAttributeHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Data
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 22:25:53
* 更新时间 ：2019/5/3 22:25:53
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace BerryCore.Data
{
    /// <summary>
    /// 功能描述    ：获取实体类Attribute自定义属性  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 22:25:53 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 22:25:53 
    /// </summary>
    public class EntityAttributeHelper
    {
        /// <summary>
        ///  获取实体对象Key
        /// </summary>
        /// <returns></returns>
        public static string GetEntityKey<T>()
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetCustomAttributes(true).OfType<KeyAttribute>().Any())
                {
                    return prop.Name;
                }
            }
            return null;
        }

        /// <summary>
        ///  获取不映射的字段集合
        /// </summary>
        /// <returns></returns>
        public static List<string> GetNotMappedFields<T>()
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            List<string> res = new List<string>();
            foreach (PropertyInfo prop in props)
            {
                res.AddRange(prop.GetCustomAttributes(true).OfType<NotMappedAttribute>().Select(key => prop.Name));
            }
            return res;
        }

        /// <summary>
        ///  获取实体对象表名
        /// </summary>
        /// <returns></returns>
        public static string GetEntityTable<T>()
        {
            Type objTye = typeof(T);
            string entityName = "";
            var tableAttribute = objTye.GetCustomAttributes(true).OfType<TableAttribute>();
            var descriptionAttributes = tableAttribute as TableAttribute[] ?? tableAttribute.ToArray();

            entityName = descriptionAttributes.Any() ? descriptionAttributes.ToList()[0].Name : objTye.Name;
            return entityName;
        }

        /// <summary>
        /// 获取实体类显示名称
        /// </summary>
        /// <param name="pi">字段属性信息</param>
        /// <returns></returns>
        public static string GetFieldDisplayName(PropertyInfo pi)
        {
            string txt = "";
            var descAttrs = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
            if (descAttrs.Any())
            {
                DisplayNameAttribute descAttr = descAttrs[0] as DisplayNameAttribute;
                if (descAttr != null)
                {
                    txt = descAttr.DisplayName;
                }
            }
            else
            {
                txt = pi.Name;
            }
            return txt;
        }

        /// <summary>
        /// 获取实体类中文名称
        /// </summary>
        /// <returns></returns>
        public static string GetClassName<T>()
        {
            Type objTye = typeof(T);
            string entityName = "";
            var busingessNames = objTye.GetCustomAttributes(true).OfType<DisplayNameAttribute>();
            var descriptionAttributes = busingessNames as DisplayNameAttribute[] ?? busingessNames.ToArray();
            if (descriptionAttributes.Any())
            {
                entityName = descriptionAttributes.ToList()[0].DisplayName;
            }
            else
            {
                entityName = objTye.Name;
            }
            return entityName;
        }

        /// <summary>
        /// 获取访问元素
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
