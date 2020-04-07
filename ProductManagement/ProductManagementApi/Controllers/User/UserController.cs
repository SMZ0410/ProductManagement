using BLL.User;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductManagementApi.Auth;
using SDKClient.Api.Request.User;
using SDKClient.Api.Response.User;
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Request.DropDownList;

namespace ProductManagementApi.Controllers.User
{
    /// <summary>
    /// 用户Api控制器
    /// </summary> 
    //[ApiAuthorize] 
    public class UserController : ApiController
    {

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public UserGetResponse GetUsers(UserGetRequest request)
        {
            return UserBll.Instance.GetUsers(request);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            return UserBll.Instance.UserLogin(request);
        }

        /// <summary>
        /// 忘记密码 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserForgotPwdResponse ForgotPassword(UserForgotPwdRequest request)
        {
            return UserBll.Instance.ForgotPassword(request);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        [HttpPost]
        public UserResetPwdResponse ResetUserPassword(UserResetPwdRequest request)
        {
            return UserBll.Instance.ResetUserPassword(request);
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserAddResponse UserAdd(UserAddRequest request)
        {
            return UserBll.Instance.UserAdd(request);
        }
        /// <summary>
        /// 地址下拉
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            return UserBll.Instance.GetAddress(request);
        }

        /// <summary>
        /// 角色下拉
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public DropDownRoleReponse GetRoles(DropDownRoleRequest request)
        {
            return UserBll.Instance.GetRoles(request);
        }

        /// <summary>
        /// 逻辑删除用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserDeleteResponse UserDelete(UserDeleteRequest request)
        {
            return UserBll.Instance.UserDelete(request);
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserEditResponse UserEdit(UserEditRequest request)
        {
            return UserBll.Instance.UserEdit(request);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public UserUptResponse UserUpt(UserUptRequest request)
        {
            return UserBll.Instance.UserUpt(request);
        }

        /// <summary>
        /// 修改个人密码
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserUpdPwdResponse UpdateUserPassword(UserUpdPwdRequest request)
        {
            return UserBll.Instance.UpdateUserPassword(request);
        }
    }
}