using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Modules_PopUp_TellaFried_TellaFriend : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_PopUp_TellaFried_TellaFriend";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
                BindData();
                this.Title = RXMali.GetXMLNode("Common/sitename");
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindData()
    {
        String function_name = "Page_Load";
        try
        {
            this.lblHeader.Text = RXMali.GetXMLNode("Modules/PopUp/Tellafriend/header");
            this.lblText.Text = RXMali.GetXMLNode("Modules/PopUp/Tellafriend/info");
            this.lblYourname.Text = RXMali.GetXMLNode("Modules/PopUp/Tellafriend/yourname");
            this.lblYourEmail.Text = RXMali.GetXMLNode("Modules/PopUp/Tellafriend/youremail");
            this.lblFriendEmail.Text = RXMali.GetXMLNode("Modules/PopUp/Tellafriend/friendsemail");
            this.lbnSend.Text = RXMali.GetXMLNode("Common/send");
            this.txtName.Text = RXMali.GetXMLNode("Common/name");
            this.txtEmail.Text = RXMali.GetXMLNode("Common/email");
            this.txtFriendMail.Text = RXMali.GetXMLNode("Common/email");
            this.ltrCancel.Text = "<a href='javascript:window.close();' class='button'> " + RXMali.GetXMLNode("Common/close") + "</a>";

            this.txtName.Attributes.Add("onclick", "this.value='';");
            this.txtEmail.Attributes.Add("onclick", "this.value='';");
            this.txtFriendMail.Attributes.Add("onclick", "this.value='';");
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void sendMail()
    {
        String function_name = "Page_Load";
        try
        {
            if (this.lblFriendEmail.Text != "")
            {
                string mailServer, mailPort, mailSender, mailTo, mailSubject, mailSenderName, mailText = "";

                mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
                mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
                mailTo = this.txtFriendMail.Text;
                mailSender = ConfigurationManager.AppSettings["MailSender"].ToString();
                mailSenderName = ConfigurationManager.AppSettings["MailSenderName"].ToString();

                mailSubject = RXMali.GetXMLNode("Mail/Tellafriend/subject") + " " + this.txtName.Text;

                String Url = "";
                //Url = RXMali.GetDomainUrl(Request.Url.ToString());
                Url = Request.Url.ToString();
                Url = Url.Replace(Request.Url.LocalPath, "");
                Url = Url.Replace(Request.Url.Query, "");

                String extraLink = "";
                if (RXServer.Web.RequestValues.Id > 0 && RXServer.Web.RequestValues.Var != "")
                {
                    extraLink = "&" + RXServer.Web.RequestValues.Var + "=" + RXServer.Web.RequestValues.Id;
                }


                Int32 pgId = 0;
                Int32.TryParse(Request["pg"], out pgId);

                mailText += "<html>";
                mailText += "<style>";
                mailText += "a, a:visited, a:active { color: #8D301E; text-decoration: none; }";
                mailText += ".text{ color: #505050; font-size: 12px; line-height: 16px; font-family: Arial, Helvetica;}";
                mailText += ".header{ color: #000; font-size: 20px; line-height: 24px; font-weight: bold; font-family: Arial, Helvetica;}";
                mailText += ".footer{ color: #505050; font-size: 11px; line-height: 14px; font-family: Arial, Helvetica;}";
                mailText += "</style>";
                mailText += "<body>";
                mailText += "<table cellpadding='0' cellspacing='0' style='width:400px;'>";
                mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/Tellafriend/header") + "</td></tr>";
                mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
                mailText += "<tr><td class='text'>" + this.txtName.Text + " (" + this.txtEmail.Text + ") " + RXMali.GetXMLNode("Mail/Tellafriend/text") + "<br /><br />";
                mailText += "<a href='" + RXMali.GetXMLNode("Mail/Tellafriend/linkurlprefix") + "/Default.aspx?PagId=" + pgId.ToString() + extraLink + "' />" + RXMali.GetXMLNode("Mail/Tellafriend/link") + "</a><br /><br /><br />";
                mailText += RXMali.GetXMLNode("Mail/Global/thank_you");
                mailText += "    </td></tr>";
                mailText += "<tr><td><hr /></td></tr>";
                mailText += "<tr><td class='footer'>" + RXMali.GetXMLNode("Mail/Global/footer") + "</td></tr>";
                mailText += "</table></body></html>";

                RXMali.SendMail(mailText, mailSubject, mailTo, mailSender, mailSenderName, mailServer, mailPort);
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void lbnSend_Click(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            Boolean valid = true;
            String Errors = "";
            this.lblError.Visible = false;
            this.lblSuccess.Visible = false;

            if (!RXMali.IsEmail(this.txtEmail.Text))
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Error/email") + "<br/>";
            }

            if (!RXMali.IsEmail(this.txtFriendMail.Text))
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Error/email") + "<br/>";
            }

            if (this.txtFriendMail.Text == "")
            {
                valid = false;
                Errors += " - " + RXMali.GetXMLNode("Error/yourname") + "<br/>";
            }


            if (valid)
            {
                sendMail();
                this.lblSuccess.Visible = true;
                this.lblSuccess.Text = " - " + RXMali.GetXMLNode("Modules/PopUp/Tellafriend/confirmation");
                this.txtFriendMail.Text = "";
            }
            else
            {
                this.lblError.Visible = true;
                this.lblError.Text = Errors;
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
