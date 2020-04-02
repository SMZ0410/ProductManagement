using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.User
{
    /// <summary>
    /// 修改表
    /// </summary>
    public class UserUptInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        public string UserPassword { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 修改人id
        /// </summary>
        public int UpdatorId { get; set; }

        public int Salt { get; set; }

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
