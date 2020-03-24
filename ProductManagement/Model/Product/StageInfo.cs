using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    /// <summary>
    /// 产品阶段表
    /// </summary>
    public class StageInfo
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public int StageId { get; set; }
        /// <summary>
        /// 地名称
        /// </summary>
        public string StageName { get; set; }
    }
}
