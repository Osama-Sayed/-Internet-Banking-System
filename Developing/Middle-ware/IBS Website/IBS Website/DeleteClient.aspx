<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteClient.aspx.cs" Inherits="IBS_Website.DeleteClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Client</title>
    <link rel="stylesheet" href="Resources/CSS/DeleteClient.css">
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <style>
        
.bg {
    background-image: url("Resources/Images/AddClientPic.jpg");
    background-size: cover;
}
    </style>
</head>
<body class="bg">
    <form id="DeleteClientForm" runat="server" target="_top" method="post" autocomplete="off" >
  <div class="container">
    <h1><center>Delete Client</center></h1>
	<br>
    <asp:TextBox ID="ClientUsernameDC" runat="server" placeholder="Client Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Please enter only letters" required OnTextChanged="ClientUsernameDC_TextChanged" ></asp:TextBox>
    <br>
    <br>
    <asp:Button ID="DeleteClientBtn" runat="server" Text="Delete" class="DeleC" OnClick="DeleteClientBtn_Click"></asp:Button>
	  
  </div>
</form>
</body>
</html>
