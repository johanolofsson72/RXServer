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

public partial class Modules_User_UserInfo_UserInfo : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_User_UserInfo_UserInfo";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.UserInfo_admin.Visible = true;                
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
                // Sets Module Width

                Int32 usrid = 0;
                Int32.TryParse(RXServer.Web.RequestValues.v1, out usrid);

                if (usrid > 0)
                {

                    Int32 ModelId = 0;
                    Int32.TryParse(tm.ModelId, out ModelId);
                    Int32 _width = RXMali.GetModelSize("2");
                    String _float = "";

                    if (tm.Float == "")
                    {
                        _float = "left";
                    }
                    else
                    {
                        _float = tm.Float;
                    }

                    String _style = "";
                    String _style2 = "";

                    _style = "position: relative; float: " + _float + "; width: " + _width + "px; padding-bottom: 20px;";
                    _style2 = "position: relative; float: " + _float + "; width: " + _width + "px;";

                    this.UserInfo_admin.Attributes.Add("style", _style2);
                    this.UserInfo_holder.Attributes.Add("style", _style);

                    String fontsize_1 = "";
                    String fontsize_2 = "";


                    this.text_size.Visible = true;
                    this.ltrFontLoader.Visible = true;
                   
                    string font_html = "";


                    font_html += "<a style=\"cursor:pointer\" onclick=\"SetFontSize('small');ChangeFontSize('" + this.lblHeader.ClientID + ";" + this.lblIngress.ClientID + ";" + this.lblText.ClientID + "');\"><img src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "Images/Modules/Boxes/fs_small.gif' alt='Normal size' title='Normal size' /></a>";
                    font_html += "<a style=\"cursor:pointer\" onclick=\"SetFontSize('medium');ChangeFontSize('" + this.lblHeader.ClientID + ";" + this.lblIngress.ClientID + ";" + this.lblText.ClientID + "');\"><img src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "Images/Modules/Boxes/fs_medium.gif' alt='Large size' title='Large size' /></a>";
                    font_html += "<a style=\"cursor:pointer\" onclick=\"SetFontSize('large');ChangeFontSize('" + this.lblHeader.ClientID + ";" + this.lblIngress.ClientID + ";" + this.lblText.ClientID + "');\"><img src='" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "Images/Modules/Boxes/fs_large.gif' alt='Extra Large size' title='Extra Large size' /></a>";

                    this.ltrFontResizer.Text = font_html;
                    this.ltrFontLoader.Text += "<script language='javascript' type='text/javascript'>ChangeFontSize('" + this.lblHeader.ClientID + ";" + this.lblIngress.ClientID + ";" + this.lblText.ClientID + "');</script>";


                    this.UserInfo_holder.Visible = true;


                    RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(usrid);

                    this.lblHeader.Text = fontsize_1 + Server.HtmlDecode(u.FirstName + " " + u.LastName) + fontsize_2;

                    string ingress = "";

                    ingress += "Medlemsnummer: " + Server.HtmlDecode(u.Fax) + "<br />";
                    ingress += "Motorcykel: " + Server.HtmlDecode(u.Company) + "<br />";
                    ingress += "Årsmodell: " + Server.HtmlDecode(u.Company2) + "<br />";
                    ingress += "Kört hoj sedan: " + Server.HtmlDecode(u.CO2) + "<br />";

                    if (ingress == "")
                    {
                        this.IngressText.Visible = false;
                    }
                    else
                    {
                        this.IngressText.Visible = true;
                    }

                    this.lblIngress.Text = fontsize_1 + EE.EncodeEmails(Server.HtmlDecode(ingress)) + fontsize_2;
                    this.lblText.Text = fontsize_1 + EE.EncodeEmails(Server.HtmlDecode(u.Description)) + fontsize_2;
                }
                //else if(Request["v1"] != null)
                //{
                //    if (Request["v1"] == "")
                //    {
                //        this.lblIngress.Text = "Användare existerar inte";
                //        this.UserInfo_holder.Visible = true;
                //    }
                //}
                else
                {
                    this.UserInfo_holder.Visible = false;
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
                this.UserInfo_holder.Visible = false;
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
