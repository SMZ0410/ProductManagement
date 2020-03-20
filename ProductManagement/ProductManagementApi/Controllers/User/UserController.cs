using BLL.User;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductManagementApi.Auth;

namespace ProductManagementApi.Controllers.User
{
    /// <summary>
    /// 用户Api控制器
    /// </summary> 
    [ApiAuthorize]
    
    public class UserController : ApiController
    {
        /// 获取用户基本信息
        /// </summary>
        /// <returns>用户集合信息</returns>
        [HttpPost]
        public UserGetResponse GetUsers()
        {
            return UserBll.Instance.GetUsers();
        }
    }
}
