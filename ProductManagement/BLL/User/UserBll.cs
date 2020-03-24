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
        public UserGetResponse GetUsers(UserGetRequest request)
        {
            //实例化一个返回对象
            UserGetResponse response = new UserGetResponse();

            //拿到用户信息集合
            var list = UserDal.Instance.GetUsers(request.UserName);

            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取用户信息失败，请检查网络问题";
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
            string password = MD5Encrypt.MD5Encrypt32(request.User.UserPassword + salt);

            //给request参数重新赋值加密后的密码
            request.User.UserPassword = password;

            //非空验证
            if (string.IsNullOrEmpty(request.User.UserName))
            {
                response.Status = false;
                response.Message = "用户名为空";
                return response;
            }
            if (string.IsNullOrEmpty(request.User.UserPassword))
            {
                response.Status = false;
                response.Message = "密码为空";
                return response;
            }

            //调用dal层方法 拿到返回id
            int userId = UserDal.Instance.UserLogin(request.User);

            //如果id>0登陆成功
            if (userId > 0)
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

        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserForgotPwdResponse ForgotPassword(UserForgotPwdRequest request)
        {
            UserForgotPwdResponse response = new UserForgotPwdResponse();

            if (string.IsNullOrEmpty(request.UserName))
            {
                response.Status = false;
                response.Message = "用户名为空";
                return response;
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                response.Status = false;
                response.Message = "邮箱地址为空";
                return response;
            }

            //判断用户名和邮箱是否存在一条信息里
            int userId = UserDal.Instance.IsExistUserNameEmail(request.UserName, request.Email);

            //存在 发送修改密码地址到邮箱
            //否则 返回失败信息
            if (userId > 0)
            {
                SendToEmail.UpdPwdAddrToEmail(request.UserName, request.Email);
                response.Message = "发送成功，请打开邮箱查看";
            }
            else
            {
                response.Status = false;
                response.Message = "发送失败，请检查用户名或邮箱地址";
            }

            return response;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserResetPwdResponse ResetUserPassword(UserResetPwdRequest request)
        {
            UserResetPwdResponse response = new UserResetPwdResponse();
            if (string.IsNullOrEmpty(request.UserName))
            {
                response.Status = false;
                response.Message = "用户名为空";
                return response;
            }
            if (string.IsNullOrEmpty(request.NewPassword))
            {
                response.Status = false;
                response.Message = "新密码为空";
                return response;
            }

            //解码用户名字符串
            var decryptusername = request.UserName.Decrypt();
            //将新密码加盐进行md5加密
            var salt = UserDal.Instance.GetSaltByUserName(decryptusername);
            var encryptionPassword = MD5Encrypt.MD5Encrypt32(request.NewPassword + salt);
            //调用dal层重置密码方法
            int res = UserDal.Instance.ResetUserPasswod(decryptusername, encryptionPassword);

            //如果res>0修改成功
            if (res > 0)
            {
                response.Message = "修改成功！";
            }
            else
            {
                response.Status = false;
                response.Message = "修改失败，请检查网络";
            }

            return response;
        }
    }
}