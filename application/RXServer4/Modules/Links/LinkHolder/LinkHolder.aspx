<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkHolder.aspx.cs" Inherits="Modules_Links_LinkHolder_LinkHolder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Internal Link</title>
    <link href="~/App_Themes/WebAdmin/admin.css" rel="stylesheet" type="text/css" />
</head>
<body  style="background-color:#ebebeb;">
<form id="form1" runat="server">
    <div>
        <table style="width: 100%; border: 0px;" cellspacing="0" cellpadding="0">
            <tr>
                <td class="Text11_gray">Level 1</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLevel1" CssClass="form_dropdown_200" OnSelectedIndexChanged="ddlLevel1_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
                <tr>
                <td class="Text11_gray">Level 2</td>
            </tr>            
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLevel2" CssClass="form_dropdown_200" OnSelectedIndexChanged="ddlLevel2_SelectedIndexChanged" runat="server"  AutoPostBack="True"></asp:DropDownList>
               </td>
            </tr> 
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
                <tr>
                <td class="Text11_gray">Level 3</td>
            </tr>             
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLevel3" CssClass="form_dropdown_200" OnSelectedIndexChanged="ddlLevel3_SelectedIndexChanged" runat="server"  AutoPostBack="True"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
                <tr>
                <td class="Text11_gray">Level 4</td>
            </tr> 
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLevel4" CssClass="form_dropdown_200" OnSelectedIndexChanged="ddlLevel4_SelectedIndexChanged"  Visible="true" AutoPostBack="True" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
                <tr>
                <td class="Text11_gray">Level 5</td>
            </tr> 
            <tr>
                <td>
                    <asp:DropDownList ID="ddlLevel5" CssClass="form_dropdown_200" OnSelectedIndexChanged="ddlLevel5_SelectedIndexChanged"  Visible="true" AutoPostBack="True" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
                <tr>
                <td class="Text11_gray">Link text:</td>
            </tr> 
            <tr>
                <td>
                    <asp:TextBox ID="linkName" CssClass="form_textbox_200" runat="server" />
                    <asp:TextBox ID="linkUrl" style="visibility:hidden;" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height:5px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td><input type="button" onclick="javascript:insertLink();" value="Insert Link"/></td>
            </tr> 
        </table>
            
        <asp:Literal ID="ltrJavaScript" runat="server" />
    </div>
	</form>
</body>
</html>