using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    /// <summary>
    /// 用户登录请求
    /// </summary>
    public class UserLoginRequest:BaseRequest
    {
        /// <summary>
        /// 用户登录信息
        /// </summary>
        public UserLogin User { get; set; }

        /// <summary>
        /// 重写基类路劲
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/User/UserLogin";
        }
    }
}
