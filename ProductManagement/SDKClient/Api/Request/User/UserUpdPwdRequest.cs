using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    /// <summary>
    /// 修改个人密码请求类
    /// </summary>
    public class UserUpdPwdRequest:BaseRequest
    { 
        /// <summary>
        /// 修改个人密码信息
        /// </summary>
        public UserUpdatePassword User { get; set; }

        /// <summary>
        /// 重写基类路径
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/User/UpdateUserPassword";
        }
    }
}
