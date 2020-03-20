using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// DAL
    /// 单例模式的实现
    /// 基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDal<T> where T : new()
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new T();
                return _instance;
            }
        }
    }
}
