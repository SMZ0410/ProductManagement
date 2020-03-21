using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementUI.Models
{
    public class ProductInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 产品经理
        /// </summary>
        public string ProductManager { get; set; }
        /// <summary>
        /// 应用行业
        /// </summary>
        public string TradeName { get; set; }
        /// <summary>
        /// 归属地
        /// </summary>
        public string AddressName { get; set; }
        /// <summary>
        /// 产品阶段
        /// </summary>
        public string StageName { get; set; }
        /// <summary>
        /// 详情
        /// </summary>
        public string ProductDetail { get; set; }
    }
}