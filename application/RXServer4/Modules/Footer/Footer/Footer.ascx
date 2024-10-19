<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Footer.ascx.cs" Inherits="Modules_Footer_Footer_Footer" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="Footer_admin" style="position: relative;" runat="server" visible="false">
     <script type="text/javascript">
        //<![CDATA[
        
        function showAdminFooter(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_Footer.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Footer/Footer/Footer_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }

    </script>

        <telerik:RadWindow
          ID ="RadWindow1_Footer" 
          VisibleTitlebar="True" 
          VisibleStatusbar="false"
          IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
         Behaviors="Maximize, Close, Move"
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
            </tr>
            <tr>
                <td style="font-size:1px; height:5px; text-align:center;"><asp:Image ID="Image0" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_arrow_gray.gif" /></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</div>
<div id="footer_holder">
    <div class="column_left">
        <p class='Copyright'><asp:Label ID="lblCopyright" runat="server"/></p>
    </div>
    <div class="column_divider">&nbsp;</div>
    <div class="column_middle">
        <p><asp:Label ID="lblText2" runat="server" /></p>
    </div>
    <div class="column_divider">&nbsp;</div>
    <div class="column_middle">
        <p><asp:Label ID="lblText3" runat="server" /></p>
    </div>
    <div class="column_divider">&nbsp;</div>
    <div class="column_right">
        <p><asp:Label ID="lblText4" runat="server" /></p>
    </div>
    <div style="position: absolute; bottom: 0px; right: 0px; padding-right: 15px;">
		<asp:HyperLink ID="hplLogin" runat="server" NavigateUrl="~/rxlogin/default.aspx">Login</asp:HyperLink>
		<asp:LinkButton ID="lnbLogout" runat="server" onclick="lnbLogout_Click">Logout</asp:LinkButton>
    </div>
</div>
