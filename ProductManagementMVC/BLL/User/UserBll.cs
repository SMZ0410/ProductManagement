using BLL.ApiRequest;
using SDKClient.Api.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request.User;

namespace BLL.User
{
    public class UserBll
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public UserGetResponse GetUsers(UserGetRequest request)
        {
            return ApiRequestHelper.Post<UserGetRequest, UserGetResponse>(request);
        }
    }
}
