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

public partial class Modules_Boxes_ProductBrowser_AddToCartWrapper : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
		this.RadAjaxPanel1.ClientEvents.OnRequestStart = "centerElementOnScreen('" + this.LoadPanelContent.ClientID + "', '" + this.loaderProd.ClientID + "');";
		this.RadAjaxPanel1.ClientEvents.OnResponseEnd = "removeOnResize();";
    }

    protected void imgBtnAddToCart_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imgbAddToCart_Click";
        try
        {
            int quantity;
            bool valid = Int32.TryParse(((TextBox)RXServer.Lib.Common.FindControlRecursive(Page, "txtQuantity")).Text, out quantity);
            if (valid && quantity > 0)
            {
				int prodId = -1;
				if (Request.QueryString["prodId"] != null)
				{
					if (Int32.TryParse(Request.QueryString["prodId"], out prodId))
					{
						if (!ItemRegister.GetInstance().NodeExists(prodId) || !ItemRegister.GetInstance().GetNodType(prodId).Equals("Produkt"))
						{
							prodId = -1;
						}
					}
					else
					{
						prodId = -1;
					}
				}

				if (prodId != -1)
				{
					int catId = ItemRegister.GetInstance().GetParentNodeId(prodId);
					String artId = ItemRegister.GetInstance().GetTextFieldData("Artikelid", prodId);
					String name = ItemRegister.GetInstance().GetTextFieldData("Titel", prodId);
					decimal price = ItemRegister.GetInstance().GetDecimalData("Pris", prodId);
					decimal vat = ItemRegister.GetInstance().GetDecimalData("Moms", prodId);
					bool stock = ItemRegister.GetInstance().GetBoolData("I lager", prodId);

					String choice = "";
					if (((RadioButtonList)RXServer.Lib.Common.FindControlRecursive(Page, "rdBtnLstChoices")).SelectedItem != null)
					{
						choice = ((RadioButtonList)RXServer.Lib.Common.FindControlRecursive(Page, "rdBtnLstChoices")).SelectedItem.Text;
					}
					else if(((RadioButtonList)RXServer.Lib.Common.FindControlRecursive(Page, "rdBtnLstChoices")).Items.Count > 0)
					{
						choice = ((RadioButtonList)RXServer.Lib.Common.FindControlRecursive(Page, "rdBtnLstChoices")).Items[0].Text;
					}
					CartModel.Current.Add(prodId.ToString(), catId.ToString(), artId, name, price, vat, quantity, stock, choice);

					Control c = RXServer.Lib.Common.FindControlRecursive(Page, "RadAjaxPanel_SmallCart");
					if (c != null)
					{
						Telerik.Web.UI.RadAjaxPanel p = (Telerik.Web.UI.RadAjaxPanel)c;
						RadAjaxPanel1.ResponseScripts.Add("$find('" + p.ClientID + "').ajaxRequest();");
					}
				}
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, ":" + function_name, String.Empty);
        }
    }
}
