using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHttpCacheBug
{
    /// <summary>
    /// CacheBug 的摘要说明
    /// </summary>
    public class CacheBug : IHttpHandler
    {
        public void ProcessRequest(HttpContext Context)
        {
            //context.Response.ContentType = "text/plain";
            //int n = 8;
            //int c = 8;
            //int b = 10 / (n - c);
            //context.Response.Write(b);
            ////context.Response.Write("Hello World");

            Context.Response.Clear();
            Context.Response.ClearHeaders();
            Context.Response.ClearContent();

            Context.Response.ContentType = "text/css";
            //配置7天缓存【客户端强制刷新 依然bug】
            SetClientCaching(Context.Response, DateTime.Now.AddDays(7));

            Context.Response.Write("body{font-family:Arial,Helvetica,sans-serif;font-family:\"AvenirNext-Regular\",Helvetica,Arial,sans-serif;font-size:1.25em}.otleft{text-align:left}.otright{text-align:right}.otcenter{text-align:center}");

        }

        private void SetClientCaching(HttpResponse response, DateTime expires)
        {
            #region 1.0
            response.Cache.SetETag(DateTime.Now.Ticks.ToString());
            response.Cache.SetLastModified(DateTime.Now);

            //public 以指定响应能由客户端和共享（代理）缓存进行缓存。    
            response.Cache.SetCacheability(HttpCacheability.Public);

            //是允许文档在被视为陈旧之前存在的最长绝对时间。 
            //response.Cache.SetMaxAge(TimeSpan.FromTicks(expires.Ticks));
            response.Cache.SetMaxAge(new TimeSpan(7, 0, 0, 0));

            response.Cache.SetSlidingExpiration(true);
            #endregion

            //response.Cache.SetCacheability(HttpCacheability.Public);
            //response.Cache.SetMaxAge(new TimeSpan(7, 0, 0, 0));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}