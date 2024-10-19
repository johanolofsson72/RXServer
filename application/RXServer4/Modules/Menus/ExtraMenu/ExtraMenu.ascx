<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExtraMenu.ascx.cs" Inherits="Modules_Menus_ExtraMenu_ExtraMenu" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<script type="text/javascript">
    
    function showRegisterWindow(SitId,PagId,ModId)
    {
        var oWnd = $find("<%=RadWindow1_RegisterWindow.ClientID%>");
        var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/User/RegisterWindow/RegisterWindow.aspx?SitId=1&amp;PagId=" + PagId + "&amp;ModId=" + ModId + "&UID=" + d.getMilliseconds());
        oWnd.show();  
    }
    
    function showProfileWindow(SitId,PagId,ModId)
    {
        var oWnd = $find("<%=RadWindow1_ProfileWindow.ClientID%>");
        var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/User/ProfileWindow/ProfileWindow.aspx?SitId=1&amp;PagId=" + PagId + "&amp;ModId=" + ModId + "&UID=" + d.getMilliseconds());
        oWnd.show();  
        
    }
    
    function showMyArticlesWindow(SitId,PagId,ModId)
    {
        var oWnd = $find("<%=RadWindow1_MyArticlesWindow.ClientID%>");
        var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/User/MyArticlesWindow/MyArticlesWindow.aspx?SitId=1&amp;PagId=" + PagId + "&amp;ModId=" + ModId + "&UID=" + d.getMilliseconds());
        oWnd.show();  
        
    }
    
    function showForgotPassWindow(SitId,PagId,ModId)
    {
        var oWnd = $find("<%=RadWindow1_ForgotPassWindow.ClientID%>");
        var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/User/ForgotPassWindow/ForgotPassWindow.aspx?SitId=1&amp;PagId=" + PagId + "&amp;ModId=" + ModId + "&UID=" + d.getMilliseconds());
        oWnd.show();  
        
    }
    
</script>


    <telerik:RadWindow
      ID ="RadWindow1_MyArticlesWindow" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      IconUrl="~/Images/Modules/HM/winow_icon_my_articles.gif"
      Behaviors="Close" 
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >

    <telerik:RadWindow
    ID ="RadWindow1_ProfileWindow" 
    IconUrl="~/Images/Site/popup_icon_user.gif"
    VisibleTitlebar="True" 
    VisibleStatusbar="False"
    Behaviors="Close" 
    ReloadOnShow="true"     
    Skin="Telerik"
    Modal="true"
    Height="480"
    Width="477" 
    Runat = "server">
    </telerik:RadWindow >
    
    <telerik:RadWindow
    ID ="RadWindow1_ForgotPassWindow" 
    IconUrl="~/Images/Modules/HM/window_icon_forgot_password.gif"
    VisibleTitlebar="True" 
    VisibleStatusbar="False"
    Behaviors="Close" 
    ReloadOnShow="true"     
    Skin="Telerik"
    Modal="true"
    Height="320"
    Width="477" 
    Runat = "server">
    </telerik:RadWindow >
    
    <telerik:RadWindow
    ID ="RadWindow1_RegisterWindow" 
    IconUrl="~/Images/Modules/HM/window_icon_new_user.gif"
    VisibleTitlebar="True" 
    VisibleStatusbar="False"
    Behaviors="Close" 
    ReloadOnShow="true"
    Skin="Telerik"
    Modal="true"
    Height="360"
    Width="477" 
    Runat = "server">
    </telerik:RadWindow >


<div id="ExtraMenu_container">
     <div id="menu_icon" runat="server" style="position:absolute; left:34px; top: 7px;">
        <asp:Image id="imgMenuIcon" runat="server" ToolTip=""/>
     </div>
     <div id="loginmenu" runat="server" style="position:relative; float: right;">
        <div id="tooltip_login_arrow" runat="server" visible="false" style="position:absolute; top:-2px; left:140px; z-index: 10; clear:left;"><img src='Images/Modules/HM/tooltip/arrow_down.gif' alt='' /></div>
        <div id="tooltip_login" visible="false" runat="server" style="position:absolute; top:-24px; left:120px; z-index: 10; clear:left;">
            <table cellpadding='0' cellspacing='0'>
                <tr> 
                    <td id="tooltp_left" class='png_img'>&nbsp;</td>
                    <td id="tooltp_main"><asp:Label ID="lblTooltipLogin" runat="server" CssClass='hm_tooltip_text'/></td>
                    <td id="tooltp_right" class='png_img'>&nbsp;</td>
                </tr>
            </table>
        </div>
        <asp:placeholder id="ScriptHolder" runat="server"></asp:placeholder>
        <asp:Button ID="btnL" onclick="lbnLogin_Click" runat="server"  style="display : none;" />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td colspan='3' class="hm_menu_text">&nbsp;&nbsp;&nbsp;<asp:Label id="lblLoginText" runat="server" /></td>
                <td>&nbsp;</td>
                <td class="hm_menu_text">&nbsp;&nbsp;&nbsp;<asp:Label id="lblLoginText2" CssClass="hm_menu_text" runat="server" /></td>
                <td>&nbsp;</td>
                <td class="hm_menu_text">&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbnForgotPass" runat="server" CssClass="hm_menu_text"></asp:LinkButton></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>                
            </tr>
            <tr>
                <td id="add_btn_left">&nbsp;</td>
                <td id="add_btn_center"><asp:LinkButton ID="lbnCreateAccount" runat="server" CssClass="hm_btn2_link"></asp:LinkButton></td>
                <td id="add_btn_right">&nbsp;</td>
                <td style="width:27px; font-size:1px;">&nbsp;</td>
                <td id="username" valign="top"><asp:TextBox ID="txtUsername" runat="server" CssClass="form_login_username" /></td>
                <td style="width:4px; font-size:1px;">&nbsp;</td>
                <td id="pass" valign="top">
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form_login_pass" /></td>
                <td style="width:4px; font-size:1px;"></td>
                <td id="login_left">&nbsp;</td>
                <td id="login_center"><asp:LinkButton ID="lbnLogin" runat="server" onclick="lbnLogin_Click" CssClass="hm_btn_link"></asp:LinkButton></td>
                <td id="login_right">&nbsp;</td>
                <td style="width:8px; font-size:1px;">&nbsp;</td>
            </tr>
        </table>
    </div>
    <div id="loggedmenu" runat="server" style="position:relative; float: right;">
        <div id="menu" runat="server" style="position:relative;  float: right; padding-top: 20px;" class='hm_menu_text'>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><asp:ImageButton id="imbAddArticle" runat="server" ImageUrl="~/Images/Modules/menu/icon_add.gif" ToolTip="" /></td>
                    <td style="width:4px; font-size:1px;">&nbsp;</td>
                    <td><asp:LinkButton id="lbnAddArticle" runat="server" /></td>
                    <td style="width:15px; font-size:1px;">&nbsp;</td>
                    <td><asp:ImageButton id="imbMyProfile" runat="server" ImageUrl="~/Images/Modules/menu/icon_user.gif" ToolTip="" /></td>
                    <td style="width:4px; font-size:1px;">&nbsp;</td>
                    <td><asp:LinkButton id="lbnMyProfile" runat="server" /></td>
                    <td style="width:15px; font-size:1px;">&nbsp;</td>
                    <td><asp:ImageButton id="imbMyArticles" runat="server" ImageUrl="~/Images/Modules/menu/icon_movies.gif" ToolTip="" /></td>
                    <td style="width:4px; font-size:1px;">&nbsp;</td>
                    <td><asp:LinkButton id="lbnMyArticles" runat="server"  /></td>
                    <td style="width:15px; font-size:1px;">&nbsp;</td>
                    <td><asp:ImageButton id="imbLogout" runat="server" ImageUrl="~/Images/Modules/menu/icon_logout.gif" ToolTip="" OnClick="lbnLogout_Click" /></td>
                    <td style="width:4px; font-size:1px;">&nbsp;</td>
                    <td><asp:LinkButton id="lbnLogout" runat="server" OnClick="lbnLogout_Click" /></td>
                    <td style="width:15px; font-size:1px;">&nbsp;</td>
                </tr>
            </table>
        </div>
        <div id="hello" runat="server" style="position:relative;  float: right; padding-top: 8px; width: 80px; padding-right: 20px; color:#423922; font-size:11px;" >
            <asp:Literal ID="ltrWelcome" runat="server" />
        </div>
    </div>
</div>
