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
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class Modules_Shop_BigCart_BigCart : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Shop_BigCart_BigCart";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
				this.RadAjaxPanel_BigCart.ClientEvents.OnRequestStart = "centerElementOnScreen('" + this.LoadPanelContent.ClientID + "', '" + this.loader.ClientID + "');";
				this.RadAjaxPanel_BigCart.ClientEvents.OnResponseEnd = "removeOnResize();";
                BindData();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindData()
    {
		String function_name = "BindData";
		try
		{
			lblTitle.Text = RXMali.GetXMLNode("Modules/BigCart/title");
			BindProducts();
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    /*
     * Populates the repeater with the products added to the cart.
     */
    private void BindProducts()
    {
		String function_name = "BindProducts";
		try
		{
			lnkBtnReturn.Text = RXMali.GetXMLNode("Modules/BigCart/return");
			lnkBtnCheckout.Text = RXMali.GetXMLNode("Modules/BigCart/checkout");
			CartModel cart = CartModel.Current;

			if (cart.Count() > 0)
			{
				//Calculate price
				bool showVat = Convert.ToBoolean(ConfigurationManager.AppSettings["Shop.ShowPriceWithVat"].ToString());
				String vatSymbol = showVat ? RXMali.GetXMLNode("Modules/BigCart/withvatsymbol") : RXMali.GetXMLNode("Modules/BigCart/withoutvatsymbol");
				decimal total = 0;
				for (int n = 0; n < cart.Count(); n++)
				{
					if (showVat)
					{
						total += (decimal)cart[n].Quantity * (cart[n].Price * ((decimal)1.0 + cart[n].Vat));
					}
					else
					{
						total += (decimal)cart[n].Quantity * cart[n].Price;
					}
				}

				lblTotalCartPrice.Text = PriceToString(total) + RXMali.GetXMLNode("Modules/BigCart/currencysymbol");
				lblShiping.Text = "0,00" + RXMali.GetXMLNode("Modules/BigCart/currencysymbol");
				lblTotalWithShiping.Text = PriceToString(total) + RXMali.GetXMLNode("Modules/BigCart/currencysymbol");
				lblVatSymbol.Text = "(" + vatSymbol + ")";

				DataSet ds = new DataSet();
				DataTable dt = ds.Tables.Add("Products");
				dt.Columns.Add("PicturePath", Type.GetType("System.String"));
				dt.Columns.Add("ProductName", Type.GetType("System.String"));
				dt.Columns.Add("Description", Type.GetType("System.String"));
				dt.Columns.Add("Quantity", Type.GetType("System.String"));
				dt.Columns.Add("Price", Type.GetType("System.String"));
				dt.Columns.Add("TotalPrice", Type.GetType("System.String"));
				dt.Columns.Add("DeleteText", Type.GetType("System.String"));
				dt.Columns.Add("ProductUrl", Type.GetType("System.String"));

				for (int n = 0; n < cart.Count(); n++)
				{
					DataRow dr = dt.NewRow();
					dr[0] = FetchProductImageUrl(Convert.ToInt32(cart[n].ProductId));

					String choice = cart[n].Choice;
					if (choice.Equals(""))
					{
						dr[1] = cart[n].Name;
					}
					else
					{
						dr[1] = cart[n].Name + " (" + choice + ")";
					}
					dr[2] = FetchProductDesc(Convert.ToInt32(cart[n].ProductId));
					dr[3] = cart[n].Quantity;

					if (showVat)
					{
						decimal price = cart[n].Price * ((decimal)1.0 + cart[n].Vat);
						dr[4] = PriceToString(price);

						price = (cart[n].Price * ((decimal)1.0 + cart[n].Vat)) * cart[n].Quantity;

						dr[5] = PriceToString(price);
					}
					else
					{
						decimal price = cart[n].Price;

						dr[4] = PriceToString(price);

						price = cart[n].Price * cart[n].Quantity;

						dr[5] = PriceToString(price);
					}

					dr[6] = RXMali.GetXMLNode("Modules/BigCart/delete");

					int pagId = GetShopBoxPageId();
					if (pagId != -1)
					{
						dr[7] = "~/Default.aspx?pagId=" + pagId + "&catId=" + cart[n].CategoryId + "&prodId=" + cart[n].ProductId;
					}

					dt.Rows.Add(dr);
				}

				rptrCartItems.DataSource = ds;
				rptrCartItems.DataMember = "Products";
				rptrCartItems.DataBind();
			}
			else
			{
				RXServer.Web.Redirect.To("~/Default.aspx?PagId=1");
			}
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

	private int GetShopBoxPageId()
	{
		String function_name = "GetShopBoxPageId";
		try
		{
			RXServer.Modules.Modules modules = new RXServer.Modules.Modules(1, 103);
			foreach (LiquidCore.Module module in modules)
			{
				if (!module.Hidden)
				{
					return module.PagId;
				}
			}

			return -1;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return -1;
		}
	}

	private string StripHTML(string inputString)
	{
		String function_name = "StripHTML";
		try
		{
			string htmlTagPattern = "<.*?>";
			return Regex.Replace(inputString, htmlTagPattern, string.Empty);
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return null;
		}
	}

    private String PriceToString(decimal price)
    {
		String function_name = "PriceToString";
		try
		{
			String totalStringWhole = Decimal.Truncate(price).ToString();
			String totalStringFractions = (price - Decimal.Truncate(price)).ToString();
			if (totalStringFractions.Equals("0"))
			{
				totalStringFractions = ",00";
			}
			else if (totalStringFractions.Length < 4)
			{
				totalStringFractions = totalStringFractions.Substring(1);
				totalStringFractions += "0";
			}
			else
			{
				totalStringFractions = totalStringFractions.Substring(1, 3);
			}

			return totalStringWhole + totalStringFractions;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return null;
		}
    }

    private String FetchProductImageUrl(int prodId)
    {
		String function_name = "FetchProductImageUrl";
		try
		{
			List<int> images = ItemRegister.GetInstance().GetNodeIdsUnderParent(prodId, "Bild");

			String url = "";

			if (images.Count > 0)
			{
				url = "~" + ItemRegister.GetInstance().GetImageData(images[0], "Galleribild").Path;
			}
			else
			{
				url = "~/" + "Images/Modules/Boxes/sb_picture_missing.png";
			}

			return url;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return null;
		}
    }

    private String FetchProductDesc(int prodId)
    {
		String function_name = "FetchProductDesc";
		try
		{
			String text = StripHTML(ItemRegister.GetInstance().GetHtmlTextFieldData("Beskrivning", prodId));
			return text;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return null;
		}
    }

    protected void rptrCartItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
		String function_name = "rptrCartItems_ItemCommand";
		try
		{
			if (e.CommandName.Equals("Delete"))
			{
				/*System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show("Är du säker?", "Ta bort", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
				if (result == System.Windows.Forms.DialogResult.Yes)
				{*/

				int index = e.Item.ItemIndex;
				CartModel.Current.DeleteAt(index);

				//}

				if (CartModel.Current.Count() == 0)
				{
					ReturnToLastPage();
				}
				else
				{
					RadAjaxPanel_BigCart.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest();", RadAjaxPanel_BigCart.ClientID));
				}
			}
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    private void ReturnToLastPage()
    {
		String function_name = "ReturnToLastPage";
		try
		{
			String url;
			if (Session["return_url"] != null)
			{
				url = Session["return_url"].ToString();
			}
			else
			{
				url = "Default.aspx";
			}

			RadAjaxPanel_BigCart.Redirect(url);
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    protected void lnkBtnReturn_Click(object sender, EventArgs e)
    {
		String function_name = "lnkBtnReturn_Click";
		try
		{
			ReturnToLastPage();
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    protected void lnkBtnCheckout_Click(object sender, EventArgs e)
    {
		String function_name = "lnkBtnCheckout_Click";
		try
		{
			RadAjaxPanel_BigCart.Redirect("Default.aspx?PagId=6");
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    protected void lnkBtnEmptyCart_Click(object sender, EventArgs e)
    {
		String function_name = "lnkBtnEmptyCart_Click";
		try
		{
			CartModel.Current.EmptyCart();
			ReturnToLastPage();
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    protected void lnkBtnUpdateCart_Click(object sender, EventArgs e)
    {
		String function_name = "lnkBtnUpdateCart_Click";
		try
		{
			CartModel cart = CartModel.Current;
			foreach (RepeaterItem item in rptrCartItems.Items)
			{
				TextBox box = (TextBox)item.FindControl("txtQuantity");
				int qty = Convert.ToInt32(box.Text);
				if (qty > 0)
				{
					cart[item.ItemIndex].Quantity = qty;
				}
			}

			RadAjaxPanel_BigCart.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest();", RadAjaxPanel_BigCart.ClientID));
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }

    protected void RadAjaxPanel_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
		String function_name = "RadAjaxPanel_AjaxRequest";
		try
		{
			BindData();
			Control c = RXServer.Lib.Common.FindControlRecursive(Page, "RadAjaxPanel_SmallCart");
			if (c != null)
			{
				Telerik.Web.UI.RadAjaxPanel p = (Telerik.Web.UI.RadAjaxPanel)c;
				RadAjaxPanel_BigCart.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest(\"from_bigcart\");", p.ClientID));
			}
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }
}
