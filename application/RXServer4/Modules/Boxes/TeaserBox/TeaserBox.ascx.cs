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

public partial class Modules_Boxes_TeaserBox_TeaserBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_TeaserBox_TeaserBox";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
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
            if (!this.Hidden || RXServer.Auth.IsInRole("Admin"))
            {
				RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);

                Int32 ModelId = 0;
                Int32.TryParse(tm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = ""; 
                String _float = "";
                String _floatx = "";
                if (tm.Float == "")
                {
                    tm.Float = "left";
                }

                if (tm.Float == "left")
                {
                    _float = "float: left; margin-left: 3px; margin-right: 3px; width: " + _width + "px;";
                    _floatx = "text-align:left; font-size:1px; padding-bottom:20px; width: " + _width + "px;";
                }
                else
                {
                    _float = "float: right; margin-left: 3px; margin-right: 3px; width: " + _width + "px;";
                    _floatx = "text-align:left; font-size:1px; padding-bottom:20px; width: " + _width + "px;";
                }
                _style = _float;
                this.TeaserBox.Attributes.Add("style", _floatx);

                //String _style = "";
                //String _float = "";
                //if (tm.Float == "center")
                //{ _float = "margin:auto;"; }
                //else
                //{ _float = "float:" + tm.Float + ";"; }
                //_style = "position: relative; " + _float + "; width: " + _width + "px;";

                //this.TeaserBox_admin.Attributes.Add("style", _style);
                this.TeaserBox_holder.Attributes.Add("style", _style);

                this.TeaserBox_holder.Visible = true;

                this.lblHeader.Text = Server.HtmlDecode(tm.Text2).Replace("`", "'");
                this.lblText.Text = EE.EncodeEmails(Server.HtmlDecode(tm.Text4)).Replace("`", "'");

              
                String showMedia = "";
                String mediafile = "~/Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + tm.Media;
                String mediafile2 = "~/Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + tm.Media;
                
                this.imgMedia.Visible = false;
                this.ltrReadMore.Visible = false;

                Int32 link = 0;
                Int32.TryParse(tm.ReadMoreLinkId, out link);

                if (tm.MediaVisible == "true")
                {

                    if (tm.MediaType == ".flv")
                    {
                        String FlashId = tm.Media;
                        FlashId = FlashId.Replace(".flv", "");
                        showMedia += RXMali.GetFLVCode("mediaplayer.swf", mediafile2, FlashId, 173, 173);
                    }
                    else if (tm.MediaType == ".swf")
                    {
                        String FlashId = tm.Media;
                        FlashId = FlashId.Replace(".swf", "");
                        showMedia += RXMali.GetFlashCode(mediafile, FlashId, 173, 173);
                    }
                    else if (tm.MediaType == ".gif" || tm.MediaType == ".jpeg" || tm.MediaType == ".jpg" || tm.MediaType == ".png")
                    {

                        /*if (link > 0)
                        {
                            //showMedia += "<a href='" + RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link) + "'>";
                            showMedia += "<a href='Default.aspx?PagId=" + link + "'>";                           
                        }*/

                        imgMedia.ImageUrl = mediafile;
                        imgMedia.Width = new Unit("173px");
                        imgMedia.ToolTip = tm.MediaToolTip;
                        //showMedia += "<img src='" + mediafile + "' style='width: " + 173 + "px;' title='" + tm.MediaToolTip + "'/>";

                        /*if (link > 0)
                        {
                            showMedia += "</a>";
                        }*/

                    }
                    this.imgMedia.Visible = true;                    
                }

                if (!tm.ReadMoreLink.Equals("") && Server.HtmlDecode(tm.Text6).Equals("extended"))
                {
                    this.ltrReadMore.Visible = true;
                    this.ltrReadMore.Text = "<a href=\"javascript:showArticleBox(" + this.PagId + "," + this.ModId + ",'1');\">" + Server.HtmlDecode(tm.ReadMoreLink) + "</a>";
                }
                else if (tm.ReadMoreLink != "" && link > 0)
                {
                    this.ltrReadMore.Visible = true;

					String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link);
					if (friendlyUrl.EndsWith("/") || friendlyUrl.Contains("//"))
					{
						String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
						this.ltrReadMore.Text = "<a href='" + path + "Default.aspx?PagId=" + tm.ReadMoreLinkId + "'>" + Server.HtmlDecode(tm.ReadMoreLink) + "</a>";
					}
					else
					{
						String path = "http://" + Request.Url.Authority;
						this.ltrReadMore.Text = "<a href='" + path + friendlyUrl + "'>" + Server.HtmlDecode(tm.ReadMoreLink) + "</a>";
					}
                }
            }
            else
            {
                this.TeaserBox_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private String GetConPa()
    {
        String function_name = "GetConPa";
        try
        {
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            return sm.ContentPane;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return "";
        }
    }

}
