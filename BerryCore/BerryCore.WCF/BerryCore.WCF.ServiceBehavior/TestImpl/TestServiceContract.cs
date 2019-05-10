using BerryCore.WCF.BaseBehavior;
using System;
using BerryCore.WCF.BaseBehavior.ParameterInspector;
using BerryCore.WCF.ServiceContract.Test;
using BerryCore.WCF.DataContract.Base;
using BerryCore.Code;
using BerryCore.WCF.DataContract.Test;

namespace BerryCore.WCF.ServiceBehavior.TestImpl
{
    /// <summary>
    /// 用于测试的协议实现
    /// </summary>
    public class TestServiceContract : BaseServiceBehavior, ITestServiceContract
    {
        /// <summary>
        /// 根据用户ID获取用户姓名
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [CustomParameterBehavior]
        public string GetUserNameById(string userId)
        {
            return "dsx-" + userId;
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        [CustomParameterBehavior]
        public DateTime GetServiceTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 实体测试
        /// </summary>
        /// <returns></returns>
        [CustomParameterBehavior]
        public BaseSoapResult<string> GetTestObjectMsg()
        {
            BaseSoapResult<string> res = this.GetBaseSoapResult<string>(JsonObjectStatus.Error);

            this.Logger(this.GetType(), "实体测试-GetTestObjectMsg", () =>
            {
                res = new BaseSoapResult<string>
                {
                    Status = JsonObjectStatus.Success,
                    Data = "Hello World！",
                    Msg = "欢迎使用WCF服务！"
                };
            }, e =>
            {
                res = this.GetBaseSoapResult<string>(JsonObjectStatus.Exception, e.Message);
            });
            return res;
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [CustomParameterBehavior]
        public BaseSoapResult<string> GetUserInfo(string userId)
        {
            UserInfoTestEntity info = new UserInfoTestEntity
            {
                Id = userId,
                Name = "测试：" + userId
            };
            return this.GetBaseSoapResult<UserInfoTestEntity>(info, JsonObjectStatus.Success);
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="info">实体参数</param>
        /// <returns></returns>
        [CustomParameterBehavior]
        public BaseSoapResult<string> SaveUserInfo(UserInfoTestEntity info)
        {
            return this.GetBaseSoapResult<UserInfoTestEntity>(info, JsonObjectStatus.Success);
        }
    }
}