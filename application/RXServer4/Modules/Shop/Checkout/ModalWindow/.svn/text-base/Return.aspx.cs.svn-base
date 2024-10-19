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

public partial class Return : RXServer.Lib.RXDefaultPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
		int orderId;
		if (Request.Form["orderId"] != null && Int32.TryParse(Request.Form["orderId"], out orderId))
		{
			RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item(orderId);
			if (order != null && order.Alias.Equals("Order"))
			{
				order.Value12 = "Creditcard payment succeeded";
				order.Save();
				SendMailToMerchant(orderId);
				SendMailToCustomer(orderId);
				CartModel.Current.EmptyCart();
				this.ltrScript.Text = "<script>parent.window.location = \"http://" + Request.Url.Authority + Request.ApplicationPath + "/Default.aspx?PagId=18\";</script>";
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

	private void SendMailToMerchant(int orderId)
	{
		//Mail order to shop.
		String mailFrom = ConfigurationManager.AppSettings["Shop.OrderEmailSender"].ToString();
		String mailFromName = ConfigurationManager.AppSettings["Shop.OrderEmailSenderName"].ToString();
		String mailTo = ConfigurationManager.AppSettings["Shop.OrderEmail"].ToString();
		String mailSubject = RXMali.GetXMLNode("Mail/Shop/ordersubject");
		String mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
		String mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();

		String mailBody = "<html><body>";
		mailBody += RXMali.GetXMLNode("Mail/Shop/ordermailintro");
		mailBody += "<table border=\"1\" cellpadding=\"5\"><tr><td>Produktid</td><td>Artikelid</td><td>Namn</td><td>Antal</td><td>Pris</td><td>Moms</td></tr>";
		RXServer.Modules.Base.List items = new RXServer.Modules.Base.List("OrderProd_" + orderId);
		foreach (RXServer.Modules.Base.List.Item item in items)
		{
			String choise = item.Value7;
			if (!choise.Equals(""))
			{
				choise = " (" + choise + ")";
			}
			mailBody += "<tr><td>" + item.Value1 + "</td><td>" + item.Value2 + "</td><td>" + item.Value3 + choise + "</td><td>" + item.Value6 + "</td><td>" + item.Value4 + "</td><td>" + item.Value5 + "</td></tr>";
		}
		mailBody += "</table><br>";

		RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item(orderId);
		if (order.Value9.Equals("Företag"))
		{
			mailBody += order.Value13 + " " + order.Value14 + "<br>";
		}
		mailBody += order.Value1 + " " + order.Value2 + "<br>";
		mailBody += order.Value3 + ", " + order.Value4 + ", " + order.Value5 + "<br>";
		mailBody += order.Value6 + "<br>";
		mailBody += order.Value7 + ", " + order.Value8 + "<br>";
		mailBody += order.Value9 + ", " + order.Value10 + "<br>";
		mailBody += order.Value11 + "<br>";
		if (order.Value9.Equals("Företag"))
		{
			if (Convert.ToBoolean(order.Value15))
			{
				mailBody += "Leveransadress samma som fakturaadress.<br>";
			}
			else
			{
				mailBody += "Leveransadress:<br>";
				mailBody += order.Value16 + ", " + order.Value17 + "<br>";
				mailBody += order.Value18 + ", " + order.Value19 + "<br>";
			}
		}
		mailBody += "</body></html>";

		RXMali.SendMail(mailBody, mailSubject, mailTo, mailFrom, mailFromName, mailServer, mailPort);
	}

	private void SendMailToCustomer(int orderId)
	{
		//Mail order to shop.
		String mailFrom = ConfigurationManager.AppSettings["Shop.OrderEmailSender"].ToString();
		String mailFromName = ConfigurationManager.AppSettings["Shop.OrderEmailSenderName"].ToString();
		String mailSubject = RXMali.GetXMLNode("Mail/Shop/ordersubject");
		String mailServer = ConfigurationManager.AppSettings["MailServer"].ToString();
		String mailPort = ConfigurationManager.AppSettings["MailPort"].ToString();

		String mailBody = "<html><body>";
		mailBody += RXMali.GetXMLNode("Mail/Shop/confirmemailintro");
		mailBody += "<table border=\"1\" cellpadding=\"5\"><tr><td>Produktid</td><td>Artikelid</td><td>Namn</td><td>Antal</td><td>Pris</td><td>Moms</td></tr>";
		RXServer.Modules.Base.List items = new RXServer.Modules.Base.List("OrderProd_" + orderId);
		foreach (RXServer.Modules.Base.List.Item item in items)
		{
			String choise = item.Value7;
			if (!choise.Equals(""))
			{
				choise = " (" + choise + ")";
			}
			mailBody += "<tr><td>" + item.Value1 + "</td><td>" + item.Value2 + "</td><td>" + item.Value3 + choise + "</td><td>" + item.Value6 + "</td><td>" + item.Value4 + "</td><td>" + item.Value5 + "</td></tr>";
		}
		mailBody += "</table><br>";

		RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item(orderId);
		if (order.Value9.Equals("Företag"))
		{
			mailBody += order.Value13 + " " + order.Value14 + "<br>";
		}
		mailBody += order.Value1 + " " + order.Value2 + "<br>";
		mailBody += order.Value3 + ", " + order.Value4 + ", " + order.Value5 + "<br>";
		mailBody += order.Value6 + "<br>";
		mailBody += order.Value7 + ", " + order.Value8 + "<br>";
		mailBody += order.Value9 + ", " + order.Value10 + "<br>";
		mailBody += order.Value11 + "<br>";
		if (order.Value9.Equals("Företag"))
		{
			if (Convert.ToBoolean(order.Value15))
			{
				mailBody += "Leveransadress samma som fakturaadress.<br>";
			}
			else
			{
				mailBody += "Leveransadress:<br>";
				mailBody += order.Value16 + ", " + order.Value17 + "<br>";
				mailBody += order.Value18 + ", " + order.Value19 + "<br>";
			}
		}
		mailBody += "</body></html>";

		RXMali.SendMail(mailBody, mailSubject, order.Value8, mailFrom, mailFromName, mailServer, mailPort);
	}
}