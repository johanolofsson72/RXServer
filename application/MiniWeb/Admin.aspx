<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table background="images/login.gif" align="center" width="263" style="height: 250px">
        <tr height="20">
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td style="width:30px"></td>
            <td>
                <asp:login id="loginctrl"  VisibleWhenLoggedIn="true" DisplayRememberMe="false" DestinationPageUrl="Om_izon.aspx" runat="server" OnAuthenticate="loginctrl_Authenticate" PasswordLabelText="Pass:" UserNameLabelText="User:" Font-Names="Verdana" Font-Size="X-Small" Font-Bold="False" ForeColor="Black" LoginButtonText="Login" TitleText="">
                </asp:login>
            </td>
        </tr>
     </table>
    
     
  
    </div>
    </form>
</body>
</html>
