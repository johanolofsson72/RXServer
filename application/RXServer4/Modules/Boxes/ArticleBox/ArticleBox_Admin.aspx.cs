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

public partial class Modules_Boxes_ArticleBox_ArticleBox_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_ArticleBox_ArticleBox_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ArticleBox/Text");
            this.Page_1.Visible = true;
            this.SubMenu.Visible = true;
            HideErrors();
            if (!Page.IsPostBack)
            {
                BindData();
                BindMenuData();
            }
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
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            this.txtHeader.Text = Server.HtmlDecode(tm.Text2);
            //this.txtTitle.Text = Server.HtmlDecode(tm.Title);
            this.RadEditor1.Content = Server.HtmlDecode(tm.Text4);
            this.txtToolTip.Text = Server.HtmlDecode(tm.MediaToolTip);

            //if (RXServer.Web.RequestValues.ConPa == "small")
            //{
            //    this.cbExtraBar.Enabled = false;
            //}

            if (tm.MediaVisible == "false")
            {
                this.cbShowImage.Checked = false;
            }
            else
            {
                this.cbShowImage.Checked = true;
            }

            //if (tm.ExtraFont == "true")
            //{
            //    this.cbExtraBar.Checked = true;
            //}
            //else
            //{
            //    this.cbExtraBar.Checked = false;
            //}
            
            #region loadImage
            if (tm.Media != "")
            {
                if (tm.MediaType == ".gif" || tm.MediaType == ".jpg" || tm.MediaType == ".jpeg" || tm.MediaType == ".png")
                {
                    String imgfile = Server.MapPath("~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/" + tm.Media);

                    if (File.Exists(imgfile))
                    {
                        // Retrieve the image.
                        Bitmap image1;

                        image1 = new Bitmap(imgfile, true);

                        Int32 width, height, newheight, newwidth;

                        width = 200;
                        height = 200;

                        newwidth = width;

                        if (image1.Width <= newwidth)
                        {
                            newwidth = image1.Width;
                        }

                        newheight = Convert.ToInt32((image1.Height * newwidth) / image1.Width);

                        if (newheight > image1.Height)
                        {
                            newwidth = Convert.ToInt32((image1.Width * height) / image1.Height);
                            newheight = height;
                        }

                        if (newheight > height)
                        {
                            float temp, temph, tempnh;
                            temph = height;
                            tempnh = newheight;
                            temp = temph / tempnh;
                            newwidth = Convert.ToInt32(newwidth * temp);
                            newheight = height;
                        }

                        this.imgContent.Visible = true;
                        this.imgContent.ImageUrl = "~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/" + tm.Media;
                        this.imgContent.Width = newwidth;
                        this.imgContent.Height = newheight;
                        this.hplZoomImg.Visible = true;
                        this.hplZoomImg.NavigateUrl = "~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/" + tm.Media;
                    }
                }
                else if(tm.MediaType == ".swf")
                {
                    this.lblImgText.Text = "FlashFile (" + tm.Media + ")";
                }
                else if (tm.MediaType == ".flv")
                {
                    this.lblImgText.Text = "FlashVideo (" + tm.Media + ")";
                }
                else
                {
                    this.lblImgText.CssClass = "Text11_red";
                    this.lblImgText.Text = "Invalid MediaFile! (" + tm.Media + ")";
                }
            }

            #endregion

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindMenuData()
    {
        String function_name = "BindMenuData";
        try
        {
            String list = "";
            this.ltrSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
       
    protected void btnSaveData_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData_Click";
        try
        {
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            tm.Text2 = Server.HtmlEncode(this.txtHeader.Text);
            //tm.Text1 = Server.HtmlEncode(this.txtTitle.Text);
            tm.Text4 = Server.HtmlEncode(this.RadEditor1.Content);
            tm.MediaToolTip = Server.HtmlEncode(this.txtToolTip.Text);
            String date = DateTime.Today.ToString("yyyy-MM-dd");
            tm.Updated = date;

            if (this.cbShowImage.Checked)
            {
                tm.MediaVisible = "true";
            }
            else
            {
                tm.MediaVisible = "false";
            }

            //if (this.cbExtraBar.Checked)
            //{
            //    tm.ExtraFont = "true";
            //}
            //else
            //{
            //    tm.ExtraFont = "false";
            //}

            Boolean valid = true;
            String Errors = "";

            #region UploadImage

            Int32 img_width = 280;
            if (RXServer.Web.RequestValues.Var == "large")
            {
                img_width = 580;
            }
            String strFileName = "";


            if (RadUpload1.InvalidFiles.Count > 0)
            {
                this.ErrorBox.Visible = true;
                Errors += " - " + RXMali.GetXMLNode("Error/media");
                this.imgError1_1.Visible = true;
                valid = false;
            }
            else
            {
                if (this.RadUpload1.UploadedFiles.Count > 0)
                {
                    String activeDir = "";
                    try
                    {
                        activeDir = Server.MapPath(@"../../../Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/");
                    }
                    catch (Exception ex)
                    {
                        this.ErrorBox.Visible = true;
                        Errors += ex;
                    }
                    this.RadUpload1.TargetFolder = activeDir;

                    if (!System.IO.Directory.Exists(activeDir))
                    {
                        System.IO.Directory.CreateDirectory(activeDir);
                    }

                    foreach (UploadedFile f1 in RadUpload1.UploadedFiles)
                    {
                        strFileName = f1.GetName().Trim();
                        f1.SaveAs(activeDir + strFileName);

                        if (f1.GetExtension() == ".jpg" || f1.GetExtension() == ".gif" || f1.GetExtension() == ".jpeg" || f1.GetExtension() == ".png")
                        {
                            // Scale Image

                            System.Drawing.Image scaleImg = System.Drawing.Image.FromFile(activeDir + strFileName);

                            if (scaleImg.Width != img_width)
                            {
                                System.Drawing.Image newImg = null;
                                newImg = RXMali.ScaleFixedWidthImage(scaleImg, img_width);
                                newImg.Save(activeDir + "s_" + f1.GetNameWithoutExtension() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                newImg.Dispose();

                                tm.Media = "s_" + f1.GetNameWithoutExtension() + ".jpg";
                                tm.MediaType = f1.GetExtension();
                            }
                            else
                            {
                                tm.Media = strFileName;
                                tm.MediaType = f1.GetExtension();
                            }
                        }
                        else
                        {
                            tm.Media = strFileName;
                            tm.MediaType = f1.GetExtension();
                        }
                    }
                }
            }

            #endregion

            //if (this.txtTitle.Text == "")
            //{

            //    Errors += " - Please write a title.";
            //    this.imgError1_2.Visible = true;
            //    valid = false;
            //}

            if (valid)
            {
                tm.Save();
                this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
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

    public void HideErrors()
    {
        String function_name = "HideErrors";
        try
        {
            // Upload Image
            this.imgError1_1.Visible = false;
            //this.imgError1_2.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
  
}
