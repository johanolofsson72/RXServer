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

public partial class Modules_Boxes_TeaserBox_TeaserBox_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_TeaserBox_TeaserBox_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("TeaserBoxes/Text");
            this.Page_1.Visible = true;
            this.SubMenu.Visible = true;

            this.CustomValidator1.ErrorMessage = "- " + RXMali.GetXMLNode("Error/upload_valid");

            HideErrors();
            if (!Page.IsPostBack)
            {
                PopulateModels();
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

            this.txtHeader.Text = Server.HtmlDecode(tm.Text2).Replace("`", "'");
            this.RadEditor1.Content = Server.HtmlDecode(tm.Text4).Replace("`", "'");
            this.RadEditor2.Content = Server.HtmlDecode(tm.Text5).Replace("`", "'");

            InternalLink.LinkId = tm.ReadMoreLinkId;

            this.txtLinkName.Text = Server.HtmlDecode(tm.ReadMoreLink).Replace("`", "'");
            this.txtToolTip.Text = Server.HtmlDecode(tm.MediaToolTip).Replace("`", "'");

            if (tm.MediaVisible == "false")
            {
                this.cbShowImage.Checked = false;
            }
            else
            {
                this.cbShowImage.Checked = true;
            }
            

            #region loadImage
            //if (tm.Media != "")
            //{
            //    if (tm.MediaType == ".gif" || tm.MediaType == ".jpg" || tm.MediaType == ".jpeg" || tm.MediaType == ".png")
            //    {
            //        String imgfile = Server.MapPath("~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/" + tm.Media);

            //        if (File.Exists(imgfile))
            //        {
            //            // Retrieve the image.
            //            Bitmap image1;

            //            image1 = new Bitmap(imgfile, true);

            //            Int32 width, height, newheight, newwidth;

            //            width = 200;
            //            height = 200;

            //            newwidth = width;

            //            if (image1.Width <= newwidth)
            //            {
            //                newwidth = image1.Width;
            //            }

            //            newheight = Convert.ToInt32((image1.Height * newwidth) / image1.Width);

            //            if (newheight > image1.Height)
            //            {
            //                newwidth = Convert.ToInt32((image1.Width * height) / image1.Height);
            //                newheight = height;
            //            }

            //            if (newheight > height)
            //            {
            //                float temp, temph, tempnh;
            //                temph = height;
            //                tempnh = newheight;
            //                temp = temph / tempnh;
            //                newwidth = Convert.ToInt32(newwidth * temp);
            //                newheight = height;
            //            }

            //            this.imgContent.Visible = true;
            //            this.imgContent.ImageUrl = "~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/" + tm.Media;
            //            this.imgContent.Width = newwidth;
            //            this.imgContent.Height = newheight;
            //            this.hplZoomImg.Visible = true;
            //            this.hplZoomImg.NavigateUrl = "~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId + "/" + tm.Media;
            //        }
            //    }
            //    else if (tm.MediaType == ".swf")
            //    {
            //        this.lblImgText.Text = "FlashFile (" + tm.Media + ")";
            //    }
            //    else if (tm.MediaType == ".flv")
            //    {
            //        this.lblImgText.Text = "FlashVideo (" + tm.Media + ")";
            //    }
            //    else
            //    {
            //        this.lblImgText.CssClass = "Text11_red";
            //        this.lblImgText.Text = "Invalid MediaFile! (" + tm.Media + ")";
            //    }
            //}

            #endregion

            BindImage();

            Int32 ModelId = 0;  // Default value
            Int32.TryParse(tm.ModelId, out ModelId);
            
            this.ddlModels.SelectedValue = ModelId.ToString();

            if (tm.Float == "right")
            {
                this.rbFloatRight.Checked = true;
            }
            else
            {
                this.rbFloatLeft.Checked = true;                
            }

            if (Server.HtmlDecode(tm.Text6).Equals("extended"))
            {
                rbtnInternal.Checked = false;
                rbtnExtended.Checked = true;
            }
            else
            {
                rbtnInternal.Checked = true;
                rbtnExtended.Checked = false;
            }

        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindImage()
    {
        String function_name = "BindImage";
        try
        {

            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);

            this.imgContent.Visible = false;
            this.hplZoomImg.Visible = false;
            this.lblImgText.Text = "";

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
                else if (tm.MediaType == ".swf")
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

    protected void btnSaveText_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveText_Click";
        try
        {
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);

            tm.Text2 = Server.HtmlEncode(this.txtHeader.Text).Replace("'", "`"); ;
            //tm.Text4 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor1.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { "Default.aspx?PagId=", "/Upload/" }));
            tm.Text4 = Server.HtmlEncode(this.RadEditor1.Content).Replace("'", "`");
            tm.Text5 = Server.HtmlEncode(this.RadEditor2.Content).Replace("'", "`");
            

            tm.ReadMoreLink = Server.HtmlEncode(this.txtLinkName.Text).Replace("'", "`"); ;
            tm.ReadMoreLinkId = GetReadMoreLink().ToString();
            tm.MediaToolTip = Server.HtmlEncode(this.txtToolTip.Text).Replace("'", "`"); ;
     
            Boolean valid = true;
            String Errors = "";

            if (this.rbFloatRight.Checked)
            {
                tm.Float = "right";
            }
            else
            {
                tm.Float = "left";
            }

            if (this.cbShowImage.Checked)
            {
                tm.MediaVisible = "true";
            }
            else
            {
                tm.MediaVisible = "false";
            }

            if (rbtnExtended.Checked)
            {
                tm.Text6 = Server.HtmlEncode("extended");
            }
            else
            {
                tm.Text6 = Server.HtmlEncode("internal");
            }

            if (this.ddlModels.SelectedItem.Value == "0")
            {
                valid = false;
                Errors += " - Please select a size.";
                this.imgError1_2.Visible = true;
            }
            else
            {
                tm.ModelId = this.ddlModels.SelectedItem.Value;
            }

            #region UploadImage

            // Sets Module Width

            Int32 ModelId = 0;
            Int32.TryParse(tm.ModelId, out ModelId);
            Int32 img_width = RXMali.GetModelSize(ModelId.ToString());
            img_width = 173;

            String strFileName = "";
            String strFileName2 = "";
            String strFileExt = "";

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

                    if (!System.IO.Directory.Exists(activeDir))
                    {
                        System.IO.Directory.CreateDirectory(activeDir);
                    }
                    this.RadUpload1.TargetFolder = "~/Upload/Pages/" + RXServer.Web.RequestValues.PagId + "/" + RXServer.Web.RequestValues.ModId;

                    foreach (UploadedFile f1 in RadUpload1.UploadedFiles)
                    {
                        strFileName = f1.GetNameWithoutExtension().Trim() + "_" + DateTime.Today.Ticks.ToString();
                        strFileExt = f1.GetExtension().ToLower();
                        strFileName2 = strFileName + strFileExt;

                        f1.SaveAs(activeDir + strFileName2);

                        if (strFileExt == ".jpg" || strFileExt == ".gif" || strFileExt == ".jpeg" || strFileExt == ".png")
                        {
                            // Scale Image

                            System.Drawing.Image scaleImg = System.Drawing.Image.FromFile(activeDir + strFileName2);

                            if (scaleImg.Width != img_width)
                            {
                                System.Drawing.Image newImg = null;
                                newImg = RXMali.ScaleFixedWidthImage(scaleImg, img_width);
                                newImg.Save(activeDir + "s_" + strFileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                newImg.Dispose();

                                tm.Media = "s_" + strFileName + ".jpg";
                                tm.MediaType = strFileExt;
                            }
                            else
                            {
                                tm.Media = strFileName2;
                                tm.MediaType = strFileExt;
                            }
                        }
                        else
                        {
                            tm.Media = strFileName2;
                            tm.MediaType = strFileExt;
                        }
                    }
                }
            }

            #endregion           

            tm.Save();

            if (valid)
            {

                this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
            }
            else
            {
                this.ErrorBox.Visible = true;
                this.ltrErrors.Text = Errors;
                BindImage();
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
            this.imgError1_2.Visible = false;             // Model Size Error
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void PopulateModels()
    {
        String function_name = "PopulateModels";
        try
        {
            Int32 modelId = 0;
            Int32.TryParse(RXServer.Web.RequestValues.Var, out modelId);

            this.ddlModels.Items.Add(new ListItem("Select a size", "0"));
            this.ddlModels.Items.Add(new ListItem("Small", "1"));
            if (modelId > 1)
            {
                this.ddlModels.Items.Add(new ListItem("Medium", "2"));
            }
            if (modelId > 2)
            {
                this.ddlModels.Items.Add(new ListItem("Large", "3"));
            }
            if (modelId > 3)
            {
                this.ddlModels.Items.Add(new ListItem("XLarge", "4"));
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private int GetReadMoreLink()
    {
        String function_name = "GetReadMoreLink";
        try
        {
            int returnValue = 0;
            DropDownList ddl1 = (DropDownList)RXServer.Lib.Common.FindControlRecursive(this, "ddlLevel1");
            DropDownList ddl2 = (DropDownList)RXServer.Lib.Common.FindControlRecursive(this, "ddlLevel2");
            DropDownList ddl3 = (DropDownList)RXServer.Lib.Common.FindControlRecursive(this, "ddlLevel3");
            DropDownList ddl4 = (DropDownList)RXServer.Lib.Common.FindControlRecursive(this, "ddlLevel4");
            DropDownList ddl5 = (DropDownList)RXServer.Lib.Common.FindControlRecursive(this, "ddlLevel5");

            if (ddl1 != null)
            {
                if (ddl1.SelectedItem.Value == "0")
                { return 0; }
                else if (ddl1.SelectedItem.Value != null)
                { returnValue = Convert.ToInt32(ddl1.SelectedItem.Value); }
            }
            if (ddl2 != null)
            {
                if (ddl2.SelectedItem.Value != "0")
                { returnValue = Convert.ToInt32(ddl2.SelectedItem.Value); }
            }
            if (ddl3 != null)
            {
                if (ddl3.SelectedItem.Value.ToString() != "0")
                {
                    if (ddl3.SelectedItem.Value != null)
                    { returnValue = Convert.ToInt32(ddl3.SelectedItem.Value); }
                }
            }
            if (ddl4 != null)
            {
                if (ddl4.SelectedItem.Value.ToString() != "0")
                {
                    if (ddl4.SelectedItem.Value != null)
                    { returnValue = Convert.ToInt32(ddl4.SelectedItem.Value); }
                }
            }
            if (ddl5 != null)
            {
                if (ddl5.SelectedItem.Value.ToString() != "0")
                {
                    if (ddl5.SelectedItem.Value != null)
                    { returnValue = Convert.ToInt32(ddl5.SelectedItem.Value); }
                }
            }
            return returnValue;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return 0;
        }
    }
}
