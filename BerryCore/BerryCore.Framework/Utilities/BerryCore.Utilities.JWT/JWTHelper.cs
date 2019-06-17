#region << 版 本 注 释 >>
/*
* 项目名称 ：GCP.Utilities.JWT
* 项目描述 ：
* 类 名 称 ：JWTHelper
* 类 描 述 ：
* 所在的域 ：DASHIXIONG
* 命名空间 ：GCP.Utilities.JWT
* 机器名称 ：DASHIXIONG 
* CLR 版本 ：4.0.30319.42000
* 作    者 ：赵轶
* 创建时间 ：2019-06-04 15:49:26
* 更新时间 ：2019-06-04 15:49:26
* 版 本 号 ：V2.0.0.0
***********************************************************************
* Copyright © 大師兄丶 2019. All rights reserved.                     *
***********************************************************************
*/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using Berry.Cache.Core.Base;
using BerryCore.Extensions;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace BerryCore.Utilities.JWT
{
    /// <summary>
    /// 功能描述    ：JWT操作帮助类  
    /// 创 建 者    ：赵轶
    /// 创建日期    ：2019-06-04 15:49:26 
    /// 最后修改者  ：赵轶
    /// 最后修改日期：2019-06-04 15:49:26 
    /// </summary>
    public sealed class JWTHelper
    {
        /// <summary>
        /// 私钥
        /// </summary>
        private static string TokenPrivateKey;
        static JWTHelper()
        {
            string path = string.Format("{0}SecretKey\\token.private.key", AppDomain.CurrentDomain.BaseDirectory);
            if (File.Exists(path))
            {
                string key = File.ReadAllText(path);
                TokenPrivateKey = key;
            }
        }

        /// <summary>
        /// 签发Token
        /// </summary>
        /// <param name="playload">载荷</param>
        /// <returns></returns>
        public static string GetToken(JWTPlayloadInfo playload)
        {
            string token = String.Empty;
            if (playload != null)
            {
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

                //设置过期时间
                TimeSpan time = TimeSpan.FromHours(24);
                playload.exp = DateTime.Now.AddHours(24).DateTime2TimeStamp().ToString();
                Dictionary<string, object> dict = playload.Object2Dictionary();
                //获取私钥
                string secret = GetPrivateKey();
                //将Token保存在缓存中
                if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals(JWTPlayloadInfo.DefaultAud))
                {
                    //计算公用Token
                    token = CacheFactory.GetCache().Get("JWT:JWT_TokenCacheKey:Guest", () =>
                    {
                        return encoder.Encode(dict, secret);
                    }, time);
                }
                else
                {
                    //计算Token
                    token = CacheFactory.GetCache().Get(string.Format("JWT:JWT_TokenCacheKey:{0}", playload.aud), () =>
                    {
                        return encoder.Encode(dict, secret);
                    }, time);
                }
            }
            return token;
        }

        /// <summary>
        /// 如果Token过期，则马上重新计算
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="account"></param>
        public static string CheckTokenHasExpiry(string userId, string account)
        {
            string token = String.Empty;
            if (!string.IsNullOrEmpty(userId) && userId.Equals(JWTPlayloadInfo.DefaultAud))
            {
                JWTPlayloadInfo playload = new JWTPlayloadInfo
                {
                    iss = JWTPlayloadInfo.DefaultIss,
                    sub = account,
                    aud = userId,
                    extend = "PUBLIC_TOKEN"
                };
                token = GetToken(playload);
            }
            else
            {
                JWTPlayloadInfo playload = new JWTPlayloadInfo
                {
                    iss = JWTPlayloadInfo.DefaultIss,
                    sub = account,
                    aud = userId,
                    extend = "USER_TOKEN"
                };
                token = GetToken(playload);
            }

            return token;
        }

        /// <summary>
        /// Token校验
        /// </summary>
        /// <param name="token"></param>
        /// <param name="jwtPlayloadInfo"></param>
        /// <returns></returns>
        public static bool CheckToken(string token, out JWTPlayloadInfo jwtPlayloadInfo)
        {
            if (string.IsNullOrEmpty(token))
            {
                jwtPlayloadInfo = default(JWTPlayloadInfo);
                return false;
            }

            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);

            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

            //获取私钥
            string secret = GetPrivateKey();
            try
            {
                JWTPlayloadInfo playload = decoder.DecodeToObject<JWTPlayloadInfo>(token, secret, true);
                if (playload != null)
                {
                    if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals(JWTPlayloadInfo.DefaultAud))
                    {
                        string cacheToken = CacheFactory.GetCache().Get<string>("JWT:JWT_TokenCacheKey:Guest");

                        jwtPlayloadInfo = playload;
                        return Check(playload, cacheToken, token);
                    }
                    else
                    {
                        string cacheToken = CacheFactory.GetCache().Get<string>(string.Format("JWT:JWT_TokenCacheKey:{0}", playload.aud));

                        jwtPlayloadInfo = playload;
                        return Check(playload, cacheToken, token);
                    }
                }
                else
                {
                    jwtPlayloadInfo = default(JWTPlayloadInfo);
                    return false;
                }
            }
            catch (Exception e)
            {
                jwtPlayloadInfo = default(JWTPlayloadInfo);
                return false;
            }
        }

        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="playload"></param>
        /// <param name="cacheToken"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private static bool Check(JWTPlayloadInfo playload, string cacheToken, string token)
        {
            if (string.IsNullOrEmpty(cacheToken))
            {
                return false;
            }

            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            if (!cacheToken.Equals(token))
            {
                return false;
            }

            //Token过期
            DateTime exp = playload.exp.TryToInt64().TimeStamp2DateTime();
            if (DateTime.Now > exp)
            {
                if (!string.IsNullOrEmpty(playload.aud) && playload.aud.Equals(JWTPlayloadInfo.DefaultAud))
                {
                    CacheFactory.GetCache().Remove("JWT:JWT_TokenCacheKey:Guest");
                }
                else
                {
                    CacheFactory.GetCache().Remove(string.Format("JWT:JWT_TokenCacheKey:{0}", playload.aud));
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取私钥
        /// </summary>
        /// <returns></returns>
        private static string GetPrivateKey()
        {
            return TokenPrivateKey;
        }
    }
}
