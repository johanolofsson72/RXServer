<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserPage.ascx.cs" Inherits="Modules__System_AdminView_UserPage" %>

<div id="UserPage" runat="server" style="position:relative; float: left; width:100%;">
    <div id="UserSubMenu" runat="server" class="SubMenu_div">
        <div style="position: relative; float: left;">        
            <table cellspacing='0' cellpadding='0' style='border:0px;'>
                <tr>
                    <td style='width:10px; height:34px;'></td>
                    <td class='Text14_bold_gray'>View by Role:</td>
                    <td style='width:10px; height:34px;'></td>
                    <td><asp:DropDownList ID="ddlUserRoles" runat="server" 
                            onselectedindexchanged="ddlUserRoles_SelectedIndexChanged" CssClass="form_dropdown_400_gray" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
            </table>
        
<%--        <asp:Literal ID="ltrUserSubMenuList" runat="server" />--%>
        </div>
        <div style="position: relative; float: right;"><asp:Literal ID="ltrUserSubMenuList2" runat="server" /></div>
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
    
    
    <%--Page 1 :: List all Users--%>
    
    <div id="UserPage_1" runat="server" visible="false" class="Page_div">
        <asp:Literal ID="ltrUserList" runat="server" />            
    </div>
    
    
    <%--Page 2 :: ViewEdit User--%>
    
    <div id="UserPage_2" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'>Edit/View User</span>
        <br />
        <hr class='line' />
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class='Text12_gray'>Username:&nbsp;<asp:Image id="imgError2_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                <td style='width:10px;'>&nbsp;</td>
                <td class='Text12_gray'>Mail:&nbsp;<asp:Image id="imgError2_2" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                <td style='width:10px;'>&nbsp;</td>
                <td class='Text12_gray'>Role:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtUsrUsername" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td>                
                <td><asp:TextBox ID="txtUsrMail" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td>                
                <td><asp:DropDownList ID="ddlUsrRoles" class="form_dropdown_200" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class='Text12_gray'>Firstname:</td>
                <td style='width:10px;'>&nbsp;</td>
                <td class='Text12_gray'>Middlename:</td>
                <td style='width:10px;'>&nbsp;</td>
                <td class='Text12_gray'>Lastname:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtUsrFirstName" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td>                
                <td><asp:TextBox ID="txtUsrMiddleName" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td>
                <td><asp:TextBox ID="txtUsrLastName" class="form_textbox_200" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class='Text12_gray'>Address:</td>
                <td style='width:10px;'>&nbsp;</td> 
                <td class='Text12_gray'>C/O:</td>
                <td style='width:10px;'>&nbsp;</td> 
                <td style='width:10px;'>&nbsp;</td> 
            </tr>
            <tr>
                <td><asp:TextBox ID="txtUsrAddress" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td> 
                <td><asp:TextBox ID="txtUsrCO" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td> 
                <td style='width:10px;'>&nbsp;</td> 
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class='Text12_gray'>Postal Code:</td>
                <td style='width:10px;'>&nbsp;</td> 
                <td class='Text12_gray'>City:</td>
                <td style='width:10px;'>&nbsp;</td> 
                <td class='Text12_gray'>Country:</td>
                <td style='width:10px;'>&nbsp;</td> 
            </tr>
            <tr>
                <td><asp:TextBox ID="txtUsrPostalCode" class="form_textbox_200" runat="server" /></td> 
                <td style='width:10px;'>&nbsp;</td>                
                <td><asp:TextBox ID="txtUsrCity" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td> 
                <td><asp:TextBox ID="txtUsrCountry" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td> 
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class='Text12_gray'>Phone:</td>
                <td style='width:10px;'>&nbsp;</td> 
                <td class='Text12_gray'>Mobile:</td>
                <td style='width:10px;'>&nbsp;</td> 
                <td class='Text12_gray'>Fax:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtUsrPhone" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td> 
                <td><asp:TextBox ID="txtUsrMobile" class="form_textbox_200" runat="server" /></td>
                <td style='width:10px;'>&nbsp;</td> 
                <td><asp:TextBox ID="txtUsrFax" class="form_textbox_200" runat="server" /></td>
            </tr>
        </table>  
        <br />
        <hr  class='line' />    
        <br />
        <div style="position:relative; float: right;">
        <asp:Button ID="btnEditUser" Text="Save" runat="server" class="form_button" onclick="btnEditUser_Click" />
        </div>
        
    </div>
    
    
    <%--Page 3 :: Add Users--%>
    
    <div id="UserPage_3" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'>Create User</span>
        <br />
        <hr class='line' />
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3" class='Text12_gray'>Role:&nbsp;<asp:Image id="imgError3_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td colspan="3"><asp:DropDownList ID="ddlRoles" class='form_dropdown_200' runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class='Text12_gray'>Mail:&nbsp;<asp:Image id="imgError3_2" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td colspan="3"><asp:TextBox ID="txtEmail" class='form_textbox_200' runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class='Text12_gray'>Username:&nbsp;<asp:Image id="imgError3_3" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td colspan="3"><asp:TextBox ID="txtUsername" class='form_textbox_200' runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class='Text12_gray'>Password:&nbsp;<asp:Image id="imgError3_4a" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                <td style='width:10px;'>&nbsp;</td>
                <td class='Text12_gray'>Retype Password:&nbsp;<asp:Image id="imgError3_4b" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox TextMode="Password" ID="txtPassword" class='form_textbox_200' runat="server" /></td>
                <td></td>
                <td><asp:TextBox TextMode="Password" ID="txtPassword2" class='form_textbox_200' runat="server" /></td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <!--<tr>
                <td colspan="3" class='Text12_gray'>
                <asp:RadioButton id="active" runat="server" GroupName="addUser" checked="true"/>Active
                <asp:RadioButton id="deactive" runat="server" GroupName="addUser" />Need to be active (sending mail)</td>
            </tr>-->       
        </table>
        <br />
        <hr class='line' />    
        <br />
        <div style="position:relative; float: right;">
            <asp:Button ID="btnAddUser" Text="Save" runat="server" class="form_button" onclick="btnAddUser_Click" />
        </div>    
    </div>
</div>