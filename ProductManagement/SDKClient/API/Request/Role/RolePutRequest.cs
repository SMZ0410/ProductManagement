using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.RoleInfo;

namespace SDKClient.Api.Request.Role
{
    /// <summary>
    /// 修改
    /// </summary>
    public class RolePutRequest : BaseRequest
    {
        public PostRoleModel RoleAll { get; set; }

        public override string GetApiName()
        {
            return "api/Role/PutRole";
        }
    }
}
