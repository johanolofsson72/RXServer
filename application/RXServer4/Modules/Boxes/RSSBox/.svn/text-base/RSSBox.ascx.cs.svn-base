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
using Telerik.Web.UI.Calendar;
using System.Xml;

public partial class Modules_Boxes_RSSBox_RSSBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_RSSBox_RSSBox";
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
				RXServer.Modules.StandardModule rf = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

                Int32 ModelId = 0;
                Int32.TryParse(rf.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                _style = "position: relative; float: " + rf.Float + "; width: " + _width + "px;";


                this.RSSBox_holder.Attributes.Add("style", _style);
                this.RSSBox_holder.Visible = true;

                //this.lblShowAmount.Text = RXMali.GetXMLNode("Common/show");
                this.lblTitle.Text = Server.HtmlDecode(rf.Text1).Replace("`", "'");


                if (rf.Text6 != "")
                {
                    Int32 amount = 0;

                    Int32.TryParse(rf.Text7, out amount);
                    if (amount > 0)
                    {
                        this.ltrRSS.Text = ListRSS(rf.Text6, amount);
                        LoadDDLData(amount);
                    }
                    else
                    {
                        this.ltrRSS.Text = ListRSS(rf.Text6, 3);
                        LoadDDLData(3);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void LoadDDLData(Int32 amount)
    {
        String function_name = "LoadDDLData";
        try
        {
            //this.ddlAmount.Items.Add(new ListItem("3", "3"));
            //this.ddlAmount.Items.Add(new ListItem("5", "5"));
            //this.ddlAmount.Items.Add(new ListItem("10", "10"));

            //this.ddlAmount.SelectedValue = amount.ToString();
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlAmount_SelectedIndexChanged";
        try
        {
            RXServer.Modules.StandardModule rf = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            //this.ltrRSS.Text = ListRSS(rf.Text6, Convert.ToInt32(this.ddlAmount.SelectedValue));
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private String ListRSS(string feedurl, Int32 amount)
    {
        String function_name = "ListRSS";
        try
        {
            String html = "";

            html += "<table cellpadding='0' cellspacing='0'>";

            RssReader.RssReader rssReader = new RssReader.RssReader();
            rssReader.RdfMode = RXMali.CheckIfRDFFeed(feedurl);

            try
            {
                RssReader.RssFeed feed = rssReader.Retrieve(feedurl);


                this.lblHeader.Text = feed.Title;


                if (feed.ErrorMessage == null || feed.ErrorMessage == "")
                {
                    Int32 maxItems = amount;

                    if (maxItems == 0 || maxItems > feed.Items.Count)
                    {
                        maxItems = feed.Items.Count;
                    }

                    if (feed.Items.Count > 0)
                    {
                        for (int i = 0; i < maxItems; i++)
                        {
                            html += "<tr>";
                            html += "<td class='Text11_505050' valign='top'>»</td>";
                            html += "<td class='Text11_505050'>&nbsp;</td>";
                            html += "<td class='Text11_505050' valign='top'><a href='" + feed.Items[i].Link + "' target='_blank' class='black_link'>" + feed.Items[i].Title + "</a></td>";
                            html += "</tr>";
                            html += "<tr>";
                            html += "<td style='height: 10px; font-size: 1px;'></td>";
                            html += "</tr>";
                        }
                    }
                    else
                    {
                        this.lblHeader.Text = RXMali.GetXMLNode("Modules/RSS/no_data");
                        html += "<tr><td class='Text11_505050'>" + RXMali.GetXMLNode("Modules/RSS/no_data") + "</td></tr>";
                    }

                }
                else
                {
                    this.lblHeader.Text = RXMali.GetXMLNode("Modules/RSS/no_data");
                    html += "<tr><td class='Text11_505050'>" + RXMali.GetXMLNode("Modules/RSS/no_data") + "</td></tr>";
                }
            }
            catch
            {
                this.lblHeader.Text = RXMali.GetXMLNode("Modules/RSS/invalid_feed");
                html += "<tr><td class='Text11_505050'>" + RXMali.GetXMLNode("Modules/RSS/invalid_feed") + "</td></tr>";
            }

            html += "</table>";

            return html;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return String.Empty;
        }
    }


    
}
