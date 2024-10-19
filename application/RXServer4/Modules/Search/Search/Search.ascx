<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Modules_Search_Search_Search" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="Search_holder" runat="server">
    <div id="Search_admin" style="position: relative;" runat="server" visible="false">

    <script type="text/javascript">
        //<![CDATA[
        
        function showAdminSearch(SitId,PagId,ModId)
        {
            var oWnd = $find("<%=RadWindow1_Search.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Search/Search/Search_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }

    </script>

    <telerik:RadWindow
      ID ="RadWindow1_Search" 
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
    <div id="Search">
        <h1><asp:Label ID="lblSuperHeader" runat="server" /></h1>
        <div id="Main">
            <!-- JOOL Start -->
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
	                <td>
                        <h2><asp:Label ID="lblResultTitle" runat="server" />:&nbsp;"<asp:Label ID="lblFrase" runat="server" />"</h2>
                    </td>
                </tr>
                <tr>
	                <td style="font-size:1px; height: 2px;">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblSearchHits" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblRes" runat="server"></asp:Label>
                                </td>
                                <td style="text-align: right;">
                                    <table width="100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td><asp:LinkButton ID="lnkSearchFirst" runat="server" OnClick="lnkSearchFirst_Click"></asp:LinkButton>&nbsp;
                                            <asp:LinkButton ID="lnkSearchPrev" runat="server" OnClick="lnkSearchPrev_Click"></asp:LinkButton>&nbsp;
                                            <asp:PlaceHolder ID="SearchHolder" runat="server"></asp:PlaceHolder>
                                            <asp:LinkButton ID="lnkSearchNext" runat="server" OnClick="lnkSearchNext_Click"></asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>    
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
	                <td style="font-size:1px; height: 4px;">&nbsp;</td>
                </tr>
                <tr>
	                <td style="font-size:1px; height: 20px;">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <p>
                            <asp:DataList ID="dlResult" CellPadding="0" CellSpacing="0" DataKeyField="obd_id" RepeatDirection="Vertical" runat="server">
                                <HeaderTemplate>
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                </HeaderTemplate>                            
                                <ItemTemplate>
                                        <tr>
                                            <td class='searchresult_header'><%# DataBinder.Eval(Container.DataItem, "obd_varchar2")%></a></td>
                                        </tr>
                                        <tr>
                                            <td class='searchresult_text'><%# DataBinder.Eval(Container.DataItem, "obd_varchar3")%></td>
                                        </tr>
                                        <tr>
                                            <td class='searchresult_text'><a href='<%# DataBinder.Eval(Container.DataItem, "obd_updatedby")%>'><%# RXMali.GetXMLNode("Modules/Search/read_more") %></a></td>
                                        </tr>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                        <tr>
                                            <td style="font-size:1px; height: 20px;">&nbsp;</td>
                                        </tr>
                                </SeparatorTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:DataList>
                        </p>
                    </td>
                </tr>
            </table>
            <!-- JOOL End -->
        </div>

    </div>        
</div>