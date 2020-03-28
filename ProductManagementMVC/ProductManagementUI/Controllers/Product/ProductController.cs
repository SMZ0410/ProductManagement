using BLL.Product;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProductManagementUI.Models;
using SDKClient.Api.Request.DropDownList;


namespace ProductManagementUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        /// <summary>
        /// 产品列表显示
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductInfoPage()
        {
            return View();
        }
        /// <summary>
        /// 获取产品列表信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProducts(ProductGetRequest getRequest)
        {
            return Json(ProductBll.Instance.GetProducts(getRequest), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取应用行业信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTreade(DropDownTreadeRquest getTreade)
        {
            return Json(ProductBll.Instance.GetTreades(getTreade));
        }
        /// <summary>
        /// 获取产品阶段信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStages(DropDownStageRequest getStage)
        {
            return Json(ProductBll.Instance.GetStages(getStage));
        }
        /// <summary>
        /// 获取归属地
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAddress(DropDownAddressRequest getAddress)
        {
            return Json(ProductBll.Instance.GetAddress(getAddress));
        }
        /// <summary>
        /// 获取产品经理信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetManage(DropDownManageRequest getAddress)
        {
            return Json(ProductBll.Instance.GetManage(getAddress));
        }

        /// <summary>
        /// 添加产品视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductAddPage()
        {
            return View();
        }
        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <returns></returns>
        public JsonResult AddProduct(ProductAddRequest addRequest)
        {
            return Json(ProductBll.Instance.AddProduct(addRequest));
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteProduct(ProductDeleteRequest request)
        {
            return Json(ProductBll.Instance.DeleteProducts(request));
        }

        /// <summary>
        /// 编辑产品视图
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductUpdatePage(int pid)
        {
            ViewBag.pid = pid;
            return View();
        }

        /// <summary>
        /// 获取产品单条信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult EditProduct(ProductEditRequest request)
        {
            return Json(ProductBll.Instance.EditProducts(request));
        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateProduct(ProductUpdateRequest request)
        {
            return Json(ProductBll.Instance.UpdateProducts(request));
        }

    }
}