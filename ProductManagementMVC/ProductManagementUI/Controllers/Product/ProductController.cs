using BLL.Product;
using SDKClient.Api.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProductManagementUI.Models;

namespace ProductManagementUI.Controllers
{
    public class ProductController : Controller
    {
        ProductBll bll = new ProductBll();

        // GET: Product
        //产品列表显示
        public ActionResult Index()
        {
            List<ProductInfo> list = new List<ProductInfo>();

            return View(list);
        }

        public JsonResult GetProductShow()
        {
            ProductGetRequest getRequest = new ProductGetRequest();
            return Json(bll.GetProducts(getRequest));
        }
    }
}