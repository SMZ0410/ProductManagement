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
    [ApiAuthorize]
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

        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ProductAddResponse AddProducts(ProductAddRequest request)
        {
            return ProductBll.Instance.ProductAdd(request);
        }

        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ProductDeleteResponse DeleteProduct(ProductDeleteRequest request)
        {
            return ProductBll.Instance.DeleteProduct(request);
        }

        /// <summary>
        /// 获取产品单条信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ProductEditResponse EditProduct(ProductEditRequest request)
        {
            return ProductBll.Instance.EditProduct(request);
        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ProductUpdateResponse UpdateProducts(ProductUpdateRequest request)
        {
            return ProductBll.Instance.UpdateProduct(request);
        }

        /// <summary>
        /// 获取类型信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public DropDownTypeResponse GetTypes(DropDownTypeRequest request)
        {
            return ProductBll.Instance.GetTypes(request);
        }
    }
}
