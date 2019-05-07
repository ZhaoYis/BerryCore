#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：SessionHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:49:40
* 更新时间 ：2019/5/7 23:49:40
* 版 本 号 ：V1.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
//----------------------------------------------------------------*/
#endregion

using System.Web;

namespace BerryCore.Utilities
{
    /// <summary>
    /// 功能描述    ：Session操作帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:49:40 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:49:40 
    /// </summary>
    public sealed class SessionHelper
    {
        #region 添加Session,有效期为默认

        /// <summary>
        /// 添加Session,有效期为默认
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="objValue">Session值</param>
        public static void AddSession(string strSessionName, object objValue)
        {
            HttpContext context = HttpContext.Current;

            context.Session[strSessionName] = objValue;
        }

        #endregion 添加Session,有效期为默认

        #region 添加Session，并调整有效期为分钟或几年

        /// <summary>
        /// 添加Session，并调整有效期为分钟或几年
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="objValue">Session值</param>
        /// <param name="iExpires">分钟数：大于0则以分钟数为有效期，等于0则以后面的年为有效期</param>
        /// <param name="iYear">年数：当分钟数为0时按年数为有效期，当分钟数大于0时此参数随意设置</param>
        public static void AddSession(string strSessionName, object objValue, int iExpires, int iYear)
        {
            HttpContext context = HttpContext.Current;

            context.Session[strSessionName] = objValue;
            if (iExpires > 0)
            {
                context.Session.Timeout = iExpires;
            }
            else if (iYear > 0)
            {
                context.Session.Timeout = 60 * 24 * 365 * iYear;
            }
        }

        #endregion 添加Session，并调整有效期为分钟或几年

        #region 读取某个Session对象值

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static T GetSession<T>(string strSessionName) where T : class
        {
            HttpContext context = HttpContext.Current;

            return context.Session[strSessionName] as T;
        }

        #endregion 读取某个Session对象值

        #region 删除某个Session对象

        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void RemoveSession(string strSessionName)
        {
            HttpContext context = HttpContext.Current;

            context.Session.Remove(strSessionName);
        }

        /// <summary>
        /// 删除所有Session对象
        /// </summary>
        public static void RemoveAllSession()
        {
            HttpContext context = HttpContext.Current;

            context.Session.RemoveAll();
        }

        #endregion 删除某个Session对象
    }
}
