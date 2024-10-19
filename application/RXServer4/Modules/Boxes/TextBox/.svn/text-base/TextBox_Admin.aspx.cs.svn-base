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

public partial class Modules_Boxes_TextBox_TextBox_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_TextBox_TextBox_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("TextBoxes/Text");
            this.Page_1.Visible = true;
            this.SubMenu.Visible = true;
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
            this.RadEditor2.Content = Server.HtmlDecode(tm.Text3).Replace("`", "'");
            


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

            if (tm.ExtraFont == "false")
            {
                this.cbExtraBar.Checked = false;
            }
            else
            {
                this.cbExtraBar.Checked = true;
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
            RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);

            tm.Text2 = Server.HtmlEncode(this.txtHeader.Text).Replace("'", "`");
            tm.Text3 = Server.HtmlEncode(this.RadEditor2.Content).Replace("'", "`");
            tm.Text4 = Server.HtmlEncode(this.RadEditor1.Content).Replace("'", "`");
            //tm.Text3 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor2.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { "Default.aspx?PagId=", "/Upload/" }));
            //tm.Text4 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor1.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { "Default.aspx?PagId=", "/Upload/" }));
            String date = DateTime.Today.ToString("yyyy-MM-dd");
            tm.Updated = date;            

            Boolean valid = true;
            String Errors = "";

            if (this.cbExtraBar.Checked)
            {
                tm.ExtraFont = "true";
            }
            else
            {
                tm.ExtraFont = "false";
            }

            if (this.rbFloatRight.Checked)
            {
                tm.Float = "right";
            }
            else
            {
                tm.Float = "left";
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

            // ONLY FOR NEWS ITEMS ------------------------------

                if (tm.Text10 == "NewsItem")
                {
                    Int32 obd_id = 0;

                    Int32.TryParse(tm.Text7, out obd_id);
                    RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(obd_id);

                    i.Value2 = Server.HtmlEncode(this.txtHeader.Text);
                    //i.Value3 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor2.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { "Default.aspx?PagId=", "/Upload/" })); 
                    //i.Value4 = Server.HtmlEncode(RXServer.Web.Parse.Replace.Href(this.RadEditor1.Content, RXServer.Lib.Common.Dynamic.GetFriendlyUrl(3) + "/?url=", new String[2] { "Default.aspx?PagId=", "/Upload/" })); 


                    i.Value3 = Server.HtmlEncode(this.RadEditor2.Content).Replace("'", "`");
                    i.Value4 = Server.HtmlEncode(this.RadEditor1.Content).Replace("'", "`");


                    
                    i.Save();

                    RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(RXServer.Web.RequestValues.PagId);
                    mItem.Title = Server.HtmlDecode(this.txtHeader.Text).Replace("'", "`"); ;
                    mItem.Alias = RXMali.GetFriendlyUrl(this.txtHeader.Text, this.txtHeader.Text, mItem.Level, mItem.Id);
                    mItem.Save();
                }
                //  ---------------------------------------------

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
  
}
