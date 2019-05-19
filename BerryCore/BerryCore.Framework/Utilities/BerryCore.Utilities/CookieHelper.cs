#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：BerryCore.Utilities
* 项目描述 ：
* 类 名 称 ：CookieHelper
* 类 描 述 ：
* 所在的域 ：MRZHAOYI
* 命名空间 ：BerryCore.Utilities
* 机器名称 ：MRZHAOYI 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019/5/7 23:37:44
* 更新时间 ：2019/5/7 23:37:44
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
    /// 功能描述    ：Cookie帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019/5/7 23:37:44 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019/5/7 23:37:44 
    /// </summary>
    public sealed class CookieHelper
    {
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);

            cookie.Value = strValue;
            cookie.Expires = System.DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }

        /// <summary>
        /// 删除Cookie对象
        /// </summary>
        /// <param name="cookiesName">Cookie对象名称</param>
        public static void DelCookie(string cookiesName)
        {
            HttpCookie objCookie = new HttpCookie(cookiesName.Trim())
            {
                Expires = System.DateTime.Now.AddYears(-5)
            };
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }
    }
}
