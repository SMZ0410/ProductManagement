using Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.Product
{
    public class ProductEditResponse:BaseResponse
    {
        /// <summary>
        /// 修改对象模型
        /// </summary>
        public ProductEditAdd ProductInfo { get; set; }
    }
}
