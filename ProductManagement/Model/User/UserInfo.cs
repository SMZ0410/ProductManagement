using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    /// <summary>
    /// 用户管理信息
    /// </summary>
    public  class UserInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string AddressName { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleName { get; set; }
    }
}
