<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeaserBox.ascx.cs" Inherits="Modules_Boxes_TeaserBox_TeaserBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="TeaserBox_holder" runat="server">
    <div id="TeaserBox" class="TeaserBox" style="text-align:left; font-size:1px; padding-bottom:20px;" runat="server">
        <script type="text/javascript">
            //<![CDATA[
            
            function showArticleBox(PagId,ModId,Var)
            {
                var oWnd = $find('<%=RadWindow2_TeaserBox.ClientID%>');
			    oWnd.SetUrl('http://<%= Request.Url.Authority + Request.ApplicationPath %>/Modules/Boxes/TeaserBox/TeaserBox_Article.aspx?SitId=1&PagId=' + PagId + '&ModId=' + ModId + '&Var=' + Var);
                oWnd.show();  
            }

        </script>
        <telerik:RadWindow
          ID ="RadWindow2_TeaserBox" 
          VisibleTitlebar="True" 
          VisibleStatusbar="false"
          ReloadOnShow="true"          
          Behaviors="Close, Move"
          Modal="true"
          Skin="Telerik"
          Height="260"
          Width="450" 
          AutoSize="true"
          Runat = "server">
        </telerik:RadWindow >
        
        <div id="tb_top">&nbsp;</div>
        <div id="tb_main">
            <asp:Image ID="imgMedia" runat="server" />
            <h2><asp:Label ID="lblHeader" runat="server" /></h2>
            <p><asp:Label ID="lblText" runat="server" /></p>
            <div style="width:100%; text-align:right; padding-bottom: 10px;"><asp:Literal ID="ltrReadMore" runat="server" /></div>
        </div>
        <div id="tb_bottom">&nbsp;</div>
    </div>
</div>