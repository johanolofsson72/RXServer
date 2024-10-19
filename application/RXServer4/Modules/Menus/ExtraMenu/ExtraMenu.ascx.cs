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
using Telerik.RadMenuUtils;
using Telerik.Web.UI;


public partial class Modules_Menus_ExtraMenu_ExtraMenu : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Menus_ExtraMenu_ExtraMenu";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.imgMenuIcon.ToolTip = " ";
            this.imgMenuIcon.AlternateText = " ";

            if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
            {
                this.imgMenuIcon.ImageUrl = "~/Images/Site/menu/icon_menu_logged.gif";
                this.loggedmenu.Visible = true;
                this.loginmenu.Visible = false;
                this.lbnAddArticle.Text = RXMali.GetXMLNode("Modules/HM/create_article");
                this.lbnMyProfile.Text = RXMali.GetXMLNode("Modules/HM/my_profile");
                this.lbnMyProfile.OnClientClick = "javascript:showProfileWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
                this.lbnMyArticles.OnClientClick = "javascript:showMyArticlesWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
                this.lbnMyArticles.Text = RXMali.GetXMLNode("Modules/HM/my_articles");
                this.lbnLogout.Text = RXMali.GetXMLNode("Common/logout");
                this.ltrWelcome.Text = RXMali.GetXMLNode("Modules/HM/hello") + ",<br/><b>" + RXServer.Auth.AuthorizedUser.Identity.Name + "</b>";
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    this.lblLoginText.Text = RXMali.GetXMLNode("Modules/User/not_logged");
                    this.lblLoginText2.Text = RXMali.GetXMLNode("Common/login");
                    this.lbnForgotPass.Text = RXMali.GetXMLNode("Modules/User/forgot_pass");
                    this.imgMenuIcon.ImageUrl = "~/Images/Site/menu/icon_menu_login.gif";
                    this.txtUsername.Attributes.Add("onclick", "this.value='';");
                    this.txtPassword.Attributes.Add("onclick", "this.value='';");
                    this.txtUsername.Text = RXMali.GetXMLNode("Common/username");
                    this.txtPassword.Text = RXMali.GetXMLNode("Common/password");
                }
                this.lblTooltipLogin.Text = RXMali.GetXMLNode("Error/login");
                RenderScript();
                this.loginmenu.Visible = true;
                this.loggedmenu.Visible = false;
                this.lbnLogin.Text = RXMali.GetXMLNode("Common/login");
                this.lbnCreateAccount.Text = RXMali.GetXMLNode("Modules/User/create_account");
                this.lbnCreateAccount.OnClientClick = "javascript:showRegisterWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
                this.lbnForgotPass.OnClientClick = "javascript:showForgotPassWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";

                this.txtPassword.Attributes.Add("onkeydown", "SetSearchField(event, '" + this.btnL.ClientID + "')");
                this.txtUsername.Attributes.Add("onkeydown", "SetSearchField(event, '" + this.btnL.ClientID + "')");
                this.txtPassword.Attributes.Add("value", "password");
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


    protected void lbnLogout_Click(object sender, EventArgs e)
    {
        String function_name = "lbnLogout_Click";
        try
        {
            RXServer.Auth.LogOut();
            RXServer.Web.Redirect.To("~/Default.aspx?PagId=1");
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private Boolean LoginUser(string username, string pass)
    {
        String function_name = "LoginUser";
        try
        {
            if (CheckUser(username, pass))
            {
                RXServer.Auth.LogIn(username, pass);
                RXServer.Web.Redirect.To("~/Default.aspx?PagId=1");
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }

    }

    public Boolean CheckUser(string username, string pass)
    {
        String function_name = "CheckUser";
        try
        {
            if (RXServer.Auth.Users.UserNameExist(username))
            {
                Int32 uId = RXServer.Auth.Users.GetUserId(username);
                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);
                if (u.Password == pass)
                {
                    if (u.Status == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    protected void lbnLogin_Click(object sender, EventArgs e)
    {
        String function_name = "lbnLogin_Click";
        try
        {
            if (LoginUser(this.txtUsername.Text, this.txtPassword.Text))
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
            }
            else
            {
                this.tooltip_login_arrow.Visible = true;
                this.tooltip_login.Visible = true;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void RenderScript()
    {
        String function_name = "RenderScript";
        try
        {

            System.Text.StringBuilder Script = new System.Text.StringBuilder();
            Script.Append("<script type='text/javascript'>");
            Script.Append("  function SetSearchField(evt,element){");
            Script.Append("      var keyCode = evt.keyCode ? evt.keyCode : evt.which ? evt.which : evt.charCode;");
            Script.Append("      if(keyCode == 13){");
            Script.Append("         document.getElementById(element).click();");
            Script.Append("      }");
            Script.Append("  }");
            Script.Append("</script>");

            ScriptHolder.Controls.Add(new System.Web.UI.LiteralControl(Script.ToString()));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

}
