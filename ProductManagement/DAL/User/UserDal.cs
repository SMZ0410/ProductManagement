﻿using System;
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
        private readonly string  connStr = ConfigurationManager.AppSettings["connectionString"];


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
        public int UserLogin(UserLogin user)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT UserId FROM dbo.UserInfo WHERE UserName=@username AND UserPassword=@userpassword";

                //获取用户id并返回
                var userId = conn.QueryFirstOrDefault<int>(sql, new { username = user.UserName, userpassword = user.UserPassword });
                return userId;
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
                

            }
            return 0;
        }

        /// <summary>
        /// 根据用户名&邮箱判断该用户是否存在
        /// 返回用户id
        /// </summary>
        public int IsExistUserNameEmail(string userName,string email)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT UserId FROM dbo.UserInfo WHERE UserName = @tusername AND Email=@temail";
                int userId =conn.QueryFirstOrDefault<int>(sql,new { tusername =userName, temail =email});
                return userId;
            }
        }
         
        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <returns>影响行数</returns>
        public int ResetUserPasswod(string userName,string newPassword)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE dbo.UserInfo SET UserPassword=@userpassword WHERE UserName=@username  ";
                int res = conn.Execute(sql, new { userpassword = newPassword, username = userName});
                return res;
            }
        }

    }
}
