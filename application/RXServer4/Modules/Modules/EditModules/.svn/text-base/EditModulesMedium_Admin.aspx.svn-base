<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="EditModulesMedium_Admin.aspx.cs" Inherits="Modules_Modules_EditModules_EditModulesMedium_Admin" %>
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
     
     
     <%--Error Box :: List all Errors--%>
    
     <div id="MessageBox" runat="server" visible="false" class="MessageBox_div">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_success_small.gif" title="Success" /></td>
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
                <td style="width:50px; text-align:left; vertical-align:top;">
                    <asp:ImageButton id="imbAddModule_1" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text1.gif" runat="server" 
                        onclick="imbAddModule_1_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add Text
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Header<br />
                        Ingress<br />
                        Text<br />
                    </span>
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:50px; text-align:left;vertical-align:top;">
                   <asp:ImageButton id="imbAddModule_2" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text2.gif" runat="server" 
                        onclick="imbAddModule_2_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add Media
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Image, FLV or Flash<br />                    </span>
                </td>
                <td style="text-align:left;"></td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:left; height: 20px; font-size:1px;"></td>
            </tr>
           <tr>
                <td style="width:50px; text-align:left;vertical-align:top;">
                    <asp:ImageButton id="imbAddModule_6" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_news1.gif" runat="server" 
                        onclick="imbAddModule_6_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add News
                    </span><br />
                    <span class='Text11_bold_gray'>
                        A list with news.<br />
                        Header, Introduction, Ingress and Text.<br />
                    </span>
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:50px; text-align:left;vertical-align:top;">
                    <asp:ImageButton id="imbAddModule_3" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text1.gif" runat="server" 
                        onclick="imbAddModule_3_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add Image Gallery
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Create a gallery with thumbnails from images<br />
                    </span>
                </td>
                <td style="text-align:left;"></td>
            </tr>
             <tr>
                <td colspan="8" style="text-align:left; height: 20px; font-size:1px;"></td>
            </tr>
           <tr>
                <td style="width:50px; text-align:left;vertical-align:top;">
                    <asp:ImageButton id="imbAddModule_8" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text1.gif" runat="server" 
                        onclick="imbAddModule_8_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    <span class='Text14_bold_gray'>
                        Add Image SlideShow
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Create a slideshow from images<br />
                    </span>
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:50px; text-align:left;vertical-align:top;">
                    <asp:ImageButton id="imbAddModule_4" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text1.gif" runat="server" 
                        onclick="imbAddModule_4_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                   <span class='Text14_bold_gray'>
                        Add TabTexts
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Texts in different tabs.<br />
                    </span>
                </td>
                <td style="text-align:left;"></td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:left; height: 20px; font-size:1px;"></td>
            </tr>
            <tr>
                <td style="width:50px; text-align:left;vertical-align:top;">
                    <asp:ImageButton id="imbAddModule_5" 
                        ImageUrl="~/Images/Modules/Icons/icon_mod_text1.gif" runat="server" 
                        onclick="imbAddModule_5_Click" />
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                   <span class='Text14_bold_gray'>
                        Add Contact Us
                    </span><br />
                    <span class='Text11_bold_gray'>
                        Contact Formular<br />
                    </span>
                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:50px; text-align:left;vertical-align:top;">

                </td>
                <td style="width:10px; text-align:left;"></td>
                <td style="width:180px; text-align:left; vertical-align:top;">
                    
                </td>
                <td style="text-align:left;"></td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:left; height: 20px; font-size:1px;"></td>
            </tr>
         </table>
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
                    <td style="height: 20px;"><img src="../../../App_Themes/WebAdmin/Images/icon_help.gif" title="Help" /></td>
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