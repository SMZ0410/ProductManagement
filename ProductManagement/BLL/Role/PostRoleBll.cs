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
    public class PostRoleBll : BaseBll<PostRoleBll>
    {
        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public RolePostResponse PostRole(RolePostRequest request)
        {
            RolePostResponse response = new RolePostResponse();
            if (string.IsNullOrEmpty(request.RoleAll.RoleName))
            {
                response.Status = false;
                response.Message = "角色名称为空";
                return response;
            }

            var str = PostRoleDal.Instance.PostRole(request.RoleAll);
            if (str < 0)
            {
                response.Status = false;
                response.Message = "出错了";
            }
            else
            {
                response.Message = "恭喜成功";
            }
            return response;
        }
    }
}
