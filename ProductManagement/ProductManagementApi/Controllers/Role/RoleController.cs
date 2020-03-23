using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDKClient.Api.Request.Role;
using SDKClient.Api.Response.Role;
using BLL.Role;
using ProductManagementApi.Auth;

namespace ProductManagementApi.Controllers.Role
{
    public class RoleController : ApiController
    {
        [ApiAuthorize]
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        [HttpPost]
        public RoleGetResponse GetRoleInfos(RoleGetRequest request)
        {

            return RoleBll.Instance.GetRoleInfos(request);
        }
    }
}
