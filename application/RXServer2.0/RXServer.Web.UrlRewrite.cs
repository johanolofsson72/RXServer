using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;

namespace RXServer
{
    namespace Web
    {
        public class UrlRewrite : IHttpModule
        {
            string CLASSNAME = "[Namespace::RXServer::Web][Class::UrlRewrite]";

            public void Init(HttpApplication c)
            {
                c.BeginRequest += new EventHandler(rx_BeginRequest);
            }

            void rx_BeginRequest(object sender, EventArgs e)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::rx_BeginRequest]";
                try
                {
                    String currentURL = HttpContext.Current.Request.Path.ToLower();
                    String processPath = currentURL.Substring(HttpContext.Current.Request.ApplicationPath.Length).TrimStart('/').ToLower();
                    String physicalPath = HttpContext.Current.Server.MapPath(currentURL.Substring(currentURL.LastIndexOf("/") + 1));

                    if (!System.IO.File.Exists(physicalPath) && !physicalPath.EndsWith(".axd") && !physicalPath.Contains("PagId="))
                    {
                        String queryString = HttpContext.Current.Request.ServerVariables["QUERY_STRING"];
                        String defaultPage = "~/Default.aspx?PagId=";

                        if (processPath.EndsWith(".aspx"))
                            processPath = processPath.Substring(0, processPath.Length - ".aspx".Length);

                        HttpContext.Current.RewritePath(defaultPage + GetRealValue(processPath) + (queryString.Length.Equals(0) ? String.Empty : ("&" + queryString)));
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

            private String GetRealValue(String p)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetRealValue]";
                // denna används bara av RXServer.Web.Menus.MenuItem i syfte av RXServer.Web.UrlRewrite
                String PagId = "1";
                if (p.IndexOf("/") > 0)
                    p = p.Substring(p.IndexOf("/") + 1);
                try
                {
                    using (RXServer.Web.Menus.MenuItem m = new RXServer.Web.Menus.MenuItem(p, ConfigurationManager.AppSettings["Data.DataSource"], ConfigurationManager.AppSettings["Data.ConnectionString"]))
                    {
                        if (!m.Id.Equals(0))
                            PagId = m.Id.ToString();
                    }
                    return PagId;
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return PagId;
                }
            }

            public void Dispose()
            { }
        }
    }
}
