using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDKClient.Api.Request.Role;
using BLL.Role;

namespace ProductManagementUI.Controllers.Role
{
    public class RoleController : Controller
    {
        // GET: Role
        /// <summary>
        /// 角色信息显示
        /// 优秀
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleInfos()
        {
            return View();
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRole(RoleGetRequest getRequest)
        {
            
            return Json(RoleBll.Instance.GetRoleInfos(getRequest),JsonRequestBehavior.AllowGet);
        }
    }
}