<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Checkout.ascx.cs" Inherits="Modules_Shop_Checkout_Checkout" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel_Checkout" EnableAJAX="true" OnAjaxRequest="RadAjaxPanel_AjaxRequest" LoadingPanelID="RadAjaxLoadingPanel1" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <div id="Checkout" runat="server" class="Checkout">
            <div id="Checkout_header">
                <div style="float: left;">
                    <asp:Label runat="server" ID="lblTitle" Text="lblTitle" Font-Bold="True" 
                        Font-Size="18px" ForeColor="White" Font-Names="Arial" />
                </div>
                <div style="float: left; padding-left: 698px; padding-bottom: 10px">
                    <table border="0" cellpadding="0" cellspacing="0" height="23px">
                        <tr>
                            <td id="Checkout_return_button_left"></td>
                            <td id="Checkout_return_button_main" align="center">
                                <asp:LinkButton ID="lnkBtnReturn" runat="server" Text="lnkBtnReturn" 
                                    onclick="lnkBtnReturn_Click" />
                            </td>
                            <td id="Checkout_return_button_right"></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="Checkout_products_main" style="float: left;">
                <asp:Repeater ID="rptrCartItems" runat="server" 
                    onitemcommand="rptrCartItems_ItemCommand">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="900px">
                        <tr id="Items_header" height="21px">
                            <td style="padding-left: 20px;"><%# RXMali.GetXMLNode("Modules/Checkout/desc") %></td>
                            <td align="center"><%# RXMali.GetXMLNode("Modules/Checkout/quantity") %></td>
                            <td></td>
                            <td align="center" colspan="2"><%# RXMali.GetXMLNode("Modules/Checkout/price") %></td>
                            <td></td>
                            <td align="center" colspan="2"><%# RXMali.GetXMLNode("Modules/Checkout/totalprice")%></td>
                            <td></td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="Items_row">
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
                            <td align="left" width="1*"><%# RXMali.GetXMLNode("Modules/Checkout/currencysymbol")%></td>
                            <td width="100px"></td>
                            <td align="right" width="1*"><%# DataBinder.Eval(Container.DataItem, "TotalPrice") %>&nbsp;</td>
                            <td align="left" width="1*"><%# RXMali.GetXMLNode("Modules/Checkout/currencysymbol")%></td>
                            <td align="right" style="padding-right: 20px;">
                                <table border="0" cellpadding="0" cellspacing="0" height="25px">
                                    <tr>
                                        <td id="Checkout_delete_button_left"></td>
                                        <td id="Checkout_delete_button_main">
                                            <asp:LinkButton ID="lnkBtnDeleteItem" runat="server" CommandName="Delete">
                                                <%# DataBinder.Eval(Container.DataItem, "DeleteText") %></asp:LinkButton>
                                        </td>
                                        <td id="Checkout_delete_button_right"></td>
                                    </tr>
                                </table>
                            </td>               
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr id="Items_footer">
                    <td valign="top" style="padding-top: 14px; padding-left: 18px;">
                        <table>
                            <tr>
                                <td style="padding-right: 8px;">
                                    <table border="0" cellpadding="0" cellspacing="0" height="25px">
                                        <tr>
                                            <td id="Checkout_update_button_left"></td>
                                            <td id="Checkout_update_button_main">
                                                <asp:LinkButton ID="lnkBtnUpdateCart" runat="server" CommandName="Update" 
                                                    onclick="lnkBtnUpdateCart_Click">
                                                    <%= RXMali.GetXMLNode("Modules/Checkout/update")%></asp:LinkButton>
                                            </td>
                                            <td id="Checkout_update_button_right"></td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" height="25px">
                                        <tr>
                                            <td id="Checkout_empty_button_left"></td>
                                            <td id="Checkout_empty_button_main">
                                                <asp:LinkButton ID="lnkBtnEmptyCart" runat="server" CommandName="Empty" 
                                                    onclick="lnkBtnEmptyCart_Click">
                                                    <%= RXMali.GetXMLNode("Modules/Checkout/empty")%></asp:LinkButton>
                                            </td>
                                            <td id="Checkout_empty_button_right"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                    <td colspan="3" align="right" valign="top" style="padding-top: 20px">
                        <div id="TopTwoPricesLables">
                            <%= RXMali.GetXMLNode("Modules/Checkout/totalcartprice")%>:<br />
                            <%= RXMali.GetXMLNode("Modules/Checkout/shiping")%>:
                        </div>
                        <b><%= RXMali.GetXMLNode("Modules/Checkout/totalcartpricewithshiping")%>:</b><br />
                    </td>
                    <td colspan="3" align="right" valign="top" style="padding-top: 20px">
                        <div id="TopTwoPrices">
                            <asp:Label ID="lblTotalCartPrice" runat="server" Text="lblTotalCartPrice" /><br />
                            <asp:Label ID="lblShiping" runat="server" Text="lblShiping" />
                        </div>
                        <asp:Label ID="lblTotalWithShiping" runat="server" Text="lblTotalWithShiping" CssClass="TotalWithShiping" /><br />
                        <asp:Label ID="lblVatSymbol" runat="server" Text="lblVatSymbol" />
                    </td>
                    <td></td>
                </tr>
                </table>
            </div>
            <div id="CustomerType">
                <asp:Label ID="lblCustomerTypeTxt" runat="server" 
                Text="lblCustomerTypeTxt" CssClass="CustomerTypeText"></asp:Label>
                <hr noshade="noshade" size="1" />
                <asp:Label ID="lblCustomerError" runat="server" Font-Bold="True" 
                ForeColor="Red" Text="lblCustomerError" Visible="False"></asp:Label>
                <asp:RadioButtonList ID="rblCustomerType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblCustomerType_SelectedIndexChanged">
                </asp:RadioButtonList>
                <hr noshade="noshade" size="1" />
            </div>
            <div id="PaymentMethods">
                <asp:Label ID="lblPaymentMethodsTxt" runat="server" 
                Text="lblPaymentMethodsTxt" CssClass="PaymentMethodsText"></asp:Label>
                <hr noshade="noshade" size="1" />
                <asp:Label ID="lblPaymentError" runat="server" Font-Bold="True" 
                ForeColor="Red" Text="lblPaymentError" Visible="False"></asp:Label>
                <asp:RadioButtonList ID="rblPaymentMethods" runat="server">
                </asp:RadioButtonList>
                <hr noshade="noshade" size="1" />
            </div>
            <div id="Shipping">
                <asp:Label ID="lblShippingTxt" runat="server" 
                Text="lblShippingTxt" CssClass="ShippingText"></asp:Label>
                <hr noshade="noshade" size="1" />
                <asp:Label ID="lblShippingError" runat="server" Font-Bold="True" 
                ForeColor="Red" Text="lblShippingError" Visible="False"></asp:Label>
                <asp:RadioButtonList ID="rblShipping" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblShipping_SelectedIndexChanged">
                </asp:RadioButtonList>
                <hr noshade="noshade" size="1" />
            </div>
            <div id="DeliveryInfo">
                <asp:Label ID="lblAddressTxt" runat="server" Text="lblAddressTxt" CssClass="DeliveryInfoTitle"></asp:Label>
                <hr noshade="noshade" size="1" />
                <table style="width: 400px;">
                    <tr id="company_row1" runat="server" visible="false">
                        <td>
                            <asp:Label ID="lblCompanyNameTxt" runat="server" Text="lblCompanyNameTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblCompanyOrgNrTxt" runat="server" Text="lblCompanyOrgNrTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCompanyOrgNr" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="company_row2" runat="server" visible="false">
						<td>
							Kontaktperson
						</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFirstNameTxt" runat="server" Text="lblFirstNameTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblLastNameTxt" runat="server" Text="lblLastNameTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblStreetAddressTxt" runat="server" Text="lblStreetAddressTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtStreetAddress" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblZipCodeTxt" runat="server" Text="lblZipCodeTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCityTxt" runat="server" Text="lblCityTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblCountryTxt" runat="server" Text="lblCountryTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhoneNumberTxt" runat="server" Text="lblPhoneNumberTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblEmailTxt" runat="server" Text="lblEmailTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="company_row3" runat="server" visible="false">
						<td>
							<asp:CheckBox ID="chbDeliveryToInvoice" runat="server" Text="Samma leveransadress som ovan" AutoPostBack="true" OnCheckedChanged="chbDeliveryToInvoice_CheckChanged" />
						</td>
                    </tr>
                    <tr id="company_row4" runat="server" visible="false">
						<td>
							<asp:Label ID="lblStreetAddressDeliveryTxt" runat="server" Text="lblStreetAddressDeliveryTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtStreetAddressDelivery" runat="server"></asp:TextBox>
						</td>
						<td>
							<asp:Label ID="lblPostalCodeDeliveryTxt" runat="server" Text="lblPostalCodeDeliveryTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtPostalCodeDelivery" runat="server"></asp:TextBox>
						</td>
                    </tr>
                    <tr id="company_row5" runat="server" visible="false">
						<td>
							<asp:Label ID="lblCityDeliveryTxt" runat="server" Text="lblCityDeliveryTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCityDelivery" runat="server"></asp:TextBox>
						</td>
						<td>
							<asp:Label ID="lblCountryDeliveryTxt" runat="server" Text="lblCountryDeliveryTxt"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCountryDelivery" runat="server"></asp:TextBox>
						</td>
                    </tr>
                </table>
                <div id="TermsCheckBox">
					<asp:Label ID="lblTermsError" runat="server" Font-Bold="True" 
						ForeColor="Red" Text="lblTermsError" Visible="False" /><br />
                    <asp:CheckBox ID="chbxAgreeToTerms" runat="server" />
                    <asp:Label ID="lblTermsCheckBoxText" runat="server" Text=" Jag godkänner " />
                    <asp:LinkButton ID="lnkBtnShowTerms" runat="server" Text="leveransvillkoren." 
                        onclick="lnkBtnShowTerms_Click" CssClass="show_terms" />
                </div>
                <div id="Terms" runat="server">
                    <asp:Literal ID="ltrTerms" runat="server" Text="ltrTerms" />
                </div>
                <hr noshade="noshade" size="1" />
            </div>
            <div id="BuyButton">
                <asp:ImageButton ID="imgBtnBuy" runat="server"  
                    ImageUrl="~/Images/Modules/Shop/checkout_buy.png" onclick="imgBtnBuy_Click" />
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

<script type="text/javascript">
	function loadModal(src)
	{
		if($.browser.msie)
		{
			window.location = src;
		}
		else
		{
			$.modal('<iframe src="' + src + '" height="600" width="500" style="border:0" />', {
				closeHTML:"",
				containerCss:{
					backgroundColor:"#fff",
					borderColor:"#fff",
					height:600,
					padding:0,
					width:500
				},
				overlayCss:{
					backgroundColor:"#000"
				},
				overlayClose:false
			});
		}
	}
</script>

<!-- Ellipsis for FF -->
<script type="text/javascript">
	$(window).load(function() {
		$(".cart_title").ellipsis();
		$(".cart_text").ellipsis();
	});
</script>
