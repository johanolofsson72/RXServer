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

public partial class Modules__System_AdminBars_AdminBar2 : RXServer.Lib.RXBaseAdminBarModule
{
    String class_name = "Modules__System_AdminBars_AdminBar2";

    protected void Page_Load(object sender, EventArgs e)
    {
		this.img_AdminDelete.OnClientClick = "javascript:showAdminDeleteModule(1," + this.PagId + "," + this.ModId + "); return false;";

        if (!this.Hidden)
        {
            this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_true.gif";
            this.imbAdminVisible.ToolTip = "Hide Content";
        }
        else
        {
            this.imbAdminVisible.ImageUrl = "~/App_Themes/WebAdmin/Images/adminbar_vis_false.gif";
            this.imbAdminVisible.ToolTip = "Publish Content";
        }
    }

    protected void img_AdminMoveDown_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveDown_Click";
        try
        {
            LiquidCore.List l = new LiquidCore.List(this.SitId, this.PagId, this.ModId);
            l.ChangeOrderDown();
            l.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }
    protected void img_AdminMoveUp_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminMoveUp_Click";
        try
        {
            LiquidCore.List l = new LiquidCore.List(this.SitId, this.PagId, this.ModId);
            l.ChangeOrderUp();
            l.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void img_AdminVisible_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "img_AdminVisible_Click";
        try
        {
            LiquidCore.List l = new LiquidCore.List(this.SitId, this.PagId, this.ModId);
            if (l.Hidden)
                l.Hidden = false;
            else
                l.Hidden = true;
            l.Save();

            RXServer.Web.Redirect.To("~/Default.aspx?PagId=" + this.PagId);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

}
