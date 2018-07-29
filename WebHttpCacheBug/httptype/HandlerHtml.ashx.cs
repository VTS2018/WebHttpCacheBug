using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCodeStatistics.httptype
{
    /// <summary>
    /// HandlerHtml 的摘要说明
    /// </summary>
    public class HandlerHtml : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();

            context.Response.ContentType = "text/html";
            string html = context.Request.MapPath("/outhtml.html");
            using (TextReader tr = new StreamReader(html, System.Text.Encoding.UTF8))
            {
                html = tr.ReadToEnd();
            }
            context.Response.Write(html);
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