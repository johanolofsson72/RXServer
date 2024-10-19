<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageTemplate.ascx.cs" Inherits="Modules__System_PageTemplate_PageTemplate" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<div id="PageTemplate_holder" runat="server" visible="false" style="position:relative; float: left; display:inline; height: 35px; width: 900px;">
 
     <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>
 
    <script type="text/javascript">
        //<![CDATA[
        
        function showPageTemplate(SitId,PagId,ModId,Mode)
        {
            var oWnd = $find("<%=RadWindow1_PageTemplate.ClientID%>");
            oWnd.SetUrl("<%=RXServer.Lib.Common.Dynamic.CreateUrlPrefix()%>Modules/_System/PageTemplate/PageTemplate_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&Mode=" +Mode);
            oWnd.show();  
        }
        
        
        //]]>            
    </script>

    <telerik:RadWindow
      ID ="RadWindow1_PageTemplate" 
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
    
    <div id="PageTemplate_Info" style="position:relative; float: left; width: 900px; height: 25px; background-color: #666666;">
        <div style="position:relative; float: left; padding-top:5px; padding-left: 370px;"><asp:Literal ID="ltrPageTemplateImg" runat="server" /></div>
        <div style="position:relative; float: left; padding-top:3px; padding-left: 10px;"><asp:Literal ID="ltrPageTemplateTxt" runat="server" /></div>
    </div>


</div>