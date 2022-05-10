<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clientprofilesidemenu.aspx.cs" Inherits="IBS_Website.clientprofilesidemenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="patient" />
    <title>side menu</title>
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">

    										<!-- CSS-->
	<link rel="stylesheet" type="text/css" href="Resources/CSS/clientprofilesidemenu.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
    
    <ul class="sidenav">
    <li><a class="linkstyle" href="TransferMoney.aspx">Transfer Money</a></li>  
    <li><a class="linkstyle" href="TransferHistory.aspx">Transfer History</a></li>
    </ul>

</body>
</html>
