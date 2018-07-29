using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCodeStatistics.httptype
{
    /// <summary>
    /// HandlerCss 的摘要说明
    /// </summary>
    public class HandlerCss : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();

            //////////////////////////////////////////////////////////////

            //ok 设置不缓存
            //context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //context.Response.Cache.SetNoStore();


            //设置缓存 Cache-Control: public, max-age=604800[三条共同设置才有效]
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetMaxAge(new TimeSpan(7, 0, 0, 0));
            context.Response.Cache.SetSlidingExpiration(true);

            //设置缓存 Expires: Wed, 11 Jul 2018 06:10:43 GMT
            context.Response.Cache.SetExpires(DateTime.Now.AddDays(7));
            context.Response.Headers.Add("Pragma", "Pragma");
            //[以上是我配置成功的，只有Etag没有配置成功]以上配置的强缓存 一旦缓存成功就不发送请求了



            //开始配置协商缓存
            //设置Etag 备注不能同时设置哦
            //context.Response.Cache.SetETag("\"50f59e42f4d8bc1:cd7\"");
            //context.Response.Cache.SetETagFromFileDependencies();
            //////////////////////////////////////////////////////////////

            context.Response.ContentType = "text/css";
            string css;
            using (TextReader tr = new StreamReader(context.Request.MapPath("/style/site.css"), System.Text.Encoding.UTF8))
            {
                css = tr.ReadToEnd();
            }
            context.Response.Write(css);
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