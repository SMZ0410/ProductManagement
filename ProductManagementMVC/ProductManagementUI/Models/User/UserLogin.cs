using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementUI.Models.User
{
    /// <summary>
    /// 用户登录模型 mvc
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }

        public bool Ck { get; set; }
    }
}