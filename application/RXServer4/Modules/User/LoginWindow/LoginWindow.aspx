<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAddon.master" CodeFile="LoginWindow.aspx.cs" Inherits="Modules_User_LoginWindow_LoginWindow" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>
  
    <div id="Menu" runat="server" style="background-color: #CCCCCC; width: 100%;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 20px; padding: 10px;" valign="top"><asp:Label ID="lblInfo" CssClass="Text11_333333" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Literal ID="ltrSubMenuList" runat="server" /></td>
            </tr>
        </table>
    </div>
    
     <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" visible="false" style="padding: 10px;">
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
 
    <div id="Page_1" runat="server" visible="false" style="background-color: white; padding: 10px;">        
        
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;">
            <tr>
                <td class='Text11_505050'>Användarnamn:</td>
            </tr>
            <tr>
                <td valign="top"><asp:TextBox ID="txtUsername" runat="server" /></td>
            </tr>
            <tr>
                <td style="font-size:1px; height: 5px;">&nbsp;</td>
            </tr>
            <tr>
                <td class='Text11_505050'>Lösenord:</td>
            </tr>
            <tr>
                <td valign="top"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
            </tr> 
            <tr>
                <td style="font-size:1px; height: 5px;">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right;"><asp:LinkButton ID="lbnLogin" runat="server" onclick="lbnLogin_Click" Text="Logga in"></asp:LinkButton></td>
            </tr>
            <tr>
                <td style="font-size:1px; height: 5px;">&nbsp;</td>
            </tr>
            <tr>
                <td><div id="loginError" runat="server" visible="false" style="border: solid 1px #DD3C10; background-color: #FFEBE8; padding: 5px;"><span class='Text11_505050'><asp:Label ID="lblLoginError" runat="server" /></span></div></td>
            </tr>
        </table>
    </div>     

</asp:Content>
