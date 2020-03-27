using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RoleInfo
{
    public class PostRoleModel
    {
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
        public int CreatorId { get; set; }
        public int UpdatorId { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
        public int PrivilegeId { get; set; }
        public string privilegeName { get; set; }
        public string privilegeDescribe { get; set; }
        public int UserId { get; set; }
    }
}
