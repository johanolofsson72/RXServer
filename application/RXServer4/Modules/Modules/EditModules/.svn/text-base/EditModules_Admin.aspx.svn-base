<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="EditModules_Admin.aspx.cs" Inherits="Modules_Modules_EditModules_EditModules_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>
  
    <div id="SubMenu" runat="server" visible="false" class="SubMenu_div">
        <asp:Literal ID="ltrSubMenuList" runat="server" />
    </div>
    
     <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" visible="false" class="ErrorBox_div">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_error_big.gif" title="Errors" alt="Errors" /></td>
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
     
     
     <%--Error Box :: List all Errors--%>
    
     <div id="MessageBox" runat="server" visible="false" class="MessageBox_div">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_success_small.gif" alt="Success" title="Success" /></td>
                <td style="width: 10px;"></td>
                <td class="Text12_bold_orange" valign="middle">Success!</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td class="Text12_gray"><asp:Literal ID="ltrMessage" runat="server"/></td>
            </tr>
        </table>
     </div>
 
    <!--  Page1 :: Edit Data --->
    <div id="Page_1" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage1" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />
        <table style="width: 100%; border: 0px;"  cellpadding="0" cellspacing="0">
             <tr>
                <td style="width:50px; text-align:left;">
                    <asp:ImageButton id="imbAddModule_5" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_rss1.gif" runat="server" 
                        onclick="imbAddModule_5_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add RSS Feeder Box
                    </span><br />
                    <span class='Text11_bold_gray'>
                        RSS Reader<br />                        Getting RSS Feeds<br />
                    </span>
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:50px; text-align:left;">
                    <asp:ImageButton id="imbAddModule_6" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text1.gif" runat="server" 
                        onclick="imbAddModule_6_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add Text Module
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Image/media centerd<br />
                        Text below image/media<br />
                    </span>
                </td>
                <td style="text-align:left;"></td>
            </tr>
            <tr>
                <td style="width:50px; text-align:left;">
                    <asp:ImageButton id="imbAddModule_7" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_rss1.gif" runat="server" 
                        onclick="imbAddModule_7_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add TagCloud
                    </span><br />
                    <span class='Text11_bold_gray'>
                        TagCloud<br />                        View all tags<br />
                    </span>
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:50px; text-align:left;">

                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">

                </td>
                <td style="text-align:left;"></td>
            </tr>
         </table>
         <br />
         <br />
        <hr class='line' />    
        <br />
    </div> 

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderId="MainAdminTextContent" runat="server">

    <%--Help Box :: Help Texts--%>
    
     <div id="Help" runat="server" class="Help_div">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="height: 5px; font-size:1px;">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 10px;"></td>
                    <td style="height: 20px;"><img src="../../../App_Themes/WebAdmin/Images/icon_help.gif" title="Help" alt="Help" /></td>
                    <td style="width: 10px;"></td>
                    <td class="Text13_bold_gray">Help</td>
                </tr>
            </table>
     </div>
     <div id="Help_Text" runat="server" class="Help_Text_div">
         <div id="Help_Text_main" runat="server" class="Help_Text_main_div">
            <asp:Literal ID="ltrHelpText" runat="server"></asp:Literal>
         </div>
     </div>

</asp:Content>