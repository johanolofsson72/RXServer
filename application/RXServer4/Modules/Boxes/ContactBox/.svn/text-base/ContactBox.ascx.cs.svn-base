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

public partial class Modules_Boxes_ContactBox_ContactBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_ContactBox_ContactBox";
    
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

                this.ContactBox_holder.Visible = true;

                this.lblHeader.Text = Server.HtmlDecode(sm.Text2);
                this.lblText.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text4));
                this.lblPolicy.Text = EE.EncodeEmails(Server.HtmlDecode(sm.Text6));

                this.lbnSend.Text = RXMali.GetXMLNode("Common/send");
                this.lblField1.Text = RXMali.GetXMLNode("Modules/ContactBox/field1") + ":";
                this.lblField2.Text = RXMali.GetXMLNode("Modules/ContactBox/field2") + ":";
                this.lblField3.Text = RXMali.GetXMLNode("Modules/ContactBox/field3") + ":";

                this.lblCategory.Text = RXMali.GetXMLNode("Modules/ContactBox/category") + ":";
                this.lblSubcategory.Text = RXMali.GetXMLNode("Modules/ContactBox/subcategory") + ":";
                this.lblWhoareyou.Text = RXMali.GetXMLNode("Modules/ContactBox/whoareyou") + ":";

                this.lblQuestion.Text = RXMali.GetXMLNode("Modules/ContactBox/question") + ":";

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

                this.ContactBox_holder.Attributes.Add("style", _style);
            }
            else
            {
                this.ContactBox_holder.Visible = false;
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

            this.ddlCategory.Items.Add(new ListItem(" - " ,"0"));
            this.ddlSubcategory.Items.Add(new ListItem(" - ", "0"));

            foreach (RXServer.Modules.Base.List.Item item in cat)
            {
                this.ddlCategory.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

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

    private void PopulateSubCategory()
    {
        String function_name = "PopulateSubCategory";
        try
        {
            RXServer.Modules.Base.List cat = new RXServer.Modules.Base.List("SubCategory_" + this.ddlCategory.SelectedValue + "_" + this.ModId);

            this.ddlSubcategory.Items.Clear();
            foreach (RXServer.Modules.Base.List.Item item in cat)
            {
                this.ddlSubcategory.Items.Add(new ListItem(Server.HtmlDecode(item.Value25), item.Id.ToString()));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        String function_name = "ddlCategory_SelectedIndexChanged";
        try
        {
            PopulateSubCategory();
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


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

            if (valid && this.ddlSubcategory.SelectedValue == "0")
            {
                valid = false;
                Error += " - " + RXMali.GetXMLNode("Modules/ContactBox/Error/select_subcategory") + "<br/>";
            }

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

                RXServer.Modules.Base.List.Item item = new LiquidCore.List.Item(Convert.ToInt32(this.ddlSubcategory.SelectedValue));

                SendQuestion(item.Value26, sm.Text8);

                this.txtField1.Text = "";
                this.txtField2.Text = "";
                this.txtField3.Text = "";
                this.txtQuestion.Text = "";
                this.cbPolicy.Checked = false;
                this.ddlCategory.Items.Clear();
                this.ddlSubcategory.Items.Clear();
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
            mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/ContactBox/header") + "</td></tr>";
            mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
            mailText += "<tr><td class='text'>";

            mailText += RXMali.GetXMLNode("Modules/ContactBox/whoareyou") + " : " + this.ddlWhoareyou.SelectedItem.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox/field1") + " : " + this.txtField1.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox/field2") + " : " + this.txtField2.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox/field3") + " : " + this.txtField3.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/ContactBox/question") + " : " + this.txtQuestion.Text + "<br /><br /><br />"; 
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
