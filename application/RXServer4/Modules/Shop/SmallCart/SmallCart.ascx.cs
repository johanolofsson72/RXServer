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

public partial class Modules_Shop_SmallCart_SmallCart : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_Shop_SmallCart_SmallCart";

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (!Page.IsPostBack)
            {
				SmallCart.Attributes["style"] += "background-color: #3F3F3F;";
                BindData();
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        if (!e.Argument.Equals("from_bigcart") && !e.Argument.Equals("from_checkout"))
        {
			SmallCart.Attributes["style"] += "background-color: #219760;";
			ltrJScript.Text = "<script type=\"text/javascript\">$('html,body').animate({scrollTop: 0}, 500); setTimeout(\"changeCartColor('" + SmallCart.ClientID + "');\", 5000);</script>";
            ltrJScript.Visible = true;
        }
        BindData();
    }

    private void BindData()
    {
        String function_name = "BindData";
        try
        {
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
        CartModel cart = CartModel.Current;

        ltrCartIcon.Text = "<img src=\"http://" + Request.Url.Authority + Request.ApplicationPath + "/Images/Modules/Shop/small_cart_icon.png\" alt=\"Ikon föreställande en kundkorg.\" />";

        if (cart.Count() > 0)
        {
            String text = cart.Count().ToString();
            if (cart.Count() == 1)
            {
                text += RXMali.GetXMLNode("Modules/SmallCart/product");
            }
            else
            {
                text += RXMali.GetXMLNode("Modules/SmallCart/products");
            }

            //Calculate price w/ or w/o VAT.
            decimal total = 0;
            bool showVat = Convert.ToBoolean(ConfigurationManager.AppSettings["Shop.ShowPriceWithVat"].ToString());
            String vatSymbol = showVat ? RXMali.GetXMLNode("Modules/SmallCart/withvatsymbol") : RXMali.GetXMLNode("Modules/SmallCart/withoutvatsymbol");
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

            //Handle fractions presentation
            String totalStringWhole = Decimal.Truncate(total).ToString();
            String totalStringFractions = (total - Decimal.Truncate(total)).ToString();
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
 
            String currencySymbol = RXMali.GetXMLNode("Modules/SmallCart/currencysymbol");
            text += totalStringWhole + totalStringFractions + currencySymbol;// +" (" + vatSymbol + ")";

            lblCartText.Text = text;
            open_cart_button.Visible = true;
            to_checkout_button.Visible = true;
        }
        else
        {
            lblCartText.Text = RXMali.GetXMLNode("Modules/SmallCart/emptytext");
            open_cart_button.Visible = false;
            to_checkout_button.Visible = false;
        }
    }

	protected void imbOpenCart_Click(object sender, ImageClickEventArgs e)
	{
		String function_name = "imbOpenCart_Click";
		try
		{
			if (RXServer.Web.RequestValues.PagId != 5 && RXServer.Web.RequestValues.PagId != 6)
			{
				Session["return_url"] = Request.RawUrl;
			}
			RadAjaxPanel_SmallCart.Redirect("~/Default.aspx?pagId=5");
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

	protected void imbOpenCheckout_Click(object sender, ImageClickEventArgs e)
	{
		String function_name = "imbOpenCheckout_Click";
		try
		{
			if (RXServer.Web.RequestValues.PagId != 5 && RXServer.Web.RequestValues.PagId != 6)
			{
				Session["return_url"] = Request.RawUrl;
			}
			RadAjaxPanel_SmallCart.Redirect("~/Default.aspx?pagId=6");
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
}
