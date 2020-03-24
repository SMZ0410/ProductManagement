using Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.DropDownList
{
    public class DropDownManageReponse:BaseResponse
    {
        /// <summary>
        /// 返回的产品经理信息集合
        /// </summary>
        public List<ProductManageInfo> Manages { get; set; }
    }
}
