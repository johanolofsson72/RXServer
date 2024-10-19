<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="Modules_Menus_TopMenu_TopMenu" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../../Shop/SmallCart/SmallCart.ascx" tagname="SmallCart" tagprefix="RXServer" %>

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
    IconUrl="~/Images/Modules/HM/popup_icon_user.gif"
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
    Height="330"
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
    Height="500"
    Width="477" 
    Runat = "server">
    </telerik:RadWindow >


<div id="topmenu_holder">
    <div id="cart_holder">
        <RXServer:SmallCart ID="SmallCart1" runat="server" />
    </div>
    <div id="search_holder">
        <asp:Panel runat="server" DefaultButton="imbSearch">
            <table cellpadding="0" cellspacing="0">
                 <tr>
                    <td style="width:685px;">&nbsp;</td>
                    <td id="search_input">
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form_search" />
                    </td>
                    <td style="width:71px;">
                        <asp:ImageButton ID="imbSearch" runat="server" ImageUrl="~/Images/Modules/Search/btn_search.gif" onclick="imbSearch_Click"></asp:ImageButton>
                    </td>
                 </tr>
            </table>
        </asp:Panel>
    </div>	
    <div id="logo"><img src="Images/Site/logo.png" /></div>
    <div id="topmenu"><asp:Literal ID="ltrTopMenu" runat="server" /></div>
    <div id="logmenu">
         <div id="loginmenu" runat="server" style="position:relative; float: right; margin-top:6px;">
            <div id="tooltip_login_arrow" runat="server" visible="false" style="position:absolute; top:-2px; left:80px; z-index: 10; clear:left;"><img src='Images/Modules/HM/tooltip/arrow_down.gif' alt='' /></div>
            <div id="tooltip_login" visible="false" runat="server" style="position:absolute; top:-24px; left: 60px; z-index: 10;  clear:left;">
                <table cellpadding='0' cellspacing='0'>
                    <tr> 
                        <td id="tooltip_left" class='png_img'>&nbsp;</td>
                        <td id="tooltip_main"><h6><asp:Label ID="lblTooltipLogin" runat="server" /></h6></td>
                        <td id="tooltip_right" class='png_img'>&nbsp;</td>
                    </tr>
                </table>
            </div>
            <asp:placeholder id="ScriptHolder" runat="server"></asp:placeholder>
            <asp:Button ID="btnL" onclick="lbnLogin_Click" runat="server"  style="display : none;" />
            <table cellpadding="0" cellspacing="0">
                <tr>
<%--                    <td colspan='3' class="hm_menu_text">&nbsp;</td>--%>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
<%--                    <td><h5> <asp:Label id="lblLoginText2" runat="server" /></h5></td>--%>
                    <td>&nbsp;</td>
<%--                    <td colspan='5'><h5><asp:LinkButton ID="lbnForgotPass" runat="server" CssClass="whitelink" /></h5></td>--%>
                </tr>
                <tr>
<%--                    <td style="background-image: url('Images/Modules/HM/Buttons/btn_add_left.gif'); background-repeat:no-repeat; width: 22px; height: 20px;">&nbsp;</td>
                    <td style="background-image: url('Images/Modules/HM/Buttons/btn_add_bg.gif'); background-repeat:repeat-x;padding-bottom: 1px;"><asp:LinkButton ID="lbnCreateAccount" runat="server" CssClass="hm_btn2_link"></asp:LinkButton></td>
                    <td style="background-image: url('Images/Modules/HM/Buttons/btn_add_right.gif'); background-repeat:no-repeat; width: 12px; height: 20px;">&nbsp;</td>
                    <td style="width:27px; font-size:1px;">&nbsp;</td>
                    <td><asp:LinkButton ID="lbnCreateAccount" runat="server" CssClass="whitelink"/></td>
                    <td style="width:4px; font-size:1px;"></td>
                    <td valign="top" style="background-image: url('Images/Modules/LoginUser/form_login_username.gif'); background-repeat:no-repeat; width:134px; height: 10px; text-align:left;"><asp:TextBox ID="txtUsername" runat="server" CssClass="form_login_username" /></td>
                    <td style="width:4px; font-size:1px;">&nbsp;</td>
                    <td valign="top" style="background-image: url('Images/Modules/LoginUser/form_login_pass.gif'); background-repeat:no-repeat; width:119px; height: 10px; text-align:left;">
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form_login_pass" /></td>
                    <td style="width:4px; font-size:1px;"></td>
                    <td style="background-image: url('Images/Modules/LoginUser/btn_left.gif'); background-repeat:no-repeat; width: 9px; height: 20px;">&nbsp;</td>
                    <td style="background-image: url('Images/Modules/LoginUser/btn_bg.gif'); background-repeat:repeat-x;padding-bottom: 1px;"><asp:LinkButton ID="lbnLogin" runat="server" onclick="lbnLogin_Click" CssClass="whitelink"></asp:LinkButton></td>
                    <td style="background-image: url('Images/Modules/LoginUser/btn_right.gif'); background-repeat:no-repeat; width: 9px; height: 20px;">&nbsp;</td>--%>

                </tr>
            </table>
        </div>
        <div id="loggedmenu" runat="server" style="position:relative; float: right;">
            <div id="hello" runat="server" style="position:relative;  float: left; text-align: right; padding-right: 10px; color:#fff; font-size:11px; text-align:right; width: 370px;" >
                <asp:Literal ID="ltrWelcome" runat="server" />
            </div>
            <div id="menu" runat="server" style="position:relative;  float: right;  padding-top: 10px;" class='hm_menu_text'>
                <table cellpadding="0" cellspacing="0">
                    <tr>
<%--                        <td><asp:ImageButton id="imbMyProfile" runat="server" ImageUrl="~/Images/Modules/menu/icon_user.gif" ToolTip="" /></td>
                        <td style="width:4px; font-size:1px;">&nbsp;</td>
                        <td><asp:LinkButton id="lbnMyProfile" runat="server" CssClass="whitelink" /></td>
                        <td style="width:15px; font-size:1px;">&nbsp;</td>
                        <td><asp:ImageButton id="imbMyArticles" runat="server" ImageUrl="~/Images/Modules/menu/icon_movies.gif" ToolTip="" /></td>
                        <td style="width:4px; font-size:1px;">&nbsp;</td>
                        <td><asp:LinkButton id="lbnMyArticles" runat="server"  /></td>
                        <td style="width:15px; font-size:1px;">&nbsp;</td>
                        <td><asp:ImageButton id="imbLogout" runat="server" ImageUrl="~/Images/Modules/menu/icon_logout.gif" ToolTip="" OnClick="lbnLogout_Click" /></td>
                        <td style="width:4px; font-size:1px;">&nbsp;</td>
                        <td><asp:LinkButton id="lbnLogout" runat="server" OnClick="lbnLogout_Click" CssClass="whitelink" /></td>
                        <td style="width:15px; font-size:1px;">&nbsp;</td>--%>
                    </tr>
                </table>
            </div>

        </div>   
    </div>
</div>

<div id="modules_access" visible="false" runat="server">
    <script type="text/javascript">
        //<![CDATA[
        
        //  -----------------
        
        function showAdminDeleteModule(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_DeleteModule.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Modules/DeleteModule/DeleteModule_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId);
            oWnd.show();  
        }
        
         function showAdminDeleteComment(SitId,PagId,ObdId)
        {
            var oWnd = $find("<%=RadWindow1_DeleteComment.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Comments/DeleteComment/DeleteComment_Admin.aspx?SitId=1&PagId=" + PagId + "&ObdId=" + ObdId);
            oWnd.show();  
        }
        
   </script>
   
     <telerik:RadWindow
      ID ="RadWindow1_DeleteModule" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
     Behaviors="Close, Maximize, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >
    
    <telerik:RadWindow
      ID ="RadWindow1_DeleteComment" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
     Behaviors="Close, Maximize, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >    
</div>