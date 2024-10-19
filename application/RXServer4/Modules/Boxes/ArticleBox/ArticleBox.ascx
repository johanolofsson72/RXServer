<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleBox.ascx.cs" Inherits="Modules_Boxes_ArticleBox_ArticleBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="ArticleBox_admin" style="position: relative;" runat="server" visible="false">

    <script type="text/javascript">
        //<![CDATA[
        
        function showAdminArticleBox(SitId,PagId,ModId,Var)
        {
            var oWnd = $find("<%=RadWindow1_ArticleBox.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Boxes/ArticleBox/ArticleBox_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&Var=" + Var + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }

    </script>

    <telerik:RadWindow
      ID ="RadWindow1_ArticleBox" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      ReloadOnShow="true"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
     Behaviors="Close, Maximize, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >

    <div id="adminbar" style="position:relative; float:left; height:35px;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminEdit" ToolTip="Edit" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_edit.gif" runat="server" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #674343; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminDelete" ToolTip="Delete" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_delete_red.gif" runat="server" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminMoveUp" ToolTip="MoveUp"
                        ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_moveup.gif" runat="server" onclick="img_AdminMoveUp_Click" /></td>
                <td style="width:3px; font-size:1px;"><asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_divider.gif" /></td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminMoveDown" ToolTip="MoveDown" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_movedown.gif" runat="server" onclick="img_AdminMoveDown_Click" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="imbAdminVisible" runat="server" onclick="img_AdminVisible_Click" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="imbAdminSocial" onclick="img_AdminSocial_Click" runat="server" /></td>
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
<div id="ArticleBox_holder" runat="server" style="position: relative; float: left; width:590px;">

        <div id="ArticleBox" style="position: relative; float: left; width: 100%; display:inline; ">
            <div id="Media" runat="server" style="position: relative; float: left; padding-top:10px; width: 100%;">
                <asp:Literal id="ltrPuffImg" runat="server"></asp:Literal>
            </div>
            <div>
                <telerik:RadAjaxPanel ID="RAP_LiteBox" runat="server">
                <div id="text_size" visible="false" runat="server" style="position: relative; float: left; padding-top: 10px;  height: 15px; width: 100%; border-bottom: solid 1px #E5E5E5; display:inline;">
                    <div id="text_left" runat="server" style="position: relative; float: left; top: 2px;">
                        <asp:Label ID="lblUpdated" runat="server" CssClass="Text10_505050"></asp:Label></div>
                    <div id="text_right" runat="server" style="position: relative; float: right; text-align: right;">
                        <asp:ImageButton id="imbSmallText" runat="server" onclick="imbSmallText_Click" /><asp:ImageButton id="imbMediumText" runat="server" onclick="imbMediumText_Click" /><asp:ImageButton id="imbLargeText" runat="server" onclick="imbLargeText_Click" />
                    </div>
                    <div id="text_right2" runat="server" style="position: relative; float: right; text-align: right; padding-right: 4px; top: 2px;">
                        <asp:Label ID="lblFontsize" runat="server" CssClass="Text10_505050" /></div>  
                </div>
                <div id="content" runat="server" style="position: relative; float: left; padding-top: 10px; width: 100%;">
                    <h2><asp:Label ID="lblHeader" runat="server" /></h2>
                    <p class="Ingress"><asp:Label ID="lblIngress" runat="server" /></p>
                    <p><asp:Label ID="lblText" runat="server" /></p>
                </div>
                </telerik:RadAjaxPanel>
            </div>
           
        </div>
        <div id="ArticleBox_social" runat="server" visible="false" runat="server" style="position: relative; float: left; width: 100%; display:inline;">
            
            <div id="icons" runat="server" style="border-top: solid 1px #E1E1E1; padding-top: 4px; position: relative; float: left; width: 100%;">
                <div id="social_left" runat="server" style="position: relative; float: left;">
                    <asp:Literal ID="ltrSocial" runat="server"></asp:Literal>
                </div>
                <div id="social_right" runat="server" style="position: relative; float: right;">
                    <asp:Literal ID="ltrSpecial" runat="server"></asp:Literal>
                </div>
           </div>
        </div>
</div>