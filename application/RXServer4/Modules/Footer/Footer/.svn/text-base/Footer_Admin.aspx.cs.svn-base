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
using System.IO;
using Telerik.Web.UI;
using System.Drawing;

public partial class Modules_Footer_Footer_Footer_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Footer_Footer_Footer_Admin";
    String ErrorList = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("Footer/Text");
            this.SubMenu.Visible = true;
            if (!Page.IsPostBack)
            {
                BindTextData();
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    public void BindTextData()
    {
        String function_name = "BindTextData";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            this.txtTitle.Text = Server.HtmlDecode(sm.Text6);
            this.RadEditor1.Content =  Server.HtmlDecode(sm.Text7);
            this.RadEditor2.Content = Server.HtmlDecode(sm.Text8);
            this.RadEditor3.Content =  Server.HtmlDecode(sm.Text9);
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
       
    protected void btnSaveData_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData_Click";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);

            sm.Text6 = Server.HtmlEncode(this.txtTitle.Text);
            String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
            sm.Text7 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor1.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { (path + "Default.aspx?PagId="), "/Upload/" }));
            sm.Text8 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor2.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { (path + "Default.aspx?PagId="), "/Upload/" }));
            sm.Text9 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor3.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { (path + "Default.aspx?PagId="), "/Upload/" }));
            sm.Save();

            this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

}
