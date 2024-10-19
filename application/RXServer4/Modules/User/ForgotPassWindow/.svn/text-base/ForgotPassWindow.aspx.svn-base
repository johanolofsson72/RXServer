<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAddon.master" CodeFile="ForgotPassWindow.aspx.cs" Inherits="Modules_User_ForgotPassWindow_ForgotPassWindow" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>
  
    <div id="Menu" runat="server" style="background-color: #812526; width: 100%;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 60px; padding: 10px;" valign="top"><h2><asp:Label ID="lblInfo" runat="server" /></h2></asp:Label></td>
            </tr>
<%--            <tr>
                <td><asp:Literal ID="ltrSubMenuList" runat="server" /></td>
            </tr>--%>
        </table>
    </div>
    
     <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" visible="false" style="padding: 10px;">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_error_big.gif" title="Errors" /></td>
                <td style="width: 10px;"></td>
                <td class="Text12_bold_orange" valign="middle">Oops!</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td class="Text12_gray"><asp:Literal ID="ltrErrors" runat="server"/></td>
            </tr>
        </table>
     </div>
 
    <div id="Page_1" runat="server" visible="false" style="background-color: white; padding: 10px;">       
            <div id="ForgotError" runat="server" visible="false" style="border: solid 1px #DD3C10; background-color: #FFEBE8; padding: 5px; margin-bottom: 10px;">
                <table>
                    <tr>
                        <td style="width: 10px;"></td>
                        <td class="Text11_505050" valign="middle">Oops!</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="Text11_505050"><asp:Label ID="lblForgotError" runat="server" /></td>
                    </tr>
                </table>
           </div>
          
           <div style="position:relative; float: left; width: 200px;">
                <div style="position:relative; float: left; width: 200px; padding-bottom: 10px;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top"><h3><asp:Label ID="lblText4_1" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td style="font-size:1px; height: 3px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtUsername4" CssClass="form_profile_textbox" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="font-size:1px; height: 3px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top"><h3><asp:Label ID="lblText4_2" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td style="font-size:1px; height: 3px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtEmail4" CssClass="form_profile_textbox" runat="server" /></td>     
                    </tr>
                </table>
            </div>
           </div>
           <div style="position:relative; float: right; width: 200px;">
                <div style="position:relative; float: left; width: 200px; padding-bottom: 10px;">            
                     <table cellpadding="0" cellspacing="0">
                       <tr>
                            <td style="font-size:1px; height: 20px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align='right'>
                                <table cellpadding='0' cellspacing='0'>
                                    <tr>
                                        <td id="btn_add_left">&nbsp;</td>
                                        <td id="btn_add_main">
                                            <asp:LinkButton ID="lbnSendPassword2" runat="server" onclick="lbnSendPassword2_Click" CssClass="hm_btn2_link" /></td>
                                        <td id="btn_add_right">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size:1px; height: 30px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align='right'>
                                <table cellpadding='0' cellspacing='0'>
                                    <tr>
                                        <td id="btn_add_left">&nbsp;</td>
                                        <td id="btn_add_main">
                                            <asp:LinkButton ID="lbnSendPassword1" runat="server" onclick="lbnSendPassword1_Click" CssClass="hm_btn2_link" /></td>
                                        <td id="btn_add_right">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                     </table>
                </div>
           </div>
           

    </div>
    <div id="Page_2" runat="server" visible="false" style="background-color: white;"> 
         <div id="MessageBox" runat="server" visible="false" class="MessageBoxProfile_div">
            <table>
                <tr>
                    <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_success_small.gif" title="Success" /></td>
                    <td style="width: 10px;"></td>
                    <td class="Text12_bold_orange" valign="middle">Allt gick bra!</td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td class="Text12_gray"><asp:Literal ID="ltrMessage" runat="server"/></td>
                </tr>
            </table>
         </div>
        <div style="position:relative; float: right; width: 200px; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:190px;">
                <tr>
                    <td></td>
                    <td align='right'>
                        <table cellpadding='0' cellspacing='0'>
                            <tr>
                                <td id="btn_add_left">&nbsp;</td>
                                <td id="btn_add_main">
                                    <asp:LinkButton ID="lbnClose" runat="server" CssClass="hm_btn2_link" OnClientClick="CloseWindow(); return false;" /></td>
                                <td id="btn_add_right">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
             </table>
         </div>
    </div>     

</asp:Content>
