using SDKClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace ProductManagementUI.APIRequest
{
    /// <summary>
    /// 请求api的辅助方法_
    /// 此类是统一设置请求为post
    /// </summary>
    public class ApiRequestHelper
    {
        //地址
        static string BaseAddress = "http://localhost:55085";

        /// <summary>
        /// 泛型post方法主要作用进行api的post请求
        /// where T:BaseRequest泛型的约束，约束的是T，必须继承BaseRequest
        /// 也就是表示次泛型方法的post请求，必须继承BaseRequest
        /// SMZ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        /// public static TResponse Post<TRequet, TResponse>(TRequet t) where TRequet : BaseRequest where TResponse : BaseResponse 
        public static TResponse Post<TRequet, TResponse>(TRequet t) where TRequet : BaseRequest where TResponse : BaseResponse// smz约束这个泛型T  必须继承BaseRequest
        {
           
            var api = t.GetApiName();//拿到接口的名称


            HttpClient client = new HttpClient();
            //设置 API的 基地址
            client.BaseAddress = new Uri(BaseAddress);
            //设置 默认请求头ACCEPT
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string token = ConfigurationManager.AppSettings["token"];
            client.DefaultRequestHeaders.Add("token", token);

            //设置消息体
            HttpContent content = new StringContent(JsonConvert.SerializeObject(t));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //发送Post请求
            HttpResponseMessage msg = client.PostAsync(api, content).Result;
            //判断结果是否成功
            if (msg.IsSuccessStatusCode)
            {

                var obj = JsonConvert.DeserializeObject<TResponse>(msg.Content.ReadAsStringAsync().Result);
                if (obj.Status)
                {
                    //请求成功
                }
                
                //返回响应结果
                return obj;
            }
            return null;
        }
    }
}
