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

public partial class Modules__System_AdminHeader_AdminHeader : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules__System_AdminHeader_AdminHeader";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                Int32 pagId = RXServer.Web.RequestValues.PagId;

                if (pagId == 0)
                {
                    pagId = 1;
                }

                this.headerAdmin_holder.Visible = true;
                //this.hplEditTopMenu.NavigateUrl = "javascript:showAdminTopMenu(1,0," + this.ModId + ")";
                //this.hplEditTopMenuImg.NavigateUrl = "javascript:showAdminTopMenu(1,0," + this.ModId + ")";
                //this.hplEditSubMenu.NavigateUrl = "javascript:showAdminTopMenu(1," + pagId + "," + this.ModId + ")";
                //this.hplEditSubMenuImg.NavigateUrl = "javascript:showAdminTopMenu(1," + pagId + "," + this.ModId + ")";
                //this.hplEditMetaTags.NavigateUrl = "javascript:showAdminMetaTags(1," + this.PagId + "," + this.ModId + ")";
                //this.hplEditMetaTagsImg.NavigateUrl = "javascript:showAdminMetaTags(1," + this.PagId + "," + this.ModId + ")";
                //this.hplAdminView.NavigateUrl = "javascript:showAdminView(1," + this.PagId + "," + this.ModId + ")";
                //this.hplAdminViewImg.NavigateUrl = "javascript:showAdminView(1," + this.PagId + "," + this.ModId + ")";


                this.ltrEditTopMenu.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminTopMenu(1,0," + this.ModId + ");" + "\" class='adminmenu'>Top Menu</a>";
                this.ltrEditTopMenuImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminTopMenu(1,0," + this.ModId + ");" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminheader_edit.gif\" /></a>";
                this.ltrEditSubMenu.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminTopMenu(1," + pagId + "," + this.ModId + ");" + "\" class='adminmenu'>Sub Menu</a>";
                this.ltrEditSubMenuImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminTopMenu(1," + pagId + "," + this.ModId + ");" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminheader_edit.gif\" /></a>";
                this.ltrEditDefault.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminDefault(1," + pagId + "," + this.ModId + ");" + "\" class='adminmenu'>Default</a>";
                this.ltrEditDefaultImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminDefault(1," + pagId + "," + this.ModId + ");" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminheader_edit.gif\" /></a>";                
                this.ltrEditMetaTags.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminMetaTags(1," + pagId + "," + this.ModId + ");" + "\" class='adminmenu'>Meta Tags</a>";
                this.ltrEditMetaTagsImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminMetaTags(1," + pagId + "," + this.ModId + ");" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminheader_edit.gif\" /></a>";
                this.ltrAdminView.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminView(1," + pagId + "," + this.ModId + ");" + "\" class='adminmenu'>Site Manager</a>";
                this.ltrAdminViewImg.Text = "<a style=\"cursor:pointer;\" onclick=\"" + "showAdminView(1," + pagId + "," + this.ModId + ");" + "\"><img border=\"0\" src=\"" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "App_Themes/WebAdmin/Images/adminheader_window.gif\" /></a>";


                this.lblAdminWelcome.Text = "Welcome, " + RXServer.Auth.AuthorizedUser.Identity.Name;
            }
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
 
    }
    protected void hplAdminLogout_Click(object sender, EventArgs e)
    {
        String function_name = "hplAdminLogout_Click";
        try
        {
            RXServer.Auth.LogOut();
            Int32 pagId = RXServer.Web.RequestValues.PagId;
            if (pagId == 0)
            {
                pagId = 1;
            }
            Session["RXadmin"] = null;

			RXServer.Lib.SearchEngineOptimization.Optimize();
			if (false)
			{
				RXServer.Web.Redirect.To("~/Default.aspx?pagId=" + pagId);
			}
			else
			{
				RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(pagId));
			}
         }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void hplAdminLogoutImg_Click(object sender, EventArgs e)
    {
        String function_name = "hplAdminLogoutImg_Click";
        try
        {
            RXServer.Auth.LogOut();
            Int32 pagId = RXServer.Web.RequestValues.PagId;
            if (pagId == 0)
            {
                pagId = 1;
            }
            Session["RXadmin"] = null;

			RXServer.Lib.SearchEngineOptimization.Optimize();
			if (false)
			{
				RXServer.Web.Redirect.To("~/Default.aspx?pagId=" + pagId);
			}
			else
			{
				RXServer.Web.Redirect.To(RXServer.Lib.Common.Dynamic.GetFriendlyUrl(pagId));
			}
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
