<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="PageTemplate_Admin.aspx.cs" Inherits="Modules__System_PageTemplate_PageTemplate_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">
    <telerik:radformdecorator id="FormDecorator1" runat="server" decoratedcontrols="CheckBoxes" skin="Default">
    </telerik:radformdecorator>

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
 
    <!--  Page1 :: Edit Data --->
    <div id="Page_1" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage1" runat="server"></asp:Label></span>
        <br />
        <hr class='line' />
        <br />
        <telerik:RadAjaxPanel ID="RAP" runat="server">
            <div id="Level12" runat="server" visible="false">
                <table style="width: 100%; border: 0px;" cellpadding="0" cellspacing="0">
                     <tr>
                        <td style="width:30px; text-align:left;"><asp:RadioButton id="pageTemplate1" runat="server" GroupName="pageTemplate" Checked="true" /></td>
                        <td style="width:50px; text-align:left;">
                            <asp:ImageButton id="imgTemplate1" 
                                ImageUrl="~/Images/Templates/Icons/icon_template_6.gif" runat="server"
                                onclick="imgTemplate1_Click" />
                        </td>
                        <td style="width:10px; text-align:left;"></td>
                        <td style="width:180px; text-align:left; vertical-align:top;">
                            <span class='Text14_bold_gray'>
                                Mainpage Template 1 
                            </span><br />
                            <span class='Text11_bold_gray'>
                                Column 1 (XLarge)<br />
                            </span>
                        </td>
                        <td style="width:10px; text-align:left;"></td>
                        <td style="width:30px; text-align:left;"><asp:RadioButton id="pageTemplate4" runat="server" GroupName="pageTemplate" Checked="true" /></td>
                        <td style="width:50px; text-align:left;">
                            <asp:ImageButton id="imgTemplate4" ImageUrl="~/Images/Templates/Icons/icon_template_7.gif" runat="server" onclick="imgTemplate4_Click" />
                        </td>
                        <td style="width:10px; text-align:left;"></td>
                        <td style="width:180px; text-align:left; vertical-align:top;">
                            <span class='Text14_bold_gray'>
                                 Mainpage Template 2 
                            </span><br />
                            <span class='Text11_bold_gray'>
                                Column 1 (Small)<br />
                                Column 2 (Large)<br />
                            </span>
                        </td>
                        <td style="text-align:left;"></td>
                    </tr>
                </table>
            </div>
            <div id="Level34" runat="server" visible="false">
                <table style="width: 100%; border: 0px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 20px; text-align:left;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width:30px; text-align:left;"><asp:RadioButton id="pageTemplate2" runat="server" GroupName="pageTemplate" /></td>
                        <td style="width:50px; text-align:left;">
                            <asp:ImageButton id="imgTemplate2" ImageUrl="~/Images/Templates/Icons/icon_template_5.gif" runat="server" onclick="imgTemplate2_Click" />
                        </td>
                        <td style="width:10px; text-align:left;"></td>
                        <td style="width:180px; text-align:left; vertical-align:top;">
                            <span class='Text14_bold_gray'>
                                Subpage Template 1
                            </span><br />
                            <span class='Text11_bold_gray'>
                                Navigation (Small)<br />                                Column 1 (Large)<br />                            </span>
                        </td>
                        <td style="width:10px; text-align:left;"></td>
                        <td style="width:30px; text-align:left;"><asp:RadioButton id="pageTemplate3" runat="server" GroupName="pageTemplate" Checked="true" /></td>
                        <td style="width:50px; text-align:left;">
                            <asp:ImageButton id="imgTemplate3" ImageUrl="~/Images/Templates/Icons/icon_template_4.gif" runat="server" onclick="imgTemplate3_Click" />
                        </td>
                        <td style="width:10px; text-align:left;"></td>
                        <td style="width:180px; text-align:left; vertical-align:top;">
                            <span class='Text14_bold_gray'>
                                Subpage Template 2
                            </span><br />
                            <span class='Text11_bold_gray'>
                                Navigation (Small)<br />
                                Column 1 (Medium)<br />
                                Column 2 (Small)<br />
                            </span>
                        </td>
                        <td style="text-align:left;"></td>
                    </tr>
                </table>
            </div>
        </telerik:RadAjaxPanel>
        <br />
        <hr class='line' />    
        <br />
        <div style="position:relative; float: right;">
        <asp:Button id="btnChangePageTemplate" runat="server" class="form_button" Text="Set Template" onclick="btnChangePageTemplate_Click" />
        </div>
    </div> 
    
     <!--  Page1 :: Edit Data --->
    <div id="Page_2" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'><asp:Label ID="lblHeaderPage2" runat="server" /></span>
        <br />
        <hr class='line' />
        <br />
        <table style="width: 100%; border: 0px;"  cellpadding="0" cellspacing="5">
            <tr>
                <td class='Text12_gray'>Are you sure you want to remove this Template?</td>
            </tr>
        </table>        
        
        <br />
        <hr class='line' />    
        <br />
        <div style="position:relative; float: right;">
        <asp:Button id="btnRemovePageTemplate" runat="server" class="form_button" 
            Text="Remove Template" onclick="btnRemovePageTemplate_Click" />
        </div>
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