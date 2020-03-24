using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{

    public class ProductQuery
    {
        /// <summary>
        /// 产品经理
        /// </summary>
        public string ProductManager { get; set; }
        /// <summary>
        /// 产品阶段
        /// </summary>
        public int StageId { get; set; }
        /// <summary>
        /// 归属地
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// 应用行业
        /// </summary>
        public int TradeId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
    }
}
