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
        public override string GetApiName()
        {
            return "api/Product/GetProducts";
        }
    }
}
