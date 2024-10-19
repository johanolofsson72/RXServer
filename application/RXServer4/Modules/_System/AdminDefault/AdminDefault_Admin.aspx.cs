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

public partial class Modules__System_AdminDefault_AdminDefault_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules__System_AdminDefault_AdminDefault_Admin";

    String ErrorList = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
			if (!RXServer.Auth.IsInRole("Admin"))
			{
				RXServer.Web.Redirect.To("~/Default.aspx");
			}

            this.SubMenu.Visible = true;
            this.ErrorBox.Visible = false;

            BindMenuData();

            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("Default/Text");

            switch (RXServer.Web.RequestValues.SubPage)
            {
                default:
                    this.Page_1.Visible = true;
                    if (!Page.IsPostBack)
                    {
                        BindMetaData();
                    }
                    break;

            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindMetaData()
    {
        String function_name = "BindMetaData";

        try
        {
            RXServer.Modules.Menu.Item m = new RXServer.Modules.Menu.Item(RXServer.Web.RequestValues.PagId);
            this.lblHeaderPage1.Text = "Edit Default Settings »";
            this.txtMetaTitle.Text = Server.HtmlDecode(m.MetaTitle);
            this.txtMetaKeywords.Text = Server.HtmlDecode(m.MetaKeywords);
            this.txtMetaDescription.Text = Server.HtmlDecode(m.MetaDescription);
            this.txtMetaAuthor.Text = Server.HtmlDecode(m.MetaAuthor);
            this.txtMetaCopyright.Text = Server.HtmlDecode(m.MetaCopyright);

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

    public void HideErrors()
    {
        String function_name = "HideErrors";
        try
        {
            // Edit Meta
            this.imgError1_1.Visible = false;
            this.imgError1_2.Visible = false;
            this.imgError1_3.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    public Boolean ValidateMeta()
    {
        String function_name = "ValidateMeta";
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return true;
        }
    }

    public Boolean EditMeta()
    {
        String function_name = "EditMeta";
        try
        {
            RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(RXServer.Web.RequestValues.PagId);
            mItem.MetaTitle = Server.HtmlEncode(this.txtMetaTitle.Text);
            mItem.MetaKeywords = Server.HtmlEncode(this.txtMetaKeywords.Text);
            mItem.MetaDescription = Server.HtmlEncode(this.txtMetaDescription.Text);
            mItem.MetaAuthor = Server.HtmlEncode(this.txtMetaAuthor.Text);
            mItem.MetaCopyright = Server.HtmlEncode(this.txtMetaCopyright.Text);
            mItem.Save();
            
            return true;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
            return false;
        }
    }

    protected void btnSaveData_Click(object sender, EventArgs e)
    {
        String function_name = "btnSaveData_Click";
        try
        {
            if (ValidateMeta())
            {
                if (EditMeta())
                {
                    this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
                }
                else
                {
                    this.ErrorBox.Visible = true;
                    this.ltrErrors.Text = " - Metadata couldn't be saved!";
                }
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
