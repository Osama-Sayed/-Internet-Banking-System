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
    <form ID="LoginForm" runat="server" method="post" autocomplete="off">
    <div class="container">
    <h1><center>Login</center></h1>
	<br>
	<asp:TextBox ID="UsernameL" runat="server" type="text" placeholder="Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Username can’t include special characters" required OnTextChanged="UsernameL_TextChanged1" ></asp:TextBox>
	<br>
    <asp:TextBox ID="PasswordL" runat="server" type="password"  placeholder="Password*" name="psw" required OnTextChanged="PasswordL_TextChanged" ></asp:TextBox>
	<br>
    <br>
      <asp:Button ID="LoginBtn" runat="server" Text="Login" class="LoginCA" OnClick="LoginBtn_Click" OnClientClick="target ='_blank';"></asp:Button>
  </div>
</form>
</body>
</html>
