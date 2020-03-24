using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 归属地
    /// </summary>
    public class AddressInfo
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int AddressId { get; set; }
        /// <summary>
        /// 地名称
        /// </summary>
        public string AddressName { get; set; }
    }
}
