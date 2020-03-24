using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.DropDownList
{
    public class DropDownStageRequest:BaseRequest
    {
        public override string GetApiName()
        {
            return "api/Product/GetStages";
        }
    }
}
