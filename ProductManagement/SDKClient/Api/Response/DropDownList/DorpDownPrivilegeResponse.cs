using Model.RoleInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.DropDownList
{
    public class DorpDownPrivilegeResponse:BaseResponse
    {
        /// <summary>
        /// 返回权限集合
        /// </summary>
        public List<PrivilegeModel>  Privileges { get; set; }
    }
}
