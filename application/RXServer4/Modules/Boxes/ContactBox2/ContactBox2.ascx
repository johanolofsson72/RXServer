<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactBox2.ascx.cs" Inherits="Modules_Boxes_ContactBox2_ContactBox2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="ContactBox2_holder" runat="server">
    <div id="ContactBox2_admin" runat="server" visible="false">
        <script type="text/javascript">
            //<![CDATA[
            
             function showAdminContactBox2(SitId,PagId,ModId,Var)
            {
                var oWnd = $find("<%=RadWindow1_ContactBox2.ClientID%>");
                var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Boxes/ContactBox2/ContactBox2_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&Var=" + Var + "&UID=" + d.getMilliseconds());
                oWnd.show();  
            }

        </script>

        <telerik:RadWindow
          ID ="RadWindow1_ContactBox2" 
          VisibleTitlebar="True" 
          VisibleStatusbar="false"
          ReloadOnShow="true"
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
                    <td style="width:1px; font-size:1px;">&nbsp;</td>
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
    <div id="ContactBox2">    
        <h2><asp:Label ID="lblHeader" runat="server" /></h2>
        <p><asp:Label ID="lblText" runat="server" /></p>
        <h3><asp:Label ID="lblCategory" runat="server" /></h3>
        <asp:DropDownList ID="ddlCategory" CssClass="form_dropdown" runat="server"/>
        <h3><asp:Label ID="lblWhoareyou" runat="server" /></h3>
        <asp:DropDownList ID="ddlWhoareyou" CssClass="form_dropdown" runat="server"/>
        <h3><asp:Label ID="lblField1" runat="server" /></h3>
        <asp:TextBox ID="txtField1" CssClass="form_textbox" runat="server" />
        <h3><asp:Label ID="lblField2" runat="server" /></h3>
        <asp:TextBox ID="txtField2" CssClass="form_textbox" runat="server" />
        <h3><asp:Label ID="lblField3" runat="server" /></h3>
        <asp:TextBox ID="txtField3" CssClass="form_textbox" runat="server" />
        <h3><asp:Label ID="lblQuestion" runat="server" /></h3>
        <asp:TextBox ID="txtQuestion" CssClass="form_textarea" TextMode="MultiLine" runat="server" /><br />
        <table>
            <tr>
                <td style="width:20px;"><asp:CheckBox ID="cbPolicy" runat="server" /></td>
                <td></td>
                <td><asp:Label ID="lblPolicy" runat="server" /></td>
            </tr>
        </table>
        
        <div id="button"><asp:LinkButton ID="lbnSend" runat="server" onclick="lbnSend_Click" /></div>
        <br />
        <em class='success'><asp:Label ID="lblSuccess" runat="server" /></em><em class='error'><asp:Label ID="lblError" runat="server" /></em>
    </div>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="lbnSend">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlSubcategory" />
                <telerik:AjaxUpdatedControl ControlID="ddlWhoareyou" />
                <telerik:AjaxUpdatedControl ControlID="txtField1" />
                <telerik:AjaxUpdatedControl ControlID="txtField2" />
                <telerik:AjaxUpdatedControl ControlID="txtField3" />
                <telerik:AjaxUpdatedControl ControlID="txtQuestion" />
                <telerik:AjaxUpdatedControl ControlID="cbPolicy" />
                <telerik:AjaxUpdatedControl ControlID="lblSuccess" />
                <telerik:AjaxUpdatedControl ControlID="lblError" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
</div>
