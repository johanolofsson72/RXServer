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

public partial class Modules_Boxes_TeaserBox_TeaserBox_Article : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_TeaserBox_TeaserBox_Article";
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
            int pagId = -1;
            Int32.TryParse(Request.QueryString["PagId"], out pagId);
            int modId = -1;
            Int32.TryParse(Request.QueryString["ModId"], out modId);
            if (modId > -1 || pagId > -1)
            {
                RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(1, pagId, modId);
                lblTitle.Text = Server.HtmlDecode(tm.Text2);
                ltrlContent.Text = Server.HtmlDecode(tm.Text5);

                //Fix media
                String showMedia = "";
                String mediafile = "http://" + Request.Url.Authority + Request.ApplicationPath + "/Upload/Pages/" + pagId + "/" + modId + "/" + tm.Media;
                String mediafile2 = "http://" + Request.Url.Authority + Request.ApplicationPath + "/Upload/Pages/" + pagId + "/" + modId + "/" + tm.Media;
                this.ltrMedia.Visible = false;
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
                        showMedia += "<img style=\"border-color: #959595; border-width: 1px; border-style: Solid;\" src='" + mediafile + "' style='width: " + 173 + "px;' title='" + tm.MediaToolTip + "'/>";
                    }
                    this.ltrMedia.Visible = true;
                    this.ltrMedia.Text = showMedia;
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
