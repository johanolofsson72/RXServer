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

public partial class Modules_Print_Print : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Print_Print";

    Int32 ModId, SitId, PagId;
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindData()
    {
        String function_name = "BindData";
        try
        {
            SitId = 1;
            ModId = 0;
            PagId = 0;

            if (Request["id"] != null)
            {
                if (Request["id"] != "")
                {
                    Int32.TryParse(Request["id"], out ModId);
                }
            }

            if (Request["pg"] != null)
            {
                if (Request["pg"] != "")
                {
                    Int32.TryParse(Request["pg"], out PagId);
                }
            }

            this.lblTitle.Text = RXMali.GetXMLNode("Common/sitename");
            this.lblTitleText.Text = RXMali.GetXMLNode("Modules/PopUp/Print/info");
            this.lblTitleText.Text += "<br />www." + RXMali.GetXMLNode("Common/siteurl");

            switch (Request["mod"])
            {
                case "ProductBrowser":
                    ProductBrowserData();
                    break;
                case "TextBox":
                    BindTextBoxData();
                    break;
                //case "LiteBox2":
                //    BindLiteBox2Data();
                //    break;
                //case "Calendar":
                //    BindCalendarData();
                //    break;
                case "News":
                    BindNewsData();
                    break;

                default:
                    this.lblHeader.Text = "No Data was found.";
                    break;

            }
        
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public void ProductBrowserData()
    {
        String function_name = "ProductBrowserData";
        try
        {
            if (ModId > 0 && PagId > 0)
            {
                RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(SitId, PagId, ModId);
                if (tm.Text2 != "")
                {
                    this.lblHeader.Text = Server.HtmlDecode(tm.Text2);
                    this.Header.Visible = true;
                }
                if (tm.Text1 != "")
                {
                    this.lblIngress.Text = Server.HtmlDecode(tm.Text1);
                    this.Ingress.Visible = true;
                }
                if (tm.Text3 != "")
                {
                    this.lblText.Text = Server.HtmlDecode(tm.Text3);
                    this.Text.Visible = true;
                }
                RXServer.Modules.Base.List cl = new RXServer.Modules.Base.List("ProductBrowserTab_" + ModId, LiquidCore.LiquidCore.Definition.ListDefinition.SortParamEnum.Order, LiquidCore.LiquidCore.Definition.ListDefinition.SortOrderEnum.Descending, 0, 1000);

                foreach (RXServer.Modules.Base.List.Item item in cl)
                    this.lblText.Text += "<br /><br /><br />"
                        + Server.HtmlDecode(item.Value1)
                        + "<br /><br />"
                        + Server.HtmlDecode(item.Value2);
              
            }
            else
            {
                ViewErrors();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    //public void BindLiteBoxData()
    //{
    //    String function_name = "BindLiteBoxData";
    //    try
    //    {
    //        if (ModId > 0 && PagId > 0)
    //        {
    //            RXServer.Modules.LiteBox lb = new RXServer.Modules.LiteBox(SitId, PagId, ModId);
    //            if (lb.Header != "")
    //            {
    //                this.lblHeader.Text = Server.HtmlDecode(lb.Header);
    //                this.Header.Visible = true;
    //            }
    //            if (lb.Text != "")
    //            {
    //                this.lblText.Text = Server.HtmlDecode(lb.Text);
    //                this.Text.Visible = true;
    //            }

    //        }
    //        else
    //        {
    //            ViewErrors();
    //        }            
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }

    //}

    public void BindTextBoxData()
    {
        String function_name = "BindTextBoxData";
        try
        {
            if (ModId > 0 && PagId > 0)
            {
                RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(SitId, PagId, ModId);
                if (tm.Text2 != "")
                {
                    this.lblHeader.Text = Server.HtmlDecode(tm.Text2);
                    this.Header.Visible = true;
                }
                if (tm.Text3 != "")
                {
                    this.lblIngress.Text = Server.HtmlDecode(tm.Text3);
                    this.Ingress.Visible = true;
                }
                if (tm.Text4 != "")
                {
                    this.lblText.Text = Server.HtmlDecode(tm.Text4);
                    this.Text.Visible = true;
                }

            }
            else
            {
                ViewErrors();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    //public void BindLiteBox2Data()
    //{
    //    String function_name = "BindLiteBox2Data";
    //    try
    //    {

    //        if (ModId > 0 && PagId > 0)
    //        {
    //            RXServer.Modules.LiteBox2 lb = new RXServer.Modules.LiteBox2(SitId, PagId, ModId);
    //            if (lb.Header != "")
    //            {
    //                this.lblHeader.Text = Server.HtmlDecode(lb.Header);
    //                this.Header.Visible = true;
    //            }
    //            if (lb.Text != "")
    //            {
    //                this.Text.Visible = true;
    //                this.lblText.Text = Server.HtmlDecode(lb.Text);
    //            }

    //        }
    //        else
    //        {
    //            ViewErrors();
    //        }
            
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }

    //}

    //public void BindCalendarData()
    //{
    //    String function_name = "BindCalendarData";
    //    try
    //    {

    //        if (ModId > 0 && PagId > 0)
    //        {
    //            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(ModId);
    //            if (i.Value2 != "")
    //            {
    //                this.lblHeader.Text = Server.HtmlDecode(i.Value2);
    //                this.Header.Visible = true;
    //            }
    //            if (i.Value3 != "")
    //            {
    //                this.Text.Visible = true;
    //                this.lblText.Text = Server.HtmlDecode(i.Value3);
    //            }


    //            if (i.Value4 != "")
    //            {
    //                String html = "";

    //                html += "<div id='event_place' style='position:relative; float: left; padding-right: 10px;'>";
    //                html += "<table cellpadding='0' cellspacing='0'>";
    //                html += "<tr>";
    //                html += "<td style='height: 20px;'>" + RXMali.GetXMLNode("Common/place") + ":" + "</td>";
    //                html += "<td style='font-size:1px; width:6px;'></td>";
    //                html += "<td style='height: 20px;'>" + Server.HtmlDecode(i.Value4) + "</td>";
    //                html += "<td></td>";
    //                html += "</tr>";
    //                html += "</table>";
    //                html += "</div>";
    //                html += "<div id='event_time' style='position:relative; float: left;'>";
    //                html += "<table cellpadding='0' cellspacing='0'>";
    //                html += "<tr>";
    //                html += "<td style='height: 20px;'>" + RXMali.GetXMLNode("Common/time") + ":" + "</td>";
    //                html += "<td style='font-size:1px; width:6px;'>&nbsp;</td>";
    //                html += "<td style='height: 20px;'>" + Server.HtmlDecode(i.Value11);
    //                if (i.Value12 != "")
    //                {
    //                    html += " - " + Server.HtmlDecode(i.Value12);
    //                }
    //                html += "</td></tr>";
    //                html += "</table>";
    //                html += "</div>";

    //                this.ltrIngress.Text = html;
    //                this.Ingress.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            ViewErrors();
    //        }
        
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }

    //}

    public void BindNewsData()
    {
        String function_name = "BindNewsData";
        try
        {

            if (ModId > 0 && PagId > 0)
            {
                RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(ModId);
                if (i.Value2 != "")
                {
                    this.lblHeader.Text = Server.HtmlDecode(i.Value2);
                    this.Header.Visible = true;
                }
                if (i.Value4 != "")
                {
                    this.Text.Visible = true;
                    this.lblText.Text = Server.HtmlDecode(i.Value4);
                }
                if (i.Value10 != "")
                {
                    this.Ingress.Visible = true;
                    this.lblIngress.Text = Server.HtmlDecode(i.Value10);
                }

            }
            else
            {
                ViewErrors();
            }
        
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public void ViewErrors()
    {
        String function_name = "ViewErrors";
        try
        {
            this.Header.Visible = true;
            this.lblHeader.Text = "No Data was found.";        
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


}
