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
using System.IO;
using System.Numeric;
using System.Collections.Generic;
using Telerik.Web.UI;

public partial class Modules__System_AdminView_ShopPage : System.Web.UI.UserControl
{   
	public struct HtmlTextValue
	{
		public String title, value;
	}

    String class_name = "Modules__System_AdminView_ShopPage";
    String ErrorList = "";
    static ArrayList nodechain = new ArrayList();
    static int nodelevel = 0;

	private List<HtmlTextValue> htmlText = new List<HtmlTextValue>();

    protected void Page_Load(object sender, EventArgs e)
    {
        String function_name = "Page_Load";
        try
        {
            if (Page.IsPostBack)
                return;

            ErrorList = "";
            this.ErrorBox.Visible = false;
            HideErrors();
            if (RXServer.Web.RequestValues.Page == "Shop")
            {

                this.ShopPage_1.Visible = false;

                this.ShopSubMenu.Visible = true;
                BindShopSubMenuData();

                switch (RXServer.Web.RequestValues.SubPage)
                {

                    case "Edit":
                        this.ShopPage_2.Visible = true;
                        ContentPlaceHolder cphEdit = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
						Literal helpEdit = cphEdit.FindControl("ltrHelpText") as Literal;
                        helpEdit.Text = RXMali.GetXMLHelpNode("ShopManager/Edit");

                        if (RXServer.Web.RequestValues.ViewId != "")
                        {
                            if (!Page.IsPostBack)
                            {
                                BindShopEditData(RXServer.Web.RequestValues.ViewId);
                            }
                        }
                        
                        break;

					case "Add":
						this.ShopPage_3.Visible = true;
						ContentPlaceHolder cphAdd = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
						Literal helpAdd = cphAdd.FindControl("ltrHelpText") as Literal;
						helpAdd.Text = RXMali.GetXMLHelpNode("ShopManager/Add");
						BindNewNodeData();
                        break;

                    case "Delete":
                        btnDeleteNode_Click(null, null);
                        break;

					case "Terms":
						if (!Page.IsPostBack)
						{
							this.ShopPage_4.Visible = true;
							ContentPlaceHolder cphTerms = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
							Literal helpTerms = cphTerms.FindControl("ltrHelpText") as Literal;
							helpTerms.Text = RXMali.GetXMLHelpNode("ShopManager/Terms");

							BindTerms();
						}
						break;

                    default:
                        this.ShopPage_1.Visible = true;
                        if (RXServer.Web.RequestValues.DelId != "")
                        {
                            //DeletePage(RXServer.Web.RequestValues.DelId);
                        }
                        else
                        {
                            if (!Page.IsPostBack)
                                BindShopData();
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

	public void BindShopData()
    {
        String function_name = "BindShopData";
        try
        {
            ContentPlaceHolder cph = Page.Master.FindControl("MainAdminTextContent") as ContentPlaceHolder;
            Literal help = cph.FindControl("ltrHelpText") as Literal;
            help.Text = RXMali.GetXMLHelpNode("ShopManager/Tree");

            this.lblHeaderPage1.Text = "Product register";

            Telerik.Web.UI.RadTreeNode rn = new Telerik.Web.UI.RadTreeNode(ItemRegister.GetInstance().Name, ItemRegister.GetInstance().RootId.ToString());
			rn.ContextMenuID = "ContextMenuRoot";
			rn.AllowEdit = false;
            //rn.NavigateUrl = "AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + ItemRegister.GetInstance().RootId.ToString();
            RadTreeView1.Nodes.Clear();
            RadTreeView1.Nodes.Add(rn);

            if (nodechain.Count < 1)
            {
                rn.Expanded = true;
                BuildRadTreeBase(rn);
            }
            else
            {
                Telerik.Web.UI.RadTreeNode rnparent = rn;
                foreach (string n in nodechain)
                {
                    Telerik.Web.UI.RadTreeNode rncurrent = RadTreeView1.FindNodeByValue(n);
                    if (rncurrent != null)
                    {
                        rncurrent.Expanded = true;
                        BuildRadTreeBase(rncurrent);
                    }
                    rnparent = rncurrent;
                }
            }

            
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
	public void BindShopEditData(String editId)
	{
		String function_name = "BindPagesEditData";
		try
		{
			List<ItemRegister.Node.DataNodeDefinition> dataNodes = ItemRegister.GetInstance().GetDataNodes(Convert.ToInt32(editId));

			DataTable dtBool = new DataTable();
			dtBool.Columns.Add("bool_title");
			dtBool.Columns.Add("bool_value", Type.GetType("System.Boolean"));

			DataTable dtDecimal = new DataTable();
			dtDecimal.Columns.Add("decimal_title");
			dtDecimal.Columns.Add("decimal_value", Type.GetType("System.Decimal"));

			DataTable dtText = new DataTable();
			dtText.Columns.Add("field_title");
			dtText.Columns.Add("field_value");
			dtText.Columns.Add("validate", Type.GetType("System.Boolean"));

			DataTable dtHtmlText = new DataTable();
			dtHtmlText.Columns.Add("htmlfield_title");
			dtHtmlText.Columns.Add("validate", Type.GetType("System.Boolean"));
			this.htmlText.Clear();

			DataTable dtImage = new DataTable();
			dtImage.Columns.Add("image_url");
			dtImage.Columns.Add("image_extensions");
			dtImage.Columns.Add("image_size");
			dtImage.Columns.Add("image_name");

			foreach (ItemRegister.Node.DataNodeDefinition def in dataNodes)
			{
				if (def.Type == ItemRegister.Node.DataNodeType.Bool)
				{
					DataRow dr = dtBool.NewRow();
					dr[0] = def.Name;
					dr[1] = ItemRegister.GetInstance().GetBoolData(def.Name, Convert.ToInt32(editId));
					dtBool.Rows.Add(dr);
				}
				else if (def.Type == ItemRegister.Node.DataNodeType.Decimal)
				{
					DataRow dr = dtDecimal.NewRow();
					dr[0] = def.Name;
					dr[1] = ItemRegister.GetInstance().GetDecimalData(def.Name, Convert.ToInt32(editId));
					dtDecimal.Rows.Add(dr);
				}
				else if (def.Type == ItemRegister.Node.DataNodeType.Textfield)
				{
					DataRow dr = dtText.NewRow();
					dr[0] = def.Name;
					dr[1] = ItemRegister.GetInstance().GetTextFieldData(def.Name, Convert.ToInt32(editId));
					dr[2] = !def.AllowEmpty;
					dtText.Rows.Add(dr);
				}
				else if (def.Type == ItemRegister.Node.DataNodeType.Htmltextfield)
				{
					DataRow dr = dtHtmlText.NewRow();
					dr[0] = def.Name;
					dr[1] = !def.AllowEmpty;

					HtmlTextValue value = new HtmlTextValue();
					value.title = def.Name;
					value.value = ItemRegister.GetInstance().GetHtmlTextFieldData(def.Name, Convert.ToInt32(editId));
					this.htmlText.Add(value);

					dtHtmlText.Rows.Add(dr);
				}
				else if (def.Type == ItemRegister.Node.DataNodeType.Image)
				{
					ItemRegister.Node.ImageDefinition img = ItemRegister.GetInstance().GetImageData(def.Id);
					DataRow dr = dtImage.NewRow();
					dr[0] = "~" + img.Path;

					List<String> extensionList = img.Extensions;
					String extensions = "";
					bool first = true;
					foreach (String ext in extensionList)
					{
						if (!first)
						{
							extensions += "|";
						}
						else
						{
							first = false;
						}

						extensions += ext;
					}
					dr[1] = extensions;

					dr[2] = img.Size.ToString();

					dr[3] = def.Name;

					dtImage.Rows.Add(dr);
				}
			}

			this.rptBool.DataSource = dtBool;
			this.rptBool.DataBind();

			this.rptDecimal.DataSource = dtDecimal;
			this.rptDecimal.DataBind();

			this.rptTextFields.DataSource = dtText;
			this.rptTextFields.DataBind();

			this.rptHtmlTextFields.DataSource = dtHtmlText;
			this.rptHtmlTextFields.DataBind();

			this.rptImageFields.DataSource = dtImage;
			this.rptImageFields.DataBind();

			this.lblHeaderPage2.Text = "Edit " + ItemRegister.GetInstance().GetTextFieldData("Titel", Convert.ToInt32(editId));
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	private void BindNewNodeData()
	{
		String function_name = "BindNewNodeData";
		try
		{
			this.lblHeaderPage3.Text = "New node";
			List<String> retrictions = ItemRegister.GetInstance().FetchPossibleNodeTypeForParent(Convert.ToInt32(RXServer.Web.RequestValues.ViewId));
			foreach (String restriction in retrictions)
			{
				this.ddlNodeTypes.Items.Add(new ListItem(restriction));
			}
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	private void BindTerms()
	{
		String function_name = "BindTerms";
		try
		{
			this.lblHeaderPage4.Text = "Terms";
			RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(1);
			this.RadEditor_Terms.Content = Server.HtmlDecode(mItem.Terms).Replace("`", "'");
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

	private void BuildTree(TreeNode rootNode)
	{
		String function_name = "BuildTree";
		try
		{
			List<int> childNodeIds = ItemRegister.GetInstance().GetNodeIdsUnderParent(Convert.ToInt32(rootNode.Value));
			foreach (int childId in childNodeIds)
			{
				String title = ItemRegister.GetInstance().GetTextFieldData("Titel", childId);
				if (title.Equals(""))
				{
					title = "[Titel ej satt]";
				}
				if (title == null)
				{
					title = "TITEL FIELD MISSING! - Contact site admin.";
				}
				title +=  " (" + ItemRegister.GetInstance().GetNodType(childId) + ")";

				TreeNode childNode = new TreeNode(title, childId.ToString());
				childNode.NavigateUrl = "AdminView_Admin.aspx?Page=Shop&SubPage=Edit&ViewId=" + childNode.Value;
				BuildTree(childNode);
				rootNode.ChildNodes.Add(childNode);
			}
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
    }
    private void BuildTreeBase(TreeNode rootNode)
    {
        String function_name = "BuildTreeBase";
        try
        {
            List<int> childNodeIds = ItemRegister.GetInstance().GetNodeIdsUnderParent(Convert.ToInt32(rootNode.Value));
            foreach (int childId in childNodeIds)
            {
                String title = ItemRegister.GetInstance().GetTextFieldData("Titel", childId);
                if (title.Equals(""))
                {
                    title = "[Titel ej satt]";
                }
                if (title == null)
                {
                    title = "TITEL FIELD MISSING! - Contact site admin.";
                }
                title += " (" + ItemRegister.GetInstance().GetNodType(childId) + ")";

                TreeNode childNode = new TreeNode(title, childId.ToString());
                childNode.NavigateUrl = "AdminView_Admin.aspx?Page=Shop&SubPage=Edit&ViewId=" + childNode.Value;

                rootNode.ChildNodes.Add(childNode);

                if (ItemRegister.GetInstance().HasChildren(Convert.ToInt32(childNode.Value)))
                {
                    TreeNode dummychildNode = new TreeNode("__dummy", "0");
                    childNode.ChildNodes.Add(dummychildNode);
                }
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
    private void BuildRadTreeBase(Telerik.Web.UI.RadTreeNode rootNode)
    {
        String function_name = "BuildRadTreeBase";
        try
        {
            List<int> childNodeIds = ItemRegister.GetInstance().GetNodeIdsUnderParent(Convert.ToInt32(rootNode.Value));
            foreach (int childId in childNodeIds)
            {
                String title = ItemRegister.GetInstance().GetTextFieldData("Titel", childId);
                if (title.Equals(""))
                {
                    title = "[Titel ej satt]";
                }
                string typ = ItemRegister.GetInstance().GetNodType(childId);
                title += " (" + typ + ")";

                Telerik.Web.UI.RadTreeNode childNode = new Telerik.Web.UI.RadTreeNode(title, childId.ToString());
                //childNode.NavigateUrl = "AdminView_Admin.aspx?Page=Shop&SubPage=Edit&ViewId=" + childNode.Value;
				if (typ.Equals("Kategori"))
				{
					childNode.CssClass = "Category";
				}
				else if (typ.Equals("Produkt"))
				{
					childNode.CssClass = "Product";
				}
				else if (typ.Equals("Variant"))
				{
					childNode.CssClass = "Variant";
				}
				else if (typ.Equals("Bild"))
				{
					childNode.CssClass = "Image";
				}
				
				childNode.ContextMenuID = "ContextMenu";
				
                rootNode.Nodes.Add(childNode);

                if (ItemRegister.GetInstance().HasChildren(Convert.ToInt32(childNode.Value)))
                {
                    //Telerik.Web.UI.RadTreeNode dummychildNode = new Telerik.Web.UI.RadTreeNode("__dummy", "0");
                    //childNode.Nodes.Add(dummychildNode);
                    childNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                }
                //info.Text = Convert.ToString(Session["CurrentLevel"]);
            }
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }

    public void BindShopSubMenuData()
    {
        String function_name = "BindPagesSubMenuData";
        try
        {
            String list = "";

            list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
            list += "<tr>";
            list += "<tr><td style='width:10px; height: 34px;'></td>";
            if (RXServer.Web.RequestValues.SubPage == "")
            {
				list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Shop' class='submenu_on'>Product register</a></td>";
            }
            else
            {
				list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Shop' class='submenu_off'>Product register</a></td>";
            }
            list += "<td style='width:10px;'>&nbsp;</td>";
            if (RXServer.Web.RequestValues.SubPage.Equals("Terms"))
            {
                list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Shop&SubPage=Terms' class='submenu_on'>Terms</a></td>";
            }
            else
            {
				list += "<td valign='middle'><a href='AdminView_Admin.aspx?Page=Shop&SubPage=Terms' class='submenu_off'>Terms</a></td>";
            }

            list += "</tr>";
            list += "</table>";

            this.ltrShopSubMenuList.Text = list;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }
    }
	public void BindShopSubMenuData2()
	{
		String function_name = "BindShopSubMenuData2";
		try
		{
			if (RXServer.Web.RequestValues.SubPage.Equals("Edit") && ItemRegister.GetInstance().FetchPossibleNodeTypeForParent(Convert.ToInt32(RXServer.Web.RequestValues.ViewId)).Count > 0)
			{
				String list = "";

				list += "<table cellspacing='0' cellpadding='0' style='border:0px;'>";
				list += "<tr>";
				list += "<td style='width:10px;'><td><img src='../../../App_Themes/WebAdmin/Images/submenu_divider.gif' class='img_noborder' /></td><td style='width:10px;'>";
				if (RXServer.Web.RequestValues.SubPage == "Add")
				{
					list += "<td><a href='AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + RXServer.Web.RequestValues.ViewId + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + RXServer.Web.RequestValues.ViewId + "' class='submenu_on'>Add Node</a></td>";
				}
				else
				{
					list += "<td><a href='AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + RXServer.Web.RequestValues.ViewId + "'><img src='../../../App_Themes/WebAdmin/Images/icon_add.gif' class='img_noborder' /></a></td><td style='width:6px;'></td><td><a href='AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + RXServer.Web.RequestValues.ViewId + "' class='submenu_off'>Add Node</a></td>";
				}
				list += "<td style='width:20px; height:34px;'></td>";
				list += "</tr>";
				list += "</table>";

				this.ltrShopSubMenuList2.Text = list;
			}
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}

	}

	protected void btnAddNode_Click(object sender, EventArgs e)
	{
		String function_name = "btnAddNode_Click";
		try
        {
			if (this.txtNodeTitle.Text.Equals(""))
			{
				this.ErrorBox.Visible = true;
				this.ltrErrors.Text = "Title required.";
			}
			else
			{
				int id = ItemRegister.GetInstance().NewNode(this.ddlNodeTypes.SelectedValue, Convert.ToInt32(RXServer.Web.RequestValues.ViewId), this.txtNodeTitle.Text.Replace("'", "´"));

				String Url = "";
				Url = RXMali.GetLastUrl(Request.Url.ToString());
				Url = Url.Replace("&SubPage=Add&ViewId=" + RXServer.Web.RequestValues.ViewId, "&SubPage=Edit&ViewId=" + id);

				RXServer.Web.Redirect.To(Url);
			}
		}
		catch (ItemRegisterExceptions.StackRoomReachedException ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = "Stack room reached. No more nodes if this type allowed in this level of the tree.";
		}
		catch (ItemRegisterExceptions.ChildCountReachedException ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = "Child count reached. The parent node doesn't allow more child nodes.";
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	protected void btnDeleteNode_Click(object sender, EventArgs e)
	{
		String function_name = "btnDeleteNode_Click";
		try
        {
			ItemRegister.GetInstance().DeleteNode(Convert.ToInt32(RXServer.Web.RequestValues.ViewId));

			String Url = "";
			Url = RXMali.GetLastUrl(Request.Url.ToString());
            Url = Url.Replace("&SubPage=Delete&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

			RXServer.Web.Redirect.To(Url);
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	protected void btnMoveNodeUp_Click(object sender, EventArgs e)
	{
		String function_name = "btnMoveNodeUp_Click";
		try
		{
			ItemRegister.GetInstance().MoveNodeUp(Convert.ToInt32(RXServer.Web.RequestValues.ViewId));

			String Url = "";
			Url = RXMali.GetLastUrl(Request.Url.ToString());
			Url = Url.Replace("&SubPage=Edit&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

			RXServer.Web.Redirect.To(Url);
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	protected void btnMoveNodeDown_Click(object sender, EventArgs e)
	{
		String function_name = "btnMoveNodeDown_Click";
		try
		{
			ItemRegister.GetInstance().MoveNodeDown(Convert.ToInt32(RXServer.Web.RequestValues.ViewId));

			String Url = "";
			Url = RXMali.GetLastUrl(Request.Url.ToString());
			Url = Url.Replace("&SubPage=Edit&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

			RXServer.Web.Redirect.To(Url);
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	protected void btnSaveNode_Click(object sender, EventArgs e)
	{
		String function_name = "btnSaveNode_Click";
		try
		{
			foreach (RepeaterItem item in this.rptBool.Items)
			{
				Label checkBoxTitle = (Label)item.FindControl("lblBoolTitle");
				CheckBox checkBox = (CheckBox)item.FindControl("chbBool");
				ItemRegister.GetInstance().SetBoolData(Convert.ToInt32(RXServer.Web.RequestValues.ViewId), checkBoxTitle.Text, checkBox.Checked);
			}

			foreach (RepeaterItem item in this.rptDecimal.Items)
			{
				Label decimalFieldTitle = (Label)item.FindControl("lblDecimalTitle");
				TextBox decimalField = (TextBox)item.FindControl("txtDecimalField");

				if (!decimalField.Text.Equals(""))
				{
					ItemRegister.GetInstance().SetDecimalData(Convert.ToInt32(RXServer.Web.RequestValues.ViewId), decimalFieldTitle.Text, Convert.ToDecimal(decimalField.Text));
				}
			}

			foreach (RepeaterItem item in this.rptTextFields.Items)
			{
				Label textFieldTitle = (Label)item.FindControl("lblTextFieldTitle");
				TextBox textField = (TextBox)item.FindControl("txtTextField");
				ItemRegister.GetInstance().SetTextFieldData(Convert.ToInt32(RXServer.Web.RequestValues.ViewId), textFieldTitle.Text, textField.Text);
			}

			foreach (RepeaterItem item in this.rptHtmlTextFields.Items)
			{
				Label htmlTextFieldTitle = (Label)item.FindControl("lblHtmlTextFieldTitle");
				Telerik.Web.UI.RadEditor htmlRadEditor = (Telerik.Web.UI.RadEditor)item.FindControl("RadEditor1_HtmlText");
				ItemRegister.GetInstance().SetHtmlTextFieldData(Convert.ToInt32(RXServer.Web.RequestValues.ViewId), htmlTextFieldTitle.Text, htmlRadEditor.Content);
			}

			String Errors = "";
			bool valid = true;
			foreach (RepeaterItem item in this.rptImageFields.Items)
			{
				#region UploadImage

				Telerik.Web.UI.RadUpload radUpload = (Telerik.Web.UI.RadUpload)item.FindControl("RadUpload1");
				Int32 img_width = 430;
				Int32 img_height = 322;
				Int32 img_thumb_width = 50;
				Int32 img_thumb_height = 50;
				String strFileName = "";
				String strFileName2 = "";
				String strFileExt = "";

				if (radUpload.InvalidFiles.Count > 0)
				{
					this.ErrorBox.Visible = true;
					Errors += " - " + RXMali.GetXMLNode("Error/media");
					valid = false;
				}
				else
				{
					if (radUpload.UploadedFiles.Count > 0)
					{
						String activeDir = "";
						try
						{
							activeDir = Server.MapPath(@"../../../Upload/ItemRegister/" + Convert.ToInt32(RXServer.Web.RequestValues.ViewId) + "/");
						}
						catch (Exception ex)
						{
							this.ErrorBox.Visible = true;
							Errors += ex;
						}

						if (!System.IO.Directory.Exists(activeDir))
						{
							System.IO.Directory.CreateDirectory(activeDir);
						}
						radUpload.TargetFolder = "~/Upload/ItemRegister/" + Convert.ToInt32(RXServer.Web.RequestValues.ViewId);

						foreach (Telerik.Web.UI.UploadedFile f1 in radUpload.UploadedFiles)
						{
							HtmlInputHidden hiddenImageName = (HtmlInputHidden)item.FindControl("name");
							strFileName = f1.GetNameWithoutExtension().Trim() + "_" + Path.GetRandomFileName();
							strFileExt = f1.GetExtension().ToLower();
							strFileName2 = strFileName + strFileExt;

							f1.SaveAs(activeDir + strFileName2);

							// Scale Image
							System.Drawing.Image scaleImg = System.Drawing.Image.FromFile(activeDir + strFileName2);

							if (scaleImg.Width != img_width || scaleImg.Height != img_height)
							{
								System.Drawing.Image newImg = null;
								newImg = RXMali.ScaleFixedImage(scaleImg, img_width, img_height);
								newImg.Save(activeDir + "s_" + strFileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
								newImg.Dispose();
								
								ItemRegister.GetInstance().SetImagePath("/Upload/ItemRegister/" + Convert.ToInt32(RXServer.Web.RequestValues.ViewId) + "/s_" + strFileName + ".jpg", ItemRegister.GetInstance().GetDataNodeId(hiddenImageName.Value, Convert.ToInt32(RXServer.Web.RequestValues.ViewId)));
							}
							else
							{
								ItemRegister.GetInstance().SetImagePath("/Upload/ItemRegister/" + Convert.ToInt32(RXServer.Web.RequestValues.ViewId) + "/" + strFileName2, ItemRegister.GetInstance().GetDataNodeId(hiddenImageName.Value, Convert.ToInt32(RXServer.Web.RequestValues.ViewId)));
							}

							// Scale Thumb Image
							System.Drawing.Image newThumb = null;
							newThumb = RXMali.ScaleFixedImage(scaleImg, img_thumb_width, img_thumb_height);
							newThumb.Save(activeDir + "t_" + strFileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
							newThumb.Dispose();
							ItemRegister.GetInstance().SetImageThumbPath("/Upload/ItemRegister/" + Convert.ToInt32(RXServer.Web.RequestValues.ViewId) + "/t_" + strFileName + ".jpg", ItemRegister.GetInstance().GetDataNodeId(hiddenImageName.Value, Convert.ToInt32(RXServer.Web.RequestValues.ViewId)));
						}
					}
				}

				#endregion
			}

			if (valid)
			{
				String Url = "";
				Url = RXMali.GetLastUrl(Request.Url.ToString());
				Url = Url.Replace("&SubPage=Edit&ViewId=" + RXServer.Web.RequestValues.ViewId, "");

				RXServer.Web.Redirect.To(Url);
			}
			else
			{
				this.ErrorBox.Visible = true;
				this.ltrErrors.Text = Errors;
			}
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	protected void rptImageFields_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
	{
		String function_name = "rptImageFields_ItemDataBound";
		try
		{
			Telerik.Web.UI.RadUpload uploader = (Telerik.Web.UI.RadUpload)e.Item.FindControl("RadUpload1");
			HtmlInputHidden hiddenExt = (HtmlInputHidden)e.Item.FindControl("extensions");
			HtmlInputHidden hiddenSize = (HtmlInputHidden)e.Item.FindControl("size");
			string[] s = hiddenExt.Value.Split('|').ToArray();
			uploader.AllowedFileExtensions = s;
			uploader.MaxFileSize = Convert.ToInt32(hiddenSize.Value);
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
	protected void rptHtmlTextFields_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
	{
		String function_name = "rptImageFields_ItemDataBound";
		try
		{
			Telerik.Web.UI.RadEditor editor = (Telerik.Web.UI.RadEditor)e.Item.FindControl("RadEditor1_HtmlText");
			Label title = (Label)e.Item.FindControl("lblHtmlTextFieldTitle");

			HtmlTextValue value = this.htmlText.Find(
				delegate(HtmlTextValue item)
				{
					return item.title == title.Text;
				});

			editor.Content = value.value;
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

	protected void btnSaveTerms_Click(object sender, EventArgs e)
	{
		String function_name = "btnSaveTerms_Click";
		try
		{
			RXServer.Modules.Menu.Item mItem = new RXServer.Modules.Menu.Item(1);
			mItem.Terms = Server.HtmlEncode(this.RadEditor_Terms.Content).Replace("'", "`");

			String Url = "";
			Url = RXMali.GetLastUrl(Request.Url.ToString());
			Url = Url.Replace("&SubPage=Terms", "");

			RXServer.Web.Redirect.To(Url);
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}

    public void HideErrors()
    {
        String function_name = "HideErrors";
        try
        {
            // Add User
            //this.imgError3_1.Visible = false;
            //this.imgError3_2.Visible = false;
            //this.imgError3_3.Visible = false;
            //this.imgError3_4a.Visible = false;
            //this.imgError3_4b.Visible = false;
        }
        catch (Exception ex)
        {
            this.ErrorBox.Visible = true;
            this.ltrErrors.Text = ex.ToString();
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

    protected void NodeExpanded(object sender, EventArgs e)
    {
        TreeNode Node = ((TreeNodeEventArgs)e).Node;
        String sId = Node.Value;
        Int32 iId = Convert.ToInt32(sId);
        if (iId > 0)
        {
            Node.ChildNodes.Clear();
            BuildTreeBase(Node);
        }
    }
   
    protected void RadTreeView1_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        String pop = e.Node.Text;
    }

    protected void RadTreeView1_NodeCollapse(object sender, RadTreeNodeEventArgs e)
    {
        String pop = e.Node.Text;
    }

    protected void RadTreeView1_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        Telerik.Web.UI.RadTreeNode Node = ((Telerik.Web.UI.RadTreeNodeEventArgs)e).Node;
        String sId = Node.Value;
        Int32 iId = Convert.ToInt32(sId);
        if (iId > 0)
        {
            Node.Nodes.Clear();
            BuildRadTreeBase(Node);
            nodechain = new ArrayList();
            nodelevel = ItemRegister.GetInstance().GetCurrentNodeLevel(iId, ref nodechain);
        }
    }

    protected void RadTreeView1_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
    {
        String function_name = "RadTreeView1_NodeDrop";
        try
        {
            ItemRegister.GetInstance().MoveNodeTo(Convert.ToInt32(e.DestDragNode.Value), Convert.ToInt32(e.SourceDragNode.Value), e.DropPosition.ToString());

            nodechain = new ArrayList();
            nodelevel = ItemRegister.GetInstance().GetCurrentNodeLevel(Convert.ToInt32(e.SourceDragNode.Value), ref nodechain);
            if (nodechain.Count > 1) 
                nodechain.RemoveAt(nodechain.Count - 1);
            
            RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()).Replace("&SubPage=Edit&ViewId=" + e.SourceDragNode.Value, String.Empty));
        }
        catch (Exception ex)
        {
            RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
        }

    }

	protected void RadTreeView1_ContextMenuItemClick(object sender, RadTreeViewContextMenuEventArgs e)
	{
		String function_name = "RadTreeView1_ContextMenuItemClick";
		try
		{
			RadTreeNode clickedNode = e.Node;

			switch (e.MenuItem.Value)
			{
				case "New":
					RXServer.Web.Redirect.To("AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + clickedNode.Value);
					break;
				case "Edit":
					if (ItemRegister.GetInstance().IsRootNode(Convert.ToInt32(clickedNode.Value)))
						RXServer.Web.Redirect.To("AdminView_Admin.aspx?Page=Shop&SubPage=Add&ViewId=" + ItemRegister.GetInstance().RootId.ToString());
					else
						RXServer.Web.Redirect.To("AdminView_Admin.aspx?Page=Shop&SubPage=Edit&ViewId=" + clickedNode.Value);
					break;
				case "Delete":
					ItemRegister.GetInstance().DeleteNode(Convert.ToInt32(clickedNode.Value));
					RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
					break;
				case "Copy":
					String nodeType = ItemRegister.GetInstance().GetNodType(Convert.ToInt32(clickedNode.Value));
					int parentId = ItemRegister.GetInstance().GetParentNodeId(Convert.ToInt32(clickedNode.Value));
					String nodeTitle = ItemRegister.GetInstance().GetTextFieldData("Titel", Convert.ToInt32(clickedNode.Value)) + " copy";

					try
					{
						int id = ItemRegister.GetInstance().NewNode(nodeType, parentId, nodeTitle);
						List<ItemRegister.Node.DataNodeDefinition> dataNodes = ItemRegister.GetInstance().GetDataNodes(Convert.ToInt32(clickedNode.Value));
						foreach (ItemRegister.Node.DataNodeDefinition nodeDef in dataNodes)
						{
							if (!nodeDef.Name.Equals("Titel"))
							{
								switch (nodeDef.Type)
								{
									case ItemRegister.Node.DataNodeType.Bool:
										ItemRegister.GetInstance().SetBoolData(id, nodeDef.Name, ItemRegister.GetInstance().GetBoolData(nodeDef.Id));
										break;
									case ItemRegister.Node.DataNodeType.Decimal:
										ItemRegister.GetInstance().SetDecimalData(id, nodeDef.Name, ItemRegister.GetInstance().GetDecimalData(nodeDef.Id));
										break;
									case ItemRegister.Node.DataNodeType.Htmltextfield:
										ItemRegister.GetInstance().SetHtmlTextFieldData(id, nodeDef.Name, ItemRegister.GetInstance().GetHtmlTextFieldData(nodeDef.Id));
										break;
									case ItemRegister.Node.DataNodeType.Image:
										ItemRegister.Node.ImageDefinition imgDef = ItemRegister.GetInstance().GetImageData(nodeDef.Id);
										ItemRegister.GetInstance().SetImagePath(imgDef.Path, nodeDef.Id);
										ItemRegister.GetInstance().SetImageLargePath(imgDef.PathLarge, nodeDef.Id);
										ItemRegister.GetInstance().SetImageThumbPath(imgDef.PathThumb, nodeDef.Id);
										break;
									case ItemRegister.Node.DataNodeType.Textfield:
										ItemRegister.GetInstance().SetTextFieldData(id, nodeDef.Name, ItemRegister.GetInstance().GetTextFieldData(nodeDef.Id));
										break;
								}
							}
						}

						RXServer.Web.Redirect.To(RXMali.GetLastUrl(Request.Url.ToString()));
					}
					catch (ItemRegisterExceptions.ChildCountReachedException)
					{
						this.ErrorBox.Visible = true;
						this.ltrErrors.Text = "Child count reached. The parent node doesn't allow more child nodes.";
					}
					break;
			}
		}
		catch (Exception ex)
		{
			this.ErrorBox.Visible = true;
			this.ltrErrors.Text = ex.ToString();
			RXServer.Lib.Error.Report(ex, class_name + ":" + function_name, String.Empty);
		}
	}
}
