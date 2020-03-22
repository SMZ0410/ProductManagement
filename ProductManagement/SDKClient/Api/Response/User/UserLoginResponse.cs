using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.User
{
    /// <summary>
    /// 用户登录返回
    /// </summary>
    public class UserLoginResponse : BaseResponse
    {
        /// <summary>
        /// 登录是否成功
        /// </summary>
        public bool IsLoginSuccess { get; set; }
    }
}
