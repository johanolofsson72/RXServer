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

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            logOut();
        }
    }
    protected void loginctrl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (FormsAuthentication.Authenticate(loginctrl.UserName.ToString(), loginctrl.Password.ToString()))
        { e.Authenticated = true; }
        else
        { e.Authenticated = false; }
    }
    private void logOut()
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Default.aspx");
    }
}
