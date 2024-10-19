<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="TopMenu" %>
<asp:Menu ID="Menu1" runat="server" Font-Names="Verdana" Font-Size="Smaller" Font-Bold="true" Orientation="Horizontal">
	<staticmenuitemstyle ForeColor="Black"  itemspacing="10px" />
	<staticselectedstyle ForeColor="#ff990e" />
	<statichoverstyle Forecolor="#ff990e" />
	<Items>
	    <asp:MenuItem NavigateUrl="~/Hem.aspx" SeparatorImageUrl="~/Images/Menu01_Seperator.gif"  Text="Hem"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Om_iZon.aspx" SeparatorImageUrl="~/Images/Menu01_Seperator.gif"  Text="Om iZon"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Medlemmar.aspx" SeparatorImageUrl="~/Images/Menu01_Seperator.gif"  Text="Medlemmar"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Länkar.aspx" SeparatorImageUrl="~/Images/Menu01_Seperator.gif"  Text="Länkar"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Kontakta_oss.aspx" Text="Kontakta oss"></asp:MenuItem>
    </Items>
</asp:Menu>
