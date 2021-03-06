﻿using Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKClient.Api.Request.Product
{
    public class ProductUpdateRequest:BaseRequest
    {
        public ProductUpdate ProductUpd { get; set; }
        /// <summary>
        /// 重写基类路径
        /// </summary>
        /// <returns></returns>
        public override string GetApiName()
        {
            return "api/Product/UpdateProducts";
        }
    }
}
