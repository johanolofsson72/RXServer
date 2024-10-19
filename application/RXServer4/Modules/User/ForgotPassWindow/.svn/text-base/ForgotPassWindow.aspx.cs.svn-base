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
using System.IO;
using Telerik.Web.UI;
using System.Drawing;

public partial class Modules_User_ForgotPassWindow_ForgotPassWindow : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_User_ForgotPassWindow_ForgotPassWindow";
    Int32 SitId = RXServer.Web.RequestValues.SitId;
    Int32 ModId = RXServer.Web.RequestValues.ModId;
    Int32 PagId = RXServer.Web.RequestValues.PagId;

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            BindData();
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindData()
    {
        String function_name = "BindData";
        try
        {
            this.lblInfo.Text = RXMali.GetXMLNode("Modules/ForgotPassword/text");
            this.Title = RXMali.GetXMLNode("Modules/ForgotPassword/title");
            this.ltrMessage.Text = RXMali.GetXMLNode("Modules/ForgotPassword/password_sent");
            this.lbnClose.Text = RXMali.GetXMLNode("Common/close");

            BindMenuData();
            if (!Page.IsPostBack)
            {
                bindData4();
                this.txtUsername4.Attributes.Add("onclick", "this.value='';");
                this.txtEmail4.Attributes.Add("onclick", "this.value='';");
            }            

            this.Page_1.Visible = true;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public void HideWindows()
    {
        String function_name = "HideWindows";
        try
        {
            this.Page_1.Visible = false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindMenuData()
    {
        String function_name = "BindMenuData";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            if (RXServer.Web.RequestValues.Page == "login" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='link_333333' href='ForgotPassWindow.aspx?Page=login&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>Glömt Lösenordet</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #CCCCCC;'><a class='link_575757' href='ForgotPassWindow.aspx?Page=login&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>Glömt Lösenordet</a></td>";
            }
            
            list += "</tr>";
            list += "</table>";


            //this.ltrSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void bindData4()
    {
        String function_name = "bindData4";
        try
        {

            this.lblText4_1.Text = RXMali.GetXMLNode("Common/username");
            this.txtUsername4.Text = RXMali.GetXMLNode("Common/username");
            this.lblText4_2.Text = RXMali.GetXMLNode("Common/email");
            this.txtEmail4.Text = RXMali.GetXMLNode("Common/email");
            this.lbnSendPassword1.Text = RXMali.GetXMLNode("Common/send");
            this.lbnSendPassword2.Text = RXMali.GetXMLNode("Common/send");

            //this.lblText4_3.Text = RXMali.GetXMLNode("Common/role");
            //this.lblText4_4.Text = RXMali.GetXMLNode("Modules/User/choose_password");
            //this.lblText4_5.Text = RXMali.GetXMLNode("Modules/User/confirm_password");
            //this.lbnCreateAccount.Text = RXMali.GetXMLNode("Modules/User/create_account");

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void lbnSendPassword1_Click(object sender, EventArgs e)
    {
        String function_name = "lbnSendPassword1_Click";
        try
        {
            String mail = this.txtEmail4.Text;
            Int32 uId = 0;

            if (mail != "")
            {
                if (RXServer.Auth.Users.UserEmailExist(mail))
                {
                    uId = RXServer.Auth.Users.GetUserIdByEmail(mail);
                }
                else
                {
                    this.lblForgotError.Text = RXMali.GetXMLNode("Error/email");
                    this.ForgotError.Visible = true;
                }
            }

            if (uId > 0)
            {
                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);

                string mailServer, mailPort, mailSender, mailTo, mailSubject, mailSenderName, mailText = "";

                mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
                mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
                mailTo = u.Mail;
                mailSender = ConfigurationManager.AppSettings["MailSender"].ToString();
                mailSenderName = ConfigurationManager.AppSettings["MailSenderName"].ToString();

                mailSubject = RXMali.GetXMLNode("Mail/LostPassword/subject");

                String Url = "";
                Url = RXMali.GetDomainUrl(Request.Url.ToString());
                Url = Url.Replace("Modules/User/ForgotPassWindow/", "");

                mailText += "<html>";
                mailText += "<style>";
                mailText += "a, a:visited, a:active { color: #8D301E; text-decoration: none; }";
                mailText += ".text{ color: #505050; font-size: 12px; line-height: 16px; font-family: Arial, Helvetica;}";
                mailText += ".header{ color: #000; font-size: 20px; line-height: 24px; font-weight: bold; font-family: Arial, Helvetica;}";
                mailText += ".footer{ color: #505050; font-size: 11px; line-height: 14px; font-family: Arial, Helvetica;}";
                mailText += "</style>";
                mailText += "<body>";
                mailText += "<table cellpadding='0' cellspacing='0' style='width:400px;'>";
                mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/LostPassword/header") + "</td></tr>";
                mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
                mailText += "<tr><td class='text'>" + RXMali.GetXMLNode("Mail/LostPassword/text") + ":<br /><br />";
                mailText += RXMali.GetXMLNode("Common/username") + ": " + u.UserName + "<br />";
                mailText += RXMali.GetXMLNode("Common/password") + ": " + u.Password + "<br /><br />";
                mailText += "<a href='" + Url + "'>" + RXMali.GetXMLNode("Mail/LostPassword/link") + "</a><br /><br />";
                 mailText += RXMali.GetXMLNode("Mail/Global/thank_you");
                 mailText += "    </td></tr>";
                mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
                mailText += "<tr><td><hr /></td></tr>";
                mailText += "<tr><td class='footer'>" + RXMali.GetXMLNode("Mail/Global/footer") + "</td></tr>";
                mailText += "</table></body></html>";

                RXMali.SendMail(mailText, mailSubject, mailTo, mailSender, mailSenderName, mailServer, mailPort);


                this.Page_2.Visible = true;
                this.MessageBox.Visible = true;
                this.Page_1.Visible = false;

            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void lbnSendPassword2_Click(object sender, EventArgs e)
    {
        String function_name = "lbnSendPassword2_Click";
        try
        {
            String user = this.txtUsername4.Text;
            Int32 uId = 0;

            if (user != "")
            {
                if (RXServer.Auth.Users.UserNameExist(user))
                {
                    uId = RXServer.Auth.Users.GetUserId(user);
                }
                else
                {
                    this.lblForgotError.Text = RXMali.GetXMLNode("Error/username");
                    this.ForgotError.Visible = true;
                }
            }

            if (uId > 0)
            {
                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);

                string mailServer, mailPort, mailSender, mailTo, mailSubject, mailSenderName, mailText = "";

                mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
                mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
                mailTo = u.Mail;
                mailSender = ConfigurationManager.AppSettings["MailSender"].ToString();
                mailSenderName = ConfigurationManager.AppSettings["MailSenderName"].ToString();

                mailSubject = RXMali.GetXMLNode("Mail/LostPassword/subject");

                String Url = "";
                Url = RXMali.GetDomainUrl(Request.Url.ToString());
                Url = Url.Replace("Modules/User/ForgotPassWindow/", "");

                mailText += "<html>";
                mailText += "<style>";
                mailText += "a, a:visited, a:active { color: #8D301E; text-decoration: none; font-family: Arial, Helvetica;}";
                mailText += ".text{ color: #505050; font-size: 12px; line-height: 16px; font-family: Arial, Helvetica;}";
                mailText += ".header{ color: #000; font-size: 20px; line-height: 24px; font-weight: bold; font-family: Arial, Helvetica;}";
                mailText += ".footer{ color: #505050; font-size: 11px; line-height: 14px; font-family: Arial, Helvetica;}";
                mailText += "</style>";
                mailText += "<body>";
                mailText += "<table cellpadding='0' cellspacing='0' style='width:400px;'>";
                mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/LostPassword/header") + "</td></tr>";
                mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
                mailText += "<tr><td class='text'>" + RXMali.GetXMLNode("Mail/LostPassword/text") + ":<br /><br />";
                mailText += RXMali.GetXMLNode("Common/username") + ": " + u.UserName + "<br />";
                mailText += RXMali.GetXMLNode("Common/password") + ": " + u.Password + "<br /><br />";
                mailText += "<a href='" + Url + "'>" + RXMali.GetXMLNode("Mail/LostPassword/link") + "</a><br /><br />";
                mailText += RXMali.GetXMLNode("Mail/Global/thank_you");
                mailText += "    </td></tr>";
                mailText += "<tr><td><hr /></td></tr>";
                mailText += "<tr><td class='footer'>" + RXMali.GetXMLNode("Mail/Global/footer") + "</td></tr>";
                mailText += "</body></html>";

                RXMali.SendMail(mailText, mailSubject, mailTo, mailSender, mailSenderName, mailServer, mailPort);

                this.Page_2.Visible = true;
                this.MessageBox.Visible = true;
                this.Page_1.Visible = false;
            }

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }



}
