using Model;
using SDKClient.Api.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response
{
    public class ProductGetResponse:BaseResponse
    {
        /// <summary>
        /// 返回的用户信息集合
        /// </summary>
        public List<ProductInfo> Users { get; set; }
    }
}
