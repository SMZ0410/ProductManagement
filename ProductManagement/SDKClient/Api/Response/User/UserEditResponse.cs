using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.User
{
    public class UserEditResponse : BaseResponse
    {
        public UserEditInfo UserEdit { get; set; }
    }
}
