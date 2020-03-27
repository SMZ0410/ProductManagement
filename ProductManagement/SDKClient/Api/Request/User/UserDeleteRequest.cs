using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    public class UserDeleteRequest:BaseRequest
    {
        public override string GetApiName()
        {
            return "api/User/UserDelete";
        }
    }
}
