
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ApiRequest;
using SDKClient.Api.Request.DropDownList;
using SDKClient.Api.Request.User;
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Response.User;

namespace BLL.User
{
    /// <summary>
    /// 
    /// </summary>
    public class UserBll : BaseBll<UserBll>
    {

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public UserGetResponse GetUsers(UserGetRequest request)
        {
            return ApiRequestHelper.Post<UserGetRequest, UserGetResponse>(request);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public UserLoginResponse UserLogin(UserLoginRequest request)
        {
            return ApiRequestHelper.Post<UserLoginRequest, UserLoginResponse>(request);
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserAddResponse UserAdd(UserAddRequest request)
        {
            return ApiRequestHelper.Post<UserAddRequest, UserAddResponse>(request);
        }

        /// <summary>
        /// 忘记密码 发送更改密码地址到用户邮箱
        /// </summary>
        /// <returns></returns>
        public UserForgotPwdResponse ForgotPassword(UserForgotPwdRequest request)
        {
            return ApiRequestHelper.Post<UserForgotPwdRequest, UserForgotPwdResponse>(request);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public UserResetPwdResponse ResetPassword(UserResetPwdRequest request)
        {
            return ApiRequestHelper.Post<UserResetPwdRequest, UserResetPwdResponse>(request);
        }

        /// <summary>
        /// 获取地址下拉表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            return ApiRequestHelper.Post<DropDownAddressRequest, DropDownAddressReponse>(request);
        }
        /// <summary>
        /// 获取角色下拉表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DropDownRoleReponse GetRoles(DropDownRoleRequest request)
        {
            return ApiRequestHelper.Post<DropDownRoleRequest, DropDownRoleReponse>(request);
        }

        /// <summary>
        /// 获取用户单条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserEditResponse UserEdit(UserEditRequest request)
        {
            return ApiRequestHelper.Post<UserEditRequest, UserEditResponse>(request);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserDeleteResponse UserDelete(UserDeleteRequest request)
        {
            return ApiRequestHelper.Post<UserDeleteRequest, UserDeleteResponse>(request);
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserUptResponse UserUpt(UserUptRequest request)
        {
            return ApiRequestHelper.Post<UserUptRequest, UserUptResponse>(request);
        }

        /// <summary>
        /// 修改个人密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserUpdPwdResponse UpdateUserPassword(UserUpdPwdRequest request)
        {
            return ApiRequestHelper.Post<UserUpdPwdRequest, UserUpdPwdResponse>(request);
        }
    }
}
