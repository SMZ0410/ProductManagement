using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.DropDownList
{
    public class DropDownTreadeResponse:BaseResponse
    {
        /// <summary>
        /// 返回的应用行业信息集合
        /// </summary>
        public List<TradeInfo> Trades { get; set; }
    }
}
