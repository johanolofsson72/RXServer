<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Forum.ascx.cs" Inherits="Modules_Boxes_Forum_Forum" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

    <style type="text/css">
    .rade_toolbar.Telerik .InsertEmoticon
    {
        background-image: url(Images/Modules/Emoticon/1.gif);
    }
    </style>

<div id="Forum_holder" runat="server">
    <div id="Forum_admin" runat="server" visible="false">

    <script type="text/javascript">
        //<![CDATA[
        
        function showAdminForum(SitId,PagId,ModId,Var)
        {
            var oWnd = $find("<%=RadWindow1_Forum.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Boxes/Forum/Forum_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&Var=" + Var + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
        function showAdminDeletePost(SitId,PagId,ObdId)
        {
            var oWnd = $find("<%=RadWindow1_DeletePost.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Boxes/Forum/DeletePost/DeletePost_Admin.aspx?SitId=1&PagId=" + PagId + "&ObdId=" + ObdId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }
        
        function showAdminDeleteThread(SitId,PagId,ModId,CatId,ThreadId)
        {
            var oWnd = $find("<%=RadWindow1_DeleteThread.ClientID%>");
            var d = new Date();oWnd.SetUrl("http://<% Response.Write(Request.Url.Authority + Request.ApplicationPath); %>/Modules/Boxes/Forum/DeleteThread/DeleteThread_Admin.aspx?SitId=1&PagId=" + PagId + "&ModId=" + ModId + "&CatId=" + CatId + "&ThreadId=" + ThreadId + "&UID=" + d.getMilliseconds());
            oWnd.show();  
        }

    </script>

    <telerik:RadWindow
      ID ="RadWindow1_Forum" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      ReloadOnShow="true"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
     Behaviors="Close, Maximize, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >
    
    <telerik:RadWindow
      ID ="RadWindow1_DeletePost" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
      Behaviors="Close, Maximize, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >
    
     <telerik:RadWindow
      ID ="RadWindow1_DeleteThread" 
      VisibleTitlebar="True" 
      VisibleStatusbar="false"
      IconUrl="~/App_Themes/WebAdmin/Images/window_logo.gif"
      Behaviors="Close, Maximize, Move"
      Skin="Telerik"
      Modal="true"
      Height="600"
      Width="900" 
      Runat = "server">
    </telerik:RadWindow >

    <div id="adminbar" style="position:relative; float:left; height:35px;">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminEdit" ToolTip="Edit" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_edit.gif" runat="server" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #674343; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminDelete" ToolTip="Delete" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_delete_red.gif" runat="server" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminMoveUp" ToolTip="MoveUp"
                        ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_moveup.gif" runat="server" onclick="img_AdminMoveUp_Click" /></td>
                <td style="width:3px; font-size:1px;"><asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_divider.gif" /></td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="img_AdminMoveDown" ToolTip="MoveDown" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_movedown.gif" runat="server" onclick="img_AdminMoveDown_Click" /></td>
                <td style="width:1px; font-size:1px;">&nbsp;</td>
                <td style="background-color: #666666; text-align: center; height:25px; width:24px;">
                    <asp:ImageButton ID="imbAdminVisible" runat="server" onclick="img_AdminVisible_Click" /></td>
            </tr>
            <tr>
                <td style="font-size:1px; height:5px; text-align:center;"><asp:Image ID="Image0" runat="server" ImageUrl="~/App_Themes/WebAdmin/Images/adminbar_arrow_gray.gif" /></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
</div> 
    <div id="Forum">   
        <div id="ForumHeader" runat="server" style="position: relative; float: left; width: 100%; padding: 10px 0 10px 0; display:inline;">
            <h2><asp:Label ID="lblThreadTitle" runat="server" /></h2></div>
        <div id="ForumMenu" runat="server" style="position: relative; float: left; width: 100%; display:inline;"><asp:Literal ID="ltrForumMenu" runat="server" /></div>       
<%--        <div id="ForumSearch" runat="server" style="position: relative; float: left; width: 100%; padding: 10px; display:inline; background-color: #F3F3F3;">Sök</div>
        <div id="ForumHeader" runat="server" style="position: relative; float: left; width: 100%; padding: 10px 0 0 0; display:inline;">
            <asp:Label ID="lblThreadTitle" runat="server" /></div>
        </div>--%>
        <div id="ForumCreate" runat="server" style="position: relative; float: left; width: 100%;padding: 10px 0 0 0; display:inline;">
            <asp:HyperLink ID="hplCreateThread" CssClass='Text11_505050' Text="Skapa ny tråd" runat="server" />
        </div>
                    
        <div id="ForumCreatePost" runat="server" style="position: relative; float: left; width: 100%; padding: 20px; display:inline;">
<%--            <div style="position: relative; float: left; width:580px; padding: 10px; background-color: #F3F3F3; margin-bottom: 10px;">
                <div style="position: relative; float: left; margin-right: 20px;"><asp:TextBox ID="txtPoster" class="form_textbox_bold_250" runat="server" /></div>
                <div style="position: relative; float: left;"><asp:TextBox ID="txtPosterMail" class="form_textbox_bold_250" runat="server" /></div>
            </div>   --%>             
            <div style="position: relative; float: left; width:580px; padding: 10px; background-color: #F3F3F3; margin-bottom: 10px;">
               
               <%--"--%>
                <telerik:radeditor runat="server" 
                    ID="RadEditor2"
                    Skin="Telerik"
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Forum.xml"
                    Height="200px"
                    Width="580px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor2.css"
                    >
                    </telerik:radeditor>
                     <script type="text/javascript">
                    //<![CDATA[
                    
                    Telerik.Web.UI.Editor.CommandList["InsertEmoticon"] = function(commandName, editor, args)
                    {
                       var myCallbackFunction = function(sender, args)
                       {
                            editor.pasteHtml(String.format("<img src='{0}' border='0' align='middle' alt='emoticon' /> ", args.image));
                       }
                      
                       editor.showExternalDialog(
                            'Modules/Emoticon/InsertEmoticon.aspx',
                            {},
                            400,
                            310,
                            myCallbackFunction,
                            null,
                            'Insert Emoticon',
                            true,
                            Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
                            false,
                            true);
                    };
                    //]]>
                    </script>
                    
            </div>
            <div style=" float: left; width:580px; margin-bottom: 10px;"><asp:Button ID="btnReply" Text="Reply" runat="server" onclick="btnCreatePost_Click" /></div>
        </div>            
        <div id="ForumList" runat="server" style="position: relative; float: left; margin-top: 10px; padding: 20px; display:inline; background-color: #F3F3F3;">
            <asp:Literal ID="ltrCategories" runat="server" />    
         </div>            
        <div id="ForumCreateThread" runat="server" style="position: relative; float: left; padding: 20px; display:inline;">
            <div style="position: relative; float: left; margin-bottom: 10px; width:580px;">
            <asp:Label ID="lblCreateThreadTitle" runat="server"></asp:Label></div>
            <div style="position: relative; float: left; padding: 10px; background-color: #F3F3F3; margin-bottom: 10px;">
                <asp:TextBox ID="txtThreadTitle" runat="server" />
            </div>                
            <div style="position: relative; float: left; padding: 10px; background-color: #F3F3F3; margin-bottom: 10px;">
                <telerik:radeditor runat="server" 
                    ID="RadEditor1"
                    ToolsFile="~/App_Themes/RXSK/RadControls/Editor/ToolsFile_Forum.xml"
                    Height="200px"
                    Width="580px"
                    ShowHtmlMode="False" 
                    ShowPreviewMode="False"
                    EditModes="Design"
                    ContentAreaCssFile="~/App_Themes/WebAdmin/radeditor2.css" 
                    Skin="Telerik"> 
                    </telerik:radeditor>
                     <script type="text/javascript">
                    //<![CDATA[
                    
                    Telerik.Web.UI.Editor.CommandList["InsertEmoticon"] = function(commandName, editor, args)
                    {
                       var myCallbackFunction = function(sender, args)
                       {
                            editor.pasteHtml(String.format("<img src='{0}' border='0' align='middle' alt='emoticon' /> ", args.image));
                       }
                      
                       editor.showExternalDialog(
                            'Modules/Emoticon/InsertEmoticon.aspx',
                            {},
                            400,
                            310,
                            myCallbackFunction,
                            null,
                            'Insert Emoticon',
                            true,
                            Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Move,
                            false,
                            true);
                    };
                    //]]>
                    </script>
            </div>
            <div style="position: relative; float: left; margin-bottom: 10px;"><asp:Button ID="btnCreateThread" Text="Skapa Tråd" runat="server" onclick="btnCreateThread_Click" /></div>
        </div>      
    </div>
</div>