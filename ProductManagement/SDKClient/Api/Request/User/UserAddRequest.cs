using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{
    /// <summary>
    /// 用户添加请求
    /// </summary>
    public  class UserAddRequest : BaseRequest
    {
        public UserAdd Users { get; set; }
        public override string GetApiName()
        {
            return "api/User/UserAdd";
        }
    }
}
