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
        /// 所在地
        /// </summary>
        public string AddressName { get; set; }
        /// <summary>
        /// 关联角色
        /// </summary>
        public string RoleName { get; set; }
    }
}
