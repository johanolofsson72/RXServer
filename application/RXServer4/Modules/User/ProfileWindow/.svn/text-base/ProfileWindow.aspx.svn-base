<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Structure/WebAdmin/WebAddon.master" CodeFile="ProfileWindow.aspx.cs" Inherits="Modules_UserModules_EditProfile_EditProfile_Admin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content" ContentPlaceHolderId="MainAdminContent" runat="server">

    <!-- Script Handler for WebAdmin -->
    <asp:Label ID="lblScript" runat="server"></asp:Label>
  
    <div id="Menu" runat="server" style="background-color: #812526; width: 100%;">
        <table cellpadding="0" cellspacing="0"">
            <tr>
                <td style="height: 20px; padding: 10px;" valign="top"><h2><asp:Label ID="lblInfo" runat="server" /></h2></td>
            </tr>
            <tr>
                <td><asp:Literal ID="ltrSubMenuList" runat="server" /></td>
            </tr>
        </table>
    </div>
    
     <%--Error Box :: List all Errors--%>
    
     <div id="ErrorBox" runat="server" visible="false" class='ErrorBoxProfile_div' >
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
 
 
  
     <%--Success Box :: List all Errors--%>
    
     <div id="MessageBox" runat="server" visible="false" class="MessageBoxProfile_div" style="width:400px;">
        <table>
            <tr>
                <td style="height: 20px;" valign="top"><img src="../../../App_Themes/WebAdmin/Images/icon_success_small.gif" title="Success" alt="Success" /></td>
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
  
    <!--  Page1 :: Content --->
    <div id="Page_1" runat="server" visible="false" style="background-color: white; padding: 10px; ">       
        
        <div style="position:relative; float: left; width: 200px;">            
            <div id="holder_company" runat="server" visible="false" style="position:relative; float: left; width: 200px; padding-bottom: 10px;">
                <table cellpadding="0" cellspacing="0" style="width:180px;">
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_1" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtCompany" runat="server" CssClass="form_login_long" /></td>
                    </tr>
                </table>
            </div>
            <div id="holder_email" runat="server" visible="false" style="position:relative; float: left; width: 200px; padding-bottom: 10px;">
                <table cellpadding="0" cellspacing="0" style="width:180px;">
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_2" runat="server" />&nbsp;<asp:Image id="imgError1_2" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>

                 </table>
           </div>
           <div id="holder_person" runat="server" visible="false" style="position:relative; float: right; width: 200px; padding-bottom: 10px;">
                <table cellpadding="0" cellspacing="0" style="width:180px;">
                    <tr>
                        <td colspan="2" ><h3><asp:Label ID="lblText1_6" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" >
                        <asp:TextBox ID="txtFirstname" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_7" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtLastname" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_9" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_10" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtZipcode" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>                      

                 </table>
           </div>
       </div>
        <div style="position:relative; float: left; width: 200px;">
            <div id="holder_password" runat="server" visible="false" style="position:relative; float: left; width: 200px; padding-bottom: 10px;">
                <table cellpadding="0" cellspacing="0" style="width:180px;">
                    <tr>
                        <td colspan="2" ><h3><asp:Label ID="lblText1_4" runat="server" />&nbsp;<asp:Image id="imgError1_3" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></h3></td>
                    </tr>           
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtNewPassword1" TextMode="Password" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_5" runat="server" />&nbsp;<asp:Image id="imgError1_4" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top"><asp:TextBox ID="txtNewPassword2" TextMode="Password" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                    </tr>
                     <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_3" runat="server" />&nbsp;<asp:Image id="imgError1_5" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top"><asp:TextBox ID="txtOldPassword" TextMode="Password" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                     <tr>
                        <td colspan="2" style="height:63px; font-size:1px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblText1_8" runat="server" /></h3></td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                </table>
            </div>
            <div id="holder_save_1" runat="server" visible="false" style="position:relative; float: left; width: 200px; padding-top: 20px; padding-bottom: 10px;">
                <table cellpadding="0" cellspacing="0" style="width:190px;">
                    <tr>
                        <td></td>
                        <td align='right'>
                            <table cellpadding='0' cellspacing='0'>
                                <tr>
                                    <td id="btn_add_left">&nbsp;</td>
                                    <td id="btn_add_main"><asp:LinkButton ID="lbnSaveData1" runat="server" onclick="btnSaveData1_Click" CssClass="hm_btn2_link"></asp:LinkButton></td>
                                    <td id="btn_add_right">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                 </table>
             </div>
       </div>          
    </div> 
    
    <!--  Page2 :: Media --->
    <div id="Page_2" runat="server" visible="false" style="background-color: white; padding: 10px;">        
        <div id="holder_media" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:200px;">
                        <table cellpadding="0" cellspacing="0" style="border: solid 1px #A7A492;">
                            <tr>
                                <td valign="middle" align="center" style="height:90px; width: 90px;">
                                    <asp:Image ID="imgContent" Visible="false" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width:20px;">&nbsp;</td>
                    <td style="width:200px; height:25px;" valign="top"><p><asp:Label ID="lblText2_2" runat="server" /></p></td>
                </tr>
                <tr>
                    <td colspan="3" style="height:10px; font-size:1px;">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="height:10px;">
                      <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                     <asp:ImageButton ID="imbRemoveImg" runat="server" ImageUrl="~/Images/Modules/EditProfile/icon_remove.gif" onclick="imbRemoveImg_Click" /></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:LinkButton ID="lbnRemove" CssClass="link_575757" OnClick="imbRemoveImg_Click" runat="server" /></td>
                            </tr>
                        </table>
                   </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:10px; font-size:1px;">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3"><h3><asp:Label ID="lblText2_1" runat="server" /></h3>&nbsp;<asp:Image id="imgError2_1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                </tr>
                <tr>
                    <td colspan="3" style="height:4px; font-size:1px;">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <telerik:RadUpload
                            ID="RadUpload1" 
                            runat="server" 
                            Skin="Telerik"
                            ControlObjectsVisibility="none"
                            MaxFileSize="524288"
                            OverwriteExistingFiles="false"
                            AllowedFileExtensions=".jpg,.jpeg,.gif,.png,.JPEG,.JPG,.GIF,.PNG" />                    
                    </td>
                </tr>
            </table>
       </div>
       <div id="holder_save_2" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:400px;">
                <tr>
                    <td align='right'>
                        <table cellpadding='0' cellspacing='0'>
                            <tr>
                                <td id="btn_add_left">&nbsp;</td>
                                <td id="btn_add_main"><asp:LinkButton ID="lbnSaveData2" runat="server" onclick="btnSaveData2_Click" CssClass="hm_btn2_link"></asp:LinkButton></td>
                                <td id="btn_add_right">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
             </table>
         </div>
    </div> 
    
    <!--  Page3 :: Information --->
    <div id="Page_3" runat="server" visible="false" style="background-color: white; padding: 10px;">        
        <div id="holder_pres" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:180px;">
                <tr>
                    <td colspan="2" ><h3><asp:Label ID="lblText3_1" runat="server" /></h3>&nbsp;<asp:Image id="Image1" runat="server" Visible="false" ImageUrl="~/App_Themes/WebAdmin/Images/icon_error_small.gif" ToolTip="Error"/></td>
                </tr>
                <tr>
                    <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                </tr>   
                <tr>
                    <td>                
                        <telerik:radeditor runat="server" 
                        ID="RadEditor1"
                        Skin="Telerik"
                        ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Profile.xml"
                        Height="150px"
                        Width="400px"
                        ShowHtmlMode="False" 
                        ShowPreviewMode="False"
                        EditModes="Design"
                        ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor.css" 
                        >
                        </telerik:radeditor>
                   </td>
               </tr>
             </table>
        </div>
        <div id="holder_info1" runat="server" visible="false" style="position:relative; float: left; width: 200px; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:180px;">
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblBike" runat="server" Text="Motorcykel:"/></h3></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox ID="txtBike" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2"><h3><asp:Label ID="lblSince" runat="server" Text="Kört hoj sedan:" /></h3></td>
                    </tr>
                    <tr>
                       <td><asp:TextBox ID="txtSince" runat="server" CssClass="form_profile_textbox" /></td>
                    </tr>
                </table>
        </div>
        <div id="holder_info2" runat="server" visible="false" style="position:relative; float: left; width: 200px; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:180px;">
                <tr>
                    <td colspan="2"><h3><asp:Label ID="lblModel" runat="server" Text="Modell: " /></h3></td>
                </tr>
                <tr>
                    <td colspan="2" valign="top">
                    <asp:TextBox ID="txtModel" runat="server" CssClass="form_profile_textbox" /></td>
                </tr>

             </table>
        </div>
        <div id="holder_save_3" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:400px;">
                <tr>
                    <td></td>
                    <td align='right'>
                        <table cellpadding='0' cellspacing='0'>
                            <tr>
                                <td id="btn_add_left">&nbsp;</td>
                                <td id="btn_add_main"><asp:LinkButton ID="lbnSaveData3" runat="server" onclick="btnSaveData3_Click" CssClass="hm_btn2_link"></asp:LinkButton></td>
                                <td id="btn_add_right">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
             </table>
         </div>
    </div> 
    
    <!--  Page4 :: RemoveUser --->
    <div id="Page_4" runat="server" visible="false" style="background-color: white; padding: 10px;">        
        <div id="holder_remove" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top"><p><asp:Label ID="lblRemoveUser" runat="server" /></p></td>
                </tr>
            </table>
       </div>
       <div id="holder_save_4" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:400px;">
                <tr>
                    <td align='right'>
                        <table cellpadding='0' cellspacing='0'>
                            <tr>
                                <td id="btn_add_left">&nbsp;</td>
                                <td id="btn_add_main"><asp:LinkButton ID="lbnSaveData4" runat="server" onclick="btnSaveData4_Click" CssClass="hm_btn2_link"></asp:LinkButton></td>
                                <td id="btn_add_right">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
             </table>
         </div>
    </div> 
    
     <!--  Page5 :: ChangeUsername --->
    <div id="Page_5" runat="server" visible="false" style="background-color: white; padding: 10px;">        
        <div id="holder_change" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top"><p><asp:Label ID="lblChangeUser" runat="server" /></p></td>
                </tr>
                <tr>
                        <td colspan="2" style="height:10px; font-size:1px;">&nbsp;</td>
                </tr>
                <tr>
                    <td valign="top"><asp:TextBox ID="txtNewUsername" runat="server" CssClass="form_profile_textbox" /></td>
                </tr>
            </table>
       </div>
       <div id="holder_save_5" runat="server" style="position:relative; float: left; width: 100%; padding-bottom: 10px;">
            <table cellpadding="0" cellspacing="0" style="width:400px;">
                <tr>
                    <td align='right'>
                        <table cellpadding='0' cellspacing='0'>
                            <tr>
                                <td id="btn_add_left">&nbsp;</td>
                                <td id="btn_add_main"><asp:LinkButton ID="lbnSaveData5" runat="server" onclick="btnSaveData5_Click" CssClass="hm_btn2_link"></asp:LinkButton></td>
                                <td id="btn_add_right">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
             </table>
         </div>
    </div> 
    
    
         <!--  Page2 :: Add Application --->
    <div id="Page_0" runat="server" visible="false" style="background-color: white; padding: 10px;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="6" class="Text11_bold_red"><asp:Label id="lblSuccess" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="6" style="font-size:1px; height:60px;">&nbsp;</td>
            </tr>
            <tr>
                <td><table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td id="btn_left">&nbsp;</td>
                            <td id="btn_main" valign="top">
                                <asp:LinkButton ID="lbnClose" runat="server" CssClass="loginbtn" OnClientClick="returnToParent(); return false;"></asp:LinkButton></td>
                            <td id="btn_right">&nbsp;</td>
                        </tr>                                    
                    </table>
                    <br />
                    </td>
                <td style="font-size:1px; width:5px;">&nbsp;</td>
            </tr>
        </table>
    </div> 
    
         <!--  Page2 :: Add Application --->
    <div id="Page_Error" runat="server" visible="false" style="background-color: white; padding: 10px;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 20px; width: 20px;" valign="top" ><img src="../../../App_Themes/WebAdmin/Images/icon_error_big.gif" title="Errors" /></td>
                <td style="width: 10px;"></td>
                <td colspan="4" class="Text12_bold_orange" valign="middle">Oops!</td>
            </tr>
            <tr>
                <td colspan="6" style="font-size:1px; height:10px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" class="Text11_bold_red"><asp:Label id="lblError" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="6" style="font-size:1px; height:60px;">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="6"><table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td id="btn_left">&nbsp;</td>
                            <td id="btn_main" valign="top">
                                <asp:LinkButton ID="lbnClose2" runat="server" CssClass="loginbtn" OnClientClick="returnToParent(); return false;"></asp:LinkButton></td>
                            <td id="btn_right">&nbsp;</td>
                        </tr>                                    
                    </table>
                    <br />
                </td>
            </tr>
        </table>
    </div> 

</asp:Content>
