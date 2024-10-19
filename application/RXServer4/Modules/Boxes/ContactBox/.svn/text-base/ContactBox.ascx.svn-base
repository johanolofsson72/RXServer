<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactBox.ascx.cs" Inherits="Modules_Boxes_ContactBox_ContactBox" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div id="ContactBox_holder" runat="server">
    <div id="ContactBox">    
        <h2><asp:Label ID="lblHeader" runat="server" /></h2>
        <p><asp:Label ID="lblText" runat="server" /></p>
        <h3><asp:Label ID="lblCategory" runat="server" /></h3>
        <asp:DropDownList ID="ddlCategory" CssClass="form_dropdown" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged" />
        <h3><asp:Label ID="lblSubcategory" runat="server" /></h3>
        <asp:DropDownList ID="ddlSubcategory" CssClass="form_dropdown" runat="server"/>
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
        <br />
        <asp:CheckBox ID="cbPolicy" runat="server" /><asp:Label ID="lblPolicy" runat="server" />
        <div id="button"><asp:LinkButton ID="lbnSend" runat="server" onclick="lbnSend_Click" /></div>
        <br />
        <em class='success'><asp:Label ID="lblSuccess" runat="server" /></em><em class='error'><asp:Label ID="lblError" runat="server" /></em>
    </div>
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="ddlCategory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlSubcategory" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="lbnSend">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlCategory" />
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
