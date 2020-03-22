using BLL.ApiRequest;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request;

namespace BLL.User
{
    public class UserBll:BaseBll<UserBll>
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
