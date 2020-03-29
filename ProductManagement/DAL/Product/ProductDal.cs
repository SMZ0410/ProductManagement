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

                string sql = @"SELECT * FROM v_Product";

                if (query.TradeId > 0 || query.StageId > 0 || query.AddressId > 0 || query.UserId > 0 || !string.IsNullOrEmpty(query.ProductName))
                {
                    sql += " WHERE 1=1";

                    if (query.TradeId > 0)
                    {
                        sql += " AND TradeId = @tradeId ";
                    }
                    if (query.StageId > 0)
                    {
                        sql += " AND StageId = @stageId ";
                    }
                    if (query.AddressId > 0)
                    {
                        sql += " AND AddressId = @addressId ";
                    }
                    if (query.UserId > 0)
                    {
                        sql += " AND UserId = @userId ";
                    }
                    if (!string.IsNullOrEmpty(query.ProductName))
                    {
                        sql += " AND ProductName LIKE @productName ";
                    }
                }

                list = conn.Query<ProductInfo>(sql, new { tradeId = query.TradeId, stageId = query.StageId, addressId = query.AddressId, userId = query.UserId, productName = "%" + query.ProductName + "%" }).ToList();

                return list;
            }
        }
        /// <summary>
        /// 获取应用行业的下拉显示
        /// </summary>
        /// <returns></returns>
        public List<TradeInfo> GetTrades()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
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
        /// 获取产品经理下拉显示
        /// </summary>
        /// <returns></returns>
        public List<ProductManageInfo> GetManages()
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                List<ProductManageInfo> list = new List<ProductManageInfo>();

                string sql = @"SELECT us.UserId,us.UserName as UName FROM dbo.UserInfo AS us
                                JOIN dbo.UserRoleMapInfo AS r ON us.UserId=r.UserId
                                JOIN dbo.RoleInfo AS ro ON r.RoleId=ro.RoleId
                                WHERE us.Status=1 AND ro.RoleName='产品经理'";

                list = conn.Query<ProductManageInfo>(sql).ToList();

                return list;
            }
        }

        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddProduct(ProductEditAdd info)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = @"EXEC dbo.p_Products @productName,
                                                  @userId,
                                                  @productDetail,
                                                  @tradeId, 
                                                  @typeId,
                                                  @addressId,
                                                  @stageId";
                var res = conn.Execute(sql, new { productName = info.ProductName, userId = info.UserId, productDetail = info.ProductDetail, tradeId = info.TradeId, typeId = info.TypeId, addressId = info.AddressId, stageId = info.StageId });

                return res;
            }
        }

        /// <summary>
        /// 逻辑删除产品信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteProduct(string ids)
        {
            using (IDbConnection conn = new SqlConnection(connStr))
            {
                string sql = $"update ProductInfo set Status=0 where ProductId in ("+ids+")";

                var res = conn.Execute(sql, new { Ids = ids });

                return res;
            }
        }
        /// <summary>
        /// 获取产品的单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductEditAdd EditProduct(int pid)
        {
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                ProductEditAdd info = new ProductEditAdd();
                string sql = $"SELECT * FROM v_Product WHERE ProductId=@id";

                info = conn.QueryFirstOrDefault<ProductEditAdd>(sql, new { id = pid });
                return info;
            }
        }
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <returns></returns>
        public int UpdateProduct(ProductUpdate ProUpd)
        {
            using (IDbConnection conn=new SqlConnection(connStr))
            {
                //update set typeid＝newtypeid where typeid＝oldtypeid and productid＝productid
                string sql = $"UPDATE ProductInfo SET ProductName='{ProUpd.ProductName}',ProductDetail='{ProUpd.ProductDetail}',TradeId='{ProUpd.NewTradeId}',TypeId='{ProUpd.NewTypeId}',AddressId='{ProUpd.NewAddressId}',StageId='{ProUpd.NewStageId}',UserId='{ProUpd.NewUserId}' where ProductId='{ProUpd.ProductId}'";

                var res = conn.Execute(sql);
                return res;
            }
        }
    }
}
