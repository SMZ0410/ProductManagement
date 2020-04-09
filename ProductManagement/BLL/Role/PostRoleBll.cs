using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RoleInfo;
using SDKClient.Api.Request.DropDownList;
using SDKClient.Api.Request.Role;
using SDKClient.Api.Response.DropDownList;
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

        /// <summary>
        /// 获得权限的下拉值
        /// </summary>
        /// <returns></returns>
        public DorpDownPrivilegeResponse GetPrivilege(DorpDownPrivilegeRequest request)
        {
            DorpDownPrivilegeResponse reponse = new DorpDownPrivilegeResponse();
            var list = PostRoleDal.Instance.GetPrivilege();
            if (list.Count <= 0)
            {
                reponse.Message = "获取失败，请稍后再试";
                reponse.Status = false;
            }
            else
            {

                reponse.Privileges = list;
                reponse.Message = $"获取数据成功，共获取{list.Count}条数据";
            }

            return reponse;
        }
    }
}
