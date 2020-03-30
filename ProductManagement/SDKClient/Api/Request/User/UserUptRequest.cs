using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    public class UserUptRequest : BaseRequest
    {
        public UserUptInfo GetUptInfo { get; set; }

        public override string GetApiName()
        {
            return "api/User/UserUpt";
        }
    }
}
