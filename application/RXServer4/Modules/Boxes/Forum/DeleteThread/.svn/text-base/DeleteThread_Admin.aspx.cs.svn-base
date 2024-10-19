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

public partial class Modules_Boxes_Forum_DeleteThread_DeleteThread_Admin : RXServer.Lib.RXDefaultPage
{
    String class_name = "Modules_Boxes_Forum_DeleteThread_DeleteThread_Admin";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.SubMenu.Visible = true;
            this.lblHeaderPage1.Text = "Delete Thread";
            this.Page_1.Visible = true;            
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
        }
    }

    protected void btnDeleteThread_Click(object sender, EventArgs e)
    {
        String function_name = "btnDeleteThread_Click";
        try
        {
            Int32 t = 0;

            Int32.TryParse(Request["threadId"].ToString(), out t);

            RXServer.Modules.Base.List li = new RXServer.Modules.Base.List("Forum_" + RXServer.Web.RequestValues.ModId + "_" + Request["catId"] + "_" + Request["threadId"]);

            if (li.Count > 0)
            {
                foreach (RXServer.Modules.Base.List.Item item in li)
                {
                    item.Delete();
                }
            }

            if (t > 0)
            {
                RXServer.Modules.Base.List.Item i = new LiquidCore.List.Item(t);
                i.Delete();
            }

            this.lblScript.Text = "<script language='javascript'>returnToParent();</script>";
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
}
