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

                this.TabTextBox_holder.Attributes.Add("style", _style);

                BindTabData2();
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
                menu += "<div class='tabs_left'>&nbsp;</div><div class='tabs_mid'><li><a href=\"#\">" + Server.HtmlDecode(item.Value25).Replace("`", "'") + "</a></li></div><div class='tabs_right'>&nbsp;</div>";
                content += "<div class=\"tabbed-content" + this.ModId + "\" style='float: left; width: 100%; border-top: solid 1px #D9D9D9;'>";
                content += "<h2>" + EE.EncodeEmails(Server.HtmlDecode(item.Value2)).Replace("`", "'") + "</h2>";
                content += "<p>" + EE.EncodeEmails(Server.HtmlDecode(item.Value4)).Replace("`", "'") + "</p>";
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
