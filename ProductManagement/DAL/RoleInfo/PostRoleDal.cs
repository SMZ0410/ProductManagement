using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.RoleInfo;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Dapper;

namespace DAL.RoleInfo
{
    public class PostRoleDal : BaseDal<PostRoleDal>
    {
        private string conStr = ConfigurationManager.AppSettings["connectionString"];

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="postRole"></param>
        /// <returns></returns>
        public int PostRole(PostRoleModel postRole)
        {

            using (IDbConnection coon = new SqlConnection(conStr))
            {
                var sql = @"EXEC dbo.p_RoleAdd @roleName,
                                                @roleDescribe,
                                                @creatorId,
                                                @privilegeId ";
                var result = coon.Execute(sql, new { roleName = postRole.RoleName, roleDescribe = postRole.RoleDescribe, creatorId = postRole.CreatorId, privilegeId = postRole.PrivilegeId });

                return result;
            }
        }

        /// <summary>
        /// 获取权限的下拉值
        /// </summary>
        /// <returns></returns>
        public List<PrivilegeModel> GetPrivilege()
        {
            using (IDbConnection conn = new SqlConnection(conStr))
            {
                List<PrivilegeModel> list = new List<PrivilegeModel>();
                var sql = $"SELECT * FROM dbo.PrivilegeInfo";
                list = conn.Query<PrivilegeModel>(sql).ToList();
                return list;
            }
        }
    }
}
