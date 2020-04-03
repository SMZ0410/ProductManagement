using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Configuration;
using Model;
using Model.RoleInfo;
using System.Data.SqlClient;

namespace DAL.RoleInfo
{
    public class RoleInfoDal : BaseDal<RoleInfoDal>
    {
        private string conStr = ConfigurationManager.AppSettings["connectionString"];

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<RoleInfoModel> GetRoleInfos(string RoleName)
        {
            List<RoleInfoModel> list = new List<RoleInfoModel>();
            using (IDbConnection coon = new SqlConnection(conStr))
            {
                string sql = @"SELECT r.RoleId,r.RoleName,p.privilegeName,t.UserNum
                                        FROM dbo.RoleInfo r 
                                        JOIN dbo.RolePrivilegeMapInfo m ON r.RoleId=m.RoleId
                                        JOIN dbo.PrivilegeInfo p ON p.PrivilegeId=m.PrivilegeId
                                        INNER JOIN 
                                        (SELECT  r.RoleId,COUNT(1) AS UserNum FROM dbo.RoleInfo r 
                                        JOIN dbo.UserRoleMapInfo m ON m.RoleId=r.RoleId
                                        JOIN dbo.UserInfo u ON m.UserId =u.UserId 
                                        GROUP BY r.RoleId) AS t ON r.RoleId=t.RoleId
                                        WHERE  r.RoleName LIKE @rolename AND r.Status = 1";

                list = coon.Query<RoleInfoModel>(sql, new { rolename = "%"+RoleName+"%" }).ToList();
                return list;
            }
        }

    }
}
