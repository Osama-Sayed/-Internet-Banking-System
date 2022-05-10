<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IBS_Website.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="Resources/CSS/Login.css">
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
    <h1><center>Login</center></h1>
	<br>
	<input type="text" placeholder="Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required>
	<br>
    <input type="password" id="password" placeholder="Password*" name="psw" required>
	<br>
<br>
      <button type="submit" class="signupbtn">Login</button>
	  
  </div>
</form>
</body>
</html>
