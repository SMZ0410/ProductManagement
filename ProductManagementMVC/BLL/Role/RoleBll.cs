using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request.Role;
using SDKClient.Api.Response.Role;
using BLL.ApiRequest;
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Request.DropDownList;

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
        /// 逻辑删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleUpdateResponse DeleteRole(RoleUpdateRequest request)
        {
            return ApiRequestHelper.Post<RoleUpdateRequest, RoleUpdateResponse>(request);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RolePostResponse AddRole(RolePostRequest request)
        {
            return ApiRequestHelper.Post<RolePostRequest, RolePostResponse>(request);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RolePutResponse UpdateRole(RolePutRequest request)
        {
            return ApiRequestHelper.Post<RolePutRequest, RolePutResponse>(request);
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleByIdResponse RoleById(RoleByIdRequest request)
        {
            return ApiRequestHelper.Post<RoleByIdRequest, RoleByIdResponse>(request);
        }

        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DorpDownPrivilegeResponse GePrivilege(DorpDownPrivilegeRequest request)
        {
            return ApiRequestHelper.Post<DorpDownPrivilegeRequest, DorpDownPrivilegeResponse>(request);
        }
        
    }
}
