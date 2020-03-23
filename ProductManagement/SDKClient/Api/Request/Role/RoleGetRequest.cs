using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.Role
{
    public class RoleGetRequest : BaseRequest
    {
        public string RoleName { get; set; }

        public override string GetApiName()
        {
            return "api/Role/GetRoleInfos";
        }

    }
}
