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

public partial class Modules_Footer_Footer_Footer : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Footer_Footer_Footer";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
			if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
			{
				this.hplLogin.Visible = false;
			}
			else
			{
				this.lnbLogout.Visible = false;
			}

            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.Footer_admin.Visible = true;
                this.img_AdminEdit.OnClientClick = "javascript:showAdminFooter(1," + this.PagId + "," + this.ModId + "); return false;";
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
            this.lblCopyright.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text6));
            this.lblText2.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text7));
            this.lblText3.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text8));
            this.lblText4.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text9));
 
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

	protected void lnbLogout_Click(object sender, EventArgs e)
	{
		String function_name = "lnbLogout_Click";
		try
		{
			RXServer.Auth.LogOut();
			Int32 pagId = RXServer.Web.RequestValues.PagId;
			if (pagId == 0)
			{
				pagId = 1;
			}
			Session["RXadmin"] = null;
			RXServer.Web.Redirect.To("~/Default.aspx?pagId=" + pagId);
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
}
