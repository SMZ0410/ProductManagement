using BLL.User;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductManagementApi.Auth;
using SDKClient.Api.Response.User;
using SDKClient.Api.Request.User;

namespace ProductManagementApi.Controllers.User
{
    /// <summary>
    /// 用户Api控制器
    /// </summary> 
    [ApiAuthorize] 
    public class UserController : ApiController
    {
       
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public UserGetResponse GetUsers()
        {
            return UserBll.Instance.GetUsers();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            return UserBll.Instance.UserLogin(request);
        }
    }
}
