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
using System.Xml;
using System.Xml.Linq;
using System.IO;

public partial class Modules_Modules_DeleteModule_DeleteModule_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Modules_DeleteModule_DeleteModule_Admin";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.SubMenu.Visible = true;
            this.lblHeaderPage1.Text = "Delete Module";
            this.Page_1.Visible = true;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnDeleteModule_Click(object sender, EventArgs e)
    {
        String function_name = "btnDeleteModule_Click";
        try
        {
            LiquidCore.Module m = new LiquidCore.Module(RXServer.Web.RequestValues.ModId);
            m.Delete();

            this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
}
