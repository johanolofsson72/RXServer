<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RSSBox.ascx.cs" Inherits="Modules_Boxes_RSSBox_RSSBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>



<div id="RSSBox_holder" runat="server" visible="false">    
    <div id="RSSBox">
        <h1><asp:Label ID="lblTitle" runat="server" /></h1>
        <h2><asp:Label ID="lblHeader" runat="server" /></h2>
        <asp:Literal ID="ltrRSS" runat="server"></asp:Literal>
    </div>
</div>