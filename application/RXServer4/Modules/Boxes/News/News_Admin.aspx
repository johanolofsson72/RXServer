<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="News_Admin.aspx.cs" Inherits="Modules_Boxes_News_News_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>

    <div id="SubMenu" runat="server" visible="false" class="SubMenu_div">
        <div style="position: relative; float: left;"><asp:Literal ID="ltrSubMenuList1" runat="server" /></div>
        <div style="position: relative; float: right;"><asp:Literal ID="ltrSubMenuList2" runat="server" /></div>
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


    <%--Page 1 :: List all Users--%>
    
    <div id="Page_1" runat="server" visible="false" class="Page_div">
        <asp:Literal ID="ltrEventsList" runat="server" />            
    </div>

 
    <!--  Page2 :: Edit Data --->
    <div id="Page_2" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'>Edit Text</span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0">
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
                <td class="Text12_gray">Title:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtTitle" class="form_textbox_bold_600" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>         
        </table>
        <br />
        <hr class='line' />    
        <br />
        
        <div style="position:relative; float: right;">
        <asp:Button ID="btnSaveData" runat="server" Text="Save & Close" class="form_button" 
            onclick="btnSaveData_Click" />
        </div>
            
    </div> 
    
    <!--  Page3 :: Add/Edit Event --->
    <div id="Page_3" runat="server" visible="false" class="Page_div">
        <span class='Text18_bold_gray'>Edit News</span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0">
             <tr>
                <td class="Text12_gray"><asp:CheckBox id="cbShowNews" Checked="true" runat="server" />&nbsp;&nbsp;Visible</td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Title:&nbsp;<asp:Image id="imgError3_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtNewsTitle" class="form_textbox_bold_600" runat="server" /></td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Introduction:</td>
            </tr>
            <tr>
                <td>
                 <telerik:radeditor runat="server" 
                    ID="RadEditor2"
                    Skin="Telerik"
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Normal.xml"
                    Height="400px"
                    Width="600px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css">
                    <ImageManager ViewPaths="~/Upload/ImageManager" UploadPaths="~/Upload/ImageManager" DeletePaths="~/Upload/ImageManager" MaxUploadFileSize="5120000" />
                    <MediaManager ViewPaths="~/Upload/MediaManager" UploadPaths="~/Upload/MediaManager" DeletePaths="~/Upload/MediaManager" MaxUploadFileSize="51200000"/>
                    <FlashManager ViewPaths="~/Upload/FlashManager" UploadPaths="~/Upload/FlashManager" DeletePaths="~/Upload/FlashManager" MaxUploadFileSize="51200000" />
                    <DocumentManager ViewPaths="~/Upload/DocumentManager" UploadPaths="~/Upload/DocumentManager" DeletePaths="~/Upload/DocumentManager" MaxUploadFileSize="10240000"/>
                    </telerik:radeditor>
                    
                </td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Ingress:</td>
            </tr>
            <tr>
                <td>
                 <telerik:radeditor runat="server" 
                    ID="RadEditor1"
                    Skin="Telerik"
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Basic.xml"
                    Height="400px"
                    Width="600px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css">
                    </telerik:radeditor>
                    
                </td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Text:</td>
            </tr>
            <tr>
                <td>
                 <telerik:radeditor runat="server" 
                    ID="RadEditor3"
                    Skin="Telerik"
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Normal.xml"
                    Height="400px"
                    Width="600px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css">
                    <ImageManager ViewPaths="~/Upload/ImageManager" UploadPaths="~/Upload/ImageManager" DeletePaths="~/Upload/ImageManager" MaxUploadFileSize="5120000" />
                    <MediaManager ViewPaths="~/Upload/MediaManager" UploadPaths="~/Upload/MediaManager" DeletePaths="~/Upload/MediaManager" MaxUploadFileSize="51200000"/>
                    <FlashManager ViewPaths="~/Upload/FlashManager" UploadPaths="~/Upload/FlashManager" DeletePaths="~/Upload/FlashManager" MaxUploadFileSize="51200000" />
                    <DocumentManager ViewPaths="~/Upload/DocumentManager" UploadPaths="~/Upload/DocumentManager" DeletePaths="~/Upload/DocumentManager" MaxUploadFileSize="10240000"/>
                    </telerik:radeditor>
                    
                   <script type="text/javascript">
                        //<![CDATA[
                        Telerik.Web.UI.Editor.CommandList["InsertSpecialLink"] = function(commandName, editor, args)
                        {
                           var elem = editor.getSelectedElement(); //returns the selected element.
                                  
                           if (elem.tagName == "A")
                           {
                                editor.selectElement(elem);
                                argument = elem;
                           }
                           else
                           {
                              var content = editor.getSelectionHtml(); 
                              var link = editor.get_document().createElement("A");
                              link.innerHTML = content;          
                              argument = link;
                           }
                           
                           var myCallbackFunction = function(sender, args)
                           {
                               editor.pasteHtml(String.format("<a href={0} >{1}</a> ", args.target, args.name))
                           }
                            
                            var selection = editor.getSelection();
                            var selectedText = selection.getText();
                           
                           editor.showExternalDialog(
                                '../../Links/LinkHolder/LinkHolder.aspx?txt=' +selectedText,
                                argument,
                                300,
                                460,
                                myCallbackFunction,
                                null,
                                'Insert Link',
                                true,
                                Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
                                false,
                                true);
                        };
                    
                </script>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <span class='Text18_bold_gray'>Date</span>
        <br />
        <hr class='line' />        
        <br />
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td class="Text12_gray">Date:&nbsp;<asp:Image id="imgError2_2" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                <td style="width:20px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
             <tr>
                <td class="Text12_gray">
                    <telerik:RadCalendar  
                        ID="RadCalendar1" 
                        runat="server"
                        Skin="Telerik"
                        EnableMultiSelect = "false"
                        UseColumnHeadersAsSelectors = "false"
                        UseRowHeadersAsSelectors = "false"
                        CultureInfo="English (United Kingdom)"
                        >
                    </telerik:RadCalendar>
                </td>
                <td></td>               
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <%--<span class='Text18_bold_gray'>Media</span>
        <br />
        <hr class='line' />
        <br />        
        <table cellpadding="0" cellspacing="0" style="">
            <tr>
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
                                <asp:HyperLink ID="hplZoomImg" Visible="false" Target="_blank" runat="server"><img src="../../../App_Themes/WebAdmin/Images/icon_zoom.gif" class="img_noborder" style="margin: 3px;" title="Zoom" /></asp:HyperLink></a>
                            </td>
                            <td style="width:20px;">&nbsp;</td>
                            <td style="width:380px; height:25px;" class="Text11_gray"  valign="top">Choose Media:&nbsp;<asp:Image id="imgError1_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                        </tr>
                        <tr>
                            <td style="height:25px;"></td>
                            <td valign="top">
                                   <telerik:RadUpload
                                    ID="RadUpload1" runat="server" 
                                    Skin="Telerik"
                                    ControlObjectsVisibility="none"
                                    Allowedfileextensions=".jpeg,.jpg,.gif,.png,.flv,.swf"
                                    OverwriteExistingFiles="false" />
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
        </table>--%>
        
        <br />
        <hr class='line' />    
        <br />
        
        <div style="position:relative; float: right;">
        <asp:Button ID="btnSaveEvent" runat="server" Text="Save" 
            class="form_button" onclick="btnSaveNews_Click" />
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