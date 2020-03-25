using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.DropDownList
{
    public class DropDownAddressRequest:BaseRequest
    {
        /// <summary>
        /// 萨达
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/Product/GetAddress";
        }
    }
}
