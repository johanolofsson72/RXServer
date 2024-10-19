<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShopPage.ascx.cs" Inherits="Modules__System_AdminView_ShopPage" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Label ID="Script" runat="server"></asp:Label>

<div id="ShopPage" runat="server" style="position:relative; float: left; width:100%;">
 
    <div id="ShopSubMenu" runat="server" visible="false" class="SubMenu_div">
        <div style="position: relative; float: left;"><asp:Literal ID="ltrShopSubMenuList" runat="server" /></div>
        <div style="position: relative; float: right;"><asp:Literal ID="ltrShopSubMenuList2" runat="server" /></div>
    </div>
    
     <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" class="ErrorBox_div">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_error_big.gif" title="Errors" /></td>
                <td style="width: 10px;"></td>
                <td class="Text12_bold_orange" valign="middle">Oops!</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td class="Text12_gray"><asp:Literal ID="ltrErrors" runat="server"/></td>
            </tr>
        </table>
     </div>
    
    
    <%--Page 1 :: List Nodes--%>
    <div id="ShopPage_1" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage1" runat="server"></asp:Label></span>
        <br />
        <br />
        <hr class='line' />
        <br />
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
			    <script language="javascript">
                    function GetSelectedNode(){
                       var treeView = $find("<%=RadTreeView1.ClientID%>")
                       var selectedNode = treeView.get_selectedNode();
                       return selectedNode;
                    }
			    </script>
                <telerik:RadTreeView 
                    ID="RadTreeView1" 
                    runat="server" 
                    EnableDragAndDropBetweenNodes="true"
                    EnableDragAndDrop="true"
                    EnableEmbeddedSkins="true"
                    LoadingMessage="Laddar..." 
                    LoadingStatusPosition="AfterNodeText" Skin="Default"
                    ExpandAnimation-Type="InOutQuad" 
                    ExpandAnimation-Duration="500"
			        OnNodeClick="RadTreeView1_NodeClick" 
			        OnNodeCollapse="RadTreeView1_NodeCollapse"
			        OnNodeExpand="RadTreeView1_NodeExpand" 
			        OnNodeDrop="RadTreeView1_NodeDrop"
			        OnContextMenuItemClick="RadTreeView1_ContextMenuItemClick"
			        OnClientContextMenuItemClicking="onClientContextMenuItemClicking">
			        <ContextMenus>
						<telerik:RadTreeViewContextMenu ID="ContextMenu" runat="server">
							<Items>
								<telerik:RadMenuItem Value="New" Text="New node"></telerik:RadMenuItem>
								<telerik:RadMenuItem Value="Edit" Text="Edit node"></telerik:RadMenuItem>
								<telerik:RadMenuItem Value="Copy" Text="Copy node"></telerik:RadMenuItem>
								<telerik:RadMenuItem Value="Delete" Text="Delete node"></telerik:RadMenuItem>
							</Items>
						</telerik:RadTreeViewContextMenu>
						<telerik:RadTreeViewContextMenu ID="ContextMenuRoot" runat="server">
							<Items>
								<telerik:RadMenuItem Value="New" Text="New node"></telerik:RadMenuItem>
							</Items>
						</telerik:RadTreeViewContextMenu>
			        </ContextMenus>
                </telerik:RadTreeView>
                <script type="text/javascript">
                    function onClientContextMenuItemClicking(sender, args)
					{
						var menuItem = args.get_menuItem();
						var treeNode = args.get_node();
						menuItem.get_menu().hide();
	                    
						switch(menuItem.get_value())
						{
							case "Delete":
								var result = confirm('IMPORTANT!\nDeleting a node is irreversible and all child nodes will be lost as well.\nAre you sure you want to do this?');
								args.set_cancel(!result);
								break;                            
						}
					}
                </script>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <hr class='line' />    
        <br />         
    </div>
    
    <!-- Page2 :: Edit Node-->
    <div id="ShopPage_2" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage2" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />
        <table cellpadding="0" cellspacing="0">
			<asp:Repeater ID="rptBool" runat="server">
				<ItemTemplate>
					<tr>
						<td class="Text12_gray"><asp:Label ID="lblBoolTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"bool_title")%>' /></td>
					</tr>
					<tr>
						<td><asp:Checkbox ID="chbBool" runat="server" EnableViewState="false" Checked='<%# DataBinder.Eval(Container.DataItem,"bool_value")%>' /></td>
					</tr>
					<tr>
						<td style="height:10px; font-size:1px;">&nbsp;</td>
					</tr>
				</ItemTemplate>
            </asp:Repeater>
			<asp:Repeater ID="rptDecimal" runat="server">
				<ItemTemplate>
					<tr>
						<td class="Text12_gray"><asp:Label ID="lblDecimalTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"decimal_title")%>' /></td>
					</tr>
					<tr>
						<td><asp:TextBox ID="txtDecimalField" class="form_textbox_200" runat="server" EnableViewState="false" Text='<%# DataBinder.Eval(Container.DataItem,"decimal_value")%>' /><asp:RegularExpressionValidator ID="regExpValidatorDecimal" runat="server" Display="Dynamic" ControlToValidate="txtDecimalField" ErrorMessage=" Must be a decimal value." ValidationExpression="[-+]?([0-9]*\,[0-9]+|[0-9]+)" SetFocusOnError="true" /><asp:RequiredFieldValidator ID="reqFieldValidatorDecimal" runat="server" ControlToValidate="txtDecimalField" Text=" Field can't be empty." SetFocusOnError="true" /></td>
					</tr>
					<tr>
						<td style="height:10px; font-size:1px;">&nbsp;</td>
					</tr>
				</ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptTextFields" runat="server">
				<ItemTemplate>
					<tr>
						<td class="Text12_gray"><asp:Label ID="lblTextFieldTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"field_title")%>' /></td>
					</tr>
					<tr>
						<td><asp:TextBox ID="txtTextField" class="form_textbox_200" runat="server" EnableViewState="false" Text='<%# DataBinder.Eval(Container.DataItem,"field_value")%>' /><asp:RequiredFieldValidator ID="reqFieldValidatorTextField" runat="server" ControlToValidate="txtTextField" Text=" Field can't be empty." Enabled='<%# DataBinder.Eval(Container.DataItem,"validate")%>' SetFocusOnError="true" /></td>
					</tr>
					<tr>
						<td style="height:10px; font-size:1px;">&nbsp;</td>
					</tr>
				</ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptHtmlTextFields" runat="server" OnItemDataBound="rptHtmlTextFields_ItemDataBound">
				<ItemTemplate>
					<tr>
						<td class="Text12_gray"><asp:Label ID="lblHtmlTextFieldTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"htmlfield_title")%>' /><asp:RequiredFieldValidator ID="reqFieldValidatorHtmlTextField" runat="server" ControlToValidate="RadEditor1_HtmlText" Text=" Field can't be empty." Enabled='<%# DataBinder.Eval(Container.DataItem,"validate")%>' SetFocusOnError="true" /></td>
					</tr>
					<tr>
						<td>
							<telerik:radeditor runat="server" 
								ID="RadEditor1_HtmlText"
								Skin="Telerik"
								ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Normal.xml"
								Height="400px"
								Width="600px"
								ShowHtmlMode="False" 
								ShowPreviewMode="False"
								EditModes="Design"
								ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css"
								EnableViewState="false" 
								>
								<ImageManager ViewPaths="~/Upload/ImageManager" UploadPaths="~/Upload/ImageManager" DeletePaths="~/Upload/ImageManager" MaxUploadFileSize="10485760" />
								<FlashManager ViewPaths="~/Upload/FlashManager" UploadPaths="~/Upload/FlashManager" DeletePaths="~/Upload/FlashManager" MaxUploadFileSize="10485760" />
								<DocumentManager ViewPaths="~/Upload/DocumentManager" UploadPaths="~/Upload/DocumentManager" DeletePaths="~/Upload/DocumentManager" MaxUploadFileSize="10485760"/>
								</telerik:radeditor>
			                    
							<script type="text/javascript">
								//<![CDATA[
								Telerik.Web.UI.Editor.CommandList["InsertSpecialLink"] = function(commandName, editor, args)
								{
								   var elem = editor.getSelectedElement(); //returns the selected element.
		                                  
								   if (elem.tagName == "A")
								   {
										editor.selectElement(elem);
										argument = elem;
								   }
								   else
								   {
									  var content = editor.getSelectionHtml(); 
									  var link = editor.get_document().createElement("A");
									  link.innerHTML = content;          
									  argument = link;
								   }
		                           
								   var myCallbackFunction = function(sender, args)
								   {
									   editor.pasteHtml(String.format("<a href={0} >{1}</a> ", args.target, args.name))
								   }
		                            
									var selection = editor.getSelection();
									var selectedText = selection.getText();
		                           
								   editor.showExternalDialog(
										'../../Links/LinkHolder/LinkHolder.aspx?txt=' +selectedText,
										argument,
										300,
										460,
										myCallbackFunction,
										null,
										'Insert Link',
										true,
										Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
										false,
										true);
								};
							</script>
						</td>
					</tr>
					<tr>
						<td style="height:10px; font-size:1px;">&nbsp;</td>
					</tr>
				</ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptImageFields" runat="server" OnItemDataBound="rptImageFields_ItemDataBound">
				<ItemTemplate>
					<tr>
						<td>
							<table width="100%" cellpadding="0" cellspacing="0">
								<tr>
									<td rowspan="9" style="width:200px;" align="right">
										<table cellpadding="0" cellspacing="0" style="border: solid 1px #CCCCCC;">
											<tr>
												<td valign="middle" align="center" style="height:200px; width: 200px;">
													<asp:Image ID="imgContent" width="180px" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"image_url")%>' />
												</td>
											</tr>
										</table>
										<asp:HyperLink ID="hplZoomImg" Visible="false" Target="_blank" runat="server"><img src="../../../App_Themes/WebAdmin/Images/icon_zoom.gif" class="img_noborder" style="margin: 3px;" title="Zoom" /></asp:HyperLink>
									</td>
									<td style="width:20px;">&nbsp;</td>
									<td style="width:380px; height:25px;" class="Text11_gray"  valign="top">Choose Media:</td>
								</tr>
								<tr>
									<td style="height:25px;"></td>
									<td valign="top">
										   <telerik:RadUpload ID="RadUpload1" runat="server" 
											Skin="Telerik"
											ControlObjectsVisibility="none"
											OverwriteExistingFiles="false"
											MaxFileInputsCount="1"
											 />
											<input id="extensions" runat="server" type="hidden" value='<%# DataBinder.Eval(Container.DataItem,"image_extensions")%>' />
											<input id="size" runat="server" type="hidden" value='<%# DataBinder.Eval(Container.DataItem,"image_size")%>' />
											<input id="name" runat="server" type="hidden" value='<%# DataBinder.Eval(Container.DataItem,"image_name")%>' />
									</td>
								</tr>
								<tr>
									<td style="height:10px; font-size:1px;">&nbsp;</td>
								</tr>
								<tr>
									<td style="height:25px;"></td>
									<td class="Text11_gray"  valign="top"></td>
								</tr>
								<tr>
									<td style="height:25px;"></td>
									<td></td>
								</tr>
								<tr>
									<td></td>
									<td>&nbsp;</td>
								</tr>
								<tr>
									<td></td>
									<td class="Text11_gray"  valign="top"></td>
								</tr>
								 <tr>
									<td></td>
									<td>&nbsp;</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td style="height:10px; font-size:1px;">&nbsp;</td>
					</tr>
				</ItemTemplate>
            </asp:Repeater>
         </table>     
        <br />
        <hr class='line' />    
        <br />
        <div style="position:relative; float: left;">
			<asp:Button ID="btnMoveNodeUp" runat="server" Text="Move Up" class="form_button" 
				onclick="btnMoveNodeUp_Click" Visible="false" />
			<asp:Button ID="btnMoveNodeDown" runat="server" Text="Move Down" class="form_button" 
				onclick="btnMoveNodeDown_Click" Visible="false" />
			<asp:Button ID="btnDelete" runat="server" Text="Delete" class="form_button" 
				onclick="btnDeleteNode_Click" Visible="false" />
        </div>
        <div style="position:relative; float: right;">
            <asp:Button ID="btnSaveNode" runat="server" Text="Save" class="form_button" 
				onclick="btnSaveNode_Click" />
        </div>
    </div> 
    
    <!--Page 3 :: Add Node-->
    <div id="ShopPage_3" runat="server" visible="false" class="Page_div">
       <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage3" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Node titel:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtNodeTitle" class="form_textbox_200" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Node type:</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="ddlNodeTypes" class="form_dropdown_200" runat="server" /></td>
            </tr>
        </table> 
        <br />
        <hr class='line' />    
        <br />   
        <div style="position:relative; float: right;">
            <asp:Button ID="btnAddNode" runat="server" Text="Save" class="form_button" 
				onclick="btnAddNode_Click" />
        </div>
    </div>
    
    <!--Page 4 :: Terms-->
    <div id="ShopPage_4" runat="server" visible="false" class="Page_div">
       <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage4" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td>
					<telerik:radeditor runat="server" 
						ID="RadEditor_Terms"
						Skin="Telerik"
						ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Normal.xml"
						Height="400px"
						Width="600px"
						ShowHtmlMode="False" 
						ShowPreviewMode="False"
						EditModes="Design"
						ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css" 
						>
						<ImageManager ViewPaths="~/Upload/ImageManager" UploadPaths="~/Upload/ImageManager" DeletePaths="~/Upload/ImageManager" MaxUploadFileSize="10485760" />
						<FlashManager ViewPaths="~/Upload/FlashManager" UploadPaths="~/Upload/FlashManager" DeletePaths="~/Upload/FlashManager" MaxUploadFileSize="10485760" />
						<DocumentManager ViewPaths="~/Upload/DocumentManager" UploadPaths="~/Upload/DocumentManager" DeletePaths="~/Upload/DocumentManager" MaxUploadFileSize="10485760"/>
						</telerik:radeditor>
	                    
					<script type="text/javascript">
							//<![CDATA[
							Telerik.Web.UI.Editor.CommandList["InsertSpecialLink"] = function(commandName, editor, args)
							{
							   var elem = editor.getSelectedElement(); //returns the selected element.
	                                  
							   if (elem.tagName == "A")
							   {
									editor.selectElement(elem);
									argument = elem;
							   }
							   else
							   {
								  var content = editor.getSelectionHtml(); 
								  var link = editor.get_document().createElement("A");
								  link.innerHTML = content;          
								  argument = link;
							   }
	                           
							   var myCallbackFunction = function(sender, args)
							   {
								   editor.pasteHtml(String.format("<a href={0} >{1}</a> ", args.target, args.name))
							   }
	                            
								var selection = editor.getSelection();
								var selectedText = selection.getText();
	                           
							   editor.showExternalDialog(
									'../../Links/LinkHolder/LinkHolder.aspx?txt=' +selectedText,
									argument,
									300,
									460,
									myCallbackFunction,
									null,
									'Insert Link',
									true,
									Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
									false,
									true);
							};
	                    
					</script>
                </td>
            </tr>
        </table> 
        <br />
        <hr class='line' />    
        <br />   
        <div style="position:relative; float: right;">
            <asp:Button ID="btnSaveTerms" runat="server" Text="Save" class="form_button" 
				onclick="btnSaveTerms_Click" />
        </div>
    </div>
   
</div>