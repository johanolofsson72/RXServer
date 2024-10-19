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

public partial class Modules_Boxes_Forum_DeletePost_DeletePost_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_Forum_DeletePost_DeletePost_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.SubMenu.Visible = true;
            this.lblHeaderPage1.Text = "Delete Post";
            this.Page_1.Visible = true;            
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
        }
    }

    protected void btnDeletePost_Click(object sender, EventArgs e)
    {
        String function_name = "btnDeletePost_Click";
        try
        {
            RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(RXServer.Web.RequestValues.ObdId);
            i.Delete();

            this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
