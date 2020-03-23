using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RoleInfo;
using SDKClient.Api.Request.Role;
using SDKClient.Api.Response.Role;

namespace BLL.Role
{
    public class RoleBll : BaseBll<RoleBll>
    {
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public RoleGetResponse GetRoleInfos(RoleGetRequest request)
        {
            RoleGetResponse response = new RoleGetResponse();

            var list = RoleInfoDal.Instance.GetRoleInfos(request.RoleName);

            if (list.Count <= 0)
            {
                response.Status = false;
                response.Message = "获取角色信息失败";
            }
            else
            {
                response.RoleInfo = list;
                response.Message = $"恭喜成功了~~亲~";
            }
            return response;
        }
    }
}
