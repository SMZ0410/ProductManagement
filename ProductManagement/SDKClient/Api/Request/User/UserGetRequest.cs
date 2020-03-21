using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.User
{

    /// <summary>
    /// 用户获取请求
    /// </summary>
    public class UserGetRequest:BaseRequest
    {

        /// <summary>
        /// 重写基类路径
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/User/GetUsers";
        }
    }
}
