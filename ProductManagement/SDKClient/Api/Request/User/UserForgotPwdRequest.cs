using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    public class UserForgotPwdRequest:BaseRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///邮箱
        /// </summary>
        public string Email { get; set; }
        public override string GetApiName()
        {
            return "api/User/ForgotPassword";
        }
    }
}
