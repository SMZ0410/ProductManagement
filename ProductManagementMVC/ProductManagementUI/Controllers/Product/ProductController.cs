using BLL.Product;
using SDKClient.Api.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProductManagementUI.Models;
using SDKClient.Api.Response;

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

    }
}