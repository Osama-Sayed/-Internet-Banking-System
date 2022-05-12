<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditClientStepOne.aspx.cs" Inherits="IBS_Website.EditClientStepOne" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Client</title>
<link rel="stylesheet" href="Resources/CSS/EditClientFirstStep.css">
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <style>
        
.bg {
    background-image: url("Resources/Images/AddClientPic.jpg");
}
    </style>
</head>
<body class="bg">
    <form id="EditClientStepOneForm" runat="server" method="post" autocomplete="off">
  <div class="container">
    <h1><center>Edit Client</center></h1>
	<br>
    <asp:TextBox ID="ClientUsernameEC" runat="server" placeholder="Client username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required OnTextChanged="ClientUsernameEC_TextChanged"></asp:TextBox>
	<br>
    <br>
      <asp:Button ID="RegisterBtn" runat="server" Text="Edit" class="EditClient" OnClick="RegisterBtn_Click" ></asp:Button>
  </div>
</form>
</body>
</html>
