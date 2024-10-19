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

public partial class Länkar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    private void bindData()
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            this.RadEditor1.HasPermission = true;
            this.RadEditor1.Editable = true;
        }
        else
        {
            this.RadEditor1.HasPermission = false;
            this.RadEditor1.Editable = false;
        }
    }
}
