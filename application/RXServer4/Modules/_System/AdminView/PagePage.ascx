<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PagePage.ascx.cs" Inherits="Modules__System_AdminView_PagePage" %>

<asp:Label ID="Script" runat="server"></asp:Label>

<div id="PagePage" runat="server" style="position:relative; float: left; width:100%;">
 
    <div id="PageSubMenu" runat="server" visible="false" class="SubMenu_div">
        <asp:Literal ID="ltrPageSubMenuList" runat="server" />
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
    
    
    <%--Page 1 :: List Pages--%>
    
    <div id="PagePage_1" runat="server" visible="false" class="Page_div">
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
    <div id="PagePage_2" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage2" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Page name:&nbsp;<asp:Image id="imgError2_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtPageName" class="form_textbox_200" runat="server" /></td>
            </tr>
         </table>     
        <br />
        <hr class='line' />    
        <br />
        <div style="position:relative; float: right;">
            <asp:Button ID="btnAddPag" runat="server" Text="Save" class="form_button"  onclick="btnAddPag_Click" />
        </div>
    </div> 
    
    <%--Page 3 :: List Modules on Pages--%>
    
    <div id="PagePage_3" runat="server" visible="false" class="Page_div">
        <asp:Literal ID="ltrModulesOnPageList" runat="server" />
    </div>
    
   
</div>