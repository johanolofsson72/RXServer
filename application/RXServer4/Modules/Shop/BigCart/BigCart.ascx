<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BigCart.ascx.cs" Inherits="Modules_Shop_BigCart_BigCart" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel_BigCart" EnableAJAX="true" OnAjaxRequest="RadAjaxPanel_AjaxRequest" LoadingPanelID="RadAjaxLoadingPanel1" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <div id="BigCart" runat="server" class="BigCart">
            <div id="BigCart_header">
                <div style="float: left;">
                    <asp:Label runat="server" ID="lblTitle" Text="lblTitle" Font-Bold="True" 
                        Font-Size="18px" ForeColor="White" Font-Names="Arial" />
                </div>
                <div style="float: left; padding-left: 572px; padding-bottom: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" height="23px">
                        <tr>
                            <td id="BigCart_return_button_left"></td>
                            <td id="BigCart_return_button_main" align="center">
                                <asp:LinkButton ID="lnkBtnReturn" runat="server" Text="lnkBtnReturn" 
                                    onclick="lnkBtnReturn_Click" />
                            </td>
                            <td id="BigCart_return_button_right"></td>
                        </tr>
                    </table>
                </div>
                <div style="float: left; padding-left: 10px; padding-bottom: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" height="23px">
                        <tr>
                            <td id="BigCart_checkout_button_left"></td>
                            <td id="BigCart_checkout_button_main" align="center">
                                <asp:LinkButton ID="lnkBtnCheckout" runat="server" Text="lnkBtnCheckout" 
                                    onclick="lnkBtnCheckout_Click" />
                            </td>
                            <td id="BigCart_checkout_button_right"></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="BigCart_main">
                <asp:Repeater ID="rptrCartItems" runat="server" 
                    onitemcommand="rptrCartItems_ItemCommand">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="900px">
                        <tr id="BigCartItems_header" height="21px">
                            <td style="padding-left: 20px;"><%# RXMali.GetXMLNode("Modules/BigCart/desc") %></td>
                            <td align="center"><%# RXMali.GetXMLNode("Modules/BigCart/quantity") %></td>
                            <td></td>
                            <td align="center" colspan="2"><%# RXMali.GetXMLNode("Modules/BigCart/price") %></td>
                            <td></td>
                            <td align="center" colspan="2"><%# RXMali.GetXMLNode("Modules/BigCart/totalprice") %></td>
                            <td></td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="BigCartItems_row">
                            <td width="335px" style="padding-left: 20px;">
								<asp:HyperLink ID="hplToProduct" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ProductUrl") %>'>
									<div style="float: left;">
										<asp:Image ID="imgProductPicture" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PicturePath") %>' BorderWidth="1px" CssClass="ProductImage" ImageAlign="Middle" />
									</div>
									<div style="float: left;">
										<div id="ProductTitle" style="overflow: hidden; text-overflow: ellipsis; -o-text-overflow: ellipsis; white-space: nowrap;" class="cart_title"><%# DataBinder.Eval(Container.DataItem, "ProductName")%></div>
										<div id="ProductDesc" style="overflow: hidden; text-overflow: ellipsis; -o-text-overflow: ellipsis; white-space: nowrap;" class="cart_text"><%# DataBinder.Eval(Container.DataItem, "Description")%></div>
									</div>
                                </asp:HyperLink>
                            </td>
                            <td align="center" width="1*"><asp:TextBox ID="txtQuantity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>' style="width: 30px; vertical-align: middle;" /></td>
                            <td width="100px"></td>
                            <td align="right" width="1*"><%# DataBinder.Eval(Container.DataItem, "Price") %>&nbsp;</td>
                            <td align="left" width="1*"><%# RXMali.GetXMLNode("Modules/BigCart/currencysymbol") %></td>
                            <td width="100px"></td>
                            <td align="right" width="1*"><%# DataBinder.Eval(Container.DataItem, "TotalPrice") %>&nbsp;</td>
                            <td align="left" width="1*"><%# RXMali.GetXMLNode("Modules/BigCart/currencysymbol") %></td>
                            <td align="right" style="padding-right: 20px;">
                                <table border="0" cellpadding="0" cellspacing="0" height="25px">
                                    <tr>
                                        <td id="BigCart_delete_button_left"></td>
                                        <td id="BigCart_delete_button_main">
                                            <asp:LinkButton ID="lnkBtnDeleteItem" runat="server" CommandName="Delete">
                                                <%# DataBinder.Eval(Container.DataItem, "DeleteText") %></asp:LinkButton>
                                        </td>
                                        <td id="BigCart_delete_button_right"></td>
                                    </tr>
                                </table>
                            </td>               
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="BigCartItems_footer">
                    <td valign="top" style="padding-top: 14px; padding-left: 18px;">
                        <table>
                            <tr>
                                <td style="padding-right: 8px;">
                                    <table border="0" cellpadding="0" cellspacing="0" height="25px">
                                        <tr>
                                            <td id="BigCart_update_button_left"></td>
                                            <td id="BigCart_update_button_main">
                                                <asp:LinkButton ID="lnkBtnUpdateCart" runat="server" CommandName="Update" 
                                                    onclick="lnkBtnUpdateCart_Click">
                                                    <%= RXMali.GetXMLNode("Modules/BigCart/update") %></asp:LinkButton>
                                            </td>
                                            <td id="BigCart_update_button_right"></td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" height="25px">
                                        <tr>
                                            <td id="BigCart_empty_button_left"></td>
                                            <td id="BigCart_empty_button_main">
                                                <asp:LinkButton ID="lnkBtnEmptyCart" runat="server" CommandName="Empty" 
                                                    onclick="lnkBtnEmptyCart_Click">
                                                    <%= RXMali.GetXMLNode("Modules/BigCart/empty") %></asp:LinkButton>
                                            </td>
                                            <td id="BigCart_empty_button_right"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                    <td colspan="3" align="right" valign="top" style="padding-top: 20px">
                        <div id="TopTwoPricesLables">
                            <%= RXMali.GetXMLNode("Modules/BigCart/totalcartprice") %>:<br />
                            <%= RXMali.GetXMLNode("Modules/BigCart/shiping") %>:
                        </div>
                        <b><%= RXMali.GetXMLNode("Modules/BigCart/totalcartpricewithshiping") %>:</b><br />
                    </td>
                    <td colspan="3" align="right" valign="top" style="padding-top: 20px">
                        <div id="TopTwoPrices">
                            <asp:Label ID="lblTotalCartPrice" runat="server" Text="lblTotalCartPrice" /><br />
                            <asp:Label ID="lblShiping" runat="server" Text="lblShiping" />
                        </div>
                        <asp:Label ID="lblTotalWithShiping" runat="server" Text="lblTotalWithShiping" CssClass="TotalWithShiping" /><br />
                        <asp:Label ID="lblVatSymbol" runat="server" Text="lblVatSymbol"></asp:Label>
                    </td>
                    <td></td>
                </tr>
                </table>
            </div>
        </div>
    </telerik:RadCodeBlock>
</telerik:RadAjaxPanel>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" MinDisplayTime="1000" InitialDelayTime="200">
    <div id="LoadPanelContent" runat="server" style="position: fixed; background-image: url('Images/Site/load_bg.png'); top: 0px; left: 0px;">
        <asp:Image ID="loader" runat="server" ImageUrl="~/Images/Site/ajax-loader.gif" />
    </div>
</telerik:RadAjaxLoadingPanel>

<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
</telerik:RadAjaxManagerProxy>

<!-- Center loader -->
<script type="text/javascript">
	function centerElementOnScreen(element, loader) 
	{
		var top = $(window).height() / 2 - 10;
		$("#" + element).css("width", $(window).width() + "px");
		$("#" + element).css("height", $(window).height() + "px");
		$("#" + loader).css("margin-top", top + "px");
		
		$(window).resize(function(){
			var top = $(window).height() / 2 - 10;
			$("#" + element).css("width", $(window).width() + "px");
			$("#" + element).css("height", $(window).height() + "px");
			$("#" + loader).css("margin-top", top + "px");
		});
	}
	
	function removeOnResize()
	{
		$(window).unbind("resize");
	}
</script>

<!-- Ellipsis for FF -->
<script type="text/javascript">
	$(window).load(function() {
		$(".cart_title").ellipsis();
		$(".cart_text").ellipsis();
	});
</script>