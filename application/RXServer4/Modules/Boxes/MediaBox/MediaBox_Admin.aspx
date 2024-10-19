<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="MediaBox_Admin.aspx.cs" Inherits="Modules_Boxes_MediaBox_MediaBox_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/Modules/Links/InternalLink/InternalLink.ascx" TagName="InternalLink" TagPrefix="uc1" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <telerik:RadProgressManager ID="RadProgressManager1" runat="server" />

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
     
      <%--Success Box :: List all success--%>
    
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
        <span class='Text18_bold_gray'>Edit Media</span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0" style="">
             <tr>
                <td class="Text12_gray">Size:&nbsp;<asp:Image id="imgError1_2" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="ddlModels" class="form_dropdown_200" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Align:</td>
            </tr>
            <tr>
                <td class="Text12_gray"><asp:RadioButton ID="rbFloatLeft" runat="server" GroupName="float" />&nbsp;Left&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFloatRight" runat="server" GroupName="float" />&nbsp;Right</td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>

            <tr>
                <td class="Text12_gray">Current Mediafile:</td>
            </tr>
            <tr>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td rowspan="9" style="width:200px;" align="right">
                                <table cellpadding="0" cellspacing="0" style="border: solid 1px #CCCCCC;">
                                    <tr>
                                        <td valign="middle" align="center" style="height:200px; width: 200px;">
                                            <asp:Image ID="imgContent" Visible="false" runat="server" />
                                            <asp:Label ID="lblImgText" CssClass="Text11_gray" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:HyperLink ID="hplZoomImg" Visible="false" Target="_blank" runat="server"><img src="../../../App_Themes/WebAdmin/Images/icon_zoom.gif" class="img_noborder" style="margin: 3px;" title="Zoom" /></asp:HyperLink>
                            </td>
                            <td style="width:20px;">&nbsp;</td>
                            <td style="width:380px; height:25px;" class="Text11_gray"  valign="top">Choose Media:&nbsp;<asp:Image id="imgError1_1" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" /></td>
                        </tr>
                        <tr>
                            <td style="height:25px;"></td>
                            <td valign="top">
                                   <telerik:RadUpload
                                    ID="RadUpload1" runat="server" 
                                    Skin="Telerik"
                                    ControlObjectsVisibility="none"
                                    OverwriteExistingFiles="false"
                                    Allowedfileextensions=".jpeg,.jpg,.gif,.png,.GIF,.JPG,.PNG,.JPEG,.FLV,.flv,.SWF,.swf"
                                     />
                            </td>
                        </tr>
                        <tr>
                            <td style="height:10px; font-size:1px;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height:25px;"></td>
                            <td class="Text11_gray"  valign="top">Media Tooltip: (Only works for images)</td>
                        </tr>
                        <tr>
                            <td style="height:25px;"></td>
                            <td><asp:TextBox ID="txtToolTip" class="form_textbox_200" runat="server" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td class="Text11_gray"  valign="top"><asp:CheckBox id="cbShowImage" Checked="true" runat="server" />&nbsp;&nbsp;Media visible on page</td>
                        </tr>
                         <tr>
                            <td></td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <span class='Text18_bold_gray'>Edit Internal Link (Only for Images)</span>
        <br />
        <hr class='line' />
        <br />    
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Internal Link:</td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td><uc1:InternalLink id="InternalLink" Visible="true" runat="server"></uc1:InternalLink></td>            
            </tr>
        </table>
        <br />
        <hr class='line' />    
        <br />
        </telerik:RadAjaxPanel> 

        <telerik:RadProgressArea ID="RadProgressArea1" skin="Telerik" runat="server" />
        <div id="Error2" runat="server" class="ErrorBox_div" style="visibility:hidden;">
             <table>
                <tr>
                    <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_error_big.gif" title="Errors" /></td>
                    <td style="width: 10px;"></td>
                    <td class="Text12_bold_orange" valign="middle">Oops!</td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td class="Text12_gray"><asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="validateRadUpload" CssClass="Text12_gray" /></td>
                </tr>
            </table>
        </div>
        <div style="position:relative; float: right; margin-top:10px;">
        <asp:Button ID="btnSaveData" runat="server" Text="Save & Close" class="form_button" 
            onclick="btnSaveData_Click" />
        </div>  
       
    </div> 

        <script type="text/javascript">
            function validateRadUpload(source, e) 
            { 
                e.IsValid = false; 
                 
                var upload = $find("<%= RadUpload1.ClientID %>"); 
                var inputs = upload.getFileInputs(); 
                document.getElementById("<%=Error2.ClientID%>").style.visibility="hidden";
                for (var i = 0; i < inputs.length; i++) 
                { 
                    //check for empty string or invalid extension 
                    if (!upload.isExtensionValid(inputs[i].value)) 
                    { 
                        document.getElementById("<%=Error2.ClientID%>").style.visibility="visible";
                        //document.getElementById("<%=imgError1_1.ClientID%>").style.display="block";
                        return; 
                    }             
                } 
                e.IsValid = true; 
            } 
        </script>  


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