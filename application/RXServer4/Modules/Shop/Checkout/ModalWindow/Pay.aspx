<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Pay.aspx.cs" Inherits="_Pay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>DIBS</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<meta http-equiv="Content-Script-Type" content="text/javascript" />
		<meta http-equiv="Content-Style-Type" content="text/css" />
		<script type='text/javascript' src='../../../../JS/jquery-1.3.2.min.js'></script>
		<script type="text/javascript">
			<!--
			window.onload = function (evt) { document.forms[0].submit(); }
			//-->
		</script>
	</head>
	<body>
	  <form id="payform" runat="server" name="payform" method="post" action="https://payment.architrade.com/paymentweb/start.action">
		  <input type="hidden" name="merchant" value="90010012" />
		  <input type="hidden" name="lang" value="sv" />
		  <input type="hidden" name="test" value="yes" />
		  <input type="hidden" name="currency" value="752" />
		  <asp:Literal ID="ltrDynamicInput" runat="server" />
		</form>
	</body>
</html>
