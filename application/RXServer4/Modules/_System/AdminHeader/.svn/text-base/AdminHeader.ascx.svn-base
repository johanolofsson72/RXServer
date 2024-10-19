<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminHeader.ascx.cs" Inherits="Modules__System_AdminHeader_AdminHeader" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div id="headerAdmin_holder" visible="false" runat="server" style="position: relative; float: left; width: 900px; display:inline;">

    <script type="text/javascript">
        //<![CDATA[
        
        //  -----------------
        
        function showAdminTopMenu(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_AdminTopMenu.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/_System/AdminTopMenu/AdminTopMenu_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
        function showAdminMetaTags(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_AdminMetaTags.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/_System/AdminMetaTags/AdminMetaTags_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
        function showAdminDefault(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_AdminDefault.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/_System/AdminDefault/AdminDefault_Admin.aspx?SitId=1&PagId=3" + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
         function showAdminView(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_AdminView.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/_System/AdminView/AdminView_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        

        //]]>  
    </script>


    <telerik:RadWindow
      ID ="RadWindow1_AdminTopMenu" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
      Behaviors="Maximize, Close, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900"
      ReloadOnShow="true" 
      Runat = "server">
    </telerik:RadWindow >

    <telerik:RadWindow
      ID ="RadWindow1_AdminMetaTags"
      ReloadOnShow="true" 
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
  
   <telerik:RadWindow
      ID ="RadWindow1_AdminDefault"
      ReloadOnShow="true" 
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
    
    <telerik:RadWindow
      ID ="RadWindow1_AdminView" 
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

<div id="headerAdmin">
    <div id="headerAdmin_left" 	style="position: relative;float: left;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 10px; height: 35px;"><img src="~/App_Themes/WebAdmin/Images/admin_logo.gif" title="RX Server" runat="server" /></td>
                <td style="width: 10px;"></td>
                <td class="Text11_bold_white">RX Server Content Manager</td>
                <td style="width: 5px;"></td>
                <td class="Text11_lightgray">|</td>
                <td style="width: 5px;"></td>
                <td class="Text11_lightgray"><asp:Label ID="lblAdminWelcome" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div id="headerAdmin_right" style="position: relative;float: right;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 20px; height: 35px; text-align:center;">
                     <img id="Img6" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
                <td style="width: 20px;">
                    <asp:Literal ID="ltrEditTopMenuImg" runat="server" />
                </td>   
                <td>
                    <asp:Literal ID="ltrEditTopMenu" runat="server" />
                </td>
                <td style="width: 20px; text-align:center;">
                     <img id="Img5" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
                <td style="width: 20px;">
                    <asp:Literal ID="ltrEditSubMenuImg" runat="server"  />
                </td>   
                <td>
                    <asp:Literal ID="ltrEditSubMenu" runat="server" />
                </td>
                <td style="width: 20px; text-align:center;">
                     <img id="Img4" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
                <td style="width: 20px;">
                    <asp:Literal ID="ltrEditMetaTagsImg" runat="server"/>
                </td>   
                <td>
                    <asp:Literal ID="ltrEditMetaTags" runat="server" />
                </td>
                 <td style="width: 20px; text-align:center;">
                     <img id="Img8" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
                <td style="width: 20px;">
                    <asp:Literal ID="ltrEditDefaultImg" runat="server"/>
                </td>   
                <td>
                    <asp:Literal ID="ltrEditDefault" runat="server" />
                </td>
                <td style="width: 20px; text-align:center;">
                     <img id="Img3" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
                <td style="width: 20px;">
                    <asp:Literal ID="ltrAdminViewImg" runat="server"  />
                </td>   
                <td>
                    <asp:Literal ID="ltrAdminView" runat="server" />
                </td>
                <td style="width: 20px; text-align:center;">
                     <img id="Img2" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
                <td style="width: 20px;">
                    <asp:LinkButton ID="hplAdminLogoutImg" runat="server"                          
                        onclick="hplAdminLogoutImg_Click">
                        <img id="Img7" src="~/App_Themes/WebAdmin/Images/adminheader_logout.gif" alt="Lout Out" class="img_noborder" runat="server" />
                        </asp:LinkButton>
                </td>   
                <td>
                    <asp:LinkButton ID="hplAdminLogout" runat="server" CssClass="adminmenu" 
                        onclick="hplAdminLogout_Click">Logout</asp:LinkButton>
                </td>
                <td style="width: 10px; text-align:right;">
                     <img id="Img1" src="~/App_Themes/WebAdmin/Images/adminheader_divider.gif" alt="" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</div>
</div>