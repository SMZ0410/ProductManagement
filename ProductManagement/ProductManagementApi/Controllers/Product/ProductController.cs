using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Product;
using ProductManagementApi.Auth;
using SDKClient.Api.Request;
using SDKClient.Api.Request.DropDownList;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response.DropDownList;
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
        /// <summary>
        /// 获取应用行业信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public DropDownTreadeResponse GetTreade(DropDownTreadeRquest request)
        {
            return ProductBll.Instance.GetTreade(request);
        }
        /// <summary>
        /// 获取产品阶段信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public DropDownStageReponse GetStages(DropDownStageRequest request)
        {
            return ProductBll.Instance.GetStages(request);
        }
        /// <summary>
        /// 获取归属地信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            return ProductBll.Instance.GetAddress(request);
        }
        /// <summary>
        /// 获取产品经理信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public DropDownManageReponse GetManages(DropDownManageRequest request)
        {
            return ProductBll.Instance.GetManages(request);
        }
    }
}
