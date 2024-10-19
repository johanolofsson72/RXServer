using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class RSS_rss : RXServer.Lib.RXDefaultPage
{
    String class_name = "RSS_rss";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Web.RequestValues.Var == "News")
            {
                if (RXServer.Web.RequestValues.Id > 0 && RXServer.Web.RequestValues.PagId > 0)
                {
                    SetNewsFeed(RXServer.Web.RequestValues.Id, RXServer.Web.RequestValues.PagId);
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    private void SetNewsFeed(Int32 modId, Int32 pagId)
    {
        String function_name = "SetNewsFeed";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(1, pagId, modId);

            if (sm.Visible == "true")
           {
               DataTable table = new DataTable();
               String sql = "SELECT pag_id, obd_varchar10, obd_varchar2, obd_varchar3, obd_id FROM obd_objectdata WHERE obd_alias = 'News_" + modId + "' AND obd_varchar6 LIKE 'true' AND obd_deleted = 0";

               DataSet dataSet = new DataSet("dataSet");
               dataSet = RXServer.Data.Direct.GetDataSet(sql);
               if (dataSet.Tables.Count > 0)
               {
                   table = dataSet.Tables[0];

                   if (dataSet.Tables[0].Rows.Count > 0)
                   {
                       DataTable myDataTable = dataSet.Tables[0];
                       foreach (DataRow dRow in myDataTable.Rows)
                       {
                           dRow["obd_varchar3"] = Server.HtmlDecode(dRow["obd_varchar3"].ToString());
                           dRow["obd_varchar2"] = Server.HtmlDecode(dRow["obd_varchar2"].ToString());
                       }

                   }
               }

               RssBuilder.RssConfigurator configurator = new RssBuilder.RssConfigurator();
               configurator.Title = Server.HtmlDecode(sm.Text1);
               configurator.Link = RXMali.GetDomainUrl(Request.Url.ToString()) + "Default.aspx?PagId=[pag_id]";
               configurator.ImageUrl = "";

               String url = RXMali.GetDomainUrl(Request.Url.ToString());

               url = url.Replace("/RSS", "");

               configurator.ExpressionDate = "[obd_varchar10]";
               configurator.ExpressionDescription = "[obd_varchar3]";
               configurator.ExpressionLink = url + "Default.aspx?PagId=[pag_id]&News=[obd_id]";
               configurator.ExpressionTitle = "[obd_varchar2]";

               Response.ClearContent();
               Response.ContentType = "text/xml";

               System.Xml.XmlDocument xmlDoc = RssBuilder.RssBuilder.BuildXML(table, configurator);

               Response.Write(xmlDoc.OuterXml);
           }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
