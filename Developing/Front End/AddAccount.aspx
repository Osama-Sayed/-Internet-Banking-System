<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAccount.aspx.cs" Inherits="IBS_Website.AddAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Account</title>
<link rel="stylesheet" href="Resources/CSS/AddAccount.css">
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <meta charset="utf-8">
    <style>
        
.bg {
    background-image: url("Resources/Images/AddClientPic.jpg");
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
}
    </style>
</head>
<body class="bg">
    <form id="form1" runat="server">
        <div>
        </div>
    </form>

    <form action="" target="_top" method="post" autocomplete="off" >
  <div class="container">
    <h1><center>Add Account</center></h1>
	<br>
	<input type="text" placeholder="Client Username*" name="clientusername" pattern="[a-zA-Z ]+" title="Please enter only letters" required>
	<br>
	<input type="email" placeholder="New Account Number*" name="NewAccountNumber"  required>
	<br>
	<select class="savcur" name="savcur">
    <option>Account Type</option>
    <option value="save">Saving</option>
    <option value="current">Current</option>
    </select>
    <br>
      <button type="submit" class="signupbtn">Add Account</button>
	  
  </div>
</form>
</body>
</html>
