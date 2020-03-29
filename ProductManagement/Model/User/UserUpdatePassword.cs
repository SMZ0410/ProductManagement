using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    /// <summary>
    /// 修改用户密码模型
    /// </summary>
    public class UserUpdatePassword
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string    UserPassword { get; set; }
    }
}
