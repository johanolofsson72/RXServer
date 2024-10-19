<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="Modules_Print_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../../../App_Themes/WebAdmin/print.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="print" style="margin:0px; padding:20px 20px 20px 20px; width: 530px;">
        <div id="Title" runat="server" style="border-bottom: solid 2px black; width: 100%;">
            <table width="530" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="290" valign="middle" align="left" class="printtitle">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                   </td>
                    <td width="240" valign="middle" align="right">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="middle" class="printinfo"><asp:Label ID="lblTitleText" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="font-size:1px; height:5px;">&nbsp;</td>
                </tr>
        </table>
        </div>
        <div id="Header" runat="server" visible="false" style="padding-bottom: 20px; width: 100%; padding-top: 20px;" class="printrubrik"><asp:Label ID="lblHeader" runat="server"></asp:Label></div>
        <div id="Ingress" runat="server" visible="false" style="padding-bottom: 20px; width: 100%;" class="printingress"><asp:Label ID="lblIngress" runat="server" /></div>
        <div id="Text" runat="server" visible="false" style="padding-bottom: 20px; width: 100%;" class="printtext"><asp:Label ID="lblText" runat="server"></asp:Label></div>

        <script type="text/javascript">
             window.print();
        </script>
    </div>
    </form>
</body>
</html>
