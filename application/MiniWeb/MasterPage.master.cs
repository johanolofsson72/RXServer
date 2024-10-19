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

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated)
            this.imbExit.Visible = true;
        else
            this.imbExit.Visible = false;
    }
    protected void imbExit_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Admin.aspx?Id=1");
    }
}
