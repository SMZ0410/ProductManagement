using BLL.User;
using ProductManagementApi.Auth;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductManagementApi.Controllers.User
{
    [ApiAuthorize]
    public class UserController : ApiController
    {
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        public UserGetResponse GetUsers()
        {
            return UserBll.Instance.GetUsers();
        }
    }
}
