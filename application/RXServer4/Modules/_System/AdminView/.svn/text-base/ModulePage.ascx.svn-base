<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ModulePage.ascx.cs" Inherits="Modules__System_AdminView_ModulePage" %>

<asp:Label ID="Script" runat="server"></asp:Label>

<div id="ModulePage" runat="server" style="position:relative; float: left; width:100%;">
 
    <div id="ModuleSubMenu" runat="server" class="SubMenu_div">
        <asp:Literal ID="ltrModuleSubMenuList" runat="server" />
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
    
    
    <%--Page 1 :: List ModDef--%>
    
    <div id="ModulePage_1" runat="server" class="Page_div">
        <asp:Literal ID="ltrModDefList" runat="server" />            
    </div>
    
    <%--Page 2 :: List Modules--%>
    
    <div id="ModulePage_2" runat="server" class="Page_div">
        <asp:Literal ID="ltrModulesList" runat="server" />            
    </div>
    
   
</div>