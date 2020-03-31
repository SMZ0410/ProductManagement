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
        /// 获取产品经理的下拉
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
        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <returns></returns>
        public ProductAddResponse ProductAdd(ProductAddRequest request)
        {
            ProductAddResponse response = new ProductAddResponse();

            //非空判断
            if (string.IsNullOrEmpty(request.Products.ProductName))
            {
                response.Status = false;
                response.Message = "产品名称不能为空";
                return response;
            }
            if (request.Products.TradeId<=0)
            {
                response.Status = false;
                response.Message = "请选择应用行业";
                return response;
            }
            if (request.Products.AddressId <= 0)
            {
                response.Status = false;
                response.Message = "请选择归属地";
                return response;
            }
            if (request.Products.StageId <= 0)
            {
                response.Status = false;
                response.Message = "请选择产品阶段";
                return response;
            }
            if (string.IsNullOrEmpty(request.Products.ProductDetail))
            {
                response.Status = false;
                response.Message = "产品描述不能为空";
                return response;
            }
            if (request.Products.UserId <= 0)
            {
                response.Status = false;
                response.Message = "请选择产品经理";
                return response;
            }
            var res = ProductDal.Instance.AddProduct(request.Products);

            if (res > 0)
            {
                response.Status = true;
                response.Message = "添加成功";
            }
            else
            {
                response.Status = false;
                response.Message = "添加失败";
            }

            return response;
        }

        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductDeleteResponse DeleteProduct(ProductDeleteRequest request)
        {
            ProductDeleteResponse response = new ProductDeleteResponse();

            var res = ProductDal.Instance.DeleteProduct(request.Ids);

            if (res>0)
            {
                response.Status = true;
                response.Message = "删除成功";
            }
            else
            {
                response.Status = false;
                response.Message = "删除失败";
            }

            return response;
        }

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductEditResponse EditProduct(ProductEditRequest request)
        {
            ProductEditResponse response = new ProductEditResponse();

            if (request.PId < 0)
            {
                response.Status = false;
                response.Message = "网络错误";
                return response;
            }

            var res = ProductDal.Instance.EditProduct(request.PId);
            if (res != null)
            {
                response.Status = true;
                response.Message = "请求成功";
                response.ProductInfo = res;
            }

            return response;
        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProductUpdateResponse UpdateProduct(ProductUpdateRequest request)
        {
            ProductUpdateResponse response = new ProductUpdateResponse();

            var res = ProductDal.Instance.UpdateProduct(request.ProductUpd);
            if (res > 0)
            {
                response.Status = true;
                response.Message = "修改成功";
            }
            else
            {
                response.Status = false;
                response.Message = "修改失败";
            }

            return response;
        }
    }
}
