<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RolePage.ascx.cs" Inherits="Modules__System_AdminView_RolePage" %>

<asp:Label ID="Script" runat="server"></asp:Label>

<div id="RolePage" runat="server" style="position:relative; float: left; width:100%;">
 
    <div id="RoleSubMenu" runat="server" visible="false" class="SubMenu_div">
        <div style="position: relative; float: left;"><asp:Literal ID="ltrRoleSubMenuList" runat="server" /></div>
        <div style="position: relative; float: right;"><asp:Literal ID="ltrRoleSubMenuList2" runat="server" /></div>
    </div>
    
      <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" style="position:relative; float: left; width:100%; background-color: #F0EFBD; border: solid 1px #CCCCCC; margin-top: 15px; padding: 10px 0px 10px 8px;">
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
    
    <%--Page 1 :: List Roles--%>
    
    <div id="RolePage_1" runat="server" visible="false" style="position:relative; float: left; padding: 20px 10px 40px 10px; width:100%;">
        <asp:Literal ID="ltrRoleList" runat="server" />            
    </div>
    
     <%--Page 2 :: Edit Roles--%>
    
    <div id="RolePage_2" runat="server" visible="false" style="position:relative; float: left; padding: 20px 10px 40px 10px; width:100%;">
        <span class='Text18_bold_gray'>Edit Role</span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Rolename:&nbsp;<asp:Image id="Image1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtEditRoleName" class="form_textbox_200" runat="server" /></td>
            </tr>
        </table>     
        <br />
        <hr class='line' />    
        <br />
        <div style="position:relative; float: right;">
        <asp:Button ID="btnEditRole" Text="Edit Role" class="form_button" runat="server" onclick="btnEditRole_Click" />
        </div>
    
    </div>   
    
     <%--Page 3 :: Add Roles--%>
    
    <div id="RolePage_3" runat="server" visible="false" style="position:relative; float: left; padding: 20px 10px 40px 10px; width:100%;">
        <span class='Text18_bold_gray'>Add Role</span>
        <br />
        <hr class='line'/>
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Rolename:&nbsp;<asp:Image id="imgError3_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtRoleName" class="form_textbox_200" runat="server" /></td>
            </tr>
        </table>        
        <br />
        <hr class='line' />    
        <br />
        <asp:Button ID="btnAddRole" Text="Add Role" runat="server" class="form_button" onclick="btnAddRole_Click" />
    </div>
    
     <%--Page 4 :: ViewUsers in Role--%>
    
    <div id="RolePage_4" runat="server" visible="false" style="position:relative; float: left; padding: 20px 10px 40px 10px; width:100%;">
        <asp:Literal ID="Literal1" runat="server" />
    </div>
</div>