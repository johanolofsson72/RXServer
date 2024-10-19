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

public partial class Modules_Menus_TopMenu_TopMenu : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Menus_TopMenu_TopMenu";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {

            if (RXServer.Auth.AuthorizedUser.Identity.Authenticated)
            {
                this.loggedmenu.Visible = false;
                this.loginmenu.Visible = false;
                //this.lbnAddArticle.Text = RXMali.GetXMLNode("Modules/HM/create_article");
                //this.lbnMyProfile.Text = RXMali.GetXMLNode("Modules/User/settings_title");
                //this.lbnMyProfile.OnClientClick = "javascript:showProfileWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
                //this.lbnMyArticles.OnClientClick = "javascript:showMyArticlesWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
                //this.lbnMyArticles.Text = RXMali.GetXMLNode("Modules/HM/my_articles");
                //this.lbnLogout.Text = RXMali.GetXMLNode("Common/logout");
                //this.ltrWelcome.Text = RXMali.GetXMLNode("Modules/User/welcome") + ", <b>" + RXServer.Auth.AuthorizedUser.Identity.Name + "</b> <a href='Default.aspx?PagId=" + ConfigurationManager.AppSettings["MembersPage"].ToString() + "&amp;v1=" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "'><img src='Images/Modules/Menu/icon_home.gif' class='img_noborder' alt='min sida' /></a>";
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    //this.lblLoginText.Text = RXMali.GetXMLNode("Modules/User/not_logged");
                    //this.lblLoginText2.Text = RXMali.GetXMLNode("Common/login");
                    //this.lbnForgotPass.Text = RXMali.GetXMLNode("Modules/User/forgot_pass");
                    //this.txtUsername.Attributes.Add("onclick", "this.value='';");
                    //this.txtPassword.Attributes.Add("onclick", "this.value='';");
                    //this.txtUsername.Text = RXMali.GetXMLNode("Common/username");
                    //this.txtPassword.Text = RXMali.GetXMLNode("Common/password");
                }
                this.lblTooltipLogin.Text = RXMali.GetXMLNode("Error/login");
                RenderScript();
                this.loginmenu.Visible = false;
                this.loggedmenu.Visible = false;
                //this.lbnLogin.Text = RXMali.GetXMLNode("Common/ok");
                //this.lbnCreateAccount.Text = RXMali.GetXMLNode("Modules/User/create_account");
                //this.lbnCreateAccount.OnClientClick = "javascript:showRegisterWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";
                //this.lbnForgotPass.OnClientClick = "javascript:showForgotPassWindow(1," + RXServer.Web.RequestValues.PagId + "," + this.ModId + "); return false;";

                //this.txtPassword.Attributes.Add("onkeydown", "SetSearchField(event, '" + this.btnL.ClientID + "')");
                //this.txtUsername.Attributes.Add("onkeydown", "SetSearchField(event, '" + this.btnL.ClientID + "')");
                //this.txtPassword.Attributes.Add("value", "password");
            }

            if (!Page.IsPostBack)
            {
                bindMenu();
                bindSearch();
            }
            if (RXServer.Auth.Roles.GetRoleId(RXServer.Auth.AuthorizedUser.Identity.Role) == 1)
            {
                this.modules_access.Visible = true;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void bindMenu()
    {
        String function_name = "bindMenu";
        try
        {
            using (RXServer.Modules.Menu m = ((RXServer.Lib.RXBasePage)this.Page).CurrentTopMenu)
            {
                String menu = "<table cellspacing='0' cellpadding='0'><tr>";

                if (m.Count > 0)
                {
                    Int32 counter = 0;
                    Int32 counter2 = 1;
                    foreach (LiquidCore.Menu.Item mi in m)
                        if (!mi.Hidden)
                            counter++;

                    foreach (LiquidCore.Menu.Item mi in m)
                    {
						if (!mi.Hidden || RXServer.Auth.IsInRole("Admin"))
                        {
                            if (mi.Id.Equals(RXServer.Web.CurrentValues.PagId) || mi.Id.Equals(RXServer.Web.SelectedPages.Level1))
                            {
                                menu += "<td class='menu1_left_on'></td>";
								if (false)
								{
									menu += "<td align='center' class='menu1_middle_on'><a href='Default.aspx?PagId=" + mi.Id + "' class='menu1_on'>" + Server.HtmlDecode(mi.Title).ToUpper() + "</a></td>";
								}
								else
								{
									menu += "<td align='center' class='menu1_middle_on'><a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(mi.Id) + "' class='menu1_on'>" + mi.Title.ToUpper() + "</a></td>";
								}
                                
								menu += "<td class='menu1_right_on'></td>";
                            }
                            else
                            {
								menu += "<td class='menu1_left_off'></td>";
								if (false)
								{
									menu += "<td align='center' class='menu1_middle_off'><a href='Default.aspx?PagId=" + mi.Id + "' class='menu1_off'>" + Server.HtmlDecode(mi.Title).ToUpper() + "</a></td>";
								}
								else
								{
									menu += "<td align='center' class='menu1_middle_off'><a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(mi.Id) + "' class='menu1_off'>" + mi.Title.ToUpper() + "</a></td>";
								}

								menu += "<td class='menu1_right_off'></td>";
                            }

                            if (counter2 != counter)
                            {
                                menu += "<td class='menu1_divider'>&nbsp;</td>";
                                counter2++;
                            }

                        }
                    }
                }
                menu += "</tr></table>";
                this.ltrTopMenu.Text = menu;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void bindSearch()
    {
        String function_name = "bindSearch";
        try
        {
            //this.txtSearch.Attributes.Add("onkeydown", "SetSearchField(event, '" + this.imbSearch.ClientID + "')");

            if (Session["RXServer_txtSearch"] != null)
            {
                this.txtSearch.Text = Session["RXServer_txtSearch"].ToString();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void imbSearch_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbSearch_Click";
        try
        {
            Session.Add("RXServer_txtSearch", txtSearch.Text);
            Session["SearchLevel"] = 1;
            Session["SearchOldLevel"] = 1;

			if (false)
			{
				RXServer.Web.Redirect.To("~/Default.aspx?pagId=2");
			}
			else
			{
				RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(2));
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

			if (false)
			{
				RXServer.Web.Redirect.To("~/Default.aspx?pagId=1");
			}
			else
			{
				RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(1));
			}
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

				if (false)
				{
					RXServer.Web.Redirect.To("~/Default.aspx?pagId=1");
				}
				else
				{
					RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(1));
				}

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
        //String function_name = "lbnLogin_Click";
        //try
        //{
        //    if (LoginUser(this.txtUsername.Text, this.txtPassword.Text))
        //    {
        //        this.txtUsername.Text = "";
        //        this.txtPassword.Text = "";
        //    }
        //    else
        //    {
        //        this.tooltip_login_arrow.Visible = true;
        //        this.tooltip_login.Visible = true;
        //    }
        //}
        //catch (Exception ex)
        //{
        //    RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        //}
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
