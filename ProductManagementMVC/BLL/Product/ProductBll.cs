using BLL.ApiRequest;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Request.DropDownList;
using SDKClient.Api.Response;
using SDKClient.Api.Response.Product;
using SDKClient.Api.Response.DropDownList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Product
{
    public class ProductBll:BaseBll<ProductBll>
    { 

        /// <summary>
        /// 获取产品信息
        /// </summary>
        public ProductGetResponse GetProducts(ProductGetRequest request)
        {
           return ApiRequestHelper.Post<ProductGetRequest, ProductGetResponse>(request);
        }
        /// <summary>
        /// 获取应用行业信息
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownTreadeResponse GetTreades(DropDownTreadeRquest request)
        {
            return ApiRequestHelper.Post<DropDownTreadeRquest, DropDownTreadeResponse>(request);
        }
        /// <summary>
        /// 获取产品阶段
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownStageReponse GetStages(DropDownStageRequest request)
        {
            return ApiRequestHelper.Post<DropDownStageRequest, DropDownStageReponse>(request);
        }
        /// <summary>
        /// 获取归属地信息
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            return ApiRequestHelper.Post<DropDownAddressRequest, DropDownAddressReponse>(request);
        }
        /// <summary>
        /// 获取产品经理
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownManageReponse GetManage(DropDownManageRequest request)
        {
            return ApiRequestHelper.Post<DropDownManageRequest, DropDownManageReponse>(request);
        }

        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductAddResponse AddProduct(ProductAddRequest request)
        {
            return ApiRequestHelper.Post<ProductAddRequest, ProductAddResponse>(request);
        }

        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductDeleteResponse DeleteProducts(ProductDeleteRequest request)
        {
            return ApiRequestHelper.Post<ProductDeleteRequest, ProductDeleteResponse>(request);
        }
        /// <summary>
        /// 获取产品单条信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductEditResponse EditProducts(ProductEditRequest request)
        {
            return ApiRequestHelper.Post<ProductEditRequest, ProductEditResponse>(request);
        }
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductUpdateResponse UpdateProducts(ProductUpdateRequest request)
        {
            return ApiRequestHelper.Post<ProductUpdateRequest, ProductUpdateResponse>(request);
        }
        /// <summary>
        /// 获取类型信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DropDownTypeResponse GetTypes(DropDownTypeRequest request)
        {
            return ApiRequestHelper.Post<DropDownTypeRequest, DropDownTypeResponse>(request);
        }
    }
}
