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
using System.Text.RegularExpressions;

public partial class Modules_Boxes_RSSBox_RSSBox_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_RSSBox_RSSBox_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
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
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("RSS/Text");
            RXServer.Modules.StandardModule lb = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            this.txtTitle.Text = Server.HtmlDecode(lb.Text1).Replace("`", "'");
            this.txtRSS.Text = Server.HtmlDecode(lb.Text6).Replace("`", "'");
            //this.txtHeader.Text = Server.HtmlDecode(lb.Header);

            PopulateModels();


            Int32 amt = 3;

            Int32.TryParse(Server.HtmlDecode(lb.Text7), out amt);
            if(amt > 0)
            {
                LoadDDLData(amt);
            }
            else
            {
                LoadDDLData(3);
            }

            Int32 ModelId = 0;  // Default value
            Int32.TryParse(lb.ModelId, out ModelId);

            this.ddlModels.SelectedValue = ModelId.ToString();

            if (lb.Float == "right")
            {
                this.rbFloatRight.Checked = true;
            }
            else
            {
                this.rbFloatLeft.Checked = true;
            }
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
            RXServer.Modules.StandardModule lb = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            lb.Text1 = Server.HtmlDecode(this.txtTitle.Text).Replace("'", "`");
            //lb.Header = Server.HtmlDecode(this.txtTitle.Text);
            lb.Text7 = this.ddlAmount.SelectedValue;

            String feedurl = this.txtRSS.Text;

            Boolean valid = true;
            String Errors = "";
            
            if(this.txtRSS.Text == "")
            {
                valid = false;
                Errors += " - You need to use a Feed";
                this.imgError1_1.Visible = true;
            }

            if (this.txtTitle.Text == "")
            {
                valid = false;
                Errors += " - Please write an title.";
                this.imgError1_2.Visible = true;
            }

            Regex RgxUrl = new Regex("(([a-zA-Z][0-9a-zA-Z+\\-\\.]*:)?/{0,2}[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?(#[0-9a-zA-Z;/?:@&=+$\\.\\-_!~*'()%]+)?");
            if (RgxUrl.IsMatch(feedurl))
            {
                lb.Text6 = feedurl;
            }
            else
            {
                valid = false;
                Errors += " - Invalid Feed Url";
                this.imgError1_1.Visible = true;
            }

            if (this.ddlModels.SelectedItem.Value == "0")
            {
                valid = false;
                Errors += " - Please select a size.";
                this.imgError1_3.Visible = true;
            }
            else
            {
                lb.ModelId = this.ddlModels.SelectedItem.Value;
            }

            if (this.rbFloatRight.Checked)
            {
                lb.Float = "right";
            }
            else
            {
                lb.Float = "left";
            }

            if (valid)
            {
                lb.Save();
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
            this.imgError1_1.Visible = false;
            this.imgError1_2.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    private void LoadDDLData(Int32 amount)
    {
        String function_name = "LoadDDLData";
        try
        {
            this.ddlAmount.Items.Add(new ListItem("3", "3"));
            this.ddlAmount.Items.Add(new ListItem("5", "5"));
            this.ddlAmount.Items.Add(new ListItem("10", "10"));

            this.ddlAmount.SelectedValue = amount.ToString();
        }
        catch (Exception ex)
        {
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
}
