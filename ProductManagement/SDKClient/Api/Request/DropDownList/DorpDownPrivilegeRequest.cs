using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.DropDownList
{
    public class DorpDownPrivilegeRequest:BaseRequest
    {
        /// <summary>
        /// 重写基类路径
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/Role/GePrivilege";
        }
    }
}
