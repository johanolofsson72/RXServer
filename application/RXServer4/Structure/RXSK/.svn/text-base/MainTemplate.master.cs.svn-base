using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (RXServer.Auth.IsInRole("Admin"))
        {
            this.admin_container.Visible = true;

            // Om man har en sida med mycket laddning EFTER
            if (Session["RXadmin"] == null)
            {
                //this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/Loading/1.0/loading.js'></script><script type='text/javascript'>window.onload = function(){renderLoadingPanel('" + RXMali.GetDomainUrl(Request.Url.ToString()) + "'); displayLoadingPanel(); setTimeout('hideLoadingPanel()', 400); } </script>"));
                Session["RXadmin"] = "set";
            }
        }

		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/JScript.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/swfobject.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/jquery-1.3.2.min.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/jquery.galleriffic.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/RXfontresizer.js'></script>"));

		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/mbTabset/jquery.metadata.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/mbTabset/mbTabset.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/mbTabset/mbTabset.min.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/mbTabset/ui.core.min.js'></script>"));
		this.PageHead.Controls.Add(new LiteralControl("<script type='text/javascript' src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "JS/mbTabset/ui.sortable.min.js'></script>"));

    }

    protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        Telerik.Web.UI.RadAjaxPanel panel = (Telerik.Web.UI.RadAjaxPanel)RXServer.Lib.Common.FindControlRecursive(this, "RadAjaxPanelCart");
        if (panel != null)
        {
        }
    }
}
