using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request.Role;
using SDKClient.Api.Response.Role;
using BLL.ApiRequest;

namespace BLL.Role
{
    public class RoleBll : BaseBll<RoleBll>
    {
        /// <summary>
        /// 角色信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleGetResponse GetRoleInfos(RoleGetRequest request)
        {
            return ApiRequestHelper.Post<RoleGetRequest, RoleGetResponse>(request);
        }

        /// <summary>
        /// 修改以及逻辑删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleUpdateResponse PutRole(RoleUpdateRequest request)
        {
            return ApiRequestHelper.Post<RoleUpdateRequest, RoleUpdateResponse>(request);
        }

    }
}
