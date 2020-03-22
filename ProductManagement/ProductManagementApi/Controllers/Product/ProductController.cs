using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Product;
using ProductManagementApi.Auth;
using SDKClient.Api.Request;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response.Product;


namespace ProductManagementApi.Controllers.Product
{
    /// <summary>
    /// 用户Api控制器
    /// </summary> 
    //[ApiAuthorize]
    public class ProductController : ApiController
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ProductGetResponse GetProducts(ProductGetRequest request)
        {
            return ProductBll.Instance.GetProducts(request);
        }
    }
}
