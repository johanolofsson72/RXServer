<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBox.ascx.cs" Inherits="Modules_Boxes_TextBox_TextBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="TextBox_holder" runat="server">
    <div id="TextBox">
        <telerik:RadAjaxPanel ID="RAP_LiteBox" runat="server">
            <div id="text_size" visible="false" runat="server" style="position: relative; float: left; padding-top: 10px; height: 15px; width: 100%; margin-bottom: 10px; border-bottom: solid 1px #E5E5E5; display:inline;">
                <div id="text_right" style="position: relative; float: right; text-align: right;">
                   <asp:ImageButton id="imbSmallText" runat="server" onclick="imbSmallText_Click" /><asp:ImageButton id="imbMediumText" runat="server" onclick="imbMediumText_Click" /><asp:ImageButton id="imbLargeText" runat="server" onclick="imbLargeText_Click" />
                   <%-- <asp:Literal ID="ltrFontResizer" runat="server" />--%>
                </div>
             </div>
            <div class="tb_main">
                <h2><asp:Label ID="lblHeader" runat="server" /></h2>
                <div id="IngressText" visible="false" runat="server"><p class="Ingress"><asp:Label ID="lblIngress" runat="server" /></p></div>
                <p><asp:Label ID="lblText" runat="server" /></p>
            </div>
            <%--<asp:Literal ID="ltrFontLoader" Visible="true" runat="server" />--%>
        </telerik:RadAjaxPanel>
    </div>
    <div id="TextBox_social" runat="server" visible="false" class="social_holder">        
        <div class="icons">
            <div class="social_left">
                <asp:Literal ID="ltrSocial" runat="server"></asp:Literal>
            </div>
            <div class="social_right">
                <asp:Literal ID="ltrSpecial" runat="server"></asp:Literal>
            </div>
       </div>
    </div>
</div>