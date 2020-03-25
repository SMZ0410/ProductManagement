﻿using System;
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
        /// 优秀
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleGetResponse GetRoleInfos(RoleGetRequest request)
        {
            return ApiRequestHelper.Post<RoleGetRequest, RoleGetResponse>(request);
        }
    }
}