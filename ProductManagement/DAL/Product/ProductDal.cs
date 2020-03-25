using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Model.Product;

namespace DAL.Product
{
    public class ProductDal : BaseDal<ProductDal>
    {
        /// <summary>
        /// 获取连接数据库字符串
        /// </summary>
        private readonly static string connStr = ConfigurationManager.AppSettings["connectionString"];

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public List<ProductInfo> GetProducts(ProductQuery query) 
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<ProductInfo> list = new List<ProductInfo>();

                string sql = @"SELECT * FROM v_Products";

                if (query.TradeId > 0)
                {
                    sql += " AND r.TradeId = @tradeId ";
                }
                if (query.StageId>0)
                {
                    sql += " AND g.StageId = @stageId ";
                }
                if (query.AddressId > 0)
                {
                    sql += " AND d.AddressId = @addressId ";
                }
                if (query.ProductId > 0)
                {
                    sql += " AND p.ProductId = @productId ";
                }
                if (!string.IsNullOrEmpty(query.ProductName))
                {
                    sql += " AND p.ProductName LIKE @productName ";
                }

                list = conn.Query<ProductInfo>(sql,new { tradeId = query.TradeId, stageId =query.StageId, addressId=query.AddressId, productId = query.ProductId, productName="%"+query.ProductName+"%" }).ToList();

                return list;
            }
        }
        /// <summary>
        /// 获取应用行业的下拉显示
        /// </summary>
        /// <returns></returns>
        public List<TradeInfo> GetTrades()
        {
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                List<TradeInfo> list = new List<TradeInfo>();

                string sql = $"SELECT * FROM TradeInfo";

                list = conn.Query<TradeInfo>(sql).ToList();

                return list;
            }
        }

        /// <summary>
        /// 获取产品阶段的下拉显示
        /// </summary>
        /// <returns></returns>
        public List<StageInfo> GetStages()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<StageInfo> list = new List<StageInfo>();

                string sql = $"SELECT * FROM StageInfo";

                list = conn.Query<StageInfo>(sql).ToList();

                return list;
            }
        }

        /// <summary>
        /// 获取归属地的下拉显示
        /// </summary>
        /// <returns></returns>
        public List<AddressInfo> GetAddress()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<AddressInfo> list = new List<AddressInfo>();

                string sql = $"SELECT * FROM AddressInfo";

                list = conn.Query<AddressInfo>(sql).ToList();

                return list;
            }
        }

        /// <summary>
        /// 获取应用行业的下拉显示
        /// </summary>
        /// <returns></returns>
        public List<ProductManageInfo> GetManages()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<ProductManageInfo> list = new List<ProductManageInfo>();

                string sql = $"SELECT * FROM ProductInfo";

                list = conn.Query<ProductManageInfo>(sql).ToList();

                return list;
            }
        }

        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddProduct(ProductAdd info)
        {
            using (IDbConnection conn=new SqlConnection())
            {
                string sql = @"EXEC dbo.p_Product @productName,
                                                  @productManage,
                                                  @productDetail,
                                                  @tradeId, 
                                                  @typeId,
                                                  @addressId,
                                                  @stageId";
                var res = conn.Execute(sql,new { productName = info.ProductName , productManage =info.ProductManager, productDetail =info.productDetail, tradeId =info.TradeId, typeId =info.TypeId, addressId =info.AddressId, stageId =info.StageId});

                return res;
            } 
        }

        /// <summary>
        /// 逻辑删除产品信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteProduct(int ids)
        {
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                string sql = $"update ProductInfo set Status=0 where ProductId in ('"+ids+"')";

                var res = conn.Execute(sql);

                return res;
            }
        }
        /// <summary>
        /// 获取产品的单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfo ExitProduct(int id)
        {
            ProductInfo info = new ProductInfo();

            return info;
        }
    }
}
