using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.Role
{
    public class RoleByIdRequest : BaseRequest
    {
        //反填

        public int RoleId { get; set; }

        public override string GetApiName()
        {
            return "api/Role/GetRoleById";
        }
    }
}
