using DAL.Product;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKClient.Api.Request.Product;
using SDKClient.Api.Response.Product;
using SDKClient.Api.Response.DropDownList;
using SDKClient.Api.Request.DropDownList;

namespace BLL.Product
{
    public class ProductBll:BaseBll<ProductBll>
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public ProductGetResponse GetProducts(ProductGetRequest request)
        {
            ProductGetResponse response = new ProductGetResponse();

            var list = ProductDal.Instance.GetProducts(request.Query);
            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取产品信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.Products = list;
                response.Message = $"获取产品信息成功，共{list.Count}条数据";
            }
            return response;
        }
        /// <summary>
        /// 获取应用行业的下拉
        /// </summary>
        /// <returns></returns>
        public DropDownTreadeResponse GetTreade(DropDownTreadeRquest request)
        {
            DropDownTreadeResponse response = new DropDownTreadeResponse();

            var list = ProductDal.Instance.GetTrades();

            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取应用行业信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.Trades = list;
                response.Message = $"获取应用行业信息成功，共{list.Count}条数据";
            }
            return response;
        }

        /// <summary>
        /// 获取产品阶段的下拉
        /// </summary>
        /// <returns></returns>
        public DropDownStageReponse GetStages(DropDownStageRequest request)
        {
            DropDownStageReponse response = new DropDownStageReponse();

            var list = ProductDal.Instance.GetStages();

            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取产品阶段信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.Stages = list;
                response.Message = $"获取产品阶段信息成功，共{list.Count}条数据";
            }
            return response;
        }

        /// <summary>
        /// 获取归属地的下拉
        /// </summary>
        /// <returns></returns>
        public DropDownAddressReponse GetAddress(DropDownAddressRequest request)
        {
            DropDownAddressReponse response = new DropDownAddressReponse();

            var list = ProductDal.Instance.GetAddress();

            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取归属地业信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.TrAddress = list;
                response.Message = $"获取归属地信息成功，共{list.Count}条数据";
            }
            return response;
        }

        /// <summary>
        /// 获取应用行业的下拉
        /// </summary>
        /// <returns></returns>
        public DropDownManageReponse GetManages(DropDownManageRequest request)
        {
            DropDownManageReponse response = new DropDownManageReponse();

            var list = ProductDal.Instance.GetManages();

            //判断是否有数据
            if (list.Count <= 0)
            {
                //给返回对象属性赋值
                response.Status = false;
                response.Message = "获取产品经理信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象赋值
                response.Manages = list;
                response.Message = $"获取产品经理信息成功，共{list.Count}条数据";
            }
            return response;
        }
    }
}
