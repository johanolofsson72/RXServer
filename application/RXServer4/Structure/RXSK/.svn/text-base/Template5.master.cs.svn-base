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

public partial class Template5 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 currentPagId = 0;
        if (RXServer.Web.RequestValues.PagId != 0)
        {
            currentPagId = RXServer.Web.RequestValues.PagId;
        }

        if (currentPagId > 0)
        {
            RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(currentPagId);
			if (mItem.Hidden && !RXServer.Auth.IsInRole("Admin"))
            {
                RXServer.Web.Redirect.To("~/Default.aspx?PagId=1");
            }
            
            Int32 usrid = 0;
            Int32.TryParse(RXServer.Web.RequestValues.v1, out usrid);
            
            if(usrid > 0)
            {
                this.ContentPane2A.Visible = false;
                this.ContentPane2.Visible = false;
                this.ContentPane1A.Visible = false;
                this.ContentPane1.Visible = false;
            }
        }
    }
}
