using System;
using System.Web;
using System.IO;
using System.Xml;

namespace RXServer.Lib
{
    public class SearchEngineOptimization
    {
        private static string PublicUrl = System.Configuration.ConfigurationSettings.AppSettings["System.Public.Url"].ToString(); 
        public static void Optimize()
        {
            if (PublicUrl == null)
                return;

            UpdateSiteMapXML();

            UpdateRobotTXT();
        }

        private static void UpdateRobotTXT()
        {
            string RobotFile = @"~/robots.txt";
            string txtFile = HttpContext.Current.Server.MapPath(RobotFile);
            StreamWriter SW = File.CreateText(txtFile);
            SW.WriteLine("User-agent: *");
            SW.WriteLine("Disallow:");
            SW.WriteLine("Sitemap: " + PublicUrl + "/sitemap.xml");
            SW.Close();
        }

        private static void UpdateSiteMapXML()
        {
            string SiteMapFile = @"~/sitemap.xml";
            string xmlFile = HttpContext.Current.Server.MapPath(SiteMapFile);

            XmlTextWriter writer = new XmlTextWriter(xmlFile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset");
            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");

            // Add Home Page
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", PublicUrl);
            writer.WriteElementString("changefreq", "daily");
            writer.WriteElementString("priority", "0.5");
            writer.WriteEndElement();// url

            // add subpages
            writer = Get(0, writer);

            // writer end section
            writer.WriteEndElement();// urlset        
            writer.Close();
        }

        public static XmlTextWriter Get(Int32 PagId, XmlTextWriter writer)
        {
            using (RXServer.Modules.Menu MM = new RXServer.Modules.Menu(1, PagId))
            {
                foreach (LiquidCore.Menu.Item i in MM)
                {
					if (!i.Hidden)
					{
						writer.WriteStartElement("url");
						writer.WriteElementString("loc", PublicUrl + "/Default.aspx?PagId=" + i.Id.ToString());
						writer.WriteElementString("changefreq", "always");
						writer.WriteElementString("priority", "0.8");
						writer.WriteEndElement();// url

						if (i.HasChildren)
							writer = Get(i.Id, writer);
					}
                }
            }
            return writer;
        }

    }
}
