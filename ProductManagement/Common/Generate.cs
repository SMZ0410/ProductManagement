using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 生成盐
    /// </summary>
    public static class Generate
    {
        /// <summary>
        /// 生成盐
        /// 此处生成4位的盐
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            string salt = string.Empty;
            //字母
            List<string> list = new List<string>()
            {
                "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"
            };
            var seed = new Random().Next();
            for (int i = 0; i < 4; i++)
            {
                salt += list[new Random(seed * i).Next(0, list.Count - 1)];
            }

            return salt;
        }
    }
}
