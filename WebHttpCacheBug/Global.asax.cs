using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebHttpCacheBug
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();

            if (objErr != null)
            {
                #region 注销
                string error = "发生异常页: " + Request.Url.ToString() + Environment.NewLine;
                error += "异常信息: " + objErr.Message + Environment.NewLine;
                error += "Source:" + objErr.Source + Environment.NewLine;
                error += "StackTrace" + objErr.StackTrace + Environment.NewLine;
                error += "方法：" + objErr.TargetSite.Name + Environment.NewLine;

                string logpath = Request.MapPath("/log.txt");
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(logpath))
                {
                    sw.Write(error);
                }
                #endregion

                ////屏蔽掉不存在的ashx 和 aspx 文件错误
                //string FunctionName = objErr.TargetSite.Name;
                //if (!FunctionName.Equals("CheckVirtualFileExists"))
                //{
                //    LogOut.Error("Application_Error:", objErr);
                //}

                //清除异常
                Server.ClearError();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}