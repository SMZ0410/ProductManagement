using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class StringEncryption
    {
        static string encryptKey = "foxm";//字符串加密密钥(注意：密钥只能是4位)


        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(this string str)
        {//加密字符串

            try
            {
                byte[] key = Encoding.Unicode.GetBytes(encryptKey);//密钥
                byte[] data = Encoding.Unicode.GetBytes(str);//待加密字符串

                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//加密、解密对象
                MemoryStream MStream = new MemoryStream();//内存流对象

                //用内存流实例化加密流对象
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);//向加密流中写入数据
                CStream.FlushFinalBlock();//将数据压入基础流
                byte[] temp = MStream.ToArray();//从内存流中获取字节序列
                CStream.Close();//关闭加密流
                MStream.Close();//关闭内存流

                return Convert.ToBase64String(temp);//返回加密后的字符串
            }
            catch
            {
                return str;
            }
        }

        /// <summary>
        /////解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decrypt(this string str)
        {

            try
            {
                byte[] key = Encoding.Unicode.GetBytes(encryptKey);//密钥
                byte[] data = Convert.FromBase64String(str);//待解密字符串

                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//加密、解密对象
                MemoryStream MStream = new MemoryStream();//内存流对象

                //用内存流实例化解密流对象
                CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
                CStream.Write(data, 0, data.Length);//向加密流中写入数据
                CStream.FlushFinalBlock();//将数据压入基础流
                byte[] temp = MStream.ToArray();//从内存流中获取字节序列
                CStream.Close();//关闭加密流
                MStream.Close();//关闭内存流

                return Encoding.Unicode.GetString(temp);//返回解密后的字符串
            }
            catch
            {
                return str;
            }
        }
    }
}
