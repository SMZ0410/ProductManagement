using DAL.Product;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response.Product;

namespace BLL.Product
{
    public class ProductBll:BaseBll<ProductBll>
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public ProductGetResponse GetProducts(ProductGetRequest request)
        {
            ProductGetResponse response = new ProductGetResponse();

            var list = ProductDal.Instance.GetProducts();

            return response;
        }
    }
}
