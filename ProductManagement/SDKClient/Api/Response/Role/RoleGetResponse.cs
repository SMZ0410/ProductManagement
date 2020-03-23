using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.RoleInfo;

namespace SDKClient.Api.Response.Role
{
    public class RoleGetResponse : BaseResponse
    {
        public List<RoleInfoModel> RoleInfo { get; set; }
    }
}
