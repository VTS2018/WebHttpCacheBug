using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCodeStatistics.httptype
{
    /// <summary>
    /// HandlerJpeg 的摘要说明
    /// </summary>
    public class HandlerJpeg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ClearHeaders();
            context.Response.ClearContent();

            context.Response.ContentType = "image/jpeg";

            string img = context.Request.MapPath("/images/banner_01.jpg");

            FileStream fs = new FileStream(img, FileMode.Open);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, (int)fs.Length);
            fs.Close();

            //防止图片被采集,可以实现图片防止采集等等
            context.Response.OutputStream.Write(b, 0, b.Length);
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