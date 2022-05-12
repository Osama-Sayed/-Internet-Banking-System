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
    <li id="TransferMoneyCPSM"><a class="linkstyle" href="TransferMoney.aspx">Transfer Money</a></li>  
    <li id="TransferHistoryCPSM"><a class="linkstyle" href="TransferHistory.aspx">Transfer History</a></li>
    </ul>
    </form>
    
   

</body>
</html>
