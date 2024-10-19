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

public partial class Modules_Boxes_TabTextBox_TabTextBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_TabTextBox_TabTextBox";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.TabTextBox_admin.Visible = true;
                if (RXMali.GetLastUrl(this.Page.MasterPageFile) == "Template3.master")
                {
                    this.img_AdminEdit.OnClientClick = "javascript:showAdminTabTextBox(1," + this.PagId + "," + this.ModId + ",'2'); return false;";
                }
                else
                {
                    this.img_AdminEdit.OnClientClick = "javascript:showAdminTabTextBox(1," + this.PagId + "," + this.ModId + ",'4'); return false;";
                }
                this.img_AdminDelete.OnClientClick = "javascript:showAdminDeleteModule(1," + this.PagId + "," + this.ModId + "); return false;";
            }

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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

            if (sm.Visible == "true" || RXServer.Auth.IsInRole("Admin"))
            {

                this.TabTextBox_holder.Visible = true;

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(sm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                String _float = "";

                if (sm.Float == "")
                {
                    _float = "left";
                }

                if (ModelId == 0)
                {
                    _width = 430;
                }

                _style = "position: relative; float: " + _float + "; width: " + _width + "px;";

                this.TabTextBox_admin.Attributes.Add("style", _style);
                this.TabTextBox_holder.Attributes.Add("style", _style);

                BindTabData2();

                // CONTENT

                if (sm.Visible == "true")
                {
                    this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_true.gif";
                    this.imbAdminVisible.ToolTip = "Hide Content";
                }
                else
                {
                    this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_false.gif";
                    this.imbAdminVisible.ToolTip = "Publish Content";
                }

            }
            else
            {
                this.TabTextBox_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void img_AdminMoveDown_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveDown_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            sm.ChangeOrderDown();
            sm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);            
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
        
    }
    protected void img_AdminMoveUp_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveUp_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            sm.ChangeOrderUp();
            sm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void img_AdminVisible_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminVisible_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            if (sm.Visible == "true")
            {
                sm.Visible = "false";
            }
            else
            {
                sm.Visible = "true";
            }
            sm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindTabData2()
    {
        string js = "";
        js += "<script type=\"text/javascript\">";       
        js += " var currentTab = 0;";
        js += " function openTab" + this.ModId + "(clickedTab) {";
        js += "     var thisTab = $(\".tabs" + this.ModId + " a\").index(clickedTab);";
        js += "     $(\".tabs" + this.ModId + " li a\").removeClass(\"active\");";
        js += "     $(\".tabs" + this.ModId + " li a:eq(\"+thisTab+\")\").addClass(\"active\");";
        js += "     $(\".tabbed-content" + this.ModId + "\").hide();";
        js += "     $(\".tabbed-content" + this.ModId + ":eq(\"+thisTab+\")\").show();";
	    js += "     currentTab = thisTab;";
        js += " }";
        js += " $(document).ready(function() {";
        js += " $(\".tabs" + this.ModId + " li a\").click(function() { ";
        js += " openTab" + this.ModId + "($(this)); return false; ";
        js += " });"; 
        js += " $(\".tabs" + this.ModId + " li a:eq(\"+currentTab+\")\").click()";
        js += " });";
        js += "</script>";
        
        RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("TabText_" + this.ModId);

        Int32 count = 0;
        string menu = "";
        string content = "";

        foreach (RXServer.Modules.Base.List.Item item in t)
        {

            if (item.Value6 == "true")
            {
                menu += "<li><a href=\"#\">" + Server.HtmlDecode(item.Value25) + "</a></li>";
                content += "<div class=\"tabbed-content" + this.ModId + "\">";
                content += "<h2>" + EE.EncodeEmails(Server.HtmlDecode(item.Value2)) + "</h2>";
                content += "<h4>" + EE.EncodeEmails(Server.HtmlDecode(item.Value4)) + "</h4>";
                content += "</div>";
            }
            count++;
        }

        string html = "";
        html += "<div id=\"TabTextBox" + this.ModId + "\"><div class=\"tabbed-menu\"><ul class=\"tabs" + this.ModId + " tabs\">";
        html += menu;
        html += "   </ul></div></div>";
        html += content;

        ltrTabText.Text = js + html;
    }

  
}
