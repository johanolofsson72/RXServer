<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserList.ascx.cs" Inherits="Modules_User_UserList_UserList" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<div id="UserList">
    <div id="trans">&nbsp;</div>
    <div style="position:relative; float: left; width: 215px; margin-bottom: 10px; ">
           <asp:Label ID="lblSort" runat="server" />
           <asp:DropDownList runat="server" ID='ddlSort' AutoPostBack="true" onselectedindexchanged="ddlSort_SelectedIndexChanged" />
    </div>
    <div style="position: relative; float: left; width:215px; margin-top: -1px;"><asp:Literal ID="ltrUserList" runat="server" /></div>   
</div>
