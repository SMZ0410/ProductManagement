using DAL.User;
using SDKClient.Api.Request.User;
using SDKClient.Api.Response;
using SDKClient.Api.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BLL.User
{
    public class UserBll : BaseBll<UserBll>
    {
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        public UserGetResponse GetUsers()
        {
            //实例化一个返回对象
            UserGetResponse response = new UserGetResponse();

            //拿到用户信息集合
            var list = UserDal.Instance.GetUsers();

            //判断是否有数据
            if (list.Count >= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取用户信息失败咯，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.Users = list;
                response.Message = $"获取用户信息成功，共{list.Count}条数据";
            }
            return response;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            UserLoginResponse response = new UserLoginResponse();

            //根据用户名获取用户的盐
            string salt = UserDal.Instance.GetSaltByUserName(request.User.UserName);

            //将密码和盐拼接进项MD5加密
            string password = MD5Encrypt.MD5Encrypt32(request.User.UserPassword+salt);

            //给request参数重新赋值加密后的密码
            request.User.UserPassword = password;

            //调用dal层方法 拿到返回id
            int userId = UserDal.Instance.UserLogin(request.User); 

            //如果id>0登陆成功
            if (userId>0)
            { 
                response.Message = "登陆成功！";
            }
            else
            {
                response.Status = false; 
                response.Message = "登录失败，密码错误";
            }
            //返回
            return response;
        }
    }
}
