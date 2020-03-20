using DAL.User;
using SDKClient.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
    /// <summary>
    /// 用户逻辑业务层
    /// </summary>
    public class UserBll:BaseBll<UserBll>
    {
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <returns></returns>
        public UserGetResponse  GetUsers()
        {
            //实例化一个返回类对象
            UserGetResponse response = new UserGetResponse(); 

            //2拿到用户信息集合
            var list = UserDal.Instance.GetUsers();

            //3判断是否有数据
            if (list.Count<=0)
            {
                //给返回对象属性 赋值
                response.Status = false;
                response.Message = "获取用户信息失败，请检查网络问题";
            }
            else
            {
                //给返回对象属性 赋值
                response.Users = list;
                response.Message = $"获取用户信息成功，共{list.Count}条数据";
            }
            //返回
            return response;
        }
    }
}
