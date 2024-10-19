<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAdmin.master" CodeFile="Cms_Admin.aspx.cs" Inherits="Modules_Boxes_Cms_Cms_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/Modules/Links/InternalLink/InternalLink.ascx" TagName="InternalLink" TagPrefix="uc1" %>

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
    <telerik:RadAjaxPanel ID="RAP_Admin" runat="server">
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
                <td class="Text12_gray"><asp:CheckBox id="cbExtraBar" runat="server" />&nbsp;Font Functionallity</td>
            </tr>
            <tr>
                <td style="height:10px; font-size:1px;">&nbsp;</td>
            </tr>
            <tr>
                <td class="Text12_gray">Header:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtHeader" class="form_textbox_bold_600" runat="server" /></td>
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
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Basic.xml"
                    Height="200px"
                    Width="600px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css" 
                    >
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
                    ID="RadEditor1"
                    Skin="Telerik"
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Normal.xml"
                    Height="400px"
                    Width="600px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css" 
                    >
                    <ImageManager ViewPaths="~/Upload/ImageManager" UploadPaths="~/Upload/ImageManager" DeletePaths="~/Upload/ImageManager" MaxUploadFileSize="10485760" />
                    <FlashManager ViewPaths="~/Upload/FlashManager" UploadPaths="~/Upload/FlashManager" DeletePaths="~/Upload/FlashManager" MaxUploadFileSize="10485760" />
                    <DocumentManager ViewPaths="~/Upload/DocumentManager" UploadPaths="~/Upload/DocumentManager" DeletePaths="~/Upload/DocumentManager" MaxUploadFileSize="10485760"/>
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
        <hr class='line' />    
        <br />
        </telerik:RadAjaxPanel> 
        <div style="position:relative; float: right;">
        <asp:Button ID="btnSaveData" runat="server" Text="Save & Close" class="form_button" 
            onclick="btnSaveData_Click" />
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