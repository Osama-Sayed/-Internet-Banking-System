<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="IBS_Website.AddClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Client</title>
    <link rel="stylesheet" href="Resources/CSS/AddClient.css">
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <style>
        
.bg {
    background-image: url("Resources/Images/AddClientPic.jpg");
}
    </style>
</head>
<body class="bg">
    <form id="AddClientForm" runat="server" method="post" autocomplete="off">
  <div class="container">
    <h1><center>Add Client</center></h1>
	<br>
    <asp:TextBox ID="UsernameAC" runat="server" placeholder="Client Username*" name="username" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required OnTextChanged="UsernameAC_TextChanged" ></asp:TextBox>
	<br>
    <asp:TextBox ID="passwordAC" runat="server" type="password" placeholder="Password*" name="psw" required OnTextChanged="passwordAC_TextChanged" ></asp:TextBox>
	<br>
    <asp:TextBox ID="passwordconfAC" runat="server" type="password" placeholder="Confirm Password*" name="psw" oninput="check(this)" required OnTextChanged="passwordconfAC_TextChanged" ></asp:TextBox>
	
	<br>
	<script language='javascript' type='text/javascript'>
    function check(input) {
        if (input.value != document.getElementById('passwordAC').value) {
            input.setCustomValidity('Passwords do not match');
        } else {
            // input is valid -- reset the error message
            input.setCustomValidity('');
        }
    }
    </script>
    <asp:TextBox ID="AccountNumAC" runat="server" type="text" placeholder="Account Number*"  pattern="[0-9]+" title="An Account Number can't include character or special character" name="accountnumber" required OnTextChanged="AccountNumAC_TextChanged" ></asp:TextBox>
    <br>
	<asp:TextBox ID="EmailAC" runat="server" type="email" placeholder="E-mail*" name="clientemail" title="The email format must be valid" required OnTextChanged="EmailAC_TextChanged" ></asp:TextBox> 
	<br>
	<asp:TextBox ID="PhoneNumAC" runat="server" type="text" placeholder="Phone Number*" name="phone" pattern="[0-9]+" title="A phone can only have numbers" required OnTextChanged="PhoneNumAC_TextChanged" ></asp:TextBox>
	<br>
    <br>
    <asp:Button ID="RegisterBtn" runat="server" Text="Add Client" class="AddC" OnClick="RegisterBtn_Click" target="_top"></asp:Button>
  </div>
</form>

</body>
</html>
