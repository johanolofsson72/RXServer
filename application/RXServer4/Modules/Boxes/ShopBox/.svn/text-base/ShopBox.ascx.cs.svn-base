using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Drawing.Printing;
using System.Collections.Generic;

public partial class Modules_Boxes_ShopBox_ShopBox : RXServer.Lib.RXBaseModule
{
    String class_name = "Modules_Boxes_ShopBox_ShopBox";
	public int thumbCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
			if (!IsPostBack)
			{
				bindData();
				bindMenu();
				bool prod = bindProductData();
				if (!prod)
				{
					bindCat();
				}
			}
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    private void bindData()
    {
        String function_name = "bindData";
        try
        {
            if (!this.Hidden || RXServer.Auth.IsInRole("Admin"))
            {
				RXServer.Modules.TextModule tm = new RXServer.Modules.TextModule(this.SitId, this.PagId, this.ModId);

                // Sets Module Width

                Int32 ModelId = 0;
                Int32.TryParse(tm.ModelId, out ModelId);
                Int32 _width = 900;
                String _float = "";

                if (tm.Float == "")
                {
                    _float = "left";
                }
                else
                {
                    _float = tm.Float;
                }

                String _style = "";
                String _style2 = "";

                _style = "position: relative; float: " + _float + "; width: " + _width + "px; padding-bottom: 20px;";

                this.ShopBox_holder.Attributes.Add("style", _style);

				this.ShopBox_holder.Visible = true;
            }
            else
            {
                this.ShopBox_holder.Visible = false;
            }
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

	private void bindMenu()
	{
		String function_name = "bindMenu";
		try
		{
			TreeNode root;
			TreeNode selectedNode;
			int nodeId;
			#region BuildMenuTree
			if (Request.QueryString["catId"] != null)
			{
				int catId;
				if (Int32.TryParse(Request.QueryString["catId"], out catId))
				{
					if (ItemRegister.GetInstance().NodeExists(catId) && ItemRegister.GetInstance().GetNodType(catId).Equals("Kategori"))
					{
						nodeId = Convert.ToInt32(Request.QueryString["catId"]);
						selectedNode = new TreeNode(ItemRegister.GetInstance().GetTextFieldData("Titel", nodeId), nodeId.ToString());
					}
					else
					{
						nodeId = ItemRegister.GetInstance().RootId;
						selectedNode = new TreeNode("Root", ItemRegister.GetInstance().RootId.ToString());
					}
				}
				else
				{
					nodeId = ItemRegister.GetInstance().RootId;
					selectedNode = new TreeNode("Root", ItemRegister.GetInstance().RootId.ToString());
				}
			}
			else
			{
				nodeId = ItemRegister.GetInstance().RootId;
				selectedNode = new TreeNode("Root", ItemRegister.GetInstance().RootId.ToString());
			}

			root = buildMenu(nodeId, selectedNode);
			List<int> childNodes = ItemRegister.GetInstance().GetNodeIdsUnderParent(Convert.ToInt32(selectedNode.Value), "Kategori");
			foreach (int i in childNodes)
			{
				TreeNode childNode = new TreeNode(ItemRegister.GetInstance().GetTextFieldData("Titel", i), i.ToString());
				selectedNode.ChildNodes.Add(childNode);
			}
			#endregion

			DataTable dt = new DataTable();
			dt.Columns.Add("item_class");
			dt.Columns.Add("item_url");
			dt.Columns.Add("item_text");
			dt.Columns.Add("divider_class");
			foreach (TreeNode node in root.ChildNodes)
			{
				DataRow dr = BuildRow(dt, node, "level1_", selectedNode.Value);
				dr[3] = "level1_divider";
				dt.Rows.Add(dr);

				foreach (TreeNode childNode in node.ChildNodes)
				{
					dr = BuildRow(dt, childNode, "level2_", selectedNode.Value);
					dt.Rows.Add(dr);
				}
			}
			this.rptMenuItems.DataSource = dt;
			this.rptMenuItems.DataBind();
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

	private bool bindProductData()
	{
		String function_name = "BindProductData";
		try
		{
			if (Request.QueryString["prodId"] != null)
			{
				int prodId;
				if (Int32.TryParse(Request.QueryString["prodId"], out prodId))
				{
					if (ItemRegister.GetInstance().NodeExists(prodId) && ItemRegister.GetInstance().GetNodType(prodId).Equals("Produkt"))
					{
						this.lblTitle.Text = ItemRegister.GetInstance().GetTextFieldData("Titel", prodId);
						this.lblProductText.Text = ItemRegister.GetInstance().GetHtmlTextFieldData("Beskrivning", prodId);

						//Price
						decimal price = ItemRegister.GetInstance().GetDecimalData("Pris", prodId);
						decimal extraPrice = ItemRegister.GetInstance().GetDecimalData("Extrapris", prodId);
						decimal vat = ItemRegister.GetInstance().GetDecimalData("Moms", prodId);

						String qntSymbol;
						try
						{
							qntSymbol = ItemRegister.GetInstance().GetTextFieldData("Pris sufix", prodId);
							if (qntSymbol.Equals(""))
							{
								qntSymbol = RXMali.GetXMLNode("Modules/ShopBox/quantitysymbol");
							}
						}
						catch (ItemRegisterExceptions.DataNodeMissingException e)
						{
							qntSymbol = RXMali.GetXMLNode("Modules/ShopBox/quantitysymbol");
						}

						if (extraPrice < price && extraPrice != 0)
						{
							this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(195, 69, 70);
							this.lblPrice.Text = CreatePriceString(extraPrice, vat) + RXMali.GetXMLNode("Modules/ShopBox/currencysymbol") + " / " + qntSymbol;
							this.extra_price.Visible = true;
							this.lblOldPrice.Text = CreatePriceString(price, vat) + RXMali.GetXMLNode("Modules/ShopBox/currencysymbol") + " / " + qntSymbol;
							this.old_price.Visible = true;
						}
						else
						{
							this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(20, 70, 80);
							this.lblPrice.Text = CreatePriceString(price, vat) + RXMali.GetXMLNode("Modules/ShopBox/currencysymbol") + " / " + qntSymbol;
						}

						#region Choises
						List<int> choises = ItemRegister.GetInstance().GetNodeIdsUnderParent(prodId, "Variant");
						if (choises.Count > 1)
						{
							this.quantity.Attributes["class"] = "quantity_choises";
							this.lblSelectionsTitle.Text = ItemRegister.GetInstance().GetTextFieldData("Varianttitel", prodId);

							foreach (int choice in choises)
							{
								ListItem choiceItem = new ListItem();
								choiceItem.Text = ItemRegister.GetInstance().GetTextFieldData("Titel", choice);
								choiceItem.Attributes.Add("vertical-align", "middle");
								this.rdBtnLstChoices.Items.Add(choiceItem);
							}
						}
						else
						{
							this.quantity.Attributes["class"] = "quantity_no_choises";
							this.options.Visible = false;
						}
						#endregion

						this.lblStock.Text = ItemRegister.GetInstance().GetBoolData("I lager", prodId) ? "I lager" : "Ej i lager";

						#region Gallery
						String html = "";
						int id = 1;
						List<int> images = ItemRegister.GetInstance().GetNodeIdsUnderParent(prodId, "Bild");
						foreach (int image in images)
						{
							ItemRegister.Node.ImageDefinition imageDef = ItemRegister.GetInstance().GetImageData(image, "Galleribild");
							html += "<div id='thumb_" + this.ModId + "_" + id + "' class='thumb'><img src='" + imageDef.PathThumb.Substring(1) +"' title='" + ItemRegister.GetInstance().GetTextFieldData("Titel", image) + "' /><div id='dimmer_" + this.ModId + "_" + id + "' class='dimmer'></div></div>";
							html += "<div id='big_image_url_" + this.ModId + "_" + id + "' class='big_image_url'>" + imageDef.Path.Substring(1) + "</div>";
							/*if (!item.Value12.Equals(""))
							{
								html += "<div id='x_big_image_url_" + this.ModId + "_" + id + "' class='x_big_image_url'>" + RXServer.Lib.Common.Dynamic.CreateUrlPrefix() + "Upload/Pages/" + this.PagId + "/" + this.ModId + "/" + item.Value12 + "</div>";
							}*/
							//html += "<div id='x_big_image_text_" + this.ModId + "_" + id + "' class='x_big_image_text'>" + item.Value25 + "</div>";

							id++;
						}

						thumbCount = (id - 1);

						if (thumbCount == 0)
						{
							html += "<div id='thumb_" + this.ModId + "_" + id + "' class='thumb'><img src='Images/Modules/Boxes/sb_picture_missing.png' title='Bild saknas' /><div id='dimmer_" + this.ModId + "_" + id + "' class='dimmer'></div></div>";
							html += "<div id='big_image_url_" + this.ModId + "_" + id + "' class='big_image_url'>Images/Modules/Boxes/sb_picture_missing.png</div>";
							thumbCount++;
						}

						if (thumbCount == 1)
						{
							this.thumb_wrapper.Attributes["style"] = "display: none;";
						}

						this.ltrThumbs.Text = html;
						#endregion

						return true;
					}
					else
					{
						this.product.Visible = false;
						return false;
					}
				}
				else
				{
					this.product.Visible = false;
					return false;
				}
			}
			else
			{
				this.product.Visible = false;
				return false;
			}
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return false;
		}
	}

	private void bindCat()
	{
		String function_name = "Page_Load";
		try
		{
			int catId;
			if (Request.QueryString["catId"] != null)
			{
				if (Int32.TryParse(Request.QueryString["catId"], out catId))
				{
					if (!ItemRegister.GetInstance().NodeExists(catId) || !ItemRegister.GetInstance().GetNodType(catId).Equals("Kategori"))
					{
						catId = ItemRegister.GetInstance().RootId;
					}
				}
				else
				{
					catId = ItemRegister.GetInstance().RootId;
				}
			}
			else
			{
				catId = ItemRegister.GetInstance().RootId;
			}

			if (ItemRegister.GetInstance().RootId != catId)
			{
				this.lblCatTitle.Text = ItemRegister.GetInstance().GetTextFieldData("Titel", catId);
				this.lblCatText.Text = ItemRegister.GetInstance().GetHtmlTextFieldData("Beskrivning", catId);

				DataTable dt = new DataTable();
				dt.Columns.Add("prod_img_url");
				dt.Columns.Add("prod_url");
				dt.Columns.Add("prod_title");
				dt.Columns.Add("price");
				dt.Columns.Add("divider_class");
				dt.Columns.Add("prod_id", Type.GetType("System.Int32"));
				dt.Columns.Add("extraprice");
				dt.Columns.Add("price_class");

				List<int> products = ItemRegister.GetInstance().GetNodeIdsUnderParent(catId, "Produkt");
				int counter = 0;
				foreach (int product in products)
				{
					counter = CreateProduct(catId, dt, counter, product);
				}

				if (products.Count == 0 && ItemRegister.GetInstance().GetBoolData("Populera från underkategorier", catId))
				{
					List<int> subCats = ItemRegister.GetInstance().GetNodeIdsUnderParent(catId, "Kategori");
					List<int> subProducts = new List<int>();
					foreach (int subCat in subCats)
					{
						List<int> productsInCat = ItemRegister.GetInstance().GetNodeIdsUnderParent(subCat, "Produkt");
						subProducts.AddRange(productsInCat);
					}

					if (subProducts.Count > 0)
					{
						Random r = new Random();
						counter = 0;
						for (int n = 0; n < 8; n++)
						{
							int randomIndex = r.Next(0, subProducts.Count);
							counter = CreateProduct(ItemRegister.GetInstance().GetParentNodeId(subProducts[randomIndex]), dt, counter, subProducts[randomIndex]);
							subProducts.RemoveAt(randomIndex);
							if (subProducts.Count == 0)
							{
								break;
							}
						}
					}
				}

				this.rptCategoryItems.DataSource = dt;
				this.rptCategoryItems.DataBind();
			}
			else
			{
				RXServer.Modules.StandardModule sm = new RXServer.Modules.StandardModule(this.SitId, this.PagId, this.ModId);
				this.lblCatTitle.Text = Server.HtmlDecode(sm.Text2).Replace("`", "'");
				this.lblCatText.Text = Server.HtmlDecode(sm.Text4).Replace("`", "'");
			}

			this.category.Visible = true;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

	private int CreateProduct(int catId, DataTable dt, int counter, int product)
	{
		String function_name = "CreateProduct";
		try
		{
			DataRow dr = dt.NewRow();

			String url;
			List<int> images = ItemRegister.GetInstance().GetNodeIdsUnderParent(product, "Bild");
			if (images.Count > 0)
			{
				String path = ItemRegister.GetInstance().GetImageData(images[0], "Galleribild").Path;
				if (!path.Equals(""))
				{
					url = "~" + path;
				}
				else
				{
					url = "~/Images/Modules/Boxes/sb_picture_missing.png";
				}
			}
			else
			{
				url = "~/Images/Modules/Boxes/sb_picture_missing.png";
			}

			dr[0] = url;
			dr[1] = "~/Default.aspx?pagId=" + this.PagId + "&catId=" + catId + "&prodId=" + product;
			dr[2] = ItemRegister.GetInstance().GetTextFieldData("Titel", product);

			decimal price = ItemRegister.GetInstance().GetDecimalData("Pris", product);
			decimal extraPrice = ItemRegister.GetInstance().GetDecimalData("Extrapris", product);
			decimal vat = ItemRegister.GetInstance().GetDecimalData("Moms", product);
			String qntSymbol;
			try
			{
				qntSymbol = ItemRegister.GetInstance().GetTextFieldData("Pris sufix", product);
				if (qntSymbol.Equals(""))
				{
					qntSymbol = RXMali.GetXMLNode("Modules/ShopBox/quantitysymbol");
				}
			}
			catch (ItemRegisterExceptions.DataNodeMissingException e)
			{
				qntSymbol = RXMali.GetXMLNode("Modules/ShopBox/quantitysymbol");
			}
			dr[3] = CreatePriceString(price, vat) + RXMali.GetXMLNode("Modules/ShopBox/currencysymbol") + " / " + qntSymbol;
			if (extraPrice < price && extraPrice != 0)
			{
				dr[6] = CreatePriceString(extraPrice, vat) + RXMali.GetXMLNode("Modules/ShopBox/currencysymbol") + " / " + qntSymbol;
				dr[7] = "oldprice";
			}
			else
			{
				dr[6] = "&nbsp;";
				dr[7] = "price";
			}

			if (counter < 3)
			{
				dr[4] = "divider_col";
				counter++;
			}
			else
			{
				dr[4] = "divider_row";
				counter = 0;
			}

			dr[5] = product;

			dt.Rows.Add(dr);
			return counter;
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return -1;
		}
	}

	private String CreatePriceString(decimal price, decimal vat)
	{
		decimal total;
		String vatSymbol;

		//Create VAT symbol
		if (ConfigurationManager.AppSettings["Shop.ShowPriceWithVat"].ToString().Equals("true"))
		{
			total = price * (1 + vat);
			vatSymbol = RXMali.GetXMLNode("Modules/ShopBox/withvatsymbol");
		}
		else
		{
			total = price;
			vatSymbol = RXMali.GetXMLNode("Modules/ShopBox/withoutvatsymbol");
		}

		//Handle fractions
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

		return totalStringWhole + totalStringFractions;
	}

	private DataRow BuildRow(DataTable dt, TreeNode node, String levelString, String selectedId)
	{
		String itemClass = levelString;
		if (node.ChildNodes.Count > 0 || selectedId == node.Value)
		{
			itemClass += "on";
		}
		else
		{
			itemClass += "off";
		}

		String itemUrl = "~/Default.aspx?pagId=" + this.PagId + "&catId=" + node.Value;
		String itemText = node.Text;

		DataRow dr = dt.NewRow();
		dr[0] = itemClass;
		dr[1] = itemUrl;
		dr[2] = itemText;

		return dr;
	}

	private TreeNode buildMenu(int nodeId, TreeNode node)
	{
		String function_name = "buildMenu";
		try
		{
			if (nodeId == ItemRegister.GetInstance().RootId)
			{
				return node;
			}
			else
			{
				int parentId = ItemRegister.GetInstance().GetParentNodeId(nodeId);
				String title;
				if (parentId == ItemRegister.GetInstance().RootId)
				{
					title = "Root";
				}
				else
				{
					title = ItemRegister.GetInstance().GetTextFieldData("Titel", parentId);
				}

				TreeNode newParentNode = new TreeNode(title, parentId.ToString());
				List<int> nodeIds = ItemRegister.GetInstance().GetNodeIdsUnderParent(parentId, "Kategori");
				TreeNodeCollection childNodes = new TreeNodeCollection();
				foreach (int i in nodeIds)
				{
					TreeNode childNode;
					if (i != nodeId)
					{
						childNode = new TreeNode(ItemRegister.GetInstance().GetTextFieldData("Titel", i), i.ToString());
					}
					else
					{
						childNode = node;
					}
					childNodes.Add(childNode);
				}

				foreach (TreeNode childNode in childNodes)
				{
					newParentNode.ChildNodes.Add(childNode);
				}

				return buildMenu(parentId, newParentNode);
			}
		}
		catch (Exception ex)
		{
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
			return null;
		}
	}
}
