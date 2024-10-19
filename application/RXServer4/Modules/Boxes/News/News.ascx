<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="Modules_Boxes_News_News" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="News_holder" runat="server" visible="false">
    <div id="News">
        <h1><asp:Label ID="lblTitle" runat="server" /></h1>
        <asp:Literal ID="ltrNewsList" runat="server" />        
    </div>
</div>