using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.User
{
    /// <summary>
    /// 重置密码返回类
    /// </summary>
    public class UserResetPwdResponse:BaseResponse
    {
        /// <summary>
        /// 用户登录 返回id 用户名 角色
        /// </summary>
        public UserLogModel User { get; set; }
    }
}
