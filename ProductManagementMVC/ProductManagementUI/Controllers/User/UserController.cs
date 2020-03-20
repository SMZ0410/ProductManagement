using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementUI.Controllers
{
    public class UserController : Controller
    {

        /*
         * 页面用 功能名称+Page   例如 UserLoginPage
         * 方法使用 功能名称+Action   例如 UserLoginAction
         */

        // GET: User
        public ActionResult UserLoginPage()
        {
            return View();
        }

        public void UserLoginAction()
        { 

        }
    }
}