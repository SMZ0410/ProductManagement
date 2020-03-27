using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.DropDownList
{
    public class DropDownRoleReponse : BaseResponse
    {
        /// <summary>
        /// 角色返回值
        /// </summary>
        public List<RoleInfos> Roles { get; set; }
    }
}
