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

namespace DAL.Product
{
    public class ProductDal:BaseDal<ProductDal>
    {
        /// <summary>
        /// 获取连接数据库字符串
        /// </summary>
        private static string connStr = ConfigurationManager.AppSettings["connectionString"];

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        public List<ProductInfo> GetProducts()
        {
            List<ProductInfo> list = new List<ProductInfo>();

            using (IDbConnection conn=new SqlConnection(connStr))
            {
                string sql = @"SELECT p.ProductId,p.ProductName,p.CreateTime,p.ProductManager,r.TradeName,d.AddressName,g.StageName,p.ProductDetail
                                FROM dbo.ProductInfo AS p
                                JOIN dbo.ProductTradeMapInfo AS t ON p.ProductId=t.ProductId
                                JOIN dbo.TradeInfo AS r ON t.TradeId=r.TradeId
                                JOIN dbo.ProductAddressMapInfo AS a ON p.ProductId=a.ProductId
                                JOIN dbo.AddressInfo AS d ON a.AddressId=d.AddressId
                                JOIN dbo.ProductStageMapInfo AS s ON p.ProductId=s.ProductId
                                JOIN dbo.StageInfo AS g ON s.StageId=g.StageId WHERE p.Status=1";

                list = conn.Query<ProductInfo>(sql).ToList();

                return list;
            }
        }
    }
}
