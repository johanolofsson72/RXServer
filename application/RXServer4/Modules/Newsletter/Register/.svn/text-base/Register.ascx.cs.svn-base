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

public partial class Modules_Newsletter_Register_Register : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Newsletter_Register_Register";
    
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

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(tm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                String _style = "";
                _style = "position: relative; float: left; width: " + _width + "px; padding-bottom: 20px;";

                this.Register_holder.Attributes.Add("style", _style);
                this.Register_holder.Visible = true;

                this.lblHeader.Text = RXMali.GetXMLNode("Modules/RegisterMail/title");
                this.lblText.Text = RXMali.GetXMLNode("Modules/RegisterMail/text");
                this.lbnSignUp.Text = RXMali.GetXMLNode("Modules/RegisterMail/button");
                this.hplUnregister.Text = RXMali.GetXMLNode("Modules/RegisterMail/link_to_unregister");
                this.hplUnregister.NavigateUrl = RXServer.Lib.Common.Dynamic.GetFriendlyUrl(4);


                this.txtMail.Text = RXMali.GetXMLNode("Common/youremail");
                this.txtMail.Attributes.Add("onclick", "this.value='';");

                PopulateNewsLetterGroups();

                String showMedia = "";
                String mediafile = "Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + tm.Media;
                this.ltrMedia.Visible = false;

                if (tm.MediaVisible == "true")
                {

                    if (tm.MediaType == ".flv")
                    {
                        String FlashId = tm.Media;
                        FlashId = FlashId.Replace(".flv", "");
                        showMedia += RXMali.GetFLVCode("mediaplayer.swf", mediafile, FlashId, 173, 173);
                    }
                    else if (tm.MediaType == ".swf")
                    {
                        String FlashId = tm.Media;
                        FlashId = FlashId.Replace(".swf", "");
                        showMedia += RXMali.GetFlashCode(mediafile, FlashId, 173, 173);
                    }
                    else if (tm.MediaType == ".gif" || tm.MediaType == ".jpeg" || tm.MediaType == ".jpg" || tm.MediaType == ".png")
                    {
                        Int32 link = 0;
                        Int32.TryParse(tm.ReadMoreLinkId, out link);
                        if (link > 0)
                        {
                            String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                            showMedia += "<a href='" + path + "Default.aspx?PagId=" + link + "'>";
                        }

                        showMedia += "<img src='" + mediafile + "' style='width: " + 173 + "px;' title='" + tm.MediaToolTip + "'/>";

                        if (link > 0)
                        {
                            showMedia += "</a>";
                        }

                    }
                    this.ltrMedia.Visible = true;
                    this.ltrMedia.Text = showMedia;
                }
            }
            else
            {
                this.Register_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void PopulateNewsLetterGroups()
    {
        String function_name = "PopulateNewsLetterGroups";
        try
        {
            this.ddlMailGroup.Items.Add(new ListItem(RXMali.GetXMLNode("Modules/RegisterMail/select_group"), "0"));

            RXServer.Modules.Base.List t = new RXServer.Modules.Base.List("MailGroup");
            foreach (RXServer.Modules.Base.List.Item item in t)
            {
                this.ddlMailGroup.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void lbnSignUp_Click(object sender, EventArgs e)
    {
        String function_name = "lbnSignUp_Click";
        try
        {
            Boolean valid = true;
            String Errors = "";
            this.lblError.Visible = false;
            this.lblSuccess.Visible = false;

            if (!RXMali.IsEmail(this.txtMail.Text))
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Error/email") + "<br/>";
            }
            if (this.ddlMailGroup.SelectedValue == "0")
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Modules/RegisterMail/Error/select_group") + "<br/>";
            }
            if (CheckIfMailIsInList(this.txtMail.Text, this.ddlMailGroup.SelectedValue))
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Modules/RegisterMail/Error/mail_exists_in_group") + "<br/>";
            }

            if (valid)
            {
                if (AddMailToGroup(this.txtMail.Text, this.ddlMailGroup.SelectedValue))
                {
                    this.lblSuccess.Visible = true;
                    this.lblSuccess.Text = " - " + this.txtMail.Text + " " + RXMali.GetXMLNode("Modules/RegisterMail/Success/added") + " " + this.ddlMailGroup.SelectedItem.Text + " <br/>";
                }
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = Errors;
                //this.lbnSignUp.Text = RXMali.GetXMLNode("Modules/RegisterMail/button");
                //this.hplUnregister.Text = RXMali.GetXMLNode("Modules/RegisterMail/link_to_unregister");
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private Boolean CheckIfMailIsInList(string mail, string groupid)
    {
        String function_name = "CheckIfMailIsInList";
        try
        {
            String sql = "SELECT obd_id ";
            sql += "FROM obd_objectdata ";
            sql += "WHERE obd_alias = 'MailItem_" + groupid + "' ";
            sql += "AND obd_varchar25 = '" + mail + "' ";
            sql += "AND obd_deleted = 0 ";

            DataSet dataSet = new DataSet("dataSet");
            dataSet = RXServer.Data.Direct.GetDataSet(sql);

            if (dataSet.Tables.Count > 0)
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }
    private Boolean AddMailToGroup(string mail, string groupid)
    {
        String function_name = "AddMailToGroup";
        try
        {
            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item();

            i.Alias = "MailItem_" + groupid;
            i.Status = 1;
            i.Language = 1;
            i.SitId = 1;
            i.PagId = RXServer.Web.RequestValues.PagId;
            i.ModId = RXServer.Web.RequestValues.ModId;
            i.Value25 = mail;
            i.Value26 = groupid;

            i.Save();

            return true;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }
}
