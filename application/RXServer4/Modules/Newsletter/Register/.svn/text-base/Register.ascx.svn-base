<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Register.ascx.cs" Inherits="Modules_Newsletter_Register_Register" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="Register_holder" runat="server">
     <div id="Register">
        <div id="r_top">&nbsp;</div>
        <div id="r_main">
           <div id="r_reload" runat="server">
                <asp:Literal ID="ltrMedia" runat="server"/>
                <h2><asp:Label ID="lblHeader" runat="server" /></h2>
                <p><asp:Label ID="lblText" runat="server" /></p>
                <table cellpadding="0" cellspacing="0" style="width:100%;">
                    <tr>
                        <td style="padding-bottom: 10px;"><asp:DropDownList ID="ddlMailGroup" CssClass="form_dropdown" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="padding-bottom: 10px;"><asp:TextBox ID="txtMail" CssClass="form_textbox" runat="server" /><br /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-bottom: 10px;"><div id="r_button">
                            <asp:LinkButton ID="lbnSignUp" runat="server" onclick="lbnSignUp_Click" /></div></td>
                    </tr>
                    <tr>
                        <td><em class='success'><asp:Label ID="lblSuccess" Visible="false" runat="server" /></em><em class='error'><asp:Label ID="lblError" Visible="false" runat="server" /></em></td>
                    </tr>
                    <tr>
                        <td style="padding: 10px 0px 0px 0px; text-align:center"><asp:HyperLink ID="hplUnregister" CssClass="remove" runat="server" /><br /></td>
                    </tr>
                </table>
             </div>
        </div>
        <div id="r_bottom">&nbsp;</div>
    </div>
    
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lbnSignUp">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblSuccess" />
                    <telerik:AjaxUpdatedControl ControlID="lblError" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
</div>


