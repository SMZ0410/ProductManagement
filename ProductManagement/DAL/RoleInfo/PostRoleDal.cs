using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.RoleInfo;
using System.Data.SqlClient;

namespace DAL.RoleInfo
{
    public class PostRoleDal
    {
        public int PostRole(PostRoleModel postRole)
        {
            int list = 0;
            using (SqlConnection scon = new SqlConnection("Server=.;uid=sa;pwd=1234;database=ProductManageDB"))
            {
                SqlCommand scom = new SqlCommand("AddRoleInfos", scon);
            }
            return list;
        }

    }
}
