<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientRegistration.aspx.cs" Inherits="IBS_Website.ClientRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Registration</title>
    <link rel="stylesheet" href="Resources\CSS\ClientRegistration.css"/>
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <meta charset="utf-8">
</head>
<body>
   
<form  method="post" autocomplete="off" id="ClientRegistrationForm" runat="server">
  <div class="container">
    <h1><center>Register</center></h1>
	<br>
	<asp:TextBox ID="UsernameCR" runat="server" placeholder="Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required OnTextChanged="UsernameCR_TextChanged"  ></asp:TextBox>
	<br>
    <asp:TextBox ID="PasswordCR" runat="server" type="password" placeholder="Password*" name="psw" required OnTextChanged="PasswordCR_TextChanged" ></asp:TextBox>
	<br>
    <asp:TextBox ID="PasswordConfCR" runat="server" type="password" placeholder="Confirm Password*" name="psw" oninput="check(this)" required OnTextChanged="PasswordConfCR_TextChanged" ></asp:TextBox>
	<br>
	<script language='javascript' type='text/javascript'>
        function check(input) {
            if (input.value != document.getElementById('PasswordCR').value) {
                input.setCustomValidity('Passwords do not match');
            } else {
                input.setCustomValidity('');
            }
        }
    </script>
    <asp:TextBox ID="AccountNumCR" runat="server" type="text" placeholder="Account Number*"  pattern="[0-9]+" title="Account Numbers can't include characters or special characters" name="accountnumber" required OnTextChanged="AccountNumCR_TextChanged" ></asp:TextBox>
    <br>
	<asp:TextBox ID="EmailCR" runat="server" type="email" placeholder="E-mail*" name="clientemail"  required OnTextChanged="EmailCR_TextChanged"  ></asp:TextBox> 
	<br>
	<asp:TextBox ID="PhoneNumCR" runat="server" type="text" placeholder="Phone Number*" name="phone" pattern="[0-9]+" title="A phone can only have numbers" required OnTextChanged="PhoneNumCR_TextChanged" ></asp:TextBox>
	<br>
    <br>
	  <asp:Button ID="RegisterBtn" runat="server" Text="Register" class="RegC" OnClick="RegisterBtn_Click" OnClientClick="target ='_blank';"></asp:Button>
  </div>
</form>

</body>
</html>
