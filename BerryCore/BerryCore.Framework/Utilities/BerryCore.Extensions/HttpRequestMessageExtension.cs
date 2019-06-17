#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Extensions
* 项目描述 ：
* 类 名 称 ：HttpRequestMessageExtension
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Extensions
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-05 11:07:10
* 更新时间 ：2019-06-05 11:07:10
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Net.Http;
using System.Text;

namespace BerryCore.Extensions
{
    /// <summary>
    /// 功能描述    ：HttpRequestMessageExtension  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-05 11:07:10 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-05 11:07:10 
    /// </summary>
    public static class HttpRequestMessageExtension
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        [Obsolete("See IsLocal at HttpRequestMessageExtensions Version 5.0.0.0")]
        public static bool IsLocal(this HttpRequestMessage request)
        {
            Lazy<bool> localFlag = request.Properties["MS_IsLocal"] as Lazy<bool>;
            return localFlag != null && localFlag.Value;
        }

        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            //Web-hosting
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    string res = ctx.Request.UserHostAddress;
                    res = res.Equals("::1") ? "127.0.0.1" : res;

                    return res;
                }
            }
            //Self-hosting
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    string res = remoteEndpoint.Address;
                    res = res.Equals("::1") ? "127.0.0.1" : res;

                    return res;
                }
            }
            //Owin-hosting
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic ctx = request.Properties[OwinContext];
                if (ctx != null)
                {
                    string res = ctx.Request.RemoteIpAddress;
                    res = res.Equals("::1") ? "127.0.0.1" : res;

                    return res;
                }
            }
            return "localhost";
        }

        /// <summary>
        /// Http返回消息
        /// </summary>
        /// <param name="obj">对象或者Json字符串</param>
        /// <param name="isIgnoreNullValue">是否忽略值为NULL的属性，默认false</param>
        /// <returns></returns>
        public static HttpResponseMessage TryToHttpResponseMessage<T>(this T obj, bool isIgnoreNullValue = false)
        {
            string json = obj.TryToJson(isIgnoreNullValue);

            HttpResponseMessage result = new HttpResponseMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            return result;
        }
    }
}
