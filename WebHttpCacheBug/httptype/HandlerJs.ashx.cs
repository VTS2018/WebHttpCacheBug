using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCodeStatistics.httptype
{
    /// <summary>
    /// HandlerJs 的摘要说明
    /// </summary>
    public class HandlerJs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();

            context.Response.ContentType = "application/x-javascript";

            string js = context.Request.MapPath("/js/jquery-1.3.2.min.js");
            using (TextReader tr = new StreamReader(js, System.Text.Encoding.UTF8))
            {
                js = tr.ReadToEnd();
            }
            context.Response.Write(js);
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