using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.Request.AppRelativeCurrentExecutionFilePath == "~/Hem.aspx")
            this.Menu1.Items[0].Selected = true;
        if (Page.Request.AppRelativeCurrentExecutionFilePath == "~/Om_iZon.aspx")
            this.Menu1.Items[1].Selected = true;
        if (Page.Request.AppRelativeCurrentExecutionFilePath == "~/Medlemmar.aspx")
            this.Menu1.Items[2].Selected = true;
        if (Page.Request.AppRelativeCurrentExecutionFilePath == "~/Länkar.aspx")
            this.Menu1.Items[3].Selected = true;
        if (Page.Request.AppRelativeCurrentExecutionFilePath == "~/Kontakta_oss.aspx")
            this.Menu1.Items[4].Selected = true;
    }
}
