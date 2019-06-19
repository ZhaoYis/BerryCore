using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using BerryCore.Code;
using BerryCore.Entity.Base;
using BerryCore.Extensions;
using BerryCore.Log;
using BerryCore.Utilities;
using BerryCore.Utilities.JWT;

namespace BerryCore.SOA.API.Filters
{
    /// <summary>
    /// 接口授权验证
    /// </summary>
    public class CheckTokenFilterAttribute : ActionFilterAttribute
    {
        #region 初始化

        /// <summary>
        /// 日志
        /// </summary>
        private readonly LogHelper _logHelper = new LogHelper(typeof(CheckTokenFilterAttribute));

        ///// <summary>
        ///// 私钥
        ///// </summary>
        //private static readonly string PrivateKey;

        ///// <summary>
        ///// 公钥
        ///// </summary>
        //private static readonly string PublicKey;

        static CheckTokenFilterAttribute()
        {
            //string path = DirFileHelper.MapPath("SecretKey\\api.privateKey.key");
            //PrivateKey = DirFileHelper.ReadAllText(path);

            //path = DirFileHelper.MapPath("SecretKey\\api.publicKey.key");
            //PublicKey = DirFileHelper.ReadAllText(path);
        }

        #endregion 初始化

        /// <summary>在调用操作方法之前发生。</summary>
        /// <param name="actionContext">操作上下文。</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string isInterfaceSignature = ConfigHelper.GetValue("IsInterfaceSignature");
            if (isInterfaceSignature.ToLower() != "true")
            {
                return;
            }

            BaseJsonResult<string> resultMsg = null;
            //授权码，最终签名字符串，时间戳，随机数字符串
            string accessToken = string.Empty, signature = string.Empty, timestamp = string.Empty, nonce = string.Empty;

            //操作上下文请求信息
            HttpRequestMessage request = actionContext.Request;
            //请求方法
            string method = request.Method.Method;

            #region 接受客户端预请求

            //接受客户端预请求
            if (actionContext.Request.Method == HttpMethod.Options)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted);
                return;
            }

            #endregion 接受客户端预请求

            #region 忽略不需要授权的方法

            //忽略不需要授权的方法
            var attributes = actionContext.ActionDescriptor.GetCustomAttributes<IgnoreTokenAttribute>();
            if (attributes.Count > 0 && attributes[0].Ignore)
            {
                return;
            }

            #endregion 忽略不需要授权的方法

            _logHelper.Debug("*************************授权开始*************************\r\n");
            _logHelper.Debug("鉴权地址：" + actionContext.Request.RequestUri + "\r\n");

            #region 获取请求头信息

            //授权Token
            if (request.Headers.Contains("access_token"))
            {
                accessToken = HttpUtility.UrlDecode(request.Headers.GetValues("access_token").FirstOrDefault());

                _logHelper.Debug("access_token：" + accessToken + "\r\n");
            }

            //签名字符串
            if (request.Headers.Contains("signature"))
            {
                signature = HttpUtility.UrlDecode(request.Headers.GetValues("signature").FirstOrDefault());

                _logHelper.Debug("signature：" + signature + "\r\n");
            }

            //时间戳
            if (request.Headers.Contains("timestamp"))
            {
                timestamp = HttpUtility.UrlDecode(request.Headers.GetValues("timestamp").FirstOrDefault());

                _logHelper.Debug("timestamp：" + timestamp + "\r\n");
            }

            //随机字符串
            if (request.Headers.Contains("nonce_str"))
            {
                nonce = HttpUtility.UrlDecode(request.Headers.GetValues("nonce_str").FirstOrDefault());

                _logHelper.Debug("nonce_str：" + nonce + "\r\n");
            }

            #endregion 获取请求头信息

            #region 判断请求头是否包含以下参数

            //判断请求头是否包含以下参数
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(signature) || string.IsNullOrEmpty(timestamp) || string.IsNullOrEmpty(nonce))
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = GlobalErrorCodes.AuthParameterError,
                    Message = GlobalErrorCodes.AuthParameterError.GetEnumDescription()
                };
                actionContext.Response = resultMsg.TryToHttpResponseMessage();

                _logHelper.Debug("*************************授权结束（请求头参数不完整）*************************\r\n");
                return;
            }

            #endregion 判断请求头是否包含以下参数

            #region 校验参数是否被篡改

            ////校验参数是否被篡改
            //Dictionary<string, object> actionArguments = null;
            //switch (method)
            //{
            //    case "POST":
            //        actionArguments = actionContext.ActionArguments;
            //        KeyValuePair<string, object> keyValuePair = actionArguments.FirstOrDefault();
            //        actionArguments = keyValuePair.Value.Object2Dictionary();
            //        break;
            //    case "GET":
            //        actionArguments = actionContext.ActionArguments;
            //        break;
            //}

            //bool isSucc = this.CheckSignature(signature, actionArguments);
            //if (!isSucc)
            //{
            //    resultMsg = new BaseJsonResult<string>
            //    {
            //        Status = (int)JsonObjectStatus.ParameterManipulation,
            //        Message = JsonObjectStatus.ParameterManipulation.GetEnumDescription()
            //    };
            //    actionContext.Response = resultMsg.TryToHttpResponseMessage();

            //    _logHelper.Debug("*************************授权结束（请求参数被篡改或指纹有误）*************************\r\n");

            //    return;
            //}

            #endregion 校验参数是否被篡改

            #region 校验Token是否有效

            //校验Token是否有效
            bool isCheckSucc = JWTHelper.CheckToken(accessToken, out JWTPlayloadInfo jwtPlayloadInfo);
            if (!isCheckSucc)
            {
                _logHelper.Debug("校验Token是否有效：TOKEN失效\r\n");

                resultMsg = new BaseJsonResult<string>
                {
                    Status = GlobalErrorCodes.TokenInvalid,
                    Message = GlobalErrorCodes.TokenInvalid.GetEnumDescription()
                };
                actionContext.Response = resultMsg.TryToHttpResponseMessage();

                _logHelper.Debug("*************************授权结束（TOKEN失效）*************************\r\n");

                return;
            }
            else
            {
                //校验当前用户是否能够操作某些特定方法（比如更新用户信息）
                if (!attributes[0].Ignore)
                {
                    string userId = jwtPlayloadInfo.aud;

                    //访客用户不能访问未忽略的接口
                    if (!string.IsNullOrEmpty(userId) && userId.Equals(JWTPlayloadInfo.DefaultAud))
                    {
                        resultMsg = new BaseJsonResult<string>
                        {
                            Status = GlobalErrorCodes.NoPermission,
                            Message = GlobalErrorCodes.NoPermission.GetEnumDescription()
                        };
                        actionContext.Response = resultMsg.TryToHttpResponseMessage();
                        _logHelper.Debug("*************************授权结束（无权执行此操作）*************************\r\n");
                        return;
                    }

                    //TODO 验证正式用户或者试用用户是否有权操作当前方法

                }
            }

            #endregion 校验Token是否有效

            #region 验证签名字符串是否有效

            SortedDictionary<string, object> dict = new SortedDictionary<string, object>
            {
                {"access_token", accessToken},
                {"timestamp", timestamp},
                {"nonce_str", nonce},
            };
            bool isSucc = this.CheckSignature(signature, dict);
            if (isSucc)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                resultMsg = new BaseJsonResult<string>
                {
                    Status = GlobalErrorCodes.SignError,
                    Message = GlobalErrorCodes.SignError.GetEnumDescription()
                };
                actionContext.Response = resultMsg.TryToHttpResponseMessage();

                _logHelper.Debug("*************************授权结束（签名有误）*************************\r\n");

                return;
            }

            #endregion

            _logHelper.Debug("*************************授权结束*************************\r\n");
        }

        #region 指纹校验

        /// <summary>
        /// 指纹校验
        /// </summary>
        /// <param name="signature">客户端传回的指纹</param>
        /// <param name="actionArguments">请求参数</param>
        /// <returns></returns>
        private bool CheckSignature(string signature, SortedDictionary<string, object> actionArguments)
        {
            if (string.IsNullOrEmpty(signature))
            {
                return false;
            }

            if (actionArguments != null)
            {
                _logHelper.Debug("开始Signature校验，参数个数：" + actionArguments.Count + "。\r\n");

                //1-获取参数字符串，并按参数名升序排序，形如：a=1&b=2&c=3
                string argString = this.GetArgumentString(actionArguments);
                _logHelper.Debug("1-获取参数字符串，并按参数名升序排序：" + argString + "\r\n");

                //2-取参数字符串的md5
                string sign = Md5Helper.Md5(argString);
                _logHelper.Debug("2-取参数字符串的md5：" + sign + "\r\n");

                _logHelper.Debug("3-校验指纹信息：" + (sign == signature).ToString() + "\r\n");

                return sign == signature;
            }
            return false;
        }

        /// <summary>
        /// 获取参数字符串，并按参数名升序排序，形如：a=1&b=2&c=3
        /// </summary>
        /// <param name="actionArguments"></param>
        /// <returns></returns>
        private string GetArgumentString(SortedDictionary<string, object> actionArguments)
        {
            StringBuilder builder = new StringBuilder();

            //actionArguments = actionArguments.OrderBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);

            foreach (KeyValuePair<string, object> pair in actionArguments)
            {
                string key = pair.Key;
                string value = pair.Value == null ? "" : pair.Value.ToString();
                builder.Append(string.Format("{0}={1}&", key, value));
            }

            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        #endregion
    }
}