<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddToCartWrapperCat.ascx.cs" Inherits="Modules_Boxes_ProductBrowser_AddToCartWrapperCat" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" EnableAJAX="true" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
    <asp:ImageButton ID="imgBtnAddToCart" runat="server"  
        ImageUrl="~/Images/Modules/Boxes/sb_add_to_cart_cat.gif" 
        onclick="imgBtnAddToCart_Click" />
</telerik:RadAjaxPanel>

<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" MinDisplayTime="1000" InitialDelayTime="200">
    <div id="LoadPanelContent" runat="server" style="position: fixed; background-image: url('Images/Site/load_bg.png'); top: 0px; left: 0px;">
        <asp:Image ID="loaderCat" runat="server" ImageUrl="~/Images/Site/ajax-loader.gif" />
    </div>
</telerik:RadAjaxLoadingPanel>
    
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server" >
</telerik:RadAjaxManagerProxy>