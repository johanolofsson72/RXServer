<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Unregister.ascx.cs" Inherits="Modules_Newsletter_Unregister_Unregister" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<div id="Unregister_admin" style="position: relative;" runat="server" visible="false">
     <script type="text/javascript">
        //<![CDATA[
        
        function showAdminUnregister(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_Unregister.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Newsletter/Unregister/Unregister_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }

    </script>

        <telerik:RadWindow
          ID ="RadWindow1_Unregister" 
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
<div id="Unregister">
    <h1><asp:Label ID="lblTitle" runat="server" /></h1>
    <p><asp:Label ID="lblText" runat="server" /></p> 
    <table cellpadding="0" cellspacing="0">
        <tr>
            <td style="padding: 10px;"><asp:TextBox ID="txtMail" CssClass="form_textbox" runat="server" /></td>
            <td style="padding: 10px;"><div id="button"><asp:LinkButton ID="lbnRemove" runat="server" onclick="lbnRemove_Click"  /></div></td>
        </tr>
        <tr>
            <td colspan="2"><em class='success'><asp:Label ID="lblSuccess" Visible="false" runat="server" /></em><em class='error'><asp:Label ID="lblError" Visible="false" runat="server" /></em></td>
        </tr>
        <tr>
            <td style="padding-top: 20px;">
                <asp:Repeater ID="rptGroups" runat="server" Visible="false" 
                    onitemcommand="rptGroups_ItemCommand" >
                    <HeaderTemplate>
                        <%# RXMali.GetXMLNode("Modules/UnregisterMail/found_groups") %>
                        <br />
                        <br />
                        <table cellpadding="0" cellspacing="0">
                     </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>&nbsp;</td>
                            <td style="padding: 10px;">
                               <%# DataBinder.Eval(Container, "DataItem.groupname")%>
                            </td>
                            <td style="padding: 10px; text-align: left;">
                                <asp:LinkButton ID="lbnGroupDelete" Text="Remove" runat="server" CommandArgument=' <%# DataBinder.Eval(Container, "DataItem.id")%>' ImageUrl="~/App_Themes/WebAdmin/Images/icon_bullet_delete.gif" OnCommand="lbnGroup_Command" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>   
     <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
         <AjaxSettings>
             <telerik:AjaxSetting AjaxControlID="lbnRemove">
                 <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="lblSuccess" />
                     <telerik:AjaxUpdatedControl ControlID="lblError" />
                     <telerik:AjaxUpdatedControl ControlID="rptGroups" />
                 </UpdatedControls>
             </telerik:AjaxSetting>
             <telerik:AjaxSetting AjaxControlID="lbnGroupDelete">
                 <UpdatedControls>
                     <telerik:AjaxUpdatedControl ControlID="lblSuccess" />
                     <telerik:AjaxUpdatedControl ControlID="lblError" />
                     <telerik:AjaxUpdatedControl ControlID="rptGroups" />
                 </UpdatedControls>
             </telerik:AjaxSetting>
         </AjaxSettings>
     </telerik:RadAjaxManagerProxy>
</div>


