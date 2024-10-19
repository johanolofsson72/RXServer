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

public partial class Modules_UserModules_EditProfile_EditProfile_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_UserModules_EditProfile_EditProfile_Admin";

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
            this.lbnClose.Text = RXMali.GetXMLNode("Common/close");
            this.lbnClose2.Text = RXMali.GetXMLNode("Common/close");
            this.lblSuccess.Text = RXMali.GetXMLNode("Modules/AddAddon/success_text");
            this.lblInfo.Text = RXMali.GetXMLNode("Modules/EditProfile/text");
            this.lblError.Text = RXMali.GetXMLNode("Common/error_mess");
            this.Title = RXMali.GetXMLNode("Modules/EditProfile/title");

            BindMenuData();
            HideErrors();

            switch (RXServer.Web.RequestValues.Page)
            {
                case "1":
                    if (!Page.IsPostBack)
                    {
                        HideWindows();
                        BindTab1Data();
                    }
                break;

                case "2":
                    if (!Page.IsPostBack)
                    {
                        HideWindows();
                        BindTab2Data();
                    }
                break;

                case "3":
                    if (!Page.IsPostBack)
                    {
                        HideWindows();
                        BindTab3Data();
                    }
                break;

                case "4":
                if (!Page.IsPostBack)
                {
                    HideWindows();
                    BindTab4Data();
                }
                break;

                case "5":
                if (!Page.IsPostBack)
                {
                    HideWindows();
                    BindTab5Data();
                }
                break;

                default:                    
                    if (!Page.IsPostBack)
                    {
                        HideWindows();
                        BindTab1Data();
                    }
     
                break;
            }
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
            this.Page_0.Visible = false;
            this.Page_1.Visible = false;
            this.Page_2.Visible = false;
            this.Page_3.Visible = false;
            this.holder_password.Visible = false;
            this.holder_email.Visible = false;
            this.holder_person.Visible = false;
            this.holder_save_1.Visible = false;
            this.holder_save_2.Visible = false;
            this.holder_save_3.Visible = false;
            this.Page_4.Visible = false;
            this.holder_remove.Visible = false;
            this.holder_save_4.Visible = false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void HideErrors()
    {
        String function_name = "HideWindows";
        try
        {
            this.MessageBox.Visible = false;
            this.ErrorBox.Visible = false;

            //this.imgError1_1.Visible = false;
            this.imgError1_2.Visible = false;
            this.imgError1_3.Visible = false;
            this.imgError1_4.Visible = false;
            this.imgError2_1.Visible = false;
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindTab1Data()
    {
        String function_name = "BindTab1Data";
        try
        {
            this.lblText1_1.Text = RXMali.GetXMLNode("Modules/EditProfile/company");
            this.lblText1_2.Text = RXMali.GetXMLNode("Common/email");
            this.lblText1_3.Text = RXMali.GetXMLNode("Modules/EditProfile/old_password");
            this.lblText1_4.Text = RXMali.GetXMLNode("Modules/EditProfile/new_password");
            this.lblText1_5.Text = RXMali.GetXMLNode("Modules/EditProfile/verify_password");
            this.lblText1_6.Text = RXMali.GetXMLNode("Modules/EditProfile/firstname");
            this.lblText1_7.Text = RXMali.GetXMLNode("Modules/EditProfile/lastname");
            this.lblText1_8.Text = RXMali.GetXMLNode("Modules/EditProfile/city");
            this.lblText1_9.Text = RXMali.GetXMLNode("Modules/EditProfile/address");
            this.lblText1_10.Text = RXMali.GetXMLNode("Modules/EditProfile/zipcode");
            this.lbnSaveData1.Text = RXMali.GetXMLNode("Common/save");

            this.Page_1.Visible = true;

            this.holder_email.Visible = true;
            this.holder_password.Visible = true;
            this.holder_save_1.Visible = true;
            this.holder_person.Visible = true;


            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            this.txtFirstname.Text = Server.HtmlDecode(u.FirstName);
            this.txtLastname.Text = Server.HtmlDecode(u.LastName);
            this.txtAddress.Text = Server.HtmlDecode(u.Address);
            this.txtZipcode.Text = Server.HtmlDecode(u.PostalCode);
            this.txtCity.Text = Server.HtmlDecode(u.City);
            this.txtEmail.Text = u.Mail;

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindTab2Data()
    {
        String function_name = "BindTab2Data";
        try
        {
            this.Page_2.Visible = true;
            this.lbnSaveData2.Text = RXMali.GetXMLNode("Common/save");
            this.lbnRemove.Text = RXMali.GetXMLNode("Modules/EditProfile/remove_image");
            this.lblText2_1.Text = RXMali.GetXMLNode("Modules/EditProfile/upload_image");
            this.lblText2_2.Text = RXMali.GetXMLNode("Modules/EditProfile/image_properties");
            //this.RadUpload1.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png" };
            //RadUpload2.MaxFileSize = 1000000;
            //this.RadUpload1.AllowedMimeTypes = new string[] {"image/gif" , "image/jpeg", "image/pjpeg" ,"image/png"};

            this.holder_media.Visible = true;
            this.holder_save_2.Visible = true;

            // Hämtar Users baserat på RolId
            RXServer.Auth.Users.User apa = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            //if (apa.ImageUrl == "")
            //{
            //    this.imbRemoveImg.Visible = false;
            //    this.lbnRemove.Visible = false;
            //}
            //else
            //{
                RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(RXServer.Auth.Roles.GetRoleId(RXServer.Auth.AuthorizedUser.Identity.Role));

//                String imgfile = Server.MapPath("~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/" + u.ImageUrl);
                this.imgContent.Visible = true;
                this.imgContent.ImageUrl = "~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/" + apa.ImageUrl;


                /*if (File.Exists(imgfile))
                {
                    //// Retrieve the image.
                    //Bitmap image1;

                    //image1 = new Bitmap(imgfile, true);

                    //Int32 width, height, newheight, newwidth;

                    //width = 48;
                    //height = 48;

                    //newwidth = width;

                    //if (image1.Width <= newwidth)
                    //{
                    //    newwidth = image1.Width;
                    //}

                    //newheight = Convert.ToInt32((image1.Height * newwidth) / image1.Width);

                    //if (newheight > image1.Height)
                    //{
                    //    newwidth = Convert.ToInt32((image1.Width * height) / image1.Height);
                    //    newheight = height;
                    //}

                    //if (newheight > height)
                    //{
                    //    float temp, temph, tempnh;
                    //    temph = height;
                    //    tempnh = newheight;
                    //    temp = temph / tempnh;
                    //    newwidth = Convert.ToInt32(newwidth * temp);
                    //    newheight = height;
                    //}

                    this.imgContent.Visible = true;
                                       //this.imgContent.Width = newwidth;
                    //this.imgContent.Height = newheight;
                }*/

            //}

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindTab3Data()
    {
        String function_name = "BindTab3Data";
        try
        {   
            this.Page_3.Visible = true;
            this.holder_info1.Visible = true;
            this.holder_info2.Visible = true;
            this.holder_pres.Visible = true;
            this.holder_save_3.Visible = true;
            this.lblText3_1.Text = RXMali.GetXMLNode("Modules/EditProfile/profile_info");
            this.lbnSaveData3.Text = RXMali.GetXMLNode("Common/save");

            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            this.RadEditor1.Content = Server.HtmlDecode(u.Description);

            this.txtBike.Text = Server.HtmlDecode(u.Company);
            this.txtModel.Text = Server.HtmlDecode(u.Company2);
            this.txtSince.Text = Server.HtmlDecode(u.CO2);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindTab4Data()
    {
        String function_name = "BindTab4Data";
        try
        {
            this.Page_4.Visible = true;
            this.holder_remove.Visible = true;
            this.holder_save_4.Visible = true;

            this.lblRemoveUser.Text = RXMali.GetXMLNode("Modules/EditProfile/remove_user_text");
            this.lbnSaveData4.Text = RXMali.GetXMLNode("Modules/EditProfile/remove_me");            

        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindTab5Data()
    {
        String function_name = "BindTab5Data";
        try
        {
            this.Page_5.Visible = true;
            this.holder_change.Visible = true;
            this.holder_save_5.Visible = true;

            this.lblChangeUser.Text = RXMali.GetXMLNode("Modules/EditProfile/change_username_text");
            this.lbnSaveData5.Text = RXMali.GetXMLNode("Common/save");

            this.txtNewUsername.Text = RXServer.Auth.AuthorizedUser.Identity.Name;

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
            if (RXServer.Web.RequestValues.Page == "1" || RXServer.Web.RequestValues.Page == "")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='tablink_on' href='ProfileWindow.aspx?Page=1&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_1") + "</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #812526;'><a class='tablink_off' href='ProfileWindow.aspx?Page=1&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_1") + "</a></td>";
            }

            if (RXServer.Web.RequestValues.Page == "2")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='tablink_on' href='ProfileWindow.aspx?Page=2&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_2") + "</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #812526;'><a class='tablink_off' href='ProfileWindow.aspx?Page=2&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_2") + "</a></td>";
            }

            if (RXServer.Web.RequestValues.Page == "3")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='tablink_on' href='ProfileWindow.aspx?Page=3&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_3") + "</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #812526;'><a class='tablink_off' href='ProfileWindow.aspx?Page=3&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_3") + "</a></td>";
            }

            if (RXServer.Web.RequestValues.Page == "5")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='tablink_on' href='ProfileWindow.aspx?Page=5&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_5") + "</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #812526;'><a class='tablink_off' href='ProfileWindow.aspx?Page=5&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_5") + "</a></td>";
            }


            if (RXServer.Web.RequestValues.Page == "4")
            {
                list += "<td style='padding: 10px; background-color: white;'><a class='tablink_on' href='ProfileWindow.aspx?Page=4&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_4") + "</a></td>";
            }
            else
            {
                list += "<td style='padding: 10px; background-color: #812526;'><a class='tablink_off' href='ProfileWindow.aspx?Page=4&PagId=" + RXServer.Web.RequestValues.PagId + "&SitId=" + RXServer.Web.RequestValues.SitId + "&ModId=" + RXServer.Web.RequestValues.ModId + "'>" + RXMali.GetXMLNode("Modules/EditProfile/tab_4") + "</a></td>";
            }


            list += "</tr>";
            list += "</table>";


            this.ltrSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnSaveData1_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData1_Click";
        try
        {

            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            u.Company = Server.HtmlEncode(this.txtCompany.Text);

            Boolean valid = true;
            String Errors = "";

            if (!RXMali.IsEmail(this.txtEmail.Text))
            {
                Errors += " - " + RXMali.GetXMLNode("Error/email") + "<br />";
                this.imgError1_2.Visible = true;
                valid = false;
            }
            else
            {
                if (u.Mail != this.txtEmail.Text)
                {
                    if (!RXServer.Auth.Users.UserEmailExist(this.txtEmail.Text))
                    {
                        u.Mail = this.txtEmail.Text;
                    }
                    else
                    {
                        Errors += " - " + RXMali.GetXMLNode("Error/email_exists") + "<br />";
                        this.imgError1_2.Visible = true;
                        valid = false;
                    }
                }               
            }

            if(this.txtNewPassword1.Text != "")
            {
                if (this.txtNewPassword1.Text == this.txtNewPassword2.Text)
                {
                    if (this.txtOldPassword.Text == u.Password.ToString())
                    {
                        u.Password = txtNewPassword1.Text;
                    }
                    else
                    {
                        Errors += " - " + RXMali.GetXMLNode("Error/fill_old_password") + "<br />";
                        this.imgError1_3.Visible = true;
                        this.imgError1_4.Visible = true;
                        this.imgError1_5.Visible = true;
                        valid = false;
                    }
                }
                else
                {
                    Errors += " - " + RXMali.GetXMLNode("Error/password_mismatch") + "<br />";
                    this.imgError1_3.Visible = true;
                    this.imgError1_4.Visible = true;
                    valid = false;
                }

            }

            if (this.txtFirstname.Text != "")
            {
                u.FirstName = Server.HtmlEncode(this.txtFirstname.Text);

            }
            if (this.txtLastname.Text != "")
            {
                u.LastName = Server.HtmlEncode(this.txtLastname.Text);

            }
            if (this.txtAddress.Text != "")
            {
                u.Address = Server.HtmlEncode(this.txtAddress.Text);
            }
            if (this.txtZipcode.Text != "")
            {
                u.PostalCode = Server.HtmlEncode(this.txtZipcode.Text);
            }
            if (this.txtCity.Text != "")
            {
                u.City = Server.HtmlEncode(this.txtCity.Text);
            }

            if (valid)
            {
                u.Save();
                this.MessageBox.Visible = true;
                this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");
                
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnSaveData2_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData2_Click";
        try
        {

            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            Boolean valid = true;
            String Errors = "";

            if (RadUpload1.InvalidFiles.Count > 0)
            {
                Errors += " - " + RXMali.GetXMLNode("Error/image") + "<br />";
                this.imgError2_1.Visible = true;
                valid = false;
            }
            else
            {
                #region UploadImage

                String strFileName = "";

                if (this.RadUpload1.UploadedFiles.Count > 0)
                {
                    Int32 img_width = 173;
                    Int32 img_height = 200;

                    String activeDir = "";
                    String activeDir2 = "";
                    try
                    {
                        RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(RXServer.Auth.Roles.GetRoleId(RXServer.Auth.AuthorizedUser.Identity.Role));
                        activeDir = Server.MapPath("~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/");
                        activeDir2 = "~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/";
                    }
                    catch (Exception ex)
                    {
                        this.ErrorBox.Visible = true;
                        Errors += ex;
                    }
                    this.RadUpload1.TargetFolder = activeDir2;

                    if (!System.IO.Directory.Exists(activeDir))
                    {
                        System.IO.Directory.CreateDirectory(activeDir);
                    }

                    foreach (UploadedFile f1 in RadUpload1.UploadedFiles)
                    {
                        strFileName = f1.GetName().Trim();
                        f1.SaveAs(activeDir + strFileName);

                        //if (f1.GetExtension() == ".jpg" || f1.GetExtension() == ".gif" || f1.GetExtension() == ".jpeg" || f1.GetExtension() == ".png")
                        //{
                            // Scale Image

                            System.Drawing.Image scaleImg = System.Drawing.Image.FromFile(activeDir + strFileName);

                            string tmp = DateTime.Now.Ticks.ToString();

                            //if (scaleImg.Width != img_width && scaleImg.Height != img_height)
                            //{
                                System.Drawing.Image newImg = null;
                                newImg = RXMali.ScaleFixedImage(scaleImg, img_width, img_height);
                                newImg.Save(activeDir + RXServer.Auth.AuthorizedUser.Identity.Name + "_" + tmp + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                newImg.Dispose();

                                u.ImageUrl = RXServer.Auth.AuthorizedUser.Identity.Name + "_" + tmp + ".jpg";
                            //}
                            //else
                            //{
                            //    u.ImageUrl = strFileName;
                            //}
                        //}                        
                    }
                }


                //if (this.RadUpload1.UploadedFiles.Count > 0)
                //{
                //    if (!System.IO.Directory.Exists(activeDir))
                //    {
                //        System.IO.Directory.CreateDirectory(activeDir);
                //    }

                //    this.RadUpload1.TargetFolder = "~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/";

                //    String activeFile = Server.MapPath("~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/" + u.ImageUrl);

                //    foreach (UploadedFile f1 in RadUpload1.UploadedFiles)
                //    {
                //        strFileName = "thumb_" + RXServer.Auth.AuthorizedUser.Identity.Name + "_" + DateTime.Now.Ticks.ToString() + f1.GetExtension();
                //        f1.SaveAs(activeDir + strFileName);
                //        u.ImageUrl = strFileName;
                //        u.ImageToolTip = f1.GetExtension();
                //    }
                //}

                #endregion
            }


            if (valid)
            {
                u.Save();
                this.MessageBox.Visible = true;
                this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");

                BindTab2Data();

            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnSaveData3_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData3_Click";
        try
        {

            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            Boolean valid = true;
            String Errors = "";

            u.Description = Server.HtmlEncode(this.RadEditor1.Content);
            u.Company = Server.HtmlEncode(this.txtBike.Text);
            u.Company2 = Server.HtmlEncode(this.txtModel.Text);
            u.CO2 = Server.HtmlEncode(this.txtSince.Text);

            if (valid)
            {
                u.Save();
                this.MessageBox.Visible = true;
                this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnSaveData4_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData4_Click";
        try
        {
            
            Int32 UserId = 0;
            UserId = RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name);

            if (UserId > 0)
            {
                Int32 RolId = 0;

                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(UserId);
                ArrayList roles = new ArrayList();

                if (u.StartPage > 0)
                {
                    RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(u.StartPage);
                    mItem.Delete();
                }

                roles = u.GetRoles();

                RXServer.Auth.Users.DeleteUser(UserId);

                Int32.TryParse(roles[0].ToString(), out RolId);

                // Rensa alla hans filer

                if (RolId > 0)
                {
                    RXServer.Auth.Roles.Role role = new RXServer.Auth.Roles.Role(RolId);
                    string activeDir = Server.MapPath("~/Upload/Users/" + role.Description + "/" + UserId + "/");

                    if (System.IO.Directory.Exists(activeDir))
                    {
                        foreach (string sFile in System.IO.Directory.GetFiles(activeDir))
                        {
                            do
                            {
                                try
                                {
                                    System.IO.File.Delete(sFile);
                                }
                                catch
                                {
                                }

                            } while (System.IO.File.Exists(sFile));

                        }
                    }

                }

                RXServer.Auth.LogOut();
                String path = "http://" + Request.Url.Authority + Request.ApplicationPath + "/";
                this.lblScript.Text = "<script language='javascript'>CloseRedirect('" + path + "Default.aspx');</script>";

            }



            //RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            //Boolean valid = true;
            //String Errors = "";

            //u.Description = Server.HtmlEncode(this.RadEditor1.Content);
            //u.Company = Server.HtmlEncode(this.txtBike.Text);
            //u.Company2 = Server.HtmlEncode(this.txtModel.Text);
            //u.CO2 = Server.HtmlEncode(this.txtSince.Text);

            //if (valid)
            //{
            //    u.Save();
            //    this.MessageBox.Visible = true;
            //    this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");
            //}
            //else
            //{
            //    this.ErrorBox.Visible = true;
            //    this.ltrErrors.Text = Errors;
            //}
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnSaveData5_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData5_Click";
        try
        {

            //RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));

            Boolean valid = true;
            String Errors = "";

            //u.Description = Server.HtmlEncode(this.RadEditor1.Content);
            //u.Company = Server.HtmlEncode(this.txtBike.Text);
            //u.Company2 = Server.HtmlEncode(this.txtModel.Text);
            //u.CO2 = Server.HtmlEncode(this.txtSince.Text);

            //if (valid)
            //{
            //    u.Save();
            //    this.MessageBox.Visible = true;
            //    this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");
            //}
            //else
            //{
            //    this.ErrorBox.Visible = true;
            //    this.ltrErrors.Text = Errors;
            //}


            string username = this.txtNewUsername.Text.Replace("'", "`");
            if (RXServer.Auth.Users.UserNameExist(username))
            {
                Errors += " - " + RXMali.GetXMLNode("Error/user_exists") + "<br />";
                valid = false;
            }

            if (valid)
            {
                RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));
                u.UserName = username;
                u.Save();                

                RXServer.Auth.AuthorizedUser.Identity.Name = username;

                //RXServer.Auth.LogOut();

                this.MessageBox.Visible = true;
                this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");

            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void imbRemoveImg_Click(object sender, EventArgs e)
    {
        String function_name = "imbRemoveImg_Click";
        try
        {

            RXServer.Auth.Users.User u = new RXServer.Auth.Users.User(RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name));
            RXServer.Auth.Roles.Role r = new RXServer.Auth.Roles.Role(RXServer.Auth.Roles.GetRoleId(RXServer.Auth.AuthorizedUser.Identity.Role));

            Boolean valid = true;
            String Errors = "";
            
            String activeFile = Server.MapPath("~/Upload/Users/" + r.Description + "/" + RXServer.Auth.Users.GetUserId(RXServer.Auth.AuthorizedUser.Identity.Name) + "/" + u.ImageUrl);
            if (!System.IO.File.Exists(activeFile))
            {
                System.IO.File.Delete(activeFile);
            }

            u.ImageUrl = "";
            u.ImageToolTip = "";
            
            if (valid)
            {
                u.Save();

                this.imgContent.Visible = false;
                this.imbRemoveImg.Visible = false;
                this.lbnRemove.Visible = false;
                
                this.MessageBox.Visible = true;
                this.ltrMessage.Text = RXMali.GetXMLNode("Success/information_updated");
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

}
