using BLL.ApiRequest;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response.Product;
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
    }
}
