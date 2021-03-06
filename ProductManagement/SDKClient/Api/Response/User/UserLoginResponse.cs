﻿using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.User
{
    /// <summary>
    /// 用户登录返回
    /// </summary>
    public class UserLoginResponse : BaseResponse
    {
        /// <summary>
        /// 返回用户信息
        /// </summary>
        public UserLogModel User { get; set; }
    }
}
