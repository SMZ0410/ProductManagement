using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.User; 
using Dapper;
using System.Data;

namespace DAL.User
{
    /// <summary>
    /// 用户数据交互层
    /// </summary>
    public class UserDal : BaseDal<UserDal>
    {
        /// <summary>
        /// 获取连接数据库字符串
        /// </summary>
        private static string connStr = ConfigurationManager.AppSettings["connectionString"]; 

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUsers()
        {
            List<UserInfo> list = new List<UserInfo>();
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                string sql = @"SELECT u.UserId,u.UserName,a.AddressName,r.RoleName FROM dbo.UserInfo u 
                                        JOIN dbo.UserAddressMapInfo m1 ON u.UserId=m1.UserId
                                        JOIN dbo.AddressInfo a ON a.AddressId=m1.AddressId
                                        JOIN dbo.UserRoleMapInfo m2 ON m2.UserId=u.UserId
                                        JOIN dbo.RoleInfo r ON m2.RoleId=r.RoleId WHERE u.Status=1";
                list = conn.Query<UserInfo>(sql).ToList();
                return list;
            }
        }
    }
}
