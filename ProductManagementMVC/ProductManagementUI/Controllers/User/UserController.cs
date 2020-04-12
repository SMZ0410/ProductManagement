using BLL.User;
using ProductManagementUI.Models.User;
using SDKClient.Api.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDKClient.Api.Request;
using SDKClient.Api.Request.DropDownList;

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
            //获取cookie中的数据
            HttpCookie hc = Request.Cookies.Get("Example");

            //判断cookie是否空值
            if (hc != null)
            {
                //把保存的用户名和密码赋值给对应的文本框
                //用户名
                var name = HttpUtility.UrlDecode(hc.Values["UserName"].ToString());
                ViewBag.UserName = name;
                //密码
                var pwd = hc.Values["UserPassword"].ToString();
                ViewBag.UserPassword = pwd;
            }
            return View();
        }

        /// <summary>
        /// 用户登录方法
        /// </summary>
        public JsonResult UserLogin(UserLoginRequest request)
        {
            return Json(UserBll.Instance.UserLogin(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 记住密码
        /// </summary>
        public void RememberPassword(UserLogin user, bool ck)
        {
            if (ck)
            {
                HttpCookie hc = new HttpCookie("Example");
                //在cookie对象中保存用户名和密码
                hc["UserName"] = HttpUtility.UrlEncode(user.UserName);
                hc["UserPassword"] = user.UserPassword;
                //设置过期时间
                hc.Expires = DateTime.Now.AddDays(7);
                //保存到客户端
                Response.Cookies.Add(hc);
            }
            else
            {
                HttpCookie hc = new HttpCookie("Example");
                //判断hc是否空值
                if (hc != null)
                {
                    //设置过期时间
                    hc.Expires = DateTime.Now.AddDays(-1);
                    //保存到客户端
                    Response.Cookies.Add(hc);
                }

            }
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
        public JsonResult GetUsers(UserGetRequest getRequest)
        {
            return Json(UserBll.Instance.GetUsers(getRequest), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 忘记密码 发送邮件到用户邮箱页面
        /// </summary>
        public ActionResult ForgotPasswordPage()
        {
            return View();
        }

        /// <summary>
        /// 忘记密码 发送邮件到用户邮箱
        /// </summary>
        /// <returns></returns>
        public JsonResult ForgotPassword(UserForgotPwdRequest request)
        {
            return Json(UserBll.Instance.ForgotPassword(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 重置密码页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetUserPasswordPage(string userName)
        {
            ViewBag.UserName = userName;
            return View();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public JsonResult ResetUserPassword(UserResetPwdRequest request)
        {
            return Json(UserBll.Instance.ResetPassword(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns>
        public ActionResult UserAdd()
        {
            return View();
        }
        [HttpPost]
        /// <summary>
        /// 获取用户添加信息方法
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GeUserAdd(UserAddRequest request)
        {
            return Json(UserBll.Instance.UserAdd(request));
        }

        /// <summary>
        /// 获取归属地
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAddress()
        {
            DropDownAddressRequest getAddress = new DropDownAddressRequest();
            return Json(UserBll.Instance.GetAddress(getAddress));
        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoles()
        {
            DropDownRoleRequest getAddress = new DropDownRoleRequest();
            return Json(UserBll.Instance.GetRoles(getAddress));
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UserUpdate(int uid)
        {
            ViewBag.uid = uid;
            return View();
        }

        /// <summary>
        /// 逻辑删除用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult UserDelete(UserDeleteRequest getAddress)
        {
            return Json(UserBll.Instance.UserDelete(getAddress));
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult UserEdit(UserEditRequest request)
        {
            return Json(UserBll.Instance.UserEdit(request));
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult UserUpt(UserUptRequest request)
        {
            return Json(UserBll.Instance.UserUpt(request));
        }

        /// <summary>
        /// 修改个人密码页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUserPasswordPage()
        {
            return View();
        }

        /// <summary>
        /// 修改个人密码
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateUserPassword(UserUpdPwdRequest request)
        {
            return Json(UserBll.Instance.UpdateUserPassword(request));
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        public void Logout()
        {
            Session.Clear();
            Response.Write("<script>location.href = '/User/UserLoginPage';</script>");
        }
    }
}