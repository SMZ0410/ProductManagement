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
        public RoleUpdateResponse PutRole(RoleUpdateRequest request)
        {
            RoleUpdateResponse response = new RoleUpdateResponse();

            var str = UpdateRoleDal.Instance.PutRole(request.RoleAll);

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
    }
}
