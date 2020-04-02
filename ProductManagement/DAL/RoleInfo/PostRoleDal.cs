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
                var sql = @"EXEC dbo.AddRoleInfos @RoleName,
                            @RoleDescribe,
                            @CreatorId,
                            @PrivilegeId,
                            @privilegeName,
                            @privilegeDescribe,
                            @UserId";
                var result = coon.Execute(sql, new { RoleName = postRole.RoleName, RoleDescribe = postRole.RoleDescribe, CreatorId = 0, PrivilegeId = 1, privilegeName = postRole.privilegeName, privilegeDescribe = postRole.privilegeDescribe, UserId = 1 });

                return result;
            }
        }

    }
}
