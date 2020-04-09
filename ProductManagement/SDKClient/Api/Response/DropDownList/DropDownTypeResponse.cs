using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Product;

namespace SDKClient.Api.Response.DropDownList
{
    public class DropDownTypeResponse:BaseResponse
    {
        /// <summary>
        /// 返回类型集合
        /// </summary>
        public List<TypeInfo>  Types { get; set; }
    }
}
