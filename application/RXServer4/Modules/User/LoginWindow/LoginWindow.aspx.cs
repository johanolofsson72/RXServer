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
            this.Title = "History Mapping -  Logga In";
            this.lblLoginError.Text = RXMali.GetXMLNode("Error/login");

            BindMenuData();

            this.Page_1.Visible = true;

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
            if (RXServer.Web.RequestValues.Page == "login" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='link_333333' href='AddAddonWindow_Admin.aspx?Page=login&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>Logga In</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #CCCCCC;'><a class='link_575757' href='AddAddonWindow_Admin.aspx?Page=login&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>Logga In</a></td>";
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
                String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                this.lblScript.Text = "<script language='javascript'>CloseRedirect('" + path + "Default.aspx?PagId=1');</script>";

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

}
