﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditModules_2.ascx.cs" Inherits="Modules_Modules_EditModules_EditModules_2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div id="EditModuls_holder2" runat="server" visible="false">
    <script type="text/javascript">
        //<![CDATA[
        
        function showEditModules2(SitId,PagId,ModId,ConPa)
        {
            var oWnd = $find("<%=RadWindow1_EditModuls2.ClientID%>");
            var d = new Date();oWnd.SetUrl("<%=RXServer.Lib.Common.Dynamic.CreateUrlPrefix()%>Modules/Modules/EditModules/EditModules_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&ConPa=" + ConPa + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
        function showEditModules2_Small(SitId,PagId,ModId,ConPa)
        {
            var oWnd = $find("<%=RadWindow1_EditModuls2.ClientID%>");
            var d = new Date();oWnd.SetUrl("<%=RXServer.Lib.Common.Dynamic.CreateUrlPrefix()%>Modules/Modules/EditModules/EditModulesSmall_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&ConPa=" + ConPa + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
         function showEditModules2_Large(SitId,PagId,ModId,ConPa)
        {
            var oWnd = $find("<%=RadWindow1_EditModuls2.ClientID%>");
            var d = new Date();oWnd.SetUrl("<%=RXServer.Lib.Common.Dynamic.CreateUrlPrefix()%>Modules/Modules/EditModules/EditModulesLarge_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&ConPa=" + ConPa + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
         function showEditModules2_Medium(SitId,PagId,ModId,ConPa)
        {
            var oWnd = $find("<%=RadWindow1_EditModuls2.ClientID%>");
            var d = new Date();oWnd.SetUrl("<%=RXServer.Lib.Common.Dynamic.CreateUrlPrefix()%>Modules/Modules/EditModules/EditModulesMedium_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&ConPa=" + ConPa + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
            
        //]]>            
    </script>

    <telerik:RadWindow
      ID ="RadWindow1_EditModuls2" 
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

    <div id="EditModules2" style="position:relative; float: left; width: 100%; height: 25px; background-color: #666666; display:inline;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:5px; height: 25px; font-size:1px;">&nbsp;</td>
                <td><asp:Literal id="ltrTextImg" runat="server" /></td>
                <td style="width:5px; height: 25px; font-size:1px;">&nbsp;</td>
                <td><asp:Literal id="ltrText" runat="server" /></td>
            </tr>
             <tr>
                <td></td>
                <td style="font-size:1px; height:5px; text-align:center;"><asp:Image ID="Image0" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_arrow_gray.gif" /></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</div>