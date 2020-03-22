using SDKClient.Api.Request.User;
using SDKClient.Api.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ApiRequest;

namespace BLL.User
{
    /// <summary>
    /// 
    /// </summary>
    public  class UserBll:BaseBll<UserBll>
    {

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public UserGetResponse GetUsers(UserGetRequest request)
        {
            return ApiRequestHelper.Post<UserGetRequest, UserGetResponse>(request);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            return  ApiRequestHelper.Post<UserLoginRequest, UserLoginResponse>(request);
        }
    }
}
