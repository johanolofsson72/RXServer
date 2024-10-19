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

public partial class Modules_Boxes_ContactBox2_ContactBox2 : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_ContactBox2_ContactBox2";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (RXServer.Auth.IsInRole("Admin"))
            {
                this.ContactBox2_admin.Visible = true;

                this.img_AdminDelete.OnClientClick = "javascript:showAdminDeleteModule(1," + this.PagId + "," + this.ModId + "); return false;";

                if (RXMali.GetLastUrl(this.Page.MasterPageFile) == "Template4.master")
                {
                    this.img_AdminEdit.OnClientClick = "javascript:showAdminContactBox2(1," + this.PagId + "," + this.ModId + ",'3'); return false;";
                }
                else
                {
                    this.img_AdminEdit.OnClientClick = "javascript:showAdminContactBox2(1," + this.PagId + "," + this.ModId + ",'2'); return false;";
                }
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

            if (sm.Visible == "true" || RXServer.Auth.IsInRole("Admin"))
            {

                this.ContactBox2_holder.Visible = true;

                this.lblHeader.Text = Server.HtmlDecode(sm.Text2).Replace("`", "'");
                this.lblText.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text4)).Replace("`", "'");
                this.lblPolicy.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text6)).Replace("`", "'");

                this.lbnSend.Text = RXMali.GetXMLNode("Common/send");
                this.lblField1.Text = RXMali.GetXMLNode("Modules/ContactBox2/field1") + ":";
                this.lblField2.Text = RXMali.GetXMLNode("Modules/ContactBox2/field2") + ":";
                this.lblField3.Text = RXMali.GetXMLNode("Modules/ContactBox2/field3") + ":";

                this.lblCategory.Text = RXMali.GetXMLNode("Modules/ContactBox2/category") + ":";
                this.lblWhoareyou.Text = RXMali.GetXMLNode("Modules/ContactBox2/whoareyou") + ":";

                this.lblQuestion.Text = RXMali.GetXMLNode("Modules/ContactBox2/question") + ":";

                PopulateCategory();
                PopulateClients();

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(sm.ModelId, out ModelId);
                Int32 _width = RXMali.GetModelSize(ModelId.ToString());

                if (ModelId == 0)
                {
                    _width = 430;
                }

                //this.txtField1.Attributes.Add("style", "width: " + _width + ";");
                //this.txtField2.Attributes.Add("style", "width: " + _width + ";");
                //this.txtField3.Attributes.Add("style", "width: " + _width + ";");
                //this.ddlCategory.Attributes.Add("style", "width: " + _width + ";");
                //this.ddlCategory.Attributes.Add("style", "width: " + _width + ";");
                //this.ddlCategory.Attributes.Add("style", "width: " + _width + ";");

                String _style = "";
                _style = "position: relative; float: " + sm.Float + "; width: " + _width + "px;";

                //this.ContactBox2_holder.Attributes.Add("style", _style);

                this.ContactBox2_admin.Attributes.Add("style", _style);
                this.ContactBox2_holder.Attributes.Add("style", _style);

                // CONTENT

                if (sm.Visible == "true")
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
                this.ContactBox2_holder.Visible = false;
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            sm.ChangeOrderDown();
            sm.Save();

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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            sm.ChangeOrderUp();
            sm.Save();

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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
            if (sm.Visible == "true")
            {
                sm.Visible = "false";
            }
            else
            {
                sm.Visible = "true";
            }
            sm.Save();

            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
        }
        catch(Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    //private void PopulateCategory()
    //{
    //    String function_name = "PopulateCategory";
    //    try
    //    {
    //        RXServer.Modules.Base.List cat = new RXServer.Modules.Base.List("Category_" + this.ModId);

    //        this.ddlCategory.Items.Add(new ListItem(" - " ,"0"));
    //        this.ddlSubcategory.Items.Add(new ListItem(" - ", "0"));

    //        foreach (RXServer.Modules.Base.List.Item item in cat)
    //        {
    //            this.ddlCategory.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}

    private void PopulateClients()
    {
        String function_name = "PopulateClients";
        try
        {
            RXServer.Modules.Base.List cat = new RXServer.Modules.Base.List("Client_" + this.ModId);

            this.ddlWhoareyou.Items.Add(new ListItem(" - ", "0"));

            foreach (RXServer.Modules.Base.List.Item item in cat)
            {
                this.ddlWhoareyou.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void PopulateCategory()
    {
        String function_name = "PopulateCategory";
        try
        {
            RXServer.Modules.Base.List cat = new RXServer.Modules.Base.List("Category_" + this.ModId);

            this.ddlCategory.Items.Clear();
            foreach (RXServer.Modules.Base.List.Item item in cat)
            {
                this.ddlCategory.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), Server.HtmlDecode(item.Value26)));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    String function_name = "ddlCategory_SelectedIndexChanged";
    //    try
    //    {
    //        PopulateSubCategory();
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //    }
    //}


    protected void lbnSend_Click(object sender, EventArgs e)
    {
        String function_name = "lbnSend_Click";
        try
        {
            Boolean valid = true;
            String Error = "";

            this.lblError.Visible = false;
            this.lblSuccess.Visible = false;

            if (this.ddlCategory.SelectedValue == "0")
            {
                valid = false;
                Error += " - " + RXMali.GetXMLNode("Modules/ContactBox/Error/select_category") + "<br/>";
            }

            //if (valid && this.ddlSubcategory.SelectedValue == "0")
            //{
            //    valid = false;
            //    Error += " - " + RXMali.GetXMLNode("Modules/ContactBox/Error/select_subcategory") + "<br/>";
            //}

            if (this.ddlWhoareyou.SelectedValue == "0")
            {
                valid = false;
                Error += " - " + RXMali.GetXMLNode("Modules/ContactBox/Error/select_client") + "<br/>";
            }

            if (!RXMali.IsEmail(this.txtField2.Text))
            {
                valid = false;
                Error += " - " + RXMali.GetXMLNode("Error/email") + "<br/>";
            }

            if (this.txtQuestion.Text == "")
            {
                valid = false;
                Error += " - " + RXMali.GetXMLNode("Modules/ContactBox/Error/question") + "<br/>";
            }

            if (!this.cbPolicy.Checked)
            {
                valid = false;
                Error += " - " + RXMali.GetXMLNode("Modules/ContactBox/Error/check_policy") + "<br/>";
            }


            if (valid)
            {
                RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);

                this.lblSuccess.Text = Server.HtmlDecode(sm.Text7);
                this.lblSuccess.Visible = true;

                //RXServer.Modules.Base.List.Item item = new LiquidCore.List.Item(Convert.ToInt32(this.ddlCategory.SelectedValue));

                SendQuestion(this.ddlCategory.SelectedValue, sm.Text8);

                this.txtField1.Text = "";
                this.txtField2.Text = "";
                this.txtField3.Text = "";
                this.txtQuestion.Text = "";
                this.cbPolicy.Checked = false;
                this.ddlCategory.Items.Clear();
                //this.ddlSubcategory.Items.Clear();
                this.ddlWhoareyou.Items.Clear();

                PopulateCategory();
                PopulateClients();

            }
            else
            {
                this.lblError.Text = Error;
                this.lblError.Visible = true;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void SendQuestion(string email, string subject)
    {
        String function_name = "SendQuestion";
        try
        {
            string mailServer, mailPort, mailSender, mailTo, mailSubject, mailSenderName, mailText = "";

            mailSubject = subject;
            mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
            mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
            mailTo = email;
            mailSender = ConfigurationManager.AppSettings["MailSender"].ToString();
            mailSenderName = ConfigurationManager.AppSettings["MailSenderName"].ToString();


            mailText += "<html>";
            mailText += "<style>";
            mailText += "a, a:visited, a:active { color: #8D301E; text-decoration: none; }";
            mailText += ".text{ color: #505050; font-size: 12px; line-height: 16px; font-family: Arial, Helvetica;}";
            mailText += ".header{ color: #000; font-size: 20px; line-height: 24px; font-weight: bold; font-family: Arial, Helvetica;}";
            mailText += ".footer{ color: #505050; font-size: 11px; line-height: 14px; font-family: Arial, Helvetica;}";
            mailText += "</style>";
            mailText += "<body>";
            mailText += "<table cellpadding='0' cellspacing='0' style='width:400px;'>";
            mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/ContactBox2/header") + "</td></tr>";
            mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
            mailText += "<tr><td class='text'>";

            mailText += RXMali.GetXMLNode("Modules/ContactBox2/whoareyou") + " : " + this.ddlWhoareyou.SelectedItem.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox2/field1") + " : " + this.txtField1.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox2/field2") + " : " + this.txtField2.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox2/field3") + " : " + this.txtField3.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox2/question") + " : " + this.txtQuestion.Text + "<br /><br /><br />"; 
            mailText += "    </td></tr>";
            mailText += "<tr><td><hr /></td></tr>";
            mailText += "<tr><td class='footer'>" + RXMali.GetXMLNode("Mail/Global/footer") + "</td></tr>";
            mailText += "</table></body></html>";

            RXMali.SendMail(mailText, mailSubject, mailTo, mailSender, mailSenderName, mailServer, mailPort);
                
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
