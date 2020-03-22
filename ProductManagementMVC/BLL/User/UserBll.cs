using SDKClient.Api.Request.User;
using SDKClient.Api.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
    /// <summary>
    /// 
    /// </summary>
    public  class UserBll:BaseBll<UserBll>
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            return ApiRequest.ApiRequestHelper.Post<UserLoginRequest, UserLoginResponse>(request);
        }
    }
}
