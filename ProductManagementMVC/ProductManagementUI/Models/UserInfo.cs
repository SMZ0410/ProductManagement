using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementUI.Models
{
    /// <summary>
    /// 用户管理表
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 所属地
        /// </summary>
        public string AddressName { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleName { get; set; }
    }
}