<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Om_iZon.aspx.cs" Inherits="Om_iZon" Title="iZon - Om iZon" %>
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
                    runat="server"><strong>OM IZON<br></strong><br><strong><font size=4></font></strong><img alt="" src="SiteFiles/ImageManager/pic2.jpg"><br><img alt="" src="SiteFiles/ImageManager/Seperator.gif"><br><font size=1>Nätverket bildades i oktober 1999 i Småland-Blekinge. <br>Ett nätverk som tror på något som inte syns, som ännu inte finns men som hör <br>framtiden till. Vad vi vet är att tillsammans är vi duktiga på att uttyda tendenserna, <br>se möjligheterna och skapa förutsättningar. Nätverket vill ta vara på de ungas egenkraft och nyfiket stimulera deras arbete och tankesätt. Det kommer säkert vara mycket vi inte förstår, men ju mer vi kraftsamlar kring dessa spännande frågetecken ju bättre kan vi navigera in i framtiden. Vi inser att det är svårt att vara bäst idag, du blir gärna trea i morgon. Det vi vill genom nätverket äratt finna och skapa NYA arenor där vi per automatik blir först, ett litet tag.<br><br>Föreningen ska verka för att få till stånd ett kraftcentrum med lyskraft inom media, kultur och lärande. De ingående aktörerna i föreningen torde garantera en sådan utveckling. Bland dessa kan nämnas Sveriges Television Växjö, Interactive <br>Insitutute, &nbsp;Högskolan i Kalmar, Rock City Hultsfred, resurscentrat Reaktor Sydost, Blekinge Tekniska Högskola, Nätverket SIP och utvecklingsbolaget Vision Vimmerby m.fl. Tillsammans bildar vi ett starkt&nbsp; nätverk med förgrenar ut i andra fungerande nätverk på regional, nationell och internationell nivå.<br><br>Föreningens verksamhet bygger på ungas egenkraft och idéer. Det innebär att barn och ungdomar engageras aktivt i symbios med den verksamhet och de utvecklingsprojekt som aktörerna driver. I dessa skapas regionalutveckling och möjlighet till ny tillväxt i Småland och Blekinge.<br><br>iZon tar sig också rollen att verka opinionsbildande för att stärka och lyfta regionens roll inom media, kultur och lärande, det vi dagligdags kallar ung kommunikation.<br><br>Under 2007 har iZon varit med att starta upp Delta Garden - en satsning för att utveckla metoder för professionella former av deltagande.<br><br><br></font><br></radE:RadEditor>
            </div>
        </div>
     </div>
     <div style="background-image:url(Images/MidContent_Bot.gif);width:505px; height:34px;position: relative;float:left;">
     </div>
  </div>    
</asp:Content>

