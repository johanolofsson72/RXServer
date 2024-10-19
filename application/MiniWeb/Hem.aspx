<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hem.aspx.cs" Inherits="Hem" Title="Untitled Page" %>
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
                    runat="server"><strong>IZON<br><br></strong><img alt="" src="SiteFiles/ImageManager/pic7.jpg"><br><br><strong>iZON – nätverk för inflytande, inspiration och <br>interaktivitet i sydöstra Sverige.<br><br></strong><font size=1>Vi vill göra sydöstra Sverige till en mer spännande plats att leva på.<br><br>I vår del av landet ska man kunna växa upp och känna att man kan göra sin röst hörd. Här lyssnar politiker, företag, skolor och media verkligen på vad folk vill.<br><strong>Det är inflytande.</strong><br><img src="SiteFiles/ImageManager/Seperator.gif"><br><br>Här berättar vi våra egna historier, som Astrid Lindgren och Vilhelm Moberg en gång gjorde för oss. Nu har texten fått hjälp av andra verktyg. Ljud, bild och musik <br>skapar vi själva och visar för varandra. Kan du så kan jag.<br><strong>Det är inspiration.<br></strong><br><img src="SiteFiles/ImageManager/Seperator.gif"><br><br>Här tror vi på de många människors förmåga att skapa själva. Så utbyte mellan generationer och kulturer innan klyftan blir för stor och misstag glöms bort. <br>Tekniken gör att vi nu kan samarbeta, skapa och uppleva även om vi inte finns på samma plats. Att bidra med det man kan och få uppskattning för det man gjort.<br><strong>Det är interaktivitet.<br></strong><br><img src="SiteFiles/ImageManager/Seperator.gif"><br><br>Inflytande, inspiration och interaktivitet. Det är dessa tre i:n som <br>föreningen iZON står för. Vi medlemmar kan bidra med kunskap och teknik <br>för att göra allt detta möjligt. Lyckas vi blir livet i vårt hörn av världen lite bättre, <br>lite roligare och förhoppningsvis lite mer meningsfull. <br><br></font></radE:RadEditor>
            </div>
        </div>
     </div>
       <div style="background-image:url(Images/MidContent_Bot.gif);width:505px; height:34px;position: relative;float:left;">
     </div>
  </div>    
</asp:Content>
