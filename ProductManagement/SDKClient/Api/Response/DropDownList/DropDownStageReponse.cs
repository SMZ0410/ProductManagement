using Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Response.DropDownList
{
    public class DropDownStageReponse:BaseResponse
    {
        /// <summary>
        /// 返回的阶段信息集合
        /// </summary>
        public List<StageInfo> Stages { get; set; }
    }
}
