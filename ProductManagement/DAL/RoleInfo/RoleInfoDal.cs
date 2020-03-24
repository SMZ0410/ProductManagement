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
                string sql = @"SELECT ri.RoleId,ri.RoleName,p.privilegeName,
                                        (SELECT COUNT(*) FROM dbo.UserInfo)AS UserNum FROM dbo.RoleInfo ri 
                                        JOIN RolePrivilegeMapInfo rp ON ri.RoleId = rp.RoleId 
                                        JOIN PrivilegeInfo p ON rp.PrivilegeId = p.PrivilegeId 
                                        JOIN dbo.UserRoleMapInfo u ON ri.RoleId = u.RoleId 
                                        JOIN dbo.UserInfo ui ON ui.UserId = u.RoleId WHERE ri.RoleName LIKE @rolename AND ri.Status = 1";

                list = coon.Query<RoleInfoModel>(sql, new { rolename = "%"+RoleName+"%" }).ToList();
                return list;
            }
        }

    }
}
