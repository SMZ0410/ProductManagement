﻿using BLL.ApiRequest;
using SDKClient.Api.Request.DropDownList;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response;
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Product
{
    public class ProductBll:BaseBll<ProductBll>
    { 

        /// <summary>
        /// 获取产品信息
        /// </summary>
        public ProductGetResponse GetProducts(ProductGetRequest request)
        {
           return ApiRequestHelper.Post<ProductGetRequest, ProductGetResponse>(request);
        }
        /// <summary>
        /// 获取应用行业信息
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownTreadeResponse GetTreades(DropDownTreadeRquest request)
        {
            return ApiRequestHelper.Post<DropDownTreadeRquest, DropDownTreadeResponse>(request);
        }
        /// <summary>
        /// 获取产品阶段
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownStageReponse GetStages(DropDownStageRequest request)
        {
            return ApiRequestHelper.Post<DropDownStageRequest, DropDownStageReponse>(request);
        }
        /// <summary>
        /// 获取归属地信息
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            return ApiRequestHelper.Post<DropDownAddressRequest, DropDownAddressReponse>(request);
        }
        /// <summary>
        /// 获取应用行业
        /// </summary>
        /// <param name="rquest"></param>
        /// <returns></returns>
        public DropDownManageReponse GetManage(DropDownManageRequest request)
        {
            return ApiRequestHelper.Post<DropDownManageRequest, DropDownManageReponse>(request);
        }
    }
}
