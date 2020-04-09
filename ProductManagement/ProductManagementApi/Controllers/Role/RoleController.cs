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
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Request.DropDownList;

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

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public RoleUpdateResponse DeleteRole(RoleUpdateRequest request)
        {
            return UpdateRoleBll.Instance.DeleteRole(request);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public RolePostResponse PostRole(RolePostRequest request)
        {
            return PostRoleBll.Instance.PostRole(request);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public RolePutResponse PutRole(RolePutRequest request)
        {
            return UpdateRoleBll.Instance.UpdateRole(request);
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public RoleByIdResponse GetRoleById(RoleByIdRequest request)
        {
            return UpdateRoleBll.Instance.GetRoleById(request);
        }

        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public DorpDownPrivilegeResponse GePrivilege(DorpDownPrivilegeRequest request)
        {
            return PostRoleBll.Instance.GetPrivilege(request);
        }

    }
}
