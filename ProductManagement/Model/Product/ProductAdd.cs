using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    public class ProductAdd
    {
        /// <summary>
        /// 产品类型
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
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
    }
}
