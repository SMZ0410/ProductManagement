using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementUI.Models
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 功能权限
        /// </summary>
        public string privilegeName { get; set; }
        /// <summary>
        /// 关联用户数
        /// </summary>
        public int UserNum { get; set; }
    }
}