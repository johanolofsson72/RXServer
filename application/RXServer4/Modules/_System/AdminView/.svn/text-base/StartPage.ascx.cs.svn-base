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

public partial class Modules__System_AdminView_StartPage : System.Web.UI.UserControl
{
    String class_name = "Modules__System_AdminView_StartPage";
    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            this.ErrorBox.Visible = false;

            if (RXServer.Web.RequestValues.Page == "Start" || RXServer.Web.RequestValues.Page == "")
            {
                ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
                Literal help = cph.FindControl("ltrHelpText") as Literal;
                help.Text = RXMali.GetXMLHelpNode("ContentManager/Welcome/Text");
                this.StartPage_1.Visible = true;
                this.StartSubMenu.Visible = true;
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
