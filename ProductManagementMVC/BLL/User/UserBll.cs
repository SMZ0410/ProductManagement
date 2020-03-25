
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ApiRequest;
using SDKClient.Api.Request.User;
using SDKClient.Api.Response.User;

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

        /// <summary>
        /// 忘记密码 发送更改密码地址到用户邮箱
        /// </summary>
        /// <returns></returns>
        public UserForgotPwdResponse ForgotPassword(UserForgotPwdRequest request)
        {
            return ApiRequestHelper.Post<UserForgotPwdRequest, UserForgotPwdResponse>(request);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public UserResetPwdResponse ResetPassword(UserResetPwdRequest request)
        {
            return ApiRequestHelper.Post<UserResetPwdRequest, UserResetPwdResponse>(request);
        }

   
   
    }
}
