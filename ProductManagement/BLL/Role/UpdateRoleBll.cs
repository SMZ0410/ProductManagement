using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request.Role;
using SDKClient.Api.Response.Role;
using DAL.RoleInfo;

namespace BLL.Role
{
    public class UpdateRoleBll : BaseBll<UpdateRoleBll>
    {
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RoleUpdateResponse DeleteRole(RoleUpdateRequest request)
        {
            RoleUpdateResponse response = new RoleUpdateResponse();

            var str = UpdateRoleDal.Instance.DeleteRole(request.RoleAll);

            if (str <= 0)
            {
                response.Status = false;
                response.Message = "出错了";
            }
            else
            {
                response.postRoles = str;
                response.Message = "恭喜成功";
            }
            return response;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RolePutResponse UpdateRole(RolePutRequest request)
        {
            RolePutResponse response = new RolePutResponse();

            var str = UpdateRoleDal.Instance.UpdateRole(request.RoleAll);

            if (str < 0)
            {
                response.Status = false;
                response.Message = "出错了";
            }
            else
            {
                response.Status = true;
                response.Message = "恭喜成功";
            }
            return response;
        }

    }
}
