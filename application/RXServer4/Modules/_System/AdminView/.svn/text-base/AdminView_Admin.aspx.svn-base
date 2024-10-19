<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="AdminView_Admin.aspx.cs" Inherits="Modules__System_AdminUsers_AdminUsers_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="UserPage.ascx" TagName="UserPage" TagPrefix="uc1" %>
<%@ Register Src="RolePage.ascx" TagName="RolePage" TagPrefix="uc1" %>
<%@ Register Src="PagePage.ascx" TagName="PagePage" TagPrefix="uc1" %>
<%@ Register Src="ModulePage.ascx" TagName="ModulePage" TagPrefix="uc1" %>
<%@ Register Src="StartPage.ascx" TagName="StartPage" TagPrefix="uc1" %>
<%@ Register Src="ShopPage.ascx" TagName="ShopPage" TagPrefix="uc1" %>



<asp:Content ID="Content2" ContentPlaceHolderId="MainAdminMenuContent" runat="server">
    <!--  TopMenu --->
    <div id="adminUserTopMenu" style="position:relative; float: left; width:100%; height: 30px; background-color: #666666;">
        <asp:Literal ID="ltrAdminUserMenu" runat="server" />
    </div>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderId="MainAdminTextContent" runat="server">

     <%--Help Box :: Help Texts--%>
    
     <div id="Help" runat="server" class="Help_div">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 5px; font-size:1px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10px;"></td>
                    <td style="height: 20px;"><img src="../../../App_Themes/WebAdmin/Images/icon_help.gif" title="Help" /></td>
                    <td style="width: 10px;"></td>
                    <td class="Text13_bold_gray">Help</td>
                </tr>
            </table>
     </div>
     <div id="Help_Text" runat="server" class="Help_Text_div">
         <div id="Help_Text_main" runat="server" class="Help_Text_main_div">
            <asp:Literal ID="ltrHelpText" runat="server"></asp:Literal>
         </div>
     </div>
    
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!--  Start --->
    <uc1:StartPage ID="StartPage" runat="server" Visible="true" />  
    
    <!--  Users --->
    <uc1:UserPage ID="UserPage" runat="server" Visible="false" />     
    
    <!--  Roles --->
    <uc1:RolePage ID="RolePage" runat="server" Visible="false" />     
    
    <!--  Pages --->
    <uc1:PagePage ID="PagePage" runat="server" Visible="false" />   
    
    <!--  Modules --->
    <uc1:ModulePage ID="ModulePage" runat="server" Visible="false" />     
    
    <!--  Shop --->
    <uc1:ShopPage ID="ShopPage" runat="server" Visible="false" />

</asp:Content>


