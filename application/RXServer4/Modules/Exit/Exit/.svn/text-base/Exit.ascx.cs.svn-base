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
using System.Text;
using System.IO;
using Telerik;
using Telerik.Web.UI;

public partial class Modules_Exit_Exit_Exit : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Exit_Exit_Exit";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.Exit_admin.Visible = true;
                this.img_AdminEdit.OnClientClick = "javascript:showAdminExit(1," + this.PagId + "," + this.ModId + "); return false;";
            }

            bindData();
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
            this.lblTitle.Text = Server.HtmlDecode(sm.Text6);
            this.lblText.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text7));

            //this.lnkGoBack.Text = RXMali.GetXMLNode("Common/close");


            if (Request["url"] != null)
            {   
                this.hplContinue.Text = RXMali.GetXMLNode("Common/continue");
                this.hplContinue.NavigateUrl = getUrl(Server.HtmlDecode(Request["url"].ToString()));
            }
 
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected String getUrl(String url)
    {
        if (url.StartsWith("http://"))
        {
            return url;
        }
        else
        {
            url = "http://" + url;
            return url;
        }
    }
 
}
