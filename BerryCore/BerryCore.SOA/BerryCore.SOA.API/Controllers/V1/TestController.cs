using System.Net.Http;
using System.Web.Http;
using BerryCore.Code;
using BerryCore.Entity.Base;
using BerryCore.Entity.Test;
using BerryCore.Extensions;
using BerryCore.SOA.API.Base;

namespace BerryCore.SOA.API.Controllers.V1
{
    /// <summary>
    /// 用于测试
    /// </summary>
    public class TestController : BaseApiController
    {
        /// <summary>
        /// 用于GET测试
        /// </summary>
        [HttpGet]
        public HttpResponseMessage GetUserName(string id)
        {
            BaseJsonResult<string> resultMsg = new BaseJsonResult<string>
            {
                Status = GlobalErrorCodes.Success,
                Data = "V1-" + id,
                Message = "操作成功"
            };
            return resultMsg.TryToHttpResponseMessage();
        }

        /// <summary>
        /// 用于POST测试
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AddUser(UserTestEntity user)
        {
            BaseJsonResult<string> resultMsg = new BaseJsonResult<string>
            {
                Status = GlobalErrorCodes.Success,
                Data = "V1-" + user.TryToJson(),
                Message = "操作成功"
            };
            return resultMsg.TryToHttpResponseMessage();
        }
    }
}
