using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using Telerik.Web.UI;

public partial class Modules_Boxes_News_News : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_News_News";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {           
            if (!Page.IsPostBack)
            {
                bindData();
            }
            
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void bindData()
    {
        String function_name = "bindData";
        try
        {
            if (!this.Hidden || RXServer.Auth.IsInRole("Admin"))
            {
				RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
 
                this.News_holder.Visible = true;
                this.lblTitle.Text = Server.HtmlDecode(sm.Text1);
                //this.hplRSS.NavigateUrl = "~/RSS/rss.aspx?Var=News&PagId=" + this.PagId + "&Id=" + this.ModId;
                //this.lbnArchive.Text = "» " + RXMali.GetXMLNode("Modules/News/newsarchive");
                //this.lbnHide.Text = RXMali.GetXMLNode("Modules/News/hide_newsarchive");


                BindListData();

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(sm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                _style = "position: relative; float: " + sm.Float + "; width: " + _width + "px;";

                this.News_holder.Attributes.Add("style", _style);
            }
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindListData()
    {
        String function_name = "BindListData";
        try
        {
            String html = "";

            RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("News_" + this.ModId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, 0, 1000);

            html += "<div id=\"NewsItem\">";

            Int32 link = 0;

            foreach (RXServer.Modules.Base.List.Item item in cl)
            {
                Int32.TryParse(item.Value26, out link);
                html += "<h2>" + Server.HtmlDecode(item.Value2).Replace("`", "'") + "</h2>";
                html += "<em class='Date'>" + item.Value25.Replace('-', '/') + "</em>";
                html += "<p class='Introduction'>" + EE.EncodeEmails(Server.HtmlDecode(item.Value5)).Replace("`", "'") + "</p>";
                //html += "<a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link) + "'>" + RXMali.GetXMLNode("Modules/News/readmore_link") + "</a><br /><br /><br />";
                String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                html += "<a href='" + path + "Default.aspx?PagId=" + link + "'>" + RXMali.GetXMLNode("Modules/News/readmore_link") + "</a><br /><br /><br />";
            }

            html += "</div>";

            this.ltrNewsList.Text = html;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
