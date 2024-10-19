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
using Telerik.Web.UI;

public partial class Modules_Boxes_ProductBrowser_AddToCartWrapperCat : System.Web.UI.UserControl
{
	public Int32 ProdId
	{
		set
		{
			this.imgBtnAddToCart.CommandName = value.ToString();
		}
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		this.RadAjaxPanel1.ClientEvents.OnRequestStart = "centerElementOnScreen('" + this.LoadPanelContent.ClientID + "', '" + this.loaderCat.ClientID + "');";
		this.RadAjaxPanel1.ClientEvents.OnResponseEnd = "removeOnResize();";
    }

    protected void imgBtnAddToCart_Click(object sender, ImageClickEventArgs e)
    {
        String function_name = "imgbAddToCart_Click";
        try
        {
			int prodId = -1;
			if (((ImageButton)sender).CommandName != null)
			{
				if (Int32.TryParse(((ImageButton)sender).CommandName, out prodId))
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
				List<int> choises = ItemRegister.GetInstance().GetNodeIdsUnderParent(prodId, "Variant");
				if (choises.Count > 1)
				{
					choice = ItemRegister.GetInstance().GetTextFieldData("Titel", choises[0]);
				}

				CartModel.Current.Add(prodId.ToString(), catId.ToString(), artId, name, price, vat, 1, stock, choice);

				Control c = RXServer.Lib.Common.FindControlRecursive(Page, "RadAjaxPanel_SmallCart");
				if (c != null)
				{
					Telerik.Web.UI.RadAjaxPanel p = (Telerik.Web.UI.RadAjaxPanel)c;
					RadAjaxPanel1.ResponseScripts.Add(String.Format("$find('{0}').ajaxRequest();", p.ClientID));
				}
			}
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, ":" + function_name, String.Empty);
        }
    }
}
