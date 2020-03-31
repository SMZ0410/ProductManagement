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
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public int CreatorId { get; set; }
        public int RoleId { get; set; }
        public int AddressId { get; set; }



    }
}
