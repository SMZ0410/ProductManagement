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
            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取用户信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.Products = list;
                response.Message = $"获取用户信息成功，共{list.Count}条数据";
            }
            return response;
        }
    }
}
