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

public partial class Modules_Links_LinkHolder_LinkHolder : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Links_LinkHolder_LinkHolder";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
                populateDDL1();
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
            if (Request["txt"] != null)
            {
                this.linkName.Text = Request["txt"].ToString();
            }

            String js = "";

            js += "<script type=\"text/javascript\">";
            js += "if (window.attachEvent)";
            js += "{";
            js += "    window.attachEvent(\"onload\", initDialog);";
            js += "}";
            js += "else if (window.addEventListener)";
            js += "{";
            js += "    window.addEventListener(\"load\", initDialog, false);";
            js += "}";

            js += "var linkUrl = document.getElementById(\"" + this.linkUrl.ClientID + "\");";
            js += "var linkName = document.getElementById(\"" + this.linkName.ClientID + "\");"; //this.linkName.ClientID
            js += "var workLink = null;";

            js += "function getRadWindow()";
            js += "{";
            js += "       if (window.radWindow)";
            js += "    {";
            js += "        return window.radWindow;";
            js += "    }";
            js += "    if (window.frameElement && window.frameElement.radWindow)";
            js += "    {";
            js += "        return window.frameElement.radWindow;";
            js += "    }";
            js += "    return null;";
            js += "}";

            js += "function initDialog()";
            js += "{";
            js += "   var clientParameters = getRadWindow().ClientParameters;";
            js += "   workLink = clientParameters;";
            js += "}";

            js += "function insertLink()";
            js += "{";
            js += "   var level = 0;";
            js += "    var pagId = 0;";

            js += "    var MyLinkContainer1 = document.getElementById(\"ddlLevel1\");";
            js += "    var MyLinkContainer2 = document.getElementById(\"ddlLevel2\");";
            js += "    var MyLinkContainer3 = document.getElementById(\"ddlLevel3\");";
            js += "    var MyLinkContainer4 = document.getElementById(\"ddlLevel4\");";
            js += "    var MyLinkContainer5 = document.getElementById(\"ddlLevel5\");";

            js += "    var ddl1 = MyLinkContainer1.options[MyLinkContainer1.selectedIndex].value;";
            js += "    var ddl2 = MyLinkContainer2.options[MyLinkContainer2.selectedIndex].value;";
            js += "    var ddl3 = MyLinkContainer3.options[MyLinkContainer3.selectedIndex].value;";
            js += "    var ddl4 = MyLinkContainer3.options[MyLinkContainer4.selectedIndex].value;";
            js += "    var ddl5 = MyLinkContainer3.options[MyLinkContainer5.selectedIndex].value;";

            js += "    if (ddl1 > 0)";
            js += "    {";
            js += "        pagId = ddl1;";
            js += "        level = 1;";
            js += "    }";
            js += "    if (ddl2 > 0)";
            js += "    {";
            js += "        pagId = ddl2;";
            js += "        level = 2;";
            js += "    }";
            js += "    if (ddl3 > 0)";
            js += "    {";
            js += "        pagId = ddl3;";
            js += "        level = 3;";
            js += "    }";
            js += "    if (ddl4 > 0)";
            js += "    {";
            js += "        pagId = ddl4;";
            js += "        level = 4;";
            js += "    }";
            js += "    if (ddl5 > 0)";
            js += "    {";
            js += "        pagId = ddl5;";
            js += "        level = 5;";
            js += "    }";

            //create an object and set some custom properties to it      
            js += "   workLink.target = linkUrl.value;";
            js += "   workLink.name = linkName.value;";

            js += "   getRadWindow().close(workLink);";
            js += "}";
            js += "</script>";

            this.ltrJavaScript.Text = js;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void populateDDL1()
    {
        String function_name = "populateDDL1";
        try
        {
            int ModId = RXServer.Web.RequestValues.ModId;
            int PagId = RXServer.Web.RequestValues.PagId;
            int SitId = RXServer.Web.RequestValues.SitId;

            this.ddlLevel1.Items.Add(new ListItem("Choose category", "0"));
            this.ddlLevel2.Items.Add(new ListItem("-", "0"));
            this.ddlLevel3.Items.Add(new ListItem("-", "0"));
            this.ddlLevel4.Items.Add(new ListItem("-", "0"));
            this.ddlLevel5.Items.Add(new ListItem("-", "0"));

            RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, 0, 1);
            if (m.Count > 0)
            {
                foreach (LiquidCore.Menu.Item mi in m)
                {
                    this.ddlLevel1.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                }
            }

            RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, 0, 2);
            if (m2.Count > 0)
            {
                foreach (LiquidCore.Menu.Item mi2 in m2)
                {
                    this.ddlLevel1.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                }
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void populateDDL2(int pageParentId)
    {
        String function_name = "populateDDL2";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 1);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel2.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
                RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m2.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi2 in m2)
                    {
                        this.ddlLevel2.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void populateDDL3(int pageParentId)
    {
        String function_name = "populateDDL3";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 1);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel3.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
                RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m2.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi2 in m2)
                    {
                        this.ddlLevel3.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void populateDDL4(int pageParentId)
    {
        String function_name = "populateDDL4";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 1);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel4.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
                RXServer.Modules.Menu m2 = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m2.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi2 in m2)
                    {
                        this.ddlLevel4.Items.Add(new ListItem(Server.HtmlDecode(mi2.Title.ToString()), mi2.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void populateDDL5(int pageParentId)
    {
        String function_name = "populateDDL5";
        try
        {
            if (pageParentId != 0)
            {
                RXServer.Modules.Menu m = new RXServer.Modules.Menu(1, pageParentId, 2);
                if (m.Count > 0)
                {
                    foreach (LiquidCore.Menu.Item mi in m)
                    {
                        this.ddlLevel5.Items.Add(new ListItem(Server.HtmlDecode(mi.Title.ToString()), mi.Id.ToString()));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


    protected void ddlLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel1_SelectedIndexChanged";
        try
        {
            //insertFileIfPostBack();

            this.ddlLevel2.Items.Clear();
            this.ddlLevel3.Items.Clear();
            this.ddlLevel4.Items.Clear();
            this.ddlLevel5.Items.Clear();

            this.ddlLevel2.Items.Add(new ListItem("Choose category", "0"));
            this.ddlLevel3.Items.Add(new ListItem("-", "0"));
            this.ddlLevel4.Items.Add(new ListItem("-", "0"));
            this.ddlLevel5.Items.Add(new ListItem("-", "0"));

            this.linkUrl.Text = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(Convert.ToInt32(this.ddlLevel1.SelectedItem.Value));

            populateDDL2(Convert.ToInt32(this.ddlLevel1.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlLevel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel2_SelectedIndexChanged";
        try
        {
            //insertFileIfPostBack();

            this.ddlLevel3.Items.Clear();
            this.ddlLevel4.Items.Clear();
            this.ddlLevel5.Items.Clear();
            this.ddlLevel3.Items.Add(new ListItem("Choose category ", "0"));
            this.ddlLevel4.Items.Add(new ListItem("- ", "0"));
            this.ddlLevel5.Items.Add(new ListItem("- ", "0"));

            this.linkUrl.Text = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(Convert.ToInt32(this.ddlLevel2.SelectedItem.Value));

            populateDDL3(Convert.ToInt32(this.ddlLevel2.SelectedItem.Value));

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    protected void ddlLevel3_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel3_SelectedIndexChanged";
        try
        {
            //insertFileIfPostBack();

            this.ddlLevel4.Items.Clear();
            this.ddlLevel5.Items.Clear();
            this.ddlLevel4.Items.Add(new ListItem("Choose category ", "0"));
            this.ddlLevel5.Items.Add(new ListItem("- ", "0"));

            this.linkUrl.Text = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(Convert.ToInt32(this.ddlLevel3.SelectedItem.Value));

            populateDDL4(Convert.ToInt32(this.ddlLevel3.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlLevel4_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel4_SelectedIndexChanged";
        try
        {

            this.ddlLevel5.Items.Clear();
            this.ddlLevel5.Items.Add(new ListItem("Choose category ", "0"));

            this.linkUrl.Text = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(Convert.ToInt32(this.ddlLevel4.SelectedItem.Value));

            populateDDL5(Convert.ToInt32(this.ddlLevel4.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlLevel5_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlLevel5_SelectedIndexChanged";
        try
        {
            this.linkUrl.Text = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(Convert.ToInt32(this.ddlLevel5.SelectedItem.Value));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
