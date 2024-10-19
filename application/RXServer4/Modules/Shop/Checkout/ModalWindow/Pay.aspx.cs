using System;
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

public partial class _Pay : RXServer.Lib.RXDefaultPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int orderId;
		if (Request.QueryString["orderId"] != null && Int32.TryParse(Request.QueryString["orderId"], out orderId))
		{
			RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item(orderId);
			if (order != null && order.Alias.Equals("Order"))
			{
				String input = "";
				input += "<input type='hidden' name='orderid' value='" + Request.QueryString["orderId"] + "' />";
				input += "<input type='hidden' name='accepturl' value='http://" + Request.Url.Authority + Request.ApplicationPath + "/Modules/Shop/Checkout/ModalWindow/Return.aspx?orderId=" + orderId + "' />";
				input += "<input type='hidden' name='cancelurl' value='http://" + Request.Url.Authority + Request.ApplicationPath + "/Modules/Shop/Checkout/ModalWindow/Cancel.aspx?orderId=" + orderId + "' />";

				String amount = (GetPrice(orderId) * 100).ToString();
				int test = amount.IndexOf(',');
				if (amount.IndexOf(',') > -1)
				{
					amount = amount.Substring(0, (amount.IndexOf(',')));
				}
				input += "<input type='hidden' name='amount' value='" + amount + "' />";

				this.ltrDynamicInput.Text = input;
			}
			else
			{
				RXServer.Web.Redirect.To("~/Default.aspx");
			}
		}
		else
		{
			RXServer.Web.Redirect.To("~/Default.aspx");
		}
    }

	private decimal GetPrice(int orderId)
	{
		RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item(orderId);
		bool withVat = (order.Value9.Equals("Privatperson"));
		decimal total = 0;
		decimal totalWithoutVat = 0;
		RXServer.Modules.Base.List items = new RXServer.Modules.Base.List("OrderProd_" + orderId);
		foreach (RXServer.Modules.Base.List.Item item in items)
		{
			if (withVat)
			{
				total += Convert.ToDecimal(item.Value6) * (Convert.ToDecimal(item.Value4) * ((decimal)1.0 + Convert.ToDecimal(item.Value5)));
			}
			else
			{
				total += Convert.ToDecimal(item.Value6) * Convert.ToDecimal(item.Value4);
			}
			totalWithoutVat += Convert.ToDecimal(item.Value6) * Convert.ToDecimal(item.Value4);
		}

		decimal shipping;
		if (order.Value11.Equals("Postpaket"))
		{
			if (totalWithoutVat < 501)
			{
				shipping = 99;
			}
			else if (totalWithoutVat < 1001)
			{
				shipping = 149;
			}
			else if (totalWithoutVat < 1501)
			{
				shipping = 199;
			}
			else
			{
				shipping = 0;
			}
		}
		else
		{
			shipping = 0;
		}

		if (withVat)
		{
			shipping *= ((decimal)1.25);
		}

		return total + shipping;
	}
}
