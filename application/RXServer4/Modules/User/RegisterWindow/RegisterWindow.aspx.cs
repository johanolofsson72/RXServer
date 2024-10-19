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

public partial class Modules_User_RegisterWindow_RegisterWindow : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_User_RegisterWindow_RegisterWindow";
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
            this.lblInfo.Text = RXMali.GetXMLNode("Modules/Register/text");
            this.Title = RXMali.GetXMLNode("Modules/Register/title");

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
                list += "<td style='padding: 10px; background-color: white;'><a class='link_333333' href='RegisterWindow.aspx?Page=login&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>Registrera</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #CCCCCC;'><a class='link_575757' href='RegisterWindow.aspx?Page=login&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>Registrera</a></td>";
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

            LoadRolesData();

            this.lblText4_1.Text = RXMali.GetXMLNode("Common/username");
            this.txtUsername4.Text = RXMali.GetXMLNode("Common/username");
            this.lblText4_2.Text = RXMali.GetXMLNode("Common/email");
            this.txtEmail4.Text = RXMali.GetXMLNode("Common/email");
            this.lblText4_3.Text = RXMali.GetXMLNode("Modules/EditProfile/firstname");
            this.lblText4_6.Text = RXMali.GetXMLNode("Modules/EditProfile/lastname");
            this.lblText4_7.Text = RXMali.GetXMLNode("Modules/EditProfile/address");
            this.lblText4_8.Text = RXMali.GetXMLNode("Modules/EditProfile/zipcode");
            this.lblText4_9.Text = RXMali.GetXMLNode("Modules/EditProfile/city");
            this.lblText4_4.Text = RXMali.GetXMLNode("Modules/User/choose_password");
            this.lblText4_5.Text = RXMali.GetXMLNode("Modules/User/confirm_password");
            this.lbnCreateAccount.Text = RXMali.GetXMLNode("Modules/User/create_account");

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void LoadRolesData()
    {
        String function_name = "LoadRolesData";
        try
        {
            //this.ddlRoles.Items.Clear();
            //this.ddlRoles.Items.Add(new ListItem(RXMali.GetXMLNode("Modules/User/choose_role"), "0"));

            //foreach (LiquidCore.Roles.Role r in new LiquidCore.Roles())
            //{
            //    if (r.Id != 1 && r.Id != 4)
            //    {
            //        this.ddlRoles.Items.Add(new ListItem(r.Title, r.Id.ToString()));
            //    }
            //}
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private Boolean RegisterUser(string user, string pw1, string pw2, string mail, string roleId)
    {
        String function_name = "RegisterUser";
        try
        {
            if (ValidateUser(user, pw1, pw2, mail, roleId))
            {
                Int32 uId, rId = 0;
                Int32.TryParse(roleId, out rId);

                uId = RXServer.Auth.Users.CreateUser(user, mail, "UserPage", pw1, rId);

                if (uId > 0)
                {
                    CreateUserFolder(rId, uId);
                    RXServer.Auth.Users.DeactivateUserAccount(uId);
                    SendAdminRegisterMail(mail, user, pw1);

                    RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(uId);
                    u.FirstName = Server.HtmlEncode(this.txtFirstName.Text).Replace("'", "`");
                    u.LastName = Server.HtmlEncode(this.txtLastName.Text).Replace("'", "`");
                    u.Address = Server.HtmlEncode(this.txtAddress.Text).Replace("'", "`");
                    u.City = Server.HtmlEncode(this.txtCity.Text).Replace("'", "`");
                    u.PostalCode = Server.HtmlEncode(this.txtPostalCode.Text).Replace("'", "`");
                    u.Save();
                    return true;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    private Boolean ValidateUser(string username, string pw1, string pw2, string mail, string roleId)
    {
        String function_name = "ValidateUser";
        try
        {
            Boolean valid = true;
            this.lblCreateErrors.Text = "";

            if (!RXMali.IsEmail(mail))
            {
                // error 1
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/email") + "<br />";
                valid = false;
            }

            if (username == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/username") + "<br />";
                valid = false;
            }

            if (pw1 != pw2 || pw1 == "" || pw2 == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/password_mismatch") + "<br />";
                valid = false;
            }

            if (RXServer.Auth.Users.UserNameExist(username))
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/user_exists") + "<br />";
                valid = false;
            }
            if (RXServer.Auth.Users.UserEmailExist(mail))
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/email_exists") + "<br />";
                valid = false;
            }

            if (this.txtFirstName.Text == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/firstname") + "<br />";
                valid = false;
            }
            if (this.txtLastName.Text == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/lastname") + "<br />";
                valid = false;
            }

            if (this.txtAddress.Text == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/address") + "<br />";
                valid = false;
            }
            if (this.txtPostalCode.Text == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/zipcode") + "<br />";
                valid = false;
            }
            if (this.txtCity.Text == "")
            {
                this.lblCreateErrors.Text += " - " + RXMali.GetXMLNode("Error/city") + "<br />";
                valid = false;
            }


            return valid;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    //private Int32 CreateUserPage(Int32 roleId, Int32 userId)
    //{
    //    String function_name = "CreateUserPage";
    //    try
    //    {
    //        Int32 userPage = 0;

    //        RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item();
    //        mItem.SitId = 1;
    //        mItem.Language = 1;
    //        mItem.Status = 3;
    //        mItem.ParentId = 0;
    //        mItem.Hidden = true;
    //        mItem.Template = "Template3.master";
    //        mItem.Title = "User - " + userId;
    //        mItem.Alias = "Userpage";
    //        mItem.ModelId = 13;
    //        mItem.Save();

    //        if (mItem.Id > 0)
    //        {
    //            userPage = mItem.Id;
    //        }

    //        //RXServer.Modules.UserInfo.Create(1, userPage, 61, "ContentPane2", 1, 1, false, false);

    //        return userPage;
    //    }
    //    catch (Exception ex)
    //    {
    //        RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
    //        return 0;
    //    }
    //}

    private void CreateUserFolder(Int32 roleId, Int32 userId)
    {
        String function_name = "CreateUserFolder";
        try
        {
            RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(roleId);

            string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/");
            string newPath = System.IO.Path.Combine(activeDir, userId.ToString());

            System.IO.Directory.CreateDirectory(newPath);

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    public void SendRegisterMail(string mail, string user, string password)
    {
        String function_name = "SendRegisterMail";
        try
        {
            string mailServer, mailPort, mailSender, mailTo, mailSubject, mailSenderName, mailText = "";

            mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
            mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
            mailTo = mail;
            mailSender = ConfigurationManager.AppSettings["MailSender"].ToString();
            mailSenderName = ConfigurationManager.AppSettings["MailSenderName"].ToString();

            mailSubject = RXMali.GetXMLNode("Mail/Welcome/subject");

            String Url = "";
            Url = RXMali.GetDomainUrl(Request.Url.ToString());
            Url = Url.Replace("Modules/User/RegisterWindow/", "");

            mailText += "<html>";
            mailText += "<style>";
            mailText += "a, a:visited, a:active { color: #8D301E; text-decoration: none; }";
            mailText += ".text{ color: #505050; font-size: 12px; line-height: 16px; font-family: Arial, Helvetica;}";
            mailText += ".header{ color: #000; font-size: 20px; line-height: 24px; font-weight: bold; font-family: Arial, Helvetica;}";
            mailText += ".footer{ color: #505050; font-size: 11px; line-height: 14px; font-family: Arial, Helvetica;}";
            mailText += "</style>";
            mailText += "<body>";
            mailText += "<table cellpadding='0' cellspacing='0' style='width:400px;'>";
            mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/Welcome/header") + "</td></tr>";
            mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
            mailText += "<tr><td class='text'>" + RXMali.GetXMLNode("Mail/Welcome/text") + "<br />";
            mailText += RXMali.GetXMLNode("Common/username") + ": " + user + "<br />";
            mailText += RXMali.GetXMLNode("Common/password") + ": " + password + "<br /><br />";

            mailText += RXMali.GetXMLNode("Mail/Global/thank_you");
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

    public void SendAdminRegisterMail(string mail, string user, string password)
    {
        String function_name = "SendRegisterMail";
        try
        {
            string mailServer, mailPort, mailSender, mailTo, mailSubject, mailSenderName, mailText = "";

            mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
            mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();
            mailTo = ConfigurationManager.AppSettings["RegisterMembersMail"].ToString();
            mailSender = ConfigurationManager.AppSettings["MailSender"].ToString();
            mailSenderName = ConfigurationManager.AppSettings["MailSenderName"].ToString();

            mailSubject = RXMali.GetXMLNode("Mail/Register/subject");


            mailText += "<html>";
            mailText += "<style>";
            mailText += "a, a:visited, a:active { color: #8D301E; text-decoration: none; }";
            mailText += ".text{ color: #505050; font-size: 12px; line-height: 16px; font-family: Arial, Helvetica;}";
            mailText += ".header{ color: #000; font-size: 20px; line-height: 24px; font-weight: bold; font-family: Arial, Helvetica;}";
            mailText += ".footer{ color: #505050; font-size: 11px; line-height: 14px; font-family: Arial, Helvetica;}";
            mailText += "</style>";
            mailText += "<body>";
            mailText += "<table cellpadding='0' cellspacing='0' style='width:400px;'>";
            mailText += "<tr><td class='header'>" + RXMali.GetXMLNode("Mail/Register/header") + "</td></tr>";
            mailText += "<tr><td style='height: 20px;'>&nbsp;</td></tr>";
            mailText += "<tr><td class='text'>" + RXMali.GetXMLNode("Mail/Register/text") + "<br />";
            mailText += RXMali.GetXMLNode("Common/username") + ": " + user + "<br />";
            mailText += RXMali.GetXMLNode("Common/password") + ": " + password + "<br /><br />";
            mailText += RXMali.GetXMLNode("Modules/EditProfile/firstname") + ": " + this.txtFirstName.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/EditProfile/lastname") + ": " + this.txtLastName.Text + "<br /><br />";
            mailText += RXMali.GetXMLNode("Modules/EditProfile/address") + ": " + this.txtAddress.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/EditProfile/zipcode") + ": " + this.txtPostalCode.Text + "<br />";
            mailText += RXMali.GetXMLNode("Modules/EditProfile/city") + ": " + this.txtCity.Text + "<br /><br />";

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

    protected void lbnCreateAccount_Click(object sender, EventArgs e)
    {
        String function_name = "lbnCreateAccount_Click";
        try
        {
            if (RegisterUser(this.txtUsername4.Text, this.txtPassword4_1.Text, this.txtPassword4_2.Text, this.txtEmail4.Text, "2"))
            {
                this.txtEmail4.Text = "";
                this.txtPassword4_1.Text = "";
                this.txtPassword4_2.Text = "";
                this.txtUsername4.Text = "";
                this.Page_1.Visible = false;
                this.Page_2.Visible = true;
                this.lbnClose.Text = RXMali.GetXMLNode("Common/close");
                this.MessageBox.Visible = true;
                this.ltrMessage.Text = RXMali.GetXMLNode("Modules/Register/user_created");


            }
            else
            {
                this.createErrors.Visible = true;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }


}
