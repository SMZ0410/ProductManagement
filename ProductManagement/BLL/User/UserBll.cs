﻿using DAL.User;
using SDKClient.Api.Request.User;
using SDKClient.Api.Response;
using SDKClient.Api.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.User;
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Request.DropDownList;

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

         

            //根据用户名获取用户的盐
            string salt = UserDal.Instance.GetSaltByUserName(request.User.UserName);

            //将密码和盐拼接进项MD5加密 
            string password = MD5Encrypt.MD5Encrypt32(request.User.UserPassword + salt);

            //给request参数重新赋值加密后的密码
            request.User.UserPassword = password;

            //调用dal层方法 拿到返回id
            var user = UserDal.Instance.UserLogin(request.User);

            //如果id>0登陆成功
            if (user != null)
            {
                //修改用户最后登录时间
                int res = UserDal.Instance.SetUserLastLoginTime(user.UserName);
                if (res > 0)
                {
                    response.Message = "登陆成功！";
                    response.User = user;
                }
                else
                {
                    response.Status = false;
                    response.Message = "登录失败，密码错误";
                } 
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

            //判断新密码是否和旧密码一致
            var uid = UserDal.Instance.CheckPassword(decryptusername, encryptionPassword);
            if (uid > 0)
            {
                response.Status = false;
                response.Message = "不能使用最近使用过的密码，请重新输入";
                return response;
            }


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


        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserAddResponse UserAdd(UserAddRequest request)
        {
            UserAddResponse response = new UserAddResponse();
            //非空判断
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
            if (string.IsNullOrEmpty(request.User.Email))
            {
                response.Status = false;
                response.Message = "邮箱为空";
                return response;
            }
            if (request.User.AddressId <= 0)
            {
                response.Status = false;
                response.Message = "请选择地址";
                return response;
            }
            if (request.User.RoleId <= 0)
            {
                response.Status = false;
                response.Message = "请选择角色";
                return response;
            }
            if (request.User.CreatorId <= 0)
            {
                response.Status = false;
                response.Message = "系统繁忙，creatorid<=0";
                return response;
            }
            //判断用户名是否已被注册
            int uid = UserDal.Instance.UserNameExist(request.User.UserName);
            if (uid > 0)
            {
                response.Status = false;
                response.Message = "用户名已存在";
                return response;
            }

            //开始获取盐
            var salt = Generate.GenerateSalt();
            //获取md5加密密码
            var pwd = MD5Encrypt.MD5Encrypt32(request.User.UserPassword + salt);
            request.User.UserPassword = pwd;
            request.User.Salt = salt;
            var res = UserDal.Instance.UserAdd(request.User);
            if (res < 0)
            {
                response.Status = false;
                response.Message = "添加失败";
            }
            else
            {
                response.Message = "添加成功";
            }
            return response;
        }

        /// <summary>
        /// 获得地址的下拉值
        /// </summary>
        /// <returns></returns>
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            DropDownAddressReponse reponse = new DropDownAddressReponse();
            var list = UserDal.Instance.GetAddress();
            if (list.Count <= 0)
            {
                reponse.Message = "获取失败，请稍后再试";
                reponse.Status = false;
            }
            else
            {

                reponse.TrAddress = list;
                reponse.Message = $"获取数据成功，共获取{list}条数据";
            }

            return reponse;
        }

        /// <summary>
        /// 获取角色的下拉值
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DropDownRoleReponse GetRoles(DropDownRoleRequest request)
        {
            DropDownRoleReponse reponse = new DropDownRoleReponse();
            var list = UserDal.Instance.GetRoles();
            if (list.Count <= 0)
            {
                reponse.Message = "获取失败，请稍后再试";
                reponse.Status = false;
            }
            else
            {

                reponse.Roles = list;
                reponse.Message = $"获取数据成功，共获取{list}条数据";
            }

            return reponse;
        }

        /// <summary>
        /// 逻辑删除用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserDeleteResponse UserDelete(UserDeleteRequest request)
        {
            UserDeleteResponse response = new UserDeleteResponse();

            var res = UserDal.Instance.UserDelete(request.ID);
            if (res <= 0)
            {
                response.Status = false;
                response.Message = "删除失败，请重试";
            }
            else
            {
                response.Status = true;
                response.Message = "删除成功";
            }
            return response;
        }

        /// <summary>
        /// 修改个人密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserUpdPwdResponse UpdateUserPassword(UserUpdPwdRequest request)
        {
            UserUpdPwdResponse response = new UserUpdPwdResponse();
            if (request.User.UserId <= 0)
            {
                response.Status = false;
                response.Message = "网络错误，请重新登录 userid<=0";
                return response;
            }
            if (string.IsNullOrEmpty(request.User.UserPassword))
            {
                response.Status = false;
                response.Message = "请输入新密码";
                return response;
            }

            //获取用户盐
            var salt = UserDal.Instance.GetSaltByUserName(request.User.UName);

            //加密用户密码
            var password = MD5Encrypt.MD5Encrypt32(request.User.UserPassword + salt);

            //判断新密码是否和旧密码一致
            var uid = UserDal.Instance.CheckPassword(request.User.UName, password);
            if (uid > 0)
            {
                response.Status = false;
                response.Message = "不能使用最近使用过的密码，请重新输入";
                return response;
            }

            //给对象赋值
            request.User.UserPassword = password;

            //调用dal层方法ResetUserPasswod
            int res = UserDal.Instance.UpdateUserPassword(request.User);
            if (res > 0)
            {
                response.Message = "修改成功，请重新登录";
            }
            else
            {
                response.Status = false;
                response.Message = "修改失败，请检查网络";
            }
            return response;
        }

        /// <summary>
        /// 获取单挑数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserEditResponse UserEdit(UserEditRequest request)
        {
            UserEditResponse response = new UserEditResponse();
            if (request.Uid < 0)
            {
                response.Status = false;
                response.Message = "网络错误请重试";
                return response;
            }

            var res = UserDal.Instance.EditUser(request.Uid);
            if (res != null)
            {
                response.Status = true;
                response.Message = "请求成功";
                response.UserEdit = res;
            }
            return response;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserUptResponse UserUpt(UserUptRequest request)
        {
            UserUptResponse response = new UserUptResponse();
            var res = UserDal.Instance.UserUpt(request.GetUptInfo);
            //判断
            if (res <= 0)
            {
                response.Status = false;
                response.Message = "修改失败，请重试";
            }
            else
            {
                response.Status = true;
                response.Message = "修改成功哦";
            }
            return response;
        }

    }
}