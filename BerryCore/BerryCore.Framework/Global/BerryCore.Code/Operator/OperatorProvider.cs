using BerryCore.Utilities;
using System;
using BerryCore.Utilities.Encrypt;
using BerryCore.Extensions;

namespace BerryCore.Code.Operator
{
    public class OperatorProvider : IOperatorProvider
    {
        private OperatorProvider()
        {
        }

        #region 静态实例

        /// <summary>
        /// 当前提供者
        /// </summary>
        public static IOperatorProvider Provider => new OperatorProvider();

        #endregion 静态实例

        /// <summary>
        /// 秘钥
        /// </summary>
        private string LoginUserKey = "__LoginUserKey";

        /// <summary>
        /// 登陆提供者模式:Session、Cookie、Cache
        /// </summary>
        private readonly string _loginProvider = ConfigHelper.GetValue("LoginProvider");

        private const string LoginProviderCookie = "Cookie";
        private const string LoginProviderSession = "Session";
        private const string LoginProviderCache = "Cache";

        /// <summary>
        /// 写入登录信息
        /// </summary>
        /// <param name="user">成员信息</param>
        public virtual void AddCurrent(OperatorEntity user)
        {
            //try
            //{
            //    if (_loginProvider == LoginProviderCookie)
            //    {
            //        CookieHelper.WriteCookie(LoginUserKey, DESEncryptHelper.Encrypt(user.TryToJson()), 60);
            //    }
            //    else if (_loginProvider == LoginProviderSession)
            //    {
            //        SessionHelper.AddSession(LoginUserKey, DESEncryptHelper.Encrypt(user.TryToJson()), 60, 0);
            //    }
            //    else if (_loginProvider == LoginProviderCache)
            //    {
            //        CacheFactory.GetCache().Add(LoginUserKey, DESEncryptHelper.Encrypt(user.TryToJson()), TimeSpan.FromMinutes(60));
            //    }

            //    //添加当前登陆用户Token
            //    CacheFactory.GetCache().Add(user.UserId, user.Token, TimeSpan.FromMinutes(60 * 12));
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        /// <returns></returns>
        public virtual OperatorEntity Current()
        {
            //try
            //{
            //    OperatorEntity user = new OperatorEntity();
            //    if (_loginProvider == LoginProviderCookie)
            //    {
            //        string json = CookieHelper.GetCookie(LoginUserKey).ToString();
            //        if (!string.IsNullOrEmpty(json))
            //        {
            //            user = DESEncryptHelper.Decrypt(json).JsonToEntity<OperatorEntity>();
            //        }
            //    }
            //    else if (_loginProvider == LoginProviderSession)
            //    {
            //        string json = SessionHelper.GetSession<string>(LoginUserKey).ToString();
            //        if (!string.IsNullOrEmpty(json))
            //        {
            //            user = DESEncryptHelper.Decrypt(json).JsonToEntity<OperatorEntity>();
            //        }
            //    }
            //    else if (_loginProvider == LoginProviderCache)
            //    {
            //        string json = CacheFactory.GetCache().Get<string>(LoginUserKey);
            //        if (!string.IsNullOrEmpty(json))
            //        {
            //            user = DESEncryptHelper.Decrypt(json).JsonToEntity<OperatorEntity>();
            //        }
            //    }
            //    return user;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            return null;
        }

        /// <summary>
        /// 删除登录信息
        /// </summary>
        public virtual void EmptyCurrent()
        {
            //if (_loginProvider == LoginProviderCookie)
            //{
            //    CookieHelper.DelCookie(LoginUserKey);
            //}
            //else if (_loginProvider == LoginProviderSession)
            //{
            //    SessionHelper.RemoveSession(LoginUserKey.Trim());
            //}
            //else if (_loginProvider == LoginProviderCache)
            //{
            //    CacheFactory.GetCache().Remove(LoginUserKey);
            //}
        }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public virtual bool IsOverdue()
        {
            //try
            //{
            //    string str = "";
            //    if (_loginProvider == LoginProviderCookie)
            //    {
            //        str = CookieHelper.GetCookie(LoginUserKey);
            //    }
            //    else if (_loginProvider == LoginProviderSession)
            //    {
            //        str = SessionHelper.GetSession<string>(LoginUserKey);
            //    }
            //    else if (_loginProvider == LoginProviderCache)
            //    {
            //        str = CacheFactory.GetCache().Get<string>(LoginUserKey);
            //    }

            //    return string.IsNullOrEmpty(str);
            //}
            //catch (Exception)
            //{
            //    return true;
            //}
            return false;
        }

        /// <summary>
        /// 是否已登录
        /// </summary>
        /// <returns></returns>
        public virtual int IsOnLine()
        {
            //OperatorEntity user = new OperatorEntity();
            //if (_loginProvider == LoginProviderCookie)
            //{
            //    user = DESEncryptHelper.Decrypt(CookieHelper.GetCookie(LoginUserKey).ToString()).JsonToEntity<OperatorEntity>();
            //}
            //else if (_loginProvider == LoginProviderSession)
            //{
            //    user = DESEncryptHelper.Decrypt(SessionHelper.GetSession<string>(LoginUserKey).ToString()).JsonToEntity<OperatorEntity>();
            //}
            //else if (_loginProvider == LoginProviderCache)
            //{
            //    string json = CacheFactory.GetCache().Get<string>(LoginUserKey);
            //    if (!string.IsNullOrEmpty(json))
            //    {
            //        user = DESEncryptHelper.Decrypt(json).JsonToEntity<OperatorEntity>();
            //    }
            //}

            //string token = CacheFactory.GetCache().Get<string>(user.UserId);
            //if (string.IsNullOrEmpty(token))
            //{
            //    return -1;//过期
            //}
            //if (user.Token == token.ToString())
            //{
            //    return 1;//正常
            //}
            //else
            //{
            //    return 0;//已登录
            //}
            return 0;
        }

        /// <summary>
        /// 当前Tab页面模块Id
        /// </summary>
        public static string CurrentModuleId
        {
            get
            {
                return CookieHelper.GetCookie("currentmoduleId");
            }
        }
    }
}