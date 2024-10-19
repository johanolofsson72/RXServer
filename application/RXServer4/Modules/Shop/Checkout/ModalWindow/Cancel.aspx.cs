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

public partial class Cancel : RXServer.Lib.RXDefaultPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int orderId;
		if (Request.Form["orderId"] != null && Int32.TryParse(Request.Form["orderId"], out orderId))
		{
			RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item(orderId);
			if (order != null && order.Alias.Equals("Order"))
			{
				order.Value12 = "Creditcard payment canceled";
				order.Save();
				this.ltrScript.Text = "<script>parent.window.location = \"http://" + Request.Url.Authority + Request.ApplicationPath + "/Default.aspx?PagId=19\";</script>";
			}
			else
			{
				this.ltrScript.Text = "<script>parent.window.location = \"http://" + Request.Url.Authority + Request.ApplicationPath + "/Default.aspx?PagId=1\";</script>";
			}
		}
		else
		{
			this.ltrScript.Text = "<script>parent.window.location = \"http://" + Request.Url.Authority + Request.ApplicationPath + "/Default.aspx?PagId=1\";</script>";
		}
    }
}
