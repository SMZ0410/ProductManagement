﻿using BLL.User;
using ProductManagementUI.Models.User;
using SDKClient.Api.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDKClient.Api.Request;



namespace ProductManagementUI.Controllers
{
    public class UserController : Controller
    {

        /*
         * 页面用 功能名称+Page   例如 UserLoginPage 
         * 方法直接 功能名称 UserLogin
         */

        // GET: User
        /// <summary>
        /// 用户登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLoginPage()
        {
            return View();
        }

       /// <summary>
       /// 用户登录方法
       /// </summary>
        public JsonResult UserLogin(UserLoginRequest request)
        {
            return Json(UserBll.Instance.UserLogin(request),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 显示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserShow()
        {
            return View();
        }

        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUsers()
        {
            UserGetRequest getRequest = new UserGetRequest();
            return Json(UserBll.Instance.GetUsers(getRequest), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 忘记密码 重置密码页面
        /// </summary>
        public ActionResult ResetPasswordPage()
        {
            return View();
        }
    }
}