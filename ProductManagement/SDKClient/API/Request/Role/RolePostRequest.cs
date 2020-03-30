using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.RoleInfo;

namespace SDKClient.Api.Request.Role
{
    public class RolePostRequest : BaseRequest
    {
        public PostRoleModel RoleAll { get; set; }

        public override string GetApiName()
        {
            return "api/Role/PostRole";
        }
    }
}
