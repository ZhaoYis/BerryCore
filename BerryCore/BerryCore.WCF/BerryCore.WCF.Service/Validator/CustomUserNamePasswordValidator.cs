using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace BerryCore.WCF.Service.Validator
{
    /// <summary>
    /// 自定义用户名、密码验证
    /// </summary>
    public class CustomUserNamePasswordValidator : UserNamePasswordValidator
    {
        /// <summary>当在派生类中重写时,验证指定的用户名和密码。</summary>
        /// <param name="userName">要验证的用户名。</param>
        /// <param name="password">要验证的密码。</param>
        public override void Validate(string userName, string password)
        {
            if (userName != "guest" && password != "pwd")
            {
                throw new SecurityTokenException("身份验证失败！");
            }
        }
    }
}