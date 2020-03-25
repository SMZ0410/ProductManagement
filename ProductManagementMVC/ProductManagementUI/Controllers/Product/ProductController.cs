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
        public JsonResult GetProducts()
        {
            ProductGetRequest getRequest = new ProductGetRequest();
            return Json(ProductBll.Instance.GetProducts(getRequest), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取应用行业信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTreade()
        {
            DropDownTreadeRquest getTreade = new DropDownTreadeRquest();
            return Json(ProductBll.Instance.GetTreades(getTreade));
        }
        /// <summary>
        /// 获取产品阶段信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetStages()
        {
            DropDownStageRequest getStage = new DropDownStageRequest();
            return Json(ProductBll.Instance.GetStages(getStage));
        }
        /// <summary>
        /// 获取归属地
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAddress()
        {
            DropDownAddressRequest getAddress = new DropDownAddressRequest();
            return Json(ProductBll.Instance.GetAddress(getAddress));
        }
        /// <summary>
        /// 获取产品经理信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetManage()
        {
            DropDownManageRequest getAddress = new DropDownManageRequest();
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
        public JsonResult AddProduct()
        {
            ProductAddRequest addRequest = new ProductAddRequest();
            return Json(ProductBll.Instance.AddProduct(addRequest));
        }
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteProduct()
        {
            ProductDeleteRequest request = new ProductDeleteRequest();
            return Json(ProductBll.Instance.DeleteProducts(request));
        }

    }
}