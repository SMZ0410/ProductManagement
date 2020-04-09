using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementUI.Controllers
{

    //七组无敌！！！！
    public class HomeController : Controller
    {
        public ActionResult Index(string userName="",string roleName="",int userId=0,string privilegeName="")
        {
            if (!string.IsNullOrEmpty(userName))
            {
                Session["UserName"] = userName;
            }
            if (!string.IsNullOrEmpty(roleName))
            {
                Session["RoleName"] = roleName;
            }
            if (userId>0)
            {
                Session["UserId"] = userId;
            }
            if (!string.IsNullOrEmpty(privilegeName))
            {
                Session["privilegeName"] = privilegeName;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}