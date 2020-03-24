using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    public class UserResetPwdRequest:BaseRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string NewPassword { get; set; }
        public override string GetApiName()
        {
            return "api/User/ResetUserPassword";
        }
    }
}
