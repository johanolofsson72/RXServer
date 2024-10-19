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

public partial class Modules_Boxes_StartBox_StartBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_StartBox_StartBox";
    
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
				RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

                this.StartBox_holder.Visible = true;

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(sm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                String _float = "";

                if (sm.Float == "")
                {
                    _float = "left";
                }
                else
                {
                    _float = sm.Float;
                }

                if (ModelId == 0)
                {
                    _width = 900;
                }

                _style = "position: relative; float: " + _float + "; width: " + _width + "px;";

                this.StartBox_holder.Attributes.Add("style", _style);

                BindStartData();
            }
            else
            {
                this.StartBox_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindStartData()
    {
        String function_name = "BindStartData";
        try
        {


            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("StartBox_" + this.ModId);          

            Int32 count = 0;

            foreach (RXServer.Modules.Base.List.Item item in t)
            {
                count++;

                Int32 link = 0;
                Int32.TryParse(item.Value17, out link);

                // Media

                String showMedia = "";
                //String mediafile = RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + item.Value10;
                String mediafile = "Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + item.Value10;
                String mediafile2 = "Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + item.Value10;

                if (item.Value11 == ".flv")
                {
                    String FlashId = item.Value10;
                    FlashId = FlashId.Replace(".flv", "");
                    showMedia += RXMali.GetFLVCode(RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "mediaplayer.swf", mediafile2, FlashId, 205, 205);
                }
                else if (item.Value11 == ".swf")
                {
                    String FlashId = item.Value10;
                    FlashId = FlashId.Replace(".swf", "");
                    showMedia += RXMali.GetFlashCode(mediafile, FlashId, 205, 205);
                }
                else if (item.Value11 == ".gif" || item.Value11 == ".jpeg" || item.Value11 == ".jpg" || item.Value11 == ".png")
                {

                    if (link > 0)
                    {
						String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link);
						if (friendlyUrl.EndsWith("/") || friendlyUrl.Contains("//"))
						{
							String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
							showMedia += "<a href='" + path + "Default.aspx?PagId=" + link + "'>";
						}
						else
						{
							String path = "http://" + Request.Url.Authority;
							showMedia += "<a href='" + path + friendlyUrl + "'>";
						}
                    }

                    showMedia += "<img src='" + mediafile + "' style='width: " + 203 + "px;' title='" + item.Value13 + "' alt='" + item.Value13 + "'/>";

                    if (link > 0)
                    {
                        showMedia += "</a>";
                    }

                }

                if (count == 1)
                {
                    this.lblHeader1.Text = Server.HtmlDecode(item.Value2).Replace("`", "'");
                    this.lblText1.Text = EE.EncodeEmails(RXMali.Substring(Server.HtmlDecode(item.Value4), 90)).Replace("`", "'");

					String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link);
					if (friendlyUrl.EndsWith("/") || friendlyUrl.Contains("//"))
					{
						this.hplReadMore1.NavigateUrl = "~/Default.aspx?PagId=" + link;
					}
					else
					{
						String path = "http://" + Request.Url.Authority;
						this.hplReadMore1.NavigateUrl = path + friendlyUrl;
					}

                    this.hplReadMore1.Text = Server.HtmlDecode(item.Value16).Replace("`", "'");
                    
                   this.ltrMedia1.Text = showMedia;

                }
                if (count == 2)
                {
                    this.lblHeader2.Text = Server.HtmlDecode(item.Value2).Replace("`", "'");
                    this.lblText2.Text = EE.EncodeEmails(RXMali.Substring(Server.HtmlDecode(item.Value4), 90)).Replace("`", "'");

					String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link);
					if (friendlyUrl.EndsWith("/") || friendlyUrl.Contains("//"))
					{
						this.hplReadMore2.NavigateUrl = "~/Default.aspx?PagId=" + link;
					}
					else
					{
						String path = "http://" + Request.Url.Authority;
						this.hplReadMore2.NavigateUrl = path + friendlyUrl;
					}

                    this.hplReadMore2.Text = Server.HtmlDecode(item.Value16).Replace("`", "'");

                    this.ltrMedia2.Text = showMedia;
                }
                if (count == 3)
                {
                    this.lblHeader3.Text = Server.HtmlDecode(item.Value2).Replace("`", "'");
                    this.lblText3.Text = EE.EncodeEmails(RXMali.Substring(Server.HtmlDecode(item.Value4), 90)).Replace("`", "'");

					String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link);
					if (friendlyUrl.EndsWith("/") || friendlyUrl.Contains("//"))
					{
						this.hplReadMore3.NavigateUrl = "~/Default.aspx?PagId=" + link;
					}
					else
					{
						String path = "http://" + Request.Url.Authority;
						this.hplReadMore3.NavigateUrl = path + friendlyUrl;
					}

                    this.hplReadMore3.Text = Server.HtmlDecode(item.Value16).Replace("`", "'");

                    this.ltrMedia3.Text = showMedia;
                }
                if (count == 4)
                {
                    this.lblHeader4.Text = Server.HtmlDecode(item.Value2).Replace("`", "'");
                    this.lblText4.Text = EE.EncodeEmails(RXMali.Substring(Server.HtmlDecode(item.Value4), 90)).Replace("`", "'");

					String friendlyUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(link);
					if (friendlyUrl.EndsWith("/") || friendlyUrl.Contains("//"))
					{
						this.hplReadMore4.NavigateUrl = "~/Default.aspx?PagId=" + link;
					}
					else
					{
						String path = "http://" + Request.Url.Authority;
						this.hplReadMore4.NavigateUrl = path + friendlyUrl;
					}

                    this.hplReadMore4.Text = Server.HtmlDecode(item.Value16).Replace("`", "'");


                    this.ltrMedia4.Text = showMedia;
                }
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
  
}
