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
using System.Numeric;

public partial class Modules__System_AdminUsers_AdminUsers_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules__System_AdminUsers_AdminUsers_Admin";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
			if (!RXServer.Auth.IsInRole("Admin"))
			{
				RXServer.Web.Redirect.To("~/Default.aspx");
			}

            BindData();
            BindMenu();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindData()
    {
        String function_name = "BindData";
        try
        {
            switch (RXServer.Web.RequestValues.Page)
            {
                case "Users":
                    this.UserPage.Visible = true;
                    break;

                case "Roles":
                    this.RolePage.Visible = true;
                    break;

                case "Pages":
                    this.PagePage.Visible = true;
                    break;

                case "ModDef":
                    this.ModulePage.Visible = true;
                    break;

                case "Start":
                    this.StartPage.Visible = true;
                    break;

				case "Shop":
					this.ShopPage.Visible = true;
					break;

                default:
                    this.StartPage.Visible = true;
                break;
            }
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindMenu()
    {

        String function_name = "BindMenu";
        try
        {
            String list = "";                

            list += "<table cellpadding='0' cellspacing='0' border='0'>";
            list += "<tr><td style='height:30px; width:10px;'></td>";

            if (RXServer.Web.RequestValues.Page == "Start" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td style='width:10px;'><img src='../../../App_Themes/WebAdmin/Images/menu_bg_left.gif' /></td><td style='height:30px; background-color:#CCCCCC'><a href='AdminView_Admin.aspx?Page=Start' class='header_on'>Start</a><td><img src='../../../App_Themes/WebAdmin/Images/menu_bg_right.gif' /></td>";
            }
            else
            {
                list += "<td style='width:10px;font-size:1px;'>&nbsp</td><td style='height:30px; background-color:#666666;'><a href='AdminView_Admin.aspx?Page=Start' class='header_off'>Start</a></td><td style='width:10px;font-size:1px;'>&nbsp;</td>";
            }
            if (RXServer.Web.RequestValues.Page == "Pages")
            {
                list += "<td style='width:10px;'><img src='../../../App_Themes/WebAdmin/Images/menu_bg_left.gif' /></td><td style='height:30px; background-color:#CCCCCC'><a href='AdminView_Admin.aspx?Page=Pages' class='header_on'>Pages</a><td><img src='../../../App_Themes/WebAdmin/Images/menu_bg_right.gif' /></td>";
            }
            else
            {
                list += "<td style='width:10px;font-size:1px;'>&nbsp</td><td style='height:30px; background-color:#666666;'><a href='AdminView_Admin.aspx?Page=Pages' class='header_off'>Pages</a></td><td style='width:10px;font-size:1px;'>&nbsp;</td>";
            }
            if (RXServer.Web.RequestValues.Page == "ModDef")
            {
                list += "<td style='width:10px;'><img src='../../../App_Themes/WebAdmin/Images/menu_bg_left.gif' /></td><td style='height:30px; background-color:#CCCCCC'><a href='AdminView_Admin.aspx?Page=ModDef' class='header_on'>Modules</a><td><img src='../../../App_Themes/WebAdmin/Images/menu_bg_right.gif' /></td>";
            }
            else
            {
                list += "<td style='width:10px;font-size:1px;'>&nbsp</td><td style='height:30px; background-color:#666666;'><a href='AdminView_Admin.aspx?Page=ModDef' class='header_off'>Modules</a></td><td style='width:10px;font-size:1px;'>&nbsp;</td>";
            }
            if (RXServer.Web.RequestValues.Page == "Roles")
            {
                list += "<td style='width:10px;'><img src='../../../App_Themes/WebAdmin/Images/menu_bg_left.gif' /></td><td style='height:30px; background-color:#CCCCCC'><a href='AdminView_Admin.aspx?Page=Roles' class='header_on'>Roles</a><td><img src='../../../App_Themes/WebAdmin/Images/menu_bg_right.gif' /></td>";
            }
            else
            {
                list += "<td style='width:10px;font-size:1px;'>&nbsp;</td><td style='height:30px; background-color:#666666;'><a href='AdminView_Admin.aspx?Page=Roles' class='header_off'>Roles</a></td><td style='width:10px;font-size:1px;'>&nbsp;</td>";
            }
            if (RXServer.Web.RequestValues.Page == "Users")
            {
                list += "<td style='width:10px;'><img src='../../../App_Themes/WebAdmin/Images/menu_bg_left.gif' /></td><td style='height:30px; background-color:#CCCCCC' ><a href='AdminView_Admin.aspx?Page=Users' class='header_on'>Users</a><td><img src='../../../App_Themes/WebAdmin/Images/menu_bg_right.gif' /></td>";
            }
            else
            {
                list += "<td style='width:10px;font-size:1px;'>&nbsp;</td><td style='height:30px; background-color:#666666;'><a href='AdminView_Admin.aspx?Page=Users' class='header_off'>Users</a></td><td style='width:10px;font-size:1px;'>&nbsp;</td>";
            }
			if (RXServer.Web.RequestValues.Page == "Shop")
			{
				list += "<td style='width:10px;'><img src='../../../App_Themes/WebAdmin/Images/menu_bg_left.gif' /></td><td style='height:30px; background-color:#CCCCCC' ><a href='AdminView_Admin.aspx?Page=Shop' class='header_on'>Shop</a><td><img src='../../../App_Themes/WebAdmin/Images/menu_bg_right.gif' /></td>";
			}
			else
			{
				list += "<td style='width:10px;font-size:1px;'>&nbsp;</td><td style='height:30px; background-color:#666666;'><a href='AdminView_Admin.aspx?Page=Shop' class='header_off'>Shop</a></td><td style='width:10px;font-size:1px;'>&nbsp;</td>";
			}

            list += "</tr>";
            list += "</table>";

            this.ltrAdminUserMenu.Text = list;
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    

}
