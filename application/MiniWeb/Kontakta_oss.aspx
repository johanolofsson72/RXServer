<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakta_oss.aspx.cs" Inherits="Kontakta_oss" Title="iZon - Kontakta oss" %>
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
                    runat="server"><strong><br>KONTAKTA OSS<br><br><img alt="" src="SiteFiles/ImageManager/pic4.jpg"><br><br><br><font size=1>För mer information kontakta:<br></font></strong><font size=1><br><font size=1>Ordförande:<br><a href="mailto:helena.collin@tii.se">Helena Collin/Interactive Institute</a><br>Tel: 0470-77 86<br>0733-36 77 50<br></font><br>Vice ordförande:<br><font size=1><a href="mailto:sten.selander@netport.se">Sten Selander/ Netport Karlsham</a><br>Tel: 0733-12 59 69 <br>Kassör:</font><br><a href="mailto:marin@reaktorsydost.se">Martin Eneborg/Reaktor Sydost</a><br>Tel:&nbsp;0470-72 47 77<br><br></font><br><br><strong><br></strong></radE:RadEditor>
            </div>
        </div>
     </div>
    <div style="background-image:url(Images/MidContent_Bot.gif);width:505px; height:34px;position: relative;float:left;">
     </div>
  </div>    
</asp:Content>

