<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SmallCart.ascx.cs" Inherits="Modules_Shop_SmallCart_SmallCart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="SmallCart_holder" runat="server">    
    <telerik:RadAjaxPanel ID="RadAjaxPanel_SmallCart" EnableAJAX="true" OnAjaxRequest="RadAjaxManager_AjaxRequest" runat="server">
        <div id="SmallCart" runat="server" class="SmallCart_style">
            <div id="cart_icon">
                <asp:Literal ID="ltrCartIcon" runat="server" Text="ltrCartIcon" />
            </div>
            <div id="cart_text">
                <asp:Label ID="lblCartText" runat="server" Text="lblCartText" />
            </div>
            <div id="to_checkout_button" runat="server" class="to_checkout_button">
                <asp:ImageButton ID="imbOpenCheckout" runat="server" ImageUrl="~/Images/Modules/Shop/small_cart_open_checkout_button.png" OnClick="imbOpenCheckout_Click" />
            </div>
            <div id="open_cart_button" runat="server" class="open_cart_button_style">
                <asp:ImageButton ID="imbOpenCart" runat="server" ImageUrl="~/Images/Modules/Shop/small_cart_open_cart_button.png" OnClick="imbOpenCart_Click" />
            </div>
        </div>
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <asp:Literal ID="ltrJScript" runat="server" Visible="false" />
            <script type="text/javascript">                
                function changeCartColor(id)
                {
                    document.getElementById(id).style.background = '#3F3F3F';
                }
            </script>
        </telerik:RadScriptBlock>
    </telerik:RadAjaxPanel>
</div>