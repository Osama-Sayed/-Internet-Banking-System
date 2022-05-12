<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adminsidemenu.aspx.cs" Inherits="IBS_Website.Adminsidemenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <base target="patient" />
    <title>Admin side menu</title>
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">

    										<!-- CSS-->
	<link rel="stylesheet" type="text/css" href="Resources/CSS/clientprofilesidemenu.css">
</head>
<body>
    <form id="AdminSideMenuForm" runat="server">
        <ul class="sidenav">
            <li id="AddClientASM"><a class="linkstyle" href="AddClient.aspx">Add Client</a></li>  
            <li id="EditClientASM"><a class="linkstyle" href="EditClientStepOne.aspx">Edit Client</a></li>
            <li id="DeleteClientASM"><a class="linkstyle" href="DeleteClient.aspx">Delete Client</a></li>  
            <li id="AddAccountASM"><a class="linkstyle" href="AddAccount.aspx">Add Account</a></li>
        </ul>
    </form>
    
</body>
</html>
