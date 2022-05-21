<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditClientStepTwo.aspx.cs" Inherits="IBS_Website.EditClientStepTwo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Client</title>
<link rel="stylesheet" href="Resources/CSS/EditClientStepTwo.css">
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <style>
        
.bg {
    background-image: url("Resources/Images/AddClientPic.jpg");
    background-size: cover;
}
    </style>
</head>
<body class="bg">
   
    <form id="EditClientStepTwoForm" runat="server" method="post" autocomplete="off">
  <div class="container">
    <h1><center>Edit Client</center></h1>
	<br>
    <asp:TextBox ID="UsernameEC" runat="server" placeholder="Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required OnTextChanged="UsernameEC_TextChanged" ></asp:TextBox>
	<br>
    <asp:TextBox ID="PasswordEC" runat="server" type="password" placeholder="Password*" name="psw" pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[/!@#$%^&*_=+-]).{8,}$" title="Password should contain at least one upper character, one lower character and at least 8 numbers" required OnTextChanged="PasswordEC_TextChanged" ></asp:TextBox>
	<br>
    <asp:TextBox ID="PasswordconEC" runat="server" type="password" placeholder="Confirm Password*" name="psw" oninput="check(this)" required pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*[/!@#$%^&*_=+-]).{8,}$" title="Password should contain at least one upper character, one lower character and at least 8 numbers" OnTextChanged="PasswordconEC_TextChanged" ></asp:TextBox>
	<br>
	<script language='javascript' type='text/javascript'>
    function check(input) {
        if (input.value != document.getElementById('PasswordEC').value) {
            input.setCustomValidity('Passwords do not match');
        } else {
            input.setCustomValidity('');
        }
    }
    </script>
    <asp:TextBox ID="AccountNumEC" runat="server" type="text" placeholder="Account Number*"  pattern="[0-9]+" title="An Account Number can't include character or special character" name="accountnumber" required OnTextChanged="AccountNumEC_TextChanged" ></asp:TextBox>
    <br>
    <asp:TextBox ID="EmailEC" runat="server" type="email" placeholder="E-mail*" name="clientemail" title="The email format must be valid" required OnTextChanged="EmailEC_TextChanged" ></asp:TextBox> 
	<br>
    <asp:TextBox ID="PhoneNumEC" runat="server" type="text" placeholder="Phone Number*" name="phone" pattern="[0-9]+" title="A phone can only have numbers" required OnTextChanged="PhoneNumEC_TextChanged"></asp:TextBox>
	<br>
    <br>
    <asp:Button ID="EditClientBtn" runat="server" Text="Edit" class="EditC" OnClick="EditClientBtn_Click"></asp:Button>
  </div>
</form>
</body>
</html>
