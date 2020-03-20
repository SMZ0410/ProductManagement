using DAL.Product;
using SDKClient.Api.Response;
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
        /// <returns></returns>
        public ProductGetResponse GetProducts()
        {
            ProductGetResponse response = new ProductGetResponse();

            var list = ProductDal.Instance.GetProducts();

            if (list.Count<=0)
            {
                response.Status = false;
                response.Message = "获取信息失败";
            }
            else
            {
                response.Users = list;
                response.Message = "获取信息成功";
            }

            return response;
        }
    }
}
