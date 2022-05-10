<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientRegistration.aspx.cs" Inherits="IBS_Website.ClientRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Client Registration</title>
    <link rel="stylesheet" href="Resources/CSS/ClientRegister.css">
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <meta charset="utf-8">
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>

<form action="" method="post" autocomplete="off">
  <div class="container">
    <h1><center>Register</center></h1>
	<br>
	<input type="text" placeholder="Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required>
	<br>
    <input type="password" id="password" placeholder="Password*" name="psw" required>
	<br>
    <input type="password" id="id="password" placeholder="Confirm Password*" name="psw" oninput="check(this)" required>
	<br>
	<script language='javascript' type='text/javascript'>
        function check(input) {
            if (input.value != document.getElementById('password').value) {
                input.setCustomValidity('Passwords do not match');
            } else {
                // input is valid -- reset the error message
                input.setCustomValidity('');
            }
        }
    </script>
<input type="text" placeholder="Account Number*" name="accountnumber" required>
<br>
	<input type="email" placeholder="E-mail*" name="clientemail"  required> 
	<br>
	<input type="text" placeholder="Phone Number*" name="phone" pattern="[0-9]+" title="A phone can only have numbers" required>
	<br>
<br>
      <button type="submit" class="signupbtn">Register</button>
	  
  </div>
</form>

</body>
</html>
