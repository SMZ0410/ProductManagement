using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Model.RoleInfo;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL.RoleInfo
{
    public class UpdateRoleDal : BaseDal<UpdateRoleDal>
    {
        private string conStr = ConfigurationManager.AppSettings["connectionString"];

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int DeleteRole(PostRoleModel post)
        {
            int result;
            using (IDbConnection coon = new SqlConnection(conStr))
            {
                string sql = @"UPDATE dbo.RoleInfo SET UpdateTime = GETDATE(),UpdatorId = @updatorid,Status = 0 WHERE RoleId = @roleid";

                result = coon.Query<PostRoleModel>(sql, new { updatorid = post.UpdatorId, roleid = post.RoleId }).Count();

                return result;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int UpdateRole(PostRoleModel post)
        {
            int result;
            using (IDbConnection coon = new SqlConnection(conStr))
            {
                string sql = @"EXEC dbo.P_PutRole @RoleId,
                               @RoleName,
                               @PrivilegeId,
                               @privilegeName";

                result = coon.Query<PostRoleModel>(sql, new { RoleId = post.RoleId, RoleName = post.RoleName, PrivilegeId = post.PrivilegeId, privilegeName = post.privilegeName }).Count();

                return result;
            }
        }

    }
}
