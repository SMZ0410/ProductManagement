using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response
{
    /// <summary>
    /// 获取用户信息返回类
    /// </summary>
    public class UserGetResponse : BaseResponse
    {
        /// <summary>
        /// 返回的用户信息集合
        /// </summary>
        public List<UserInfo> Users { get; set; }
    }
}
