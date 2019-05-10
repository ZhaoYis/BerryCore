using BerryCore.WCF.BaseBehavior;
using BerryCore.WCF.DataContract.Base;
using System;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Web;
using BerryCore.WCF.DataContract.Test;

namespace BerryCore.WCF.ServiceContract.Test
{
    /// <summary>
    /// 用于测试的协议
    /// </summary>
    [ServiceContract(ProtectionLevel = ProtectionLevel.None)]
    public interface ITestServiceContract : IBaseServiceBehavior
    {
        /// <summary>
        /// 根据用户ID获取用户姓名
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string GetUserNameById(string userId);

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        DateTime GetServiceTime();

        /// <summary>
        /// 实体测试
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        BaseSoapResult<string> GetTestObjectMsg();

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        BaseSoapResult<string> GetUserInfo(string userId);

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        BaseSoapResult<string> SaveUserInfo(UserInfoTestEntity info);
    }
}