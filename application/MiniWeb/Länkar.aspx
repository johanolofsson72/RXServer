<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Länkar.aspx.cs" Inherits="Länkar" Title="iZon - Länkar" %>
<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="radE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div  style="width: 505px; margin-right: auto; margin-left: auto;">
    <div style="width:505px; background-color:White; background-image:url(Images/MidContent_Top.gif); background-repeat:no-repeat; position: relative;float:left;">
        <div style="width:450px; margin-left:35px; margin-right:25px; margin-top:25px; z-index:1001">
            <div style="width:430px;">
                <radE:RadEditor 
                    Visible="true"  
                    ID="RadEditor1" 
                    Width="435px" 
                    ToolsFile="~/RadControls/Editor/ToolsFile1.xml"        
                    ImagesPaths="~/SiteFiles/ImageManager" 
                    DeleteImagesPaths="~/SiteFiles/ImageManager" 
                    UploadImagesPaths="~/SiteFiles/ImageManager" 
                    TemplatePaths="~/SiteFiles/Template" 
                    DeleteTemplatePaths="~/SiteFiles/Template" 
                    UploadTemplatePaths="~/SiteFiles/Template"
                    FocusOnLoad="True" 
                    Font-Names="Verdana" 
                    Font-Size="10" 
                    ForeColor="#7b7b7b" 
                    Height="600px" 
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False" 
                    ShowSubmitCancelButtons="True" 
                    SaveInFile="true"                                             
                    runat="server"><strong>LÄNKAR<br><br><img alt="" src="SiteFiles/ImageManager/pic6.jpg"><br><br></strong>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://www.deltagarden.se">Delta Garden</a><br>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://www.idg.se/"><font color=#ff990e size=1>idg.se</font></a><br>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://www.idg.se/"><font color=#ff990e size=1>idg.se</font></a><br>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://www.idg.se/"><font color=#ff990e size=1>idg.se</font></a><br><strong>&nbsp;</strong></radE:RadEditor>
            </div>
        </div>
     </div>
      <div style="background-image:url(Images/MidContent_Bot.gif);width:505px; height:34px;position: relative;float:left;">
     </div>
  </div>    
</asp:Content>
