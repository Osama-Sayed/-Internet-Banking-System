<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientprofilesidemenu.aspx.cs" Inherits="IBS_Website.clientprofilesidemenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="patient" />
    <title>Client Profile side menu</title>
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">

    										<!-- CSS-->
	<link rel="stylesheet" type="text/css" href="Resources/CSS/ClientProfilesidemenu.css">
</head>
<body>
    <form id="ClientProfileSideMneuForm" runat="server">
         <ul class="sidenav">
    <li id="TransferMoneyCPSM"><asp:HyperLink ID="TransferMoneyCP" class="linkstyle" runat="server" NavigateUrl="TransferMoney.aspx">Transfer Money</asp:HyperLink></li> 
    <li id="TransferHistoryCPSM"><asp:HyperLink ID="TransferHistoryCP" class="linkstyle" runat="server" NavigateUrl="TransferHistory.aspx">Transfer History</asp:HyperLink></li>
    </ul>
    </form>
    
   


</body>
</html>
