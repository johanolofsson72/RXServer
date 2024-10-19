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

public partial class Modules_Boxes_ArticleBox_ArticleBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_ArticleBox_ArticleBox";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.ArticleBox_admin.Visible = true;
                this.img_AdminEdit.OnClientClick = "javascript:showAdminArticleBox(1," + this.PagId + "," + this.ModId + ",'medium'); return false;";
                this.img_AdminDelete.OnClientClick = "javascript:showAdminDeleteModule(1," + this.PagId + "," + this.ModId + "); return false;";
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
            String showMedia = "";
            String social_img = "";
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);

            if (tm.Visible == "true" || RXServer.Auth.IsInRole("Admin"))
            {
                String fontsize_1 = "";
                String fontsize_2 = "";

                if (tm.ExtraFont == "true")
                {
                    this.text_size.Visible = true;
                    #region fontsize

                    this.imbLargeText.ImageUrl = "~/Images/Modules/Boxes/fs_large.gif";
                    this.imbMediumText.ImageUrl = "~/Images/Modules/Boxes/fs_medium.gif";
                    this.imbSmallText.ImageUrl = "~/Images/Modules/Boxes/fs_small.gif";
                    if (tm.Updated != "")
                    {
                        this.lblUpdated.Text = RXMali.GetXMLNode("Common/updated") + " : " + tm.Updated;
                    }

                    this.lblFontsize.Text = RXMali.GetXMLNode("Common/fontsize") + ":";

                    if (Session != null)
                    {
                        if (Session["font_" + this.ModId] != null)
                        {
                            switch (Session["font_" + this.ModId].ToString())
                            {

                                case "0":

                                    fontsize_1 = "";
                                    fontsize_2 = "";

                                    break;

                                case "1":

                                    fontsize_1 = "<big>";
                                    fontsize_2 = "</big>";

                                    break;

                                case "2":

                                    fontsize_1 = "<big><big>";
                                    fontsize_2 = "</big></big>";

                                    break;

                                default:

                                    fontsize_1 = "";
                                    fontsize_2 = "";

                                    break;
                            }
                        }
                    }

                    #endregion
                }

                this.ArticleBox_holder.Visible = true;
                this.lblHeader.Text = fontsize_1 + Server.HtmlDecode(tm.Text2) + fontsize_2;
                this.lblIngress.Text = fontsize_1 + Server.HtmlDecode(tm.Text3) + fontsize_2;
                this.lblText.Text = fontsize_1 + Server.HtmlDecode(tm.Text4) + fontsize_2;

                if (tm.Media != "" && tm.MediaVisible == "true")
                {
                    String mediafile = "Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + tm.Media;

                    if (tm.MediaType == ".flv")
                    {
                        String FlashId = tm.Media;
                        FlashId = FlashId.Replace(".flv", "");
                        showMedia += RXMali.GetFLVCode("mediaplayer.swf", mediafile, FlashId, 435, 200);
                    }
                    else if(tm.MediaType == ".swf")
                    {
                        String FlashId = tm.Media;
                        FlashId = FlashId.Replace(".swf", "");
                        showMedia += RXMali.GetFlashCode(mediafile, FlashId, 435, 200);
                    }
                    else if(tm.MediaType == ".gif" || tm.MediaType == ".jpeg" || tm.MediaType == ".jpg" || tm.MediaType == ".png")
                    {
                        showMedia += "<img src='" + mediafile + "' class='Puff_Image' />";
                        social_img = RXMali.GetDomainUrl(Request.Url.ToString()) + mediafile;                    
                    }

                    this.ltrPuffImg.Text = showMedia;
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

                //if (tm.ExtraCommentComment == "true")
                //{
                //    this.TextBox_comment.Visible = true;
                //    this.imbAdminComment.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_comment_on.gif";
                //    this.imbAdminComment.ToolTip = "Disable Comments";
                //}
                //else
                //{
                //    this.TextBox_comment.Visible = false;
                //    this.imbAdminComment.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_comment_off.gif.";
                //    this.imbAdminComment.ToolTip = "Enable Comments";
                //}

                if (tm.ExtraSocial == "true")
                {
                    this.ArticleBox_social.Visible = true;
                    this.imbAdminSocial.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_share_on.gif";
                    this.imbAdminSocial.ToolTip = "Disable Social Links"; 

                    #region SpecialBox

                        String html = "";

                        html += "<table cellpadding='0' cellspacing='0'><tr>";
                        html += "<td>";
                        html += "<a class='social_link' style='cursor:pointer;' onclick=\"javascript:TellaFriendClick('" + this.PagId + "'); return false; \" >";
                        html += "<img name='tellfriend_img" + this.ModId + "' src=\"Images/Modules/Boxes/special_tellfriend_off.gif\" onmouseover=\"this.src='Images/Modules/Boxes/special_tellfriend_on.gif'\" onmouseout=\"this.src='Images/Modules/Boxes/special_tellfriend_off.gif'\" class=\"img_noborder\" alt=\"" + RXMali.GetXMLNode("Common/send") + "\"  title=\"" + RXMali.GetXMLNode("Common/send") + "\" /></a>";
                        html += "</td>";
                        html += "<td style='font-size:1px; width:6px;'>&nbsp;</td>";
                        html += "<td>";
                        html += "<a class='social_link' style='cursor:pointer;' onclick=\"javascript:TellaFriendClick('" + this.PagId + "'); return false; \" onmouseover=\"document['tellfriend_img" + this.ModId + "'].src='Images/Modules/Boxes/special_tellfriend_on.gif'\" onmouseout=\"document['tellfriend_img" + this.ModId + "'].src='Images/Modules/Boxes/special_tellfriend_off.gif'\" >" + RXMali.GetXMLNode("Common/send") + "</a>";
                        html += "</td>";
                        html += "<td style='font-size:1px; width:10px;'>&nbsp;</td>";
                        html += "<td>";
                        html += "<a class='social_link' style='cursor:pointer;' onclick=\"javascript:PrintClick('TextBox','" + this.ModId + "','" + this.PagId + "'); return false;\" >";
                        html += "<img name='print_img" + this.ModId + "' src=\"Images/Modules/Boxes/special_print_off.gif\" onmouseover=\"this.src='Images/Modules/Boxes/special_print_on.gif'\" onmouseout=\"this.src='Images/Modules/Boxes/special_print_off.gif'\" class=\"img_noborder\" alt=\"" + RXMali.GetXMLNode("Modules/Social/Tooltip/print") + "\"  title=\"" + RXMali.GetXMLNode("Modules/Social/Tooltip/print") + "\" /></a>";
                        html += "</td>";
                        html += "<td style='font-size:1px; width:6px;'>&nbsp;</td>";
                        html += "<td>";
                        html += "<a class='social_link' style='cursor:pointer;' onclick=\"javascript:PrintClick('TextBox','" + this.ModId + "','" + this.PagId + "'); return false;\" onmouseover=\"document['print_img" + this.ModId + "'].src='Images/Modules/Boxes/special_print_on.gif'\" onmouseout=\"document['print_img" + this.ModId + "'].src='Images/Modules/Boxes/special_print_off.gif'\" >" + RXMali.GetXMLNode("Common/print") + "</a>";
                        html += "</td>";

                        html += "</tr></table>";

                        this.ltrSpecial.Text = html;

                        #endregion;

                }
                else
                {
                    this.ArticleBox_social.Visible = false;
                    this.imbAdminSocial.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_share_off.gif";
                    this.imbAdminSocial.ToolTip = "Enable Social Links";

                }

            }
            else
            {
                this.ArticleBox_holder.Visible = false;
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

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
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

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
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

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void img_AdminSocial_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminSocial_Click";
        try
        {
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);
            if (tm.ExtraSocial == "true")
            {
                tm.ExtraSocial = "false";
            }
            else
            {
                tm.ExtraSocial = "true";
            }
            tm.Save();

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void imbMediumText_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbMediumText_Click";
        try
        {
            Session["font_" + this.ModId] = "1";
            bindData();
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbSmallText_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbSmallText_Click";
        try
        {
            Session["font_" + this.ModId] = "0";
            bindData();
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void imbLargeText_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imbLargeText_Click";
        try
        {
            Session["font_" + this.ModId] = "2";
            bindData();
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

}
