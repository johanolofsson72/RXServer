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

public partial class Modules_Boxes_ShopBox_ShopBox_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_ShopBox_ShopBox_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ltrHelpText.Text = RXMali.GetXMLHelpNode("ShopBoxes/Text");
            this.Page_1.Visible = true;
            this.SubMenu.Visible = true;
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
            RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            this.txtHeader.Text = Server.HtmlDecode(sm.Text2).Replace("`", "'");
            this.RadEditor1.Content = Server.HtmlDecode(sm.Text4).Replace("`", "'");
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
			RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(RXServer.Web.RequestValues.SitId, RXServer.Web.RequestValues.PagId, RXServer.Web.RequestValues.ModId);
            sm.Text2 = Server.HtmlEncode(this.txtHeader.Text).Replace("'", "`");
            sm.Text4 = Server.HtmlEncode(this.RadEditor1.Content).Replace("'", "`");
            String date = DateTime.Today.ToString("yyyy-MM-dd");
            sm.Updated = date;            

            Boolean valid = true;
            String Errors = "";

            if (valid)
            {
                sm.Save();
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
}
