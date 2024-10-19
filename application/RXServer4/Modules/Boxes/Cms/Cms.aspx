<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="Cms.aspx.cs" Inherits="Modules_Boxes_Cms_Cms" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script>
        function doGreen(id){
            var o = document.getElementById(id);
            if( o != null ){
                o.style.color = "green";
            }
        }
        function doBlink1(id, speed){
            if(speed == null) speed = 500;
            var o = document.getElementById(id);
            if( o != null ){
                o.style.color = (o.style.color != "orange")? "orange" : "black";
                setTimeout('doBlink1("' + id + '")', speed);
            }
        }
        function doBlink2(id, speed){
            if(speed == null) speed = 500;
            var o = document.getElementById(id);
            if( o != null ){
                o.style.color = (o.style.color != "red")? "red" : "black";
                setTimeout('doBlink2("' + id + '")', speed);
            }
        }
        function doBlink3(id, speed){
            if(speed == null) speed = 500;
            var o = document.getElementById(id);
            if( o != null ){
                o.style.color = (o.style.color != "red")? "red" : "black";
                setTimeout('doBlink3("' + id + '")', speed);
            }
        }
        function doBlink4(id, speed){
            if(speed == null) speed = 500;
            var o = document.getElementById(id);
            if( o != null ){
                o.style.color = (o.style.color != "red")? "red" : "black";
                setTimeout('doBlink4("' + id + '")', speed);
            }
        }
    </script>
</head>
<body onload="">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Skin="Default" AnimationDuration="500" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <div>
        <asp:Panel ID="Panel1" Visible="false" runat="server">
            <table border="0" cellpadding="0" cellspacing="0" width="640" align="left">
                <tr>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="50"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="100"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                </tr>
                <tr>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td align="right">User:</td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                </tr>
                <tr>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td align="right">Pass:</td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td><asp:TextBox ID="txtPass" TextMode="Password" runat="server"></asp:TextBox></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                </tr>
                <tr>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                </tr>
                <tr>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                    <td><asp:Button ID="btnLogin" runat="server" Text="Logga in" 
                            onclick="btnLogin_Click" /></td>
                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                </tr>
                <tr>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="50"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="100"></td>
                    <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="Panel2" Visible="false" runat="server">
        <telerik:RadAjaxPanel ID="RadAjaxPanel5" runat="server" LoadingPanelID="RadAjaxLoadingPanel1">
        <b>Nuvarande kontakt/nätverkstatus:</b>
        <br />
        Antal bokade möten med helt nya kontakter fram till i dag:&nbsp;<asp:Label ID="lblTotalNewEvents" runat="server" Text="0"></asp:Label> 
        &nbsp;av&nbsp;
        <asp:Label ID="lblEventBudget" runat="server" Text="0"></asp:Label>&nbsp;(baserat på budgeterade minst 7 möten per vecka fom 2011-08-01)
        <br />
        Antal bokade möten fram till idag:&nbsp;<asp:Label ID="lblEventBookedTotal" runat="server" Text="0"></asp:Label> 
        <br />
        Antal utförda möten fram till idag:&nbsp;<asp:Label ID="lblEventPerformed" runat="server" Text="0"></asp:Label> 
        <br /><br />
        <telerik:RadTabStrip ID="RadTabStrip1" SelectedIndex="5" CausesValidation="false" MultiPageID="RadMultiPage1" runat="server">
            <Tabs>
                <telerik:RadTab Text="Ny kontakt"></telerik:RadTab>
                <telerik:RadTab Text="Nytt möte-, telefon el. Event"></telerik:RadTab>
                <telerik:RadTab Text="Alla Kontakter"></telerik:RadTab>
                <telerik:RadTab Text="Alla Företag"></telerik:RadTab>
                <telerik:RadTab Text="Alla Möten"></telerik:RadTab>
                <telerik:RadTab Text="Min ToDo"></telerik:RadTab>
            </Tabs> 
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" SelectedIndex="5" runat="server">
            <telerik:RadPageView ID="NewContact" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" runat="server">
                <telerik:RadTabStrip ID="RadTabStrip2" SelectedIndex="0" MultiPageID="RadMultiPage2" runat="server">
                    <Tabs>
                        <telerik:RadTab Text="Steg1"></telerik:RadTab>
                        <telerik:RadTab Text="Steg2"></telerik:RadTab>
                        <telerik:RadTab Text="Steg3"></telerik:RadTab>
                    </Tabs> 
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage2" SelectedIndex="0" runat="server">
                    <telerik:RadPageView ID="RadPageView4" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" width="640">
                            <tr>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="270"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Företag:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtCompany" Width="200" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" ControlToValidate="txtCompany" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td align="left"><asp:CheckBox ID="chkOldCompany" Text="  Tidigare kontakt" Checked="false" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="6"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Namn:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtName" Width="200" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" ControlToValidate="txtName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="270"></td>
                            </tr>
                            <tr>
                                <td colspan="6"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Roll:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtRole" Width="200" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" ControlToValidate="txtRole" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="270"></td>
                            </tr>
                            <tr>
                                <td colspan="6"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Telefon:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtPhone" Width="200" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator4" ControlToValidate="txtPhone" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="270"></td>
                            </tr>
                            <tr>
                                <td colspan="6"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Mail:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtMail" Width="200" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator5" ControlToValidate="txtMail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" 
                                        ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" 
                                        ControlToValidate="txtMail"></asp:RegularExpressionValidator></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="270"></td>
                            </tr>
                            <tr>
                                <td colspan="6"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:LinkButton ID="LinkButton1" Text="nästa ->" runat="server" 
                                        onclick="LinkButton1_Click" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="270"></td>
                            </tr>
                            <tr>
                                <td colspan="6"><img alt="" height="40" src="pixel_trans.gif" width="600"></td>
                            </tr>
                        </table>
                    </telerik:RadPageView> 
                    <telerik:RadPageView ID="RadPageView5" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" width="640">
                            <tr>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Referrens:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:DropDownList ID="rlbRelations" AutoPostBack="true" runat="server" 
                                        OnSelectedIndexChanged="rlbRelations_SelectedIndexChanged" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtRelation" Visible="false" runat="server"></asp:TextBox>
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Nätverk:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:DropDownList ID="rlbNetworks" AutoPostBack="true" runat="server" 
                                        OnSelectedIndexChanged="rlbNetworks_SelectedIndexChanged" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="txtNetwork" Visible="false" runat="server"></asp:TextBox>
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:LinkButton ID="LinkButton2" Text="nästa ->" runat="server" 
                                        onclick="LinkButton2_Click" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="40" src="pixel_trans.gif" width="600"></td>
                            </tr>
                        </table>
                    </telerik:RadPageView> 
                    <telerik:RadPageView ID="RadPageView6" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" width="640">
                            <tr>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">Kommentar:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtComment" runat="server" Height="176px" TextMode="MultiLine" Width="246px"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Nytt möte:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:CheckBox ID="chkMeeting" Checked="false" runat="server" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:LinkButton ID="LinkButton3" Text="slutför" runat="server" 
                                        onclick="LinkButton3_Click" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="40" src="pixel_trans.gif" width="600"></td>
                            </tr>
                        </table>
                    </telerik:RadPageView> 
                </telerik:RadMultiPage>
            </telerik:RadPageView> 
            <telerik:RadPageView ID="NewEvent" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" runat="server">
                <telerik:RadTabStrip ID="RadTabStrip3" SelectedIndex="0" CausesValidation="false" MultiPageID="RadMultiPage3" runat="server">
                    <Tabs>
                        <telerik:RadTab Text="Steg1"></telerik:RadTab>
                    </Tabs> 
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage3" SelectedIndex="0" runat="server">
                    <telerik:RadPageView ID="RadPageView8" runat="server">
                        <table border="0" cellpadding="0" cellspacing="0" width="640">
                            <tr>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="30" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr><td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Typ:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:DropDownList ID="ddType" runat="server">
                                        <asp:ListItem Selected="true" Text="Telefon" Value="Telefon" />
                                        <asp:ListItem Text="Möte" Value="Möte" />
                                        <asp:ListItem Text="Event" Value="Event" />
                                    </asp:DropDownList>
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Titel:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtETitle" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Företag:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:DropDownList ID="ddECompanies" AutoPostBack="true" runat="server" 
                                        onselectedindexchanged="ddECompanies_SelectedIndexChanged"  />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Kontakt:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:DropDownList ID="ddEContacts" AutoPostBack="true" runat="server" 
                                        onselectedindexchanged="ddEContacts_SelectedIndexChanged" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Telefon:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:Label ID="lblEPhone" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Mail:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:HyperLink ID="lblEMail" runat="server"></asp:HyperLink></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Plats:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtEPlace" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Tilldelad:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:DropDownList ID="ddWho" runat="server">
                                        <asp:ListItem Selected="true" Text="Charlie Jolin" Value="Charlie Jolin" />
                                        <asp:ListItem Text="Björn Andersson" Value="Björn Andersson" />
                                        <asp:ListItem Text="Johan Olofsson" Value="Johan Olofsson" />
                                        <asp:ListItem Text="Rikard Nilsson" Value="Rikard Nilsson" />
                                        <asp:ListItem Text="David Olandersson" Value="David Olandersson" />
                                        <asp:ListItem Text="Daniel Lenneer" Value="Daniel Lenneer" />
                                    </asp:DropDownList>
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>&nbsp;</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:DropDownList ID="ddWho2" runat="server">
                                        <asp:ListItem Selected="true" Text="Fler ?" Value="0" />
                                        <asp:ListItem Text="Charlie Jolin" Value="Charlie Jolin" />
                                        <asp:ListItem Text="Björn Andersson" Value="Björn Andersson" />
                                        <asp:ListItem Text="Johan Olofsson" Value="Johan Olofsson" />
                                        <asp:ListItem Text="Rikard Nilsson" Value="Rikard Nilsson" />
                                        <asp:ListItem Text="David Olandersson" Value="David Olandersson" />
                                        <asp:ListItem Text="Daniel Lenneer" Value="Daniel Lenneer" />
                                    </asp:DropDownList>
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Börjar:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <telerik:RadDateTimePicker ID="txtEStartDate" runat="server">
                                    </telerik:RadDateTimePicker></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Slutar:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <telerik:RadDateTimePicker ID="txtEEndDate" runat="server">
                                    </telerik:RadDateTimePicker></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">Kommentar:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtEComment" runat="server" Height="176px" TextMode="MultiLine" Width="246px"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="10" src="pixel_trans.gif" width="600"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton4" Text="slutför" runat="server" 
                                        onclick="LinkButton4_Click" CausesValidation="false" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="280"></td>
                            </tr>
                            <tr>
                                <td colspan="5"><img alt="" height="40" src="pixel_trans.gif" width="600"></td>
                            </tr>
                        </table>
                    </telerik:RadPageView> 
                    <telerik:RadPageView ID="RadPageView9" runat="server">2</telerik:RadPageView> 
                </telerik:RadMultiPage>
            </telerik:RadPageView> 
            <telerik:RadPageView ID="AllContacts" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" runat="server">
                <asp:DataList ID="dlContacts" 
                    runat="server" 
                    BorderStyle="None" 
                    BorderWidth="0px"
                    cellpadding="0" 
                    cellspacing="0" 
                    DataKeyField="Id" 
                    GridLines="None"
                    OnCancelCommand="dlContacts_CancelCommand" 
                    OnUpdateCommand="dlContacts_UpdateCommand" 
                    OnEditCommand="dlContacts_EditCommand" 
                    OnDeleteCommand="dlContacts_DeleteCommand" 
                    Width="1000px" EnableViewState="true">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1000px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="130px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="240px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="120px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td>Namn</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td>Företag</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td>Roll</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td>Telefon</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td>Mail</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td>Nätverk/Kommentar</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="130px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="240px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="120px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50px"></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle BackColor="LightBlue" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1000px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="130px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="240px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="120px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                            </tr>
                            <tr>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value3")%></td>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# GetCompanyById(DataBinder.Eval(Container.DataItem, "Value16").ToString())%></td>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value18")%></td>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value4")%></td>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value12")%></td>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# GetNetworkByNetId(DataBinder.Eval(Container.DataItem, "Value17").ToString())%></td>
                                <td valign="top"><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top">
                                    <asp:LinkButton ID="Button1" CausesValidation="false" CommandName="edit" Text="Editera" runat="server" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="130px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="240px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="120px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50px"></td>
                            </tr>
                        </table>
                    </ItemTemplate> 
                    <EditItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1000px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="130px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="240px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="120px"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><asp:TextBox ID="txtCName" Width="120px" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><asp:Label ID="txtCCompany" Width="120px" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><asp:TextBox ID="txtCRole" Width="90px" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><asp:TextBox ID="txtCPhone" Width="120px" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><asp:TextBox ID="txtCMail" Width="120px" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top"><%# GetNetworkByNetId(DataBinder.Eval(Container.DataItem, "Value17").ToString())%><br /><asp:TextBox ID="txtCComment" Width="120px" Height="130" TextMode="MultiLine" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10px"></td>
                                <td valign="top">
                                    <asp:LinkButton ID="Button2" CausesValidation="false" CommandName="update" Text="Spara" runat="server" />
                                    <asp:LinkButton ID="Button3" CausesValidation="false" CommandName="delete" Text="Radera" runat="server" />
                                    <asp:LinkButton ID="Button4" CausesValidation="false" CommandName="cancel" Text="Ångra" runat="server" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="130px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="1px0"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="240px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="120px"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50px"></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:DataList>
            </telerik:RadPageView> 
            <telerik:RadPageView ID="AllCompanies" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" runat="server">
                <asp:DataList ID="dlCompanies" 
                    runat="server" 
                    BorderStyle="None" 
                    BorderWidth="0px"
                    cellpadding="0" 
                    cellspacing="0" 
                    DataKeyField="Id" 
                    GridLines="None"
                    OnCancelCommand="dlCompanies_CancelCommand" 
                    OnUpdateCommand="dlCompanies_UpdateCommand" 
                    OnEditCommand="dlCompanies_EditCommand" 
                    OnDeleteCommand="dlCompanies_DeleteCommand" 
                    Width="850" EnableViewState="true">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="850">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Namn</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>OrgNummer</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle BackColor="LightBlue" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="640">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Value3")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><%# DataBinder.Eval(Container.DataItem, "Value16")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:LinkButton ID="Button1" CausesValidation="false" CommandName="edit" Text="Editera" runat="server" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </ItemTemplate> 
                    <EditItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" style="border: solid 1px black;">
                            <tr>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="50"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Namn:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>OrgNummer:</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:TextBox ID="txtOrgNr" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><asp:DropDownList ID="ddAllaBolag" AutoPostBack="true" runat="server" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>
                                    <asp:LinkButton ID="Button2" CausesValidation="false" CommandName="update" Text="Spara" runat="server" />
                                    <asp:LinkButton ID="Button3" CausesValidation="false" CommandName="delete" Text="Radera" runat="server" />
                                    <asp:LinkButton ID="Button4" CausesValidation="false" CommandName="cancel" Text="Ångra" runat="server" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="50"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="200"></td>
                                <td><img alt="" height="20" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:DataList>
            </telerik:RadPageView> 
            <telerik:RadPageView ID="AllEvents" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" runat="server">
                <asp:DataList ID="ddAllEvents" 
                    runat="server" 
                    BorderStyle="None" 
                    BorderWidth="1px"
                    cellpadding="0" 
                    cellspacing="0" 
                    DataKeyField="Id" 
                    GridLines="None"
                    OnCancelCommand="ddAllEvents_CancelCommand" 
                    OnUpdateCommand="ddAllEvents_UpdateCommand" 
                    OnEditCommand="ddAllEvents_EditCommand" 
                    OnDeleteCommand="ddAllEvents_DeleteCommand"  OnItemCommand="ddAllEvents_ItemCommand"  
                    Width="1010px" EnableViewState="true">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Tilldelad</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Typ</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Företag</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Kontakt</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Title</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Startar</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Slutar</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>&nbsp;</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle BackColor="LightBlue" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# IsEventTheFirstForThisContact(DataBinder.Eval(Container.DataItem, "Value17").ToString(), DataBinder.Eval(Container.DataItem, "Value5").ToString())%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value10")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# GetCompanyById(DataBinder.Eval(Container.DataItem, "Value16").ToString())%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# GetContactById(DataBinder.Eval(Container.DataItem, "Value17").ToString())%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Title")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value6")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value7")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:LinkButton ID="LinkButton5" CausesValidation="false" CommandName="done" Text="Utfört" runat="server" />&nbsp;<asp:LinkButton ID="Button1" CausesValidation="false" CommandName="edit" Text="Editera" runat="server" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </ItemTemplate> 
                    <EditItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVWho" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVType" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVCompany" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVContact" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:TextBox ID="txtVTitle" Width="90" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">
                                    <telerik:RadDateTimePicker ID="txtVStartDate" runat="server">
                                    </telerik:RadDateTimePicker></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">
                                    <telerik:RadDateTimePicker ID="txtVEndDate" runat="server">
                                    </telerik:RadDateTimePicker><br />
                                    <asp:TextBox ID="txtVComment" Width="150" Height="130" TextMode="MultiLine" runat="server"></asp:TextBox><br />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">
                                    <asp:LinkButton ID="Button2" CausesValidation="false" CommandName="update" Text="Spara" runat="server" />
                                    <asp:LinkButton ID="Button3" CausesValidation="false" CommandName="delete" Text="Radera" runat="server" />
                                    <asp:LinkButton ID="Button4" CausesValidation="false" CommandName="cancel" Text="Ångra" runat="server" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:DataList>
            </telerik:RadPageView> 
            <telerik:RadPageView ID="MinToDo" Visible="true" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" runat="server">
                 <div id="autothings" runat="server">
                     <b>Saker att ta itu mä...</b><br /><br />
                     <asp:DataList ID="ddThings" 
                        runat="server" 
                        BorderStyle="None" 
                        BorderWidth="1px"
                        cellpadding="0" 
                        cellspacing="0" 
                        DataKeyField="Id" 
                        GridLines="None"
                        OnCancelCommand="ddThings_CancelCommand" 
                        OnUpdateCommand="ddThings_UpdateCommand" 
                        OnEditCommand="ddThings_EditCommand" 
                        OnDeleteCommand="ddThings_DeleteCommand" OnItemCommand="ddThings_ItemCommand"  
                        Width="1010px" EnableViewState="true">
                        <HeaderTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                                <tr>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="120"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="80"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                </tr>
                                <tr>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>&nbsp;</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>Network</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>Företag</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>Kontakt</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>Title</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>&nbsp;</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>&nbsp;</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td>&nbsp;</td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                </tr>
                                <tr>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="120"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="80"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemStyle BackColor="LightBlue" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                                <tr>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="120"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="80"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                </tr>
                                <tr>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td valign="top"><asp:LinkButton ID="LinkButton5" CausesValidation="false" CommandName="create" Text="Skapa möte el. event" runat="server" /></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td valign="top"><%# GetNetworkByContact(DataBinder.Eval(Container.DataItem, "Value17").ToString())%></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td valign="top"><%# GetCompanyById(DataBinder.Eval(Container.DataItem, "Value16").ToString())%></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td valign="top"><%# GetContactById(DataBinder.Eval(Container.DataItem, "Value17").ToString())%></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Title")%></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                    <td valign="top" colspan="5"><asp:LinkButton ID="LinkButton6" CausesValidation="false" CommandName="delete" Text="Radera" runat="server" /></td>
                                    <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                </tr>
                                <tr>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="120"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="80"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                    <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                     </asp:DataList>
                     <br /><br /><hr />
                 </div><b>Bokade möten, telefon el. event</b><br /><br />
                 <asp:DataList ID="ddMyEvents" 
                    runat="server" 
                    BorderStyle="None" 
                    BorderWidth="1px"
                    cellpadding="0" 
                    cellspacing="0" 
                    DataKeyField="Id" 
                    GridLines="None"
                    OnCancelCommand="ddMyEvents_CancelCommand" 
                    OnUpdateCommand="ddMyEvents_UpdateCommand" 
                    OnEditCommand="ddMyEvents_EditCommand" 
                    OnDeleteCommand="ddMyEvents_DeleteCommand" OnItemCommand="ddMyEvents_ItemCommand"  
                    Width="1010px" EnableViewState="true">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Tilldelad</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Typ</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Företag</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Kontakt</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Title</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Startar</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>Slutar</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td>&nbsp;</td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemStyle BackColor="LightBlue" />
                    <AlternatingItemStyle BackColor="White" />
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# IsEventTheFirstForThisContact(DataBinder.Eval(Container.DataItem, "Value17").ToString(), DataBinder.Eval(Container.DataItem, "Value5").ToString())%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value10")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# GetCompanyById(DataBinder.Eval(Container.DataItem, "Value16").ToString())%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# GetContactById(DataBinder.Eval(Container.DataItem, "Value17").ToString())%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Title")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value6")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><%# DataBinder.Eval(Container.DataItem, "Value7")%></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:LinkButton ID="LinkButton5" CausesValidation="false" CommandName="done" Text="Utfört" runat="server" />&nbsp;<asp:LinkButton ID="Button1" CausesValidation="false" CommandName="edit" Text="Editera" runat="server" /></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </ItemTemplate> 
                    <EditItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="1010px">
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVWho" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVType" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVCompany" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:Label ID="txtVContact" runat="server"></asp:Label></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top"><asp:TextBox ID="txtVTitle" Width="90" runat="server"></asp:TextBox></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">
                                    <telerik:RadDateTimePicker ID="txtVStartDate" runat="server">
                                    </telerik:RadDateTimePicker></td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">
                                    <telerik:RadDateTimePicker ID="txtVEndDate" runat="server">
                                    </telerik:RadDateTimePicker><br />
                                    <asp:TextBox ID="txtVComment" Width="150" Height="130" TextMode="MultiLine" runat="server"></asp:TextBox><br />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                                <td valign="top">
                                    <asp:LinkButton ID="Button2" CausesValidation="false" CommandName="update" Text="Spara" runat="server" />
                                    <asp:LinkButton ID="Button3" CausesValidation="false" CommandName="delete" Text="Radera" runat="server" />
                                    <asp:LinkButton ID="Button4" CausesValidation="false" CommandName="cancel" Text="Ångra" runat="server" />
                                </td>
                                <td><img alt="" height="1" src="pixel_trans.gif" width="10"></td>
                            </tr>
                            <tr>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="150"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="110"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="100"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="140"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="50"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="40"></td>
                                <td><img alt="" height="10" src="pixel_trans.gif" width="10"></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                </asp:DataList>
            </telerik:RadPageView> 
            <telerik:RadPageView ID="AllaBolag" Visible="false" BorderStyle="Solid" BorderColor="Gray" BorderWidth="1px" ContentUrl="http://www.allabolag.se" runat="server"></telerik:RadPageView>
        </telerik:RadMultiPage> 
        </telerik:RadAjaxPanel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
