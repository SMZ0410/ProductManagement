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

                result = coon.Execute(sql, new { updatorid = post.UpdatorId, roleid = post.RoleId });

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
                string sql = @"EXEC dbo.p_UpdRole @roleId,
                                                    @roleName,
                                                    @privilegeId,
                                                    @updatorId ";

                result = coon.Query<PostRoleModel>(sql, new { roleId = post.RoleId, roleName = post.RoleName, privilegeId = post.PrivilegeId, updatorId = post.UpdatorId }).Count();

                return result;
            }
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public PostRoleModel GetRoleById(int RoleId)
        {
            using (IDbConnection coon = new SqlConnection(conStr))
            {
                PostRoleModel info = new PostRoleModel();

                string sql = @"SELECT ri.RoleName,p.PrivilegeId FROM dbo.RoleInfo ri 
                                JOIN RolePrivilegeMapInfo rp ON rp.RoleId = ri.RoleId
                                JOIN dbo.PrivilegeInfo p ON p.PrivilegeId = rp.PrivilegeId WHERE ri.RoleId = @roleId";

                info = coon.QueryFirstOrDefault<PostRoleModel>(sql, new { roleId = RoleId });
                return info;

            }
        }

    }
}
