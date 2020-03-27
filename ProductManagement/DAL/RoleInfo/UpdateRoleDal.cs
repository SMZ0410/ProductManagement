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
        /// 修改以及逻辑删除
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public int PutRole(PostRoleModel post)
        {
            int result;
            using (IDbConnection coon = new SqlConnection(conStr))
            {
                string sql = @"UPDATE dbo.RoleInfo SET UpdateTime = GETDATE(),UpdatorId = @updatorid,Status = 0 WHERE RoleId = @roleid";

                result = coon.Query<PostRoleModel>(sql, new { updatorid = post.UpdatorId, roleid = post.RoleId }).Count();

                return result;
            }
        }

    }
}
