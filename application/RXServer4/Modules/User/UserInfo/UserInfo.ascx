<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="Modules_User_UserInfo_UserInfo" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="UserInfo_holder" runat="server">
    <div id="UserInfo_admin" runat="server" visible="false">
        <div id="adminbar" style="position:relative; float:left; height:35px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                        <asp:ImageButton ID="img_AdminMoveUp" ToolTip="MoveUp"
                            ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_moveup.gif" runat="server" onclick="img_AdminMoveUp_Click" /></td>
                    <td style="width:3px; font-size:1px;"><asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_divider.gif" /></td>
                    <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                        <asp:ImageButton ID="img_AdminMoveDown" ToolTip="MoveDown" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_movedown.gif" runat="server" onclick="img_AdminMoveDown_Click" /></td>
                    <td style="width:1px; font-size:1px;">&nbsp;</td>
                    <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                        <asp:ImageButton ID="imbAdminVisible" runat="server" onclick="img_AdminVisible_Click" /></td>
                </tr>
                <tr>
                    <td style="font-size:1px; height:5px; text-align:center;"><asp:Image ID="Image0" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_arrow_gray.gif" /></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
    <div id="TextBox">
            <div id="text_size" visible="false" runat="server" style="position: relative; float: left; padding-top: 10px; height: 15px; width: 100%; margin-bottom: 10px; border-bottom: solid 1px #E5E5E5; display:inline;">
                <div id="text_right" style="position: relative; float: right; text-align: right;">
                    <asp:Literal ID="ltrFontResizer" runat="server" />
                </div>
             </div>
            <div class="tb_main">
                <h2><asp:Label ID="lblHeader" runat="server" /></h2>
                <div id="IngressText" visible="false" runat="server"><p class="Ingress"><asp:Label ID="lblIngress" runat="server" /></p></div>
                <p><asp:Label ID="lblText" runat="server" /></p>
            </div>
            <asp:Literal ID="ltrFontLoader" Visible="true" runat="server" />
    </div>
</div>