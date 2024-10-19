<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="AdminTopMenu_Admin.aspx.cs" Inherits="Modules__System_AdminTopMenu_AdminTopMenu_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <div id="AdminSubMenu" runat="server" visible="false" class="SubMenu_div">
        <div style="position: relative; float: left;"><asp:Literal ID="ltrAdminSubMenuList" runat="server" /></div>
        <div style="position: relative; float: right;"><asp:Literal ID="ltrAdminSubMenuList2" runat="server" /></div>
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
    
    
    <!--  Page1 --->
    <div id="Page_1" runat="server" visible="false" class="Page_div">
         <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage1" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br /> 
            <asp:Literal ID="ltrPageList" runat="server" />
        <br />
        <hr class='line' />    
        <br />
    </div>
   
    <!--  Page2 :: Add/Edit Page --->
    <div id="Page_2" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage2" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Name:&nbsp;<asp:Image id="imgError2_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtPageName" class="form_textbox_200" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">View rights:</td>
            </tr>
            <tr>
                <td><asp:CheckBoxList ID="chbListViewRights" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
			<tr>
                <td class="Text12_gray">Edit rights:</td>
            </tr>
            <tr>
                <td><asp:CheckBoxList ID="chbListEditRights" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <%--<tr>
             <td class="Text12_gray">Friendly URL:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtFriendlyUrl" class="form_textbox_200" runat="server" /></td>
            </tr>--%>
         </table>     
        <br />    
        <br />
        
        <div style="position:relative; float: right;">
            <asp:Button ID="btnAddPag" runat="server" Text="Save" class="form_button"  onclick="btnAddPag_Click" />
        </div>
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
