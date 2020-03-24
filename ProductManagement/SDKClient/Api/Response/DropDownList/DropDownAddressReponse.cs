using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.DropDownList
{
    public class DropDownAddressReponse:BaseResponse
    {
        /// <summary>
        /// 返回的地址信息集合
        /// </summary>
        public List<AddressInfo> TrAddress { get; set; }
    }
}
