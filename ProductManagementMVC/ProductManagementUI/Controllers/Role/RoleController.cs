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

        /// <summary>
        /// 获取逻辑删除方法
        /// </summary>
        /// <param name="getRequest"></param>
        /// <returns></returns>
        public JsonResult DeleteRole(RoleUpdateRequest request)
        {

            return Json(RoleBll.Instance.DeleteRole(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRole()
        {
            return View();
        }

        /// <summary>
        /// 获取添加角色信息方法
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult PostRole(RolePostRequest request)
        {

            return Json(RoleBll.Instance.AddRole(request));
        }


        /// <summary>
        /// 编辑角色信息
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRole(int RoleId)
        {
            ViewBag.RoleId = RoleId;
            return View();
        }

        /// <summary>
        /// 获取修改 角色信息方法
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult PutRole(RolePutRequest request)
        {
            return Json(RoleBll.Instance.UpdateRole(request));
        }
    }
}