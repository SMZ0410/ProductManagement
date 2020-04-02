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
using Model;

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
        private readonly string connStr = ConfigurationManager.AppSettings["connectionString"];



        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUsers(string uname)
        {
            List<UserInfo> list = new List<UserInfo>();
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT u.UserId,u.UserName,a.AddressName,ro.RoleName FROM dbo.UserInfo u
                                    JOIN dbo.UserAddressMapInfo ua ON ua.UserId = u.UserId
                                    JOIN dbo.AddressInfo a ON a.AddressId = ua.AddressId
                                    JOIN dbo.UserRoleMapInfo r ON r.UserId = u.UserId
                                    JOIN dbo.RoleInfo ro ON ro.RoleId = r.RoleId WHERE u.Status = 1 AND u.UserName LIKE @username";
                list = conn.Query<UserInfo>(sql, new { username = "%" + uname + "%" }).ToList();
                return list;
            }
        }

        /// <summary>
        /// 根据用户名获取用户的盐
        /// </summary>
        /// <returns></returns>
        public string GetSaltByUserName(string userName)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT Salt FROM dbo.UserInfo WHERE UserName = @username";

                var saltStr = conn.QueryFirstOrDefault<string>(sql, new { username = userName });
                //返回
                return saltStr;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户登录信息</param>
        /// <returns></returns>
        public UserLogModel UserLogin(UserLogModel user)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT u.UserId, u.UserName,r.RoleName FROM dbo.UserInfo u
                                        JOIN dbo.UserRoleMapInfo m ON u. UserId = m.UserId
                                        JOIN dbo.RoleInfo r ON m.RoleId = r.RoleId
                                        WHERE UserName = @username  AND UserPassword = @userpassword";

                //获取用户信息并返回 
                var userinfo = conn.QueryFirstOrDefault<UserLogModel>(sql, new { username = user.UserName, userpassword = user.UserPassword });
                return userinfo;
            }
        }

        /// <summary>
        /// 获得地址的下拉值
        /// </summary>
        /// <returns></returns>
        public List<AddressInfo> GetAddress()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<AddressInfo> list = new List<AddressInfo>();
                var sql = "SELECT AddressName FROM dbo.AddressInfo";
                list = conn.Query<AddressInfo>(sql).ToList();
                return list;
            }


        }

        /// <summary>
        /// 获取角色的下拉值
        /// </summary>
        /// <returns></returns>
        public List<RoleInfos> GetRoles()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<RoleInfos> list = new List<RoleInfos>();
                var sql = $"SELECT * FROM dbo.RoleInfo";
                list = conn.Query<RoleInfos>(sql).ToList();
                return list;
            }
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int UserAdd(UserAdd users)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                var sql = @"EXEC dbo.P_UserAddInfo  @userName, 
                               @userPassword,
                                @salt, 
                               @email,
                                 @creatorId, 
                                 @roleId, @addressId ";

                var iu = conn.Execute(sql, new { userName = users.UserName, userPassword = users.UserPassword, salt = users.Salt, email = users.Email, creatorId = users.CreatorId, roleId = users.RoleId, addressId = users.AddressId });
                return iu;
            }

        }

        /// <summary>
        /// 根据用户名&邮箱判断该用户是否存在
        /// 返回用户id
        /// </summary>
        public int IsExistUserNameEmail(string userName, string email)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = $"SELECT * FROM dbo.UserInfo WHERE UserName = @tusername AND Email=@temail";
                int userId = conn.QueryFirstOrDefault<int>(sql, new { tusername = userName, temail = email });
                return userId;
            }
        }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <returns>影响行数</returns>
        public int ResetUserPasswod(string userName, string newPassword)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE dbo.UserInfo SET UserPassword=@userpassword WHERE UserName=@username  ";
                int res = conn.Execute(sql, new { userpassword = newPassword, username = userName });
                return res;
            }
        }

        /// <summary>
        /// 修改个人密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int UpdateUserPassword(UserUpdatePassword user)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE dbo.UserInfo SET UserPassword=@userpassword WHERE UserId =@userid";
                var res = conn.Execute(sql, new { userpassword = user.UserPassword, userid = user.UserId });
                return res;
            }
        }

        /// <summary>
        /// 逻辑删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UserDelete(string id)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = $"UPDATE  dbo.UserInfo SET Status=0 WHERE UserId in (" + id + ")";
                var res = conn.Execute(sql, new { ID = id });
                return res;
            }

        }
        /// <summary>
        /// 获取用户胡的单条信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public UserEditInfo EditUser(int uid)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                UserEditInfo info = new UserEditInfo();
                string sql = @"SELECT u.UserId,u.UserName,a.AddressName,ro.RoleName FROM dbo.UserInfo u
                                    JOIN dbo.UserAddressMapInfo ua ON ua.UserId = u.UserId
                                    JOIN dbo.AddressInfo a ON a.AddressId = ua.AddressId
                                    JOIN dbo.UserRoleMapInfo r ON r.UserId = u.UserId
                                    JOIN dbo.RoleInfo ro ON ro.RoleId = r.RoleId where u.UserId={ " + uid + "}";
                info = conn.QueryFirstOrDefault<UserEditInfo>(sql, new { id = uid });
                return info;
            }
        }

        /// <summary>
        /// 修改用户信息。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UserUpt(UserUptInfo info)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {

                string sql = @"EXEC dbo.P_UserUpt @userId ,
                                        @userName , @userPassword , 
                                        @salt , @email , @creatorId , 
                                        @role,   @addressId  ";
                var res = conn.Execute(sql, new { userId = info.UserId, userName = info.UserName, userPassword = info.UserPassword, salt = info.Salt, email = info.Email, creatorId = info.CreatorId, role = info.RoleId, addressId = info.AddressId });
                return res;
            }
        }

    }
}
