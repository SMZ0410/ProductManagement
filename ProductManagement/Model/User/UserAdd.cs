using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    public class UserAdd
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 盐
        /// </summary>
        public string Salt { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 当前登录人id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 地址id
        /// </summary>
        public int AddressId { get; set; }
    }
}
