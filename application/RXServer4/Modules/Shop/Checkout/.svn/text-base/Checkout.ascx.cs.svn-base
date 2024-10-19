using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public partial class Modules_Shop_Checkout_Checkout : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Shop_Checkout_Checkout";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
				this.RadAjaxPanel_Checkout.ClientEvents.OnRequestStart = "centerElementOnScreen('" + this.LoadPanelContent.ClientID + "', '" + this.loader.ClientID + "');";
				this.RadAjaxPanel_Checkout.ClientEvents.OnResponseEnd = "removeOnResize();";
                Terms.Visible = false;
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
        BindData(false);
    }

    private void BindData(bool fromAjax)
    {
        String function_name = "BindData";
        try
        {
            lblTitle.Text = RXMali.GetXMLNode("Modules/Checkout/title");
            BindProducts();
            
            if (!fromAjax)
            {
				BindCustomer();
                BindPayment();
				BindShipping();
            }
            
            BindAddress();
            BindTerms();
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
            CartModel cart = CartModel.Current;

            if (cart.Count() > 0)
            {
                //Calculate price
				bool showVat;
				if (this.rblCustomerType.SelectedItem != null)
				{
					showVat = this.rblCustomerType.SelectedItem.Text.Equals("Privatperson");
				}
				else
				{
					showVat = true;
				}
                String vatSymbol = showVat ? RXMali.GetXMLNode("Modules/BigCart/withvatsymbol") : RXMali.GetXMLNode("Modules/BigCart/withoutvatsymbol");
                decimal total = 0;
				decimal totalWithoutVat = 0;
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
					totalWithoutVat += (decimal)cart[n].Quantity * cart[n].Price;
                }

				decimal shipping;
				if (this.rblShipping.SelectedItem != null && this.rblShipping.SelectedItem.Text.Equals("Postpaket"))
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

				if (showVat)
				{
					shipping *= ((decimal)1.25);
				}

                lblTotalCartPrice.Text = PriceToString(total) + RXMali.GetXMLNode("Modules/BigCart/currencysymbol");
				lblShiping.Text = PriceToString(shipping) + RXMali.GetXMLNode("Modules/BigCart/currencysymbol");
                lblTotalWithShiping.Text = PriceToString(total + shipping) + RXMali.GetXMLNode("Modules/BigCart/currencysymbol");
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

	private String FetchProductImageUrl(int prodId)
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

	private String FetchProductDesc(int prodId)
	{
		String text = StripHTML(ItemRegister.GetInstance().GetHtmlTextFieldData("Beskrivning", prodId));
		return text;
	}

	private void BindShipping()
	{
		String function_name = "BindShipping";
		try
		{
			lblShippingTxt.Text = RXMali.GetXMLNode("Modules/Checkout/shipping");
			lblShippingError.Text = RXMali.GetXMLNode("Modules/Checkout/shippingerror");

			ListItem postal = new ListItem(RXMali.GetXMLNode("Modules/Checkout/postal"));
			ListItem pickUp = new ListItem(RXMali.GetXMLNode("Modules/Checkout/pickup"));
			ListItem delivery = new ListItem(RXMali.GetXMLNode("Modules/Checkout/delivery"));

			postal.Enabled = false;
			pickUp.Enabled = false;
			delivery.Enabled = false;

			rblShipping.Items.Add(postal);
			rblShipping.Items.Add(pickUp);
			rblShipping.Items.Add(delivery);
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

    private void BindPayment()
    {
        String function_name = "BindPayment";
        try
        {
            lblPaymentMethodsTxt.Text = RXMali.GetXMLNode("Modules/Checkout/paymentmethods");
            lblPaymentError.Text = RXMali.GetXMLNode("Modules/Checkout/paymenterror");

			ListItem creditCard = new ListItem(RXMali.GetXMLNode("Modules/Checkout/creditcard"));
			ListItem invoice = new ListItem(RXMali.GetXMLNode("Modules/Checkout/invoice"));
			ListItem cashOnDelivery = new ListItem(RXMali.GetXMLNode("Modules/Checkout/cashondelivery"));

			creditCard.Enabled = false;
			invoice.Enabled = false;
			cashOnDelivery.Enabled = false;

            rblPaymentMethods.Items.Add(creditCard);
			rblPaymentMethods.Items.Add(invoice);
			rblPaymentMethods.Items.Add(cashOnDelivery);
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

	private void BindCustomer()
	{
		String function_name = "BindCustomer";
		try
		{
			lblCustomerTypeTxt.Text = RXMali.GetXMLNode("Modules/Checkout/customertype");
			lblCustomerError.Text = RXMali.GetXMLNode("Modules/Checkout/customererror");

			ListItem privatePerson = new ListItem(RXMali.GetXMLNode("Modules/Checkout/private"));
			ListItem company = new ListItem(RXMali.GetXMLNode("Modules/Checkout/company"));

			rblCustomerType.Items.Add(privatePerson);
			rblCustomerType.Items.Add(company);
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

    private void BindAddress()
    {
        String function_name = "BindAddress";
        try
        {
            lblAddressTxt.Text = RXMali.GetXMLNode("Modules/Checkout/address");
			lblCompanyNameTxt.Text = RXMali.GetXMLNode("Modules/Checkout/companyname");
			lblCompanyOrgNrTxt.Text = RXMali.GetXMLNode("Modules/Checkout/orgnr");
            lblFirstNameTxt.Text = RXMali.GetXMLNode("Modules/Checkout/firstname");
            lblLastNameTxt.Text = RXMali.GetXMLNode("Modules/Checkout/lastname");
            lblStreetAddressTxt.Text = RXMali.GetXMLNode("Modules/Checkout/streetaddress");
            lblZipCodeTxt.Text = RXMali.GetXMLNode("Modules/Checkout/zipcode");
            lblCityTxt.Text = RXMali.GetXMLNode("Modules/Checkout/city");
            lblCountryTxt.Text = RXMali.GetXMLNode("Modules/Checkout/country");
            lblPhoneNumberTxt.Text = RXMali.GetXMLNode("Modules/Checkout/phonenumber");
            lblEmailTxt.Text = RXMali.GetXMLNode("Modules/Checkout/email");
			lblStreetAddressDeliveryTxt.Text = RXMali.GetXMLNode("Modules/Checkout/streetaddress");
			lblPostalCodeDeliveryTxt.Text = RXMali.GetXMLNode("Modules/Checkout/zipcode");
			lblCityDeliveryTxt.Text = RXMali.GetXMLNode("Modules/Checkout/city");
			lblCountryDeliveryTxt.Text = RXMali.GetXMLNode("Modules/Checkout/country");
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void BindTerms()
    {
        String function_name = "BindTerms";
        try
        {
			RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(1);
			ltrTerms.Text = Server.HtmlDecode(mItem.Terms).Replace("`", "'");
			lblTermsError.Text = RXMali.GetXMLNode("Modules/Checkout/termserror");
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void btnEmptyCart_Click(object sender, EventArgs e)
    {
        String function_name = "btnEmptyCart_Click";
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
                    RadAjaxPanel_Checkout.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest();", RadAjaxPanel_Checkout.ClientID));
                }
            }
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

            RadAjaxPanel_Checkout.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest();", RadAjaxPanel_Checkout.ClientID));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    protected void lnkBtnEmptyCart_Click(object sender, EventArgs e)
    {
        CartModel.Current.EmptyCart();
        ReturnToLastPage();
    }

    private void ReturnToLastPage()
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

		RadAjaxPanel_Checkout.Redirect(url);
    }

    protected void lnkBtnReturn_Click(object sender, EventArgs e)
    {
        ReturnToLastPage();
    }

    protected void imgBtnBuy_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "btnConfirm_Click";
        try
        {
			bool isCustomerSelected = (this.rblCustomerType.SelectedItem != null);
            bool isPaymentSelected = (this.rblPaymentMethods.SelectedItem != null);
			bool isShippingSelected = (this.rblShipping.SelectedItem != null);
			bool hasFirstName = !this.txtFirstName.Text.Equals("");
			bool hasLastName = !this.txtLastName.Text.Equals("");
			bool hasStreetAddress = !this.txtStreetAddress.Text.Equals("");
			bool hasZipCode = !this.txtZipCode.Text.Equals("");
			bool hasCity = !this.txtCity.Text.Equals("");
			bool hasCountry = !this.txtCountry.Text.Equals("");
			bool hasPhoneNumber = !this.txtPhoneNumber.Text.Equals("");
			bool hasEmail = !this.txtEmail.Text.Equals("") && RXMali.IsEmail(this.txtEmail.Text);
			bool hasAcceptedTerms = this.chbxAgreeToTerms.Checked;
			bool hasCompanyName = !this.txtCompanyName.Text.Equals("");
			bool hasCompanyOrgNr = !this.txtCompanyOrgNr.Text.Equals("");
			bool hasDeliveryAddress = !this.txtStreetAddressDelivery.Text.Equals("");
			bool hasDeliveryPostalCode = !this.txtPostalCodeDelivery.Text.Equals("");
			bool hasDeliveryCity = !this.txtCityDelivery.Text.Equals("");
			bool hasDeliveryCountry = !this.txtCountryDelivery.Text.Equals("");

			bool valid = true;
            //Handle input error display
			if (!isCustomerSelected)
			{
				this.lblCustomerError.Visible = true;
				valid = false;
			}
			else
			{
				this.lblCustomerError.Visible = false;
			}

            if (!isPaymentSelected)
            {
                this.lblPaymentError.Visible = true;
				valid = false;
            }
            else
            {
                this.lblPaymentError.Visible = false;
            }

			if (!isShippingSelected)
			{
				this.lblShippingError.Visible = true;
				valid = false;
			}
			else
			{
				this.lblShippingError.Visible = false;
			}

            if (!hasFirstName)
            {
                lblFirstNameTxt.ForeColor = System.Drawing.Color.Red;
                lblFirstNameTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblFirstNameTxt.ForeColor = System.Drawing.Color.Black;
                lblFirstNameTxt.Font.Bold = false;
            }

            if (!hasLastName)
            {
                lblLastNameTxt.ForeColor = System.Drawing.Color.Red;
                lblLastNameTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblLastNameTxt.ForeColor = System.Drawing.Color.Black;
                lblLastNameTxt.Font.Bold = false;
            }

            if (!hasStreetAddress)
            {
                lblStreetAddressTxt.ForeColor = System.Drawing.Color.Red;
                lblStreetAddressTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblStreetAddressTxt.ForeColor = System.Drawing.Color.Black;
                lblStreetAddressTxt.Font.Bold = false;
            }

            if (!hasZipCode)
            {
                lblZipCodeTxt.ForeColor = System.Drawing.Color.Red;
                lblZipCodeTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblZipCodeTxt.ForeColor = System.Drawing.Color.Black;
                lblZipCodeTxt.Font.Bold = false;
            }

            if (!hasCity)
            {
                lblCityTxt.ForeColor = System.Drawing.Color.Red;
                lblCityTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblCityTxt.ForeColor = System.Drawing.Color.Black;
                lblCityTxt.Font.Bold = false;
            }

            if (!hasCountry)
            {
                lblCountryTxt.ForeColor = System.Drawing.Color.Red;
                lblCountryTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblCountryTxt.ForeColor = System.Drawing.Color.Black;
                lblCountryTxt.Font.Bold = false;
            }

            if (!hasPhoneNumber)
            {
                lblPhoneNumberTxt.ForeColor = System.Drawing.Color.Red;
                lblPhoneNumberTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblPhoneNumberTxt.ForeColor = System.Drawing.Color.Black;
                lblPhoneNumberTxt.Font.Bold = false;
            }

            if (!hasEmail)
            {
                lblEmailTxt.ForeColor = System.Drawing.Color.Red;
                lblEmailTxt.Font.Bold = true;
				valid = false;
            }
            else
            {
                lblEmailTxt.ForeColor = System.Drawing.Color.Black;
                lblEmailTxt.Font.Bold = false;
            }

			if (isCustomerSelected && this.rblCustomerType.SelectedItem.Text.Equals("Företag") && !hasCompanyName)
			{
				lblCompanyNameTxt.ForeColor = System.Drawing.Color.Red;
				lblCompanyNameTxt.Font.Bold = true;
				valid = false;
			}
			else
			{
				lblCompanyNameTxt.ForeColor = System.Drawing.Color.Black;
				lblCompanyNameTxt.Font.Bold = false;
			}

			if (isCustomerSelected && this.rblCustomerType.SelectedItem.Text.Equals("Företag") && !hasCompanyOrgNr)
			{
				lblCompanyOrgNrTxt.ForeColor = System.Drawing.Color.Red;
				lblCompanyOrgNrTxt.Font.Bold = true;
				valid = false;
			}
			else
			{
				lblCompanyOrgNrTxt.ForeColor = System.Drawing.Color.Black;
				lblCompanyOrgNrTxt.Font.Bold = false;
			}

			if (isCustomerSelected && this.rblCustomerType.SelectedItem.Text.Equals("Företag") && !this.chbDeliveryToInvoice.Checked && !hasDeliveryAddress)
			{
				lblStreetAddressDeliveryTxt.ForeColor = System.Drawing.Color.Red;
				lblStreetAddressDeliveryTxt.Font.Bold = true;
				valid = false;
			}
			else
			{
				lblStreetAddressDeliveryTxt.ForeColor = System.Drawing.Color.Black;
				lblStreetAddressDeliveryTxt.Font.Bold = false;
			}

			if (isCustomerSelected && this.rblCustomerType.SelectedItem.Text.Equals("Företag") && !this.chbDeliveryToInvoice.Checked && !hasDeliveryPostalCode)
			{
				lblPostalCodeDeliveryTxt.ForeColor = System.Drawing.Color.Red;
				lblPostalCodeDeliveryTxt.Font.Bold = true;
				valid = false;
			}
			else
			{
				lblPostalCodeDeliveryTxt.ForeColor = System.Drawing.Color.Black;
				lblPostalCodeDeliveryTxt.Font.Bold = false;
			}

			if (isCustomerSelected && this.rblCustomerType.SelectedItem.Text.Equals("Företag") && !this.chbDeliveryToInvoice.Checked && !hasDeliveryCity)
			{
				lblCityDeliveryTxt.ForeColor = System.Drawing.Color.Red;
				lblCityDeliveryTxt.Font.Bold = true;
				valid = false;
			}
			else
			{
				lblCityDeliveryTxt.ForeColor = System.Drawing.Color.Black;
				lblCityDeliveryTxt.Font.Bold = false;
			}

			if (isCustomerSelected && this.rblCustomerType.SelectedItem.Text.Equals("Företag") && !this.chbDeliveryToInvoice.Checked && !hasDeliveryCountry)
			{
				lblCountryDeliveryTxt.ForeColor = System.Drawing.Color.Red;
				lblCountryDeliveryTxt.Font.Bold = true;
				valid = false;
			}
			else
			{
				lblCountryDeliveryTxt.ForeColor = System.Drawing.Color.Black;
				lblCountryDeliveryTxt.Font.Bold = false;
			}

            if (!hasAcceptedTerms)
            {
				this.lblTermsError.Visible = true;
				valid = false;
            }
            else
            {
				this.lblTermsError.Visible = false;
            }

            if (valid)
            {
				int orderId = CreateOrder();
				if (this.rblPaymentMethods.SelectedItem.Text.Equals("Kortbetalning"))
				{
					this.RadAjaxPanel_Checkout.ResponseScripts.Add("loadModal('http://" + Request.Url.Authority + Request.ApplicationPath + "/Modules/Shop/Checkout/ModalWindow/Pay.aspx?orderId=" + orderId + "');");
				}
				else
				{
					SendMailToMerchant(orderId);
					SendMailToCustomer(orderId);
					CartModel.Current.EmptyCart();
					this.RadAjaxPanel_Checkout.Redirect("~/Default.aspx?pagId=18");
				}
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
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
		foreach(RXServer.Modules.Base.List.Item item in items)
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

	private int CreateOrder()
	{
		String function_name = "CreateOrder";
		try
		{
			RXServer.Modules.Base.List.Item order = new LiquidCore.List.Item();
			order.Alias = "Order";
			order.Status = 1;
			order.Language = 1;
			order.SitId = 1;
			order.PagId = this.PagId;
			order.ModId = this.ModId;
			order.Value1 = this.txtFirstName.Text;
			order.Value2 = this.txtLastName.Text;
			order.Value3 = this.txtStreetAddress.Text;
			order.Value4 = this.txtZipCode.Text;
			order.Value5 = this.txtCity.Text;
			order.Value6 = this.txtCountry.Text;
			order.Value7 = this.txtPhoneNumber.Text;
			order.Value8 = this.txtEmail.Text;
			order.Value9 = this.rblCustomerType.SelectedItem.Text;
			order.Value10 = this.rblPaymentMethods.SelectedItem.Text;
			order.Value11 = this.rblShipping.SelectedItem.Text;
			order.Value12 = "New order";

			if (this.rblCustomerType.SelectedItem.Text.Equals("Företag"))
			{
				order.Value13 = this.txtCompanyName.Text;
				order.Value14 = this.txtCompanyOrgNr.Text;
				order.Value15 = this.chbDeliveryToInvoice.Checked.ToString();

				if (!this.chbDeliveryToInvoice.Checked)
				{
					order.Value16 = this.txtStreetAddressDelivery.Text;
					order.Value17 = this.txtPostalCodeDelivery.Text;
					order.Value18 = this.txtCityDelivery.Text;
					order.Value19 = this.txtCountryDelivery.Text;
				}
			}

			order.Save();

			CartModel cart = CartModel.Current;
			for (int n = 0; n < cart.Count(); n++)
			{
				RXServer.Modules.Base.List.Item orderItem = new LiquidCore.List.Item();
				orderItem.Alias = "OrderProd_" + order.Id;
				orderItem.Status = 1;
				orderItem.Language = 1;
				orderItem.SitId = 1;
				orderItem.PagId = this.PagId;
				orderItem.ModId = this.ModId;
				orderItem.ParentId = order.Id;
				orderItem.Value1 = cart[n].ProductId;
				orderItem.Value2 = cart[n].ArtId;
				orderItem.Value3 = cart[n].Name;
				orderItem.Value4 = cart[n].Price.ToString();
				orderItem.Value5 = cart[n].Vat.ToString();
				orderItem.Value6 = cart[n].Quantity.ToString();
				orderItem.Value7 = cart[n].Choice;
				orderItem.Save();
			}

			return order.Id;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return -1;
		}
	}

    protected void lnkBtnShowTerms_Click(object sender, EventArgs e)
    {
        Terms.Visible = !Terms.Visible;
    }

	protected void rblCustomerType_SelectedIndexChanged(object sender, EventArgs e)
	{
		this.rblPaymentMethods.SelectedIndex = -1;
		this.rblShipping.SelectedIndex = -1;
		if (this.rblCustomerType.SelectedItem != null)
		{
			if (this.rblCustomerType.SelectedItem.Text.Equals("Privatperson"))
			{
				this.rblPaymentMethods.Items[0].Enabled = true;
				this.rblPaymentMethods.Items[1].Enabled = false;
				this.rblPaymentMethods.Items[2].Enabled = true;

				this.rblShipping.Items[0].Enabled = true;
				this.rblShipping.Items[1].Enabled = true;
				this.rblShipping.Items[2].Enabled = false;

				company_row1.Visible = false;
				company_row2.Visible = false;
				company_row3.Visible = false;
				company_row4.Visible = false;
				company_row5.Visible = false;
			}
			else
			{
				this.rblPaymentMethods.Items[0].Enabled = true;
				this.rblPaymentMethods.Items[1].Enabled = true;
				this.rblPaymentMethods.Items[2].Enabled = false;

				this.rblShipping.Items[0].Enabled = true;
				this.rblShipping.Items[1].Enabled = true;
				this.rblShipping.Items[2].Enabled = true;

				company_row1.Visible = true;
				company_row2.Visible = true;
				company_row3.Visible = true;
				company_row4.Visible = true;
				company_row5.Visible = true;
			}

			BindData(true);
		}
		else
		{
			this.rblPaymentMethods.Items[0].Enabled = false;
			this.rblPaymentMethods.Items[1].Enabled = false;
			this.rblPaymentMethods.Items[2].Enabled = false;

			this.rblShipping.Items[0].Enabled = false;
			this.rblShipping.Items[1].Enabled = false;
			this.rblShipping.Items[2].Enabled = false;
		}
	}

	protected void chbDeliveryToInvoice_CheckChanged(object sender, EventArgs e)
	{
		if (this.chbDeliveryToInvoice.Checked)
		{
			this.txtStreetAddressDelivery.Enabled = false;
			this.txtPostalCodeDelivery.Enabled = false;
			this.txtCityDelivery.Enabled = false;
			this.txtCountryDelivery.Enabled = false;
		}
		else
		{
			this.txtStreetAddressDelivery.Enabled = true;
			this.txtPostalCodeDelivery.Enabled = true;
			this.txtCityDelivery.Enabled = true;
			this.txtCountryDelivery.Enabled = true;
		}
	}

	protected void rblShipping_SelectedIndexChanged(object sender, EventArgs e)
	{
		BindData(true);
	}

    protected void RadAjaxPanel_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        BindData(true);
        Control c = RXServer.Lib.Common.FindControlRecursive(Page, "RadAjaxPanel_SmallCart");
        if (c != null)
        {
            Telerik.Web.UI.RadAjaxPanel p = (Telerik.Web.UI.RadAjaxPanel)c;
            RadAjaxPanel_Checkout.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest(from_checkout);", p.ClientID));
        }
    }
}
