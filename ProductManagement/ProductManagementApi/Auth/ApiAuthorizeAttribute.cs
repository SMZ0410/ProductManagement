using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ProductManagementApi.Auth
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            //从网络请求中获取到token
            //用相同的解密方式，判断请求过来的token是不是复合规范
            //符合 验证通过
            //不符合要求 验证失败
            //在Api中使用权限过滤器，过滤请求的请求头中间是否包含key=token
            //如果包含则验证token的值是否正确(token是不是在api中获取的，tpken是否过期)，不包含返回失败

            var authHeader = from t in actionContext.Request.Headers where t.Key == "token" select t.Value.FirstOrDefault();
            if (authHeader != null)
            {
                string token = authHeader.FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        const string secret = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC4aKpVo2OHXPwb1R7duLgg";
                        //secret需要加密
                        IJsonSerializer serializer = new JsonNetSerializer();
                        IDateTimeProvider provider = new UtcDateTimeProvider();
                        IJwtValidator validator = new JwtValidator(serializer, provider);
                        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();


                        IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                        var json = decoder.DecodeToObject<object>(token, secret, verify: true);
                        if (json != null)
                        {
                            actionContext.RequestContext.RouteData.Values.Add("auth", json);
                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}

