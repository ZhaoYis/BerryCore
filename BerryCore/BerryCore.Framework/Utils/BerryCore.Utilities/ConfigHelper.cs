#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：ConfigHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/3 21:59:26
* 更新时间 ：2019/5/3 21:59:26
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System.Configuration;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：配置文件操作帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/3 21:59:26 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/3 21:59:26 
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name)
        {
            string reg = @"Data Source=(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)\.(25[0-5]|2[0-4]\d|[0-1]\d{2}|[1-9]?\d)";
            if (StringHelper.QuickValidate(reg, name))
            {
                return name;
            }

            string res = ConfigurationManager.ConnectionStrings[name].ConnectionString.ToString();
            return res;
        }

        /// <summary>
        /// 根据Key获取配置值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            string res = ConfigurationManager.AppSettings[key].ToString();
            return res;
        }

        /// <summary>
        /// 获取配置文件节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static T GetSection<T>(string sectionName) where T : class, new()
        {
            T res = ConfigurationManager.GetSection(sectionName) as T;
            return res;
        }
    }
}
