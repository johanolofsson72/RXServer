<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="RSSBox_Admin.aspx.cs" Inherits="Modules_Boxes_RSSBox_RSSBox_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/Modules/Links/InternalLink/InternalLink.ascx" TagName="InternalLink" TagPrefix="uc1" %>

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
     
      <%--Success Box :: List all success--%>
    
     <div id="MessageBox" runat="server" visible="false" class="MessageBox_div">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_success_small.gif" title="Success" /></td>
                <td style="width: 10px;"></td>
                <td class="Text12_bold_orange" valign="middle">Success!</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td class="Text12_gray"><asp:Literal ID="ltrMessage" runat="server"/></td>
            </tr>
        </table>
     </div>


 
    <!--  Page1 :: Edit Data --->
    <div id="Page_1" runat="server" visible="false" class="Page_div">
    <telerik:RadAjaxPanel ID="RAP_Admin" runat="server">
        <span class='Text18_bold_gray'>Edit RSS</span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Size:&nbsp;<asp:Image id="imgError1_3" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="ddlModels" class="form_dropdown_200" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Align:</td>
            </tr>
            <tr>
                <td class="Text12_gray"><asp:RadioButton ID="rbFloatLeft" runat="server" GroupName="float" />&nbsp;Left&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFloatRight" runat="server" GroupName="float" />&nbsp;Right</td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Title:&nbsp;<asp:Image id="imgError1_2" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtTitle" class="form_textbox_bold_600" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
<%--            <tr>
                <td class="Text12_gray">Header:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtHeader" class="form_textbox_bold_600" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>--%>
            <tr>
                <td class="Text12_gray">RSS Url:&nbsp;<asp:Image id="imgError1_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtRSS" class="form_textbox_bold_600" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
             <tr>
                <td class="Text12_gray">Default amount:</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlAmount" class="form_dropdown_200" runat="server" />
                </td>
            </tr>
         </table>     
        <br />
        <hr class='line' />    
        <br />
        </telerik:RadAjaxPanel> 
        
        <div style="position:relative; float: right;">
        <asp:Button ID="btnSaveData" runat="server" Text="Save & Close" class="form_button" 
            onclick="btnSaveData_Click" />
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