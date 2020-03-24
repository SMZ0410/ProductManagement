using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.DropDownList
{
    public class DropDownManageRequest:BaseRequest
    {
        public override string GetApiName()
        {
            return "api/Product/GetManages";
        }
    }
}
