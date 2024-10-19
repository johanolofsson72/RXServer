using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;

public partial class Modules_User_UserTeaser_UserTeaser : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_User_UserTeaser_UserTeaser";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.UserTeaser_admin.Visible = true;
            }

            if (!Page.IsPostBack)
            {
                bindData();
            }
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
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);

            if (tm.Visible == "true" || RXServer.Auth.IsInRole("Admin"))
            {
                Int32 ModelId = 0;
                Int32.TryParse(tm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize("1");

                String _style = "";
                _style = "position: relative; float: left; width: " + _width + "px;";

                this.UserTeaser_admin.Attributes.Add("style", _style);
                this.UserTeaser_holder.Attributes.Add("style", _style);

                this.UserTeaser_holder.Visible = true;

                Int32 usrid = 0;
                Int32.TryParse(RXServer.Web.RequestValues.v1, out usrid);

                if (usrid > 0)
                {
                    RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(usrid);

                    //this.lblHeader.Text = Server.HtmlDecode(tm.Text2);
                    this.lblMember.Text = EE.EncodeEmails("Medlemsnr:" + Server.HtmlDecode(u.Fax));
                    string mail = Server.HtmlDecode(u.Mail) + "<br />";
                    this.lblMail.Text = EE.EncodeEmails("<a href='mailto:" + mail + "'>" + mail + "</a>");

                    String showMedia = "";

                    this.ltrMedia.Visible = false;

                    Int32 rolid = 0;
                    Int32.TryParse(u.GetRoles()[0].ToString(), out rolid);

                    RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(rolid);

                    string mediafile = "";

                    if (u.ImageUrl != "")
                    {
                        mediafile = "Upload/Users/" + r.Description + "/" + RXServer.Web.RequestValues.v1 + "/" + u.ImageUrl;
                        showMedia += "<img src='" + mediafile + "' style='width: " + 173 + "px;' title='" + u.FirstName + " " + u.LastName + "'/>";

                        this.ltrMedia.Visible = true;
                        this.ltrMedia.Text = showMedia;
                    }
                }
                else
                {
                    this.UserTeaser_holder.Visible = false;
                }

                if (tm.Visible == "true")
                {
                    this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_true.gif";
                    this.imbAdminVisible.ToolTip = "Hide Content";
                }
                else
                {
                    this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_false.gif";
                    this.imbAdminVisible.ToolTip = "Publish Content";
                }

            }
            else
            {
                this.UserTeaser_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void img_AdminMoveDown_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveDown_Click";
        try
        {
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);
            tm.ChangeOrderDown();
            tm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
        
    }
    protected void img_AdminMoveUp_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveUp_Click";
        try
        {
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);
            tm.ChangeOrderUp();
            tm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void img_AdminVisible_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminVisible_Click";
        try
        {
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);
            if (tm.Visible == "true")
            {
                tm.Visible = "false";
            }
            else
            {
                tm.Visible = "true";
            }
            tm.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


}
