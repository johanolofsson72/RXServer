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

public partial class Modules_User_LoginWindow_LoginWindow : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_User_LoginWindow_LoginWindow";
    Int32 SitId = RXServer.Web.RequestValues.SitId;
    Int32 ModId = RXServer.Web.RequestValues.ModId;
    Int32 PagId = RXServer.Web.RequestValues.PagId;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetFocus(txtUsername);

        String function_name = "Page_Load";
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindData()
    {
        String function_name = "BindData";
        try
        {
			BindMenuData();
			this.Title = "RXLogin";

			switch (RXServer.Web.RequestValues.Page)
			{
				case "Register":
					if (ConfigurationManager.AppSettings["Users.AllowPublicRegistration"].Equals("true"))
					{
						this.Page_2.Visible = true;
					}
					else
					{
						this.lblLoginError.Text = RXMali.GetXMLNode("Error/login");
						this.Page_1.Visible = true;
					}
					break;

				default:
					this.lblLoginError.Text = RXMali.GetXMLNode("Error/login");
					this.Page_1.Visible = true;
					break;
			}

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public void HideWindows()
    {
        String function_name = "HideWindows";
        try
        {
            this.Page_1.Visible = false;
			this.Page_2.Visible = false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindMenuData()
    {
        String function_name = "BindMenuData";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";

			String url = RXMali.GetLastUrl(Request.Url.ToString());
			url = url.Replace("?Page=Login", "");
			url = url.Replace("?Page=Register", "");
			if(RXServer.Web.RequestValues.Page.Equals("") || RXServer.Web.RequestValues.Page.Equals("Login"))
			{
				list += "<td style='padding: 10px; background-color: white;'>Logga In</a></td>";
			}
			else
			{
				list += "<td style='padding: 10px;'><a href='" + url + "?Page=Login'>Logga In</a></td>";
			}

			if (ConfigurationManager.AppSettings["Users.AllowPublicRegistration"].Equals("true"))
			{
				if (RXServer.Web.RequestValues.Page.Equals("Register"))
				{
					list += "<td style='padding: 10px; background-color: white;'>Ny användare</a></td>";
				}
				else
				{
					list += "<td style='padding: 10px;'><a href='" + url + "?Page=Register'>Ny användare</a></td>";
				}
			}
			
			list += "</tr>";
            list += "</table>";


            this.ltrSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
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

				String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(1);
				if (false)
				{
					if (RXServer.Auth.IsInRole("Admin"))
					{
						RXServer.Web.Redirect.To("~/Default.aspx");
					}
					else
					{
						LiquidCore.Menu userPages = new LiquidCore.Menu(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name).ToString());
						if (userPages.Count > 0)
						{
							RXServer.Web.Redirect.To("~/Default.aspx?pagId=" + userPages[0].Id);
						}
						else
						{
							RXServer.Web.Redirect.To("~/Default.aspx");
						}
					}

				}
				else
				{
					String path = "http://" + Request.Url.Authority;
					//RXServer.Web.Redirect.To(path + friendlyUrl);

					if (RXServer.Auth.IsInRole("Admin"))
					{
						RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(1));
					}
					else
					{
						LiquidCore.Menu userPages = new LiquidCore.Menu(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name).ToString());
						if (userPages.Count > 0)
						{
							RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(userPages[0].Id));
						}
						else
						{
							RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(1));
						}
					}
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
                 this.loginError.Visible = true;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
	protected void lbnRegister_Click(object sender, EventArgs e)
	{
		String function_name = "lbnRegister_Click";
		try
		{
			bool valid = true;
			String errors = "";

			if (this.txtRegUserName.Text.Equals(""))
			{
				errors += " - Användarnamn saknas<br />";
				valid = false;
			}

			if (RXServer.Auth.Users.UserNameExist(this.txtRegUserName.Text))
			{
				errors += " - Användarnamn finns redan.<br />";
				valid = false;
			}

			if (this.txtRegPass.Text.Equals(""))
			{
				errors += " - Lösenord saknas.<br />";
				valid = false;
			}

			if (!this.txtRegPass.Text.Equals(this.txtRegPassConfirm.Text))
			{
				errors += " - Lösenorden matchar inte.<br />";
				valid = false;
			}

			if (!RXMali.IsEmail(this.txtRegEmail.Text))
			{
				errors += " - Email inte giltig.<br />";
				valid = false;
			}

			if (RXServer.Auth.Users.UserEmailExist(this.txtRegEmail.Text))
			{
				errors += " - Email finns redan.<br />";
				valid = false;
			}

			if (valid)
			{
				int uId = RXServer.Auth.Users.CreateUser(this.txtRegUserName.Text, txtRegEmail.Text, "User", this.txtRegPass.Text, RXServer.Auth.Roles.GetRoleId(ConfigurationManager.AppSettings["Users.PublicRegistrationDefaultRole"]));
				if (uId > 0)
				{
					RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item();
					mItem.SitId = 1;
					mItem.Language = 1;
					mItem.Status = 3;
					mItem.ParentId = 0;
					mItem.Template = "Template1.master";
					mItem.Title = Server.HtmlEncode("User page (" + this.txtRegUserName.Text + ")").Replace("'", "`");
					mItem.Alias = uId.ToString();
					mItem.ModelId = 1;
					mItem.Hidden = false;
					mItem.Save();

					CreateUserFolder(RXServer.Auth.Roles.GetRoleId(ConfigurationManager.AppSettings["Users.PublicRegistrationDefaultRole"]), uId);

					LoginUser(this.txtRegUserName.Text, this.txtRegPass.Text);
					this.txtRegEmail.Text = "";
					this.txtRegPass.Text = "";
					this.txtRegPassConfirm.Text = "";
					this.txtRegUserName.Text = "";
				}
				else
				{
					this.lblRegisterError.Text = "Oväntat fel uppstod vid skapande av konto. Kontakta administratören.";
					this.registerError.Visible = true;
				}
			}
			else
			{
				this.lblRegisterError.Text = errors;
				this.registerError.Visible = true;
			}
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

	private void CreateUserFolder(Int32 roleId, Int32 userId)
	{
		String function_name = "CreateUserFolder";
		try
		{
			RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(roleId);

			string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/");
			string newPath = System.IO.Path.Combine(activeDir, userId.ToString());

			System.IO.Directory.CreateDirectory(newPath);

		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}

	}
}
