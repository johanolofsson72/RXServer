<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="DeleteThread_Admin.aspx.cs" Inherits="Modules_Boxes_Forum_DeleteThread_DeleteThread_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>
  
    <div id="SubMenu" runat="server" visible="false" class="SubMenu_div">
        <asp:Literal ID="ltrSubMenuList" runat="server" />
    </div>
    
     <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" visible="false" class="ErrorBox_div">
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
 
  
     <!--  Page1 :: Delete Module --->
    <div id="Page_1" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage1" runat="server" /></span>
        <br />
        <hr class='line' />
        <br />
        <table style="width: 100%;" border="0" cellpadding="0" cellspacing="5">
            <tr>
                <td class='Text12_gray'>Are you sure you want to remove this thread (including all posts)?</td>
            </tr>
        </table>        
        
        <br />
        <hr class='line' />    
        <br />
        <asp:Button id="btnDeleteThread" runat="server" class="form_button" 
            Text="Delete Thread" onclick="btnDeleteThread_Click" />
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