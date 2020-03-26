using Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.Product
{
    public class ProductGetRequest:BaseRequest
    {
        /// <summary>
        /// 产品信息查询model
        /// </summary>
        public ProductQuery Query { get; set; }
        /// <summary>
        /// 重写基类路径
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/Product/GetProducts";
        }
    }
}
