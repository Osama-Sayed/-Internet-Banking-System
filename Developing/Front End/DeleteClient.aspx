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
    <h1><center>Delete Client</center></h1>
	<br>
	<input type="text" placeholder="Client Username*" name="username" pattern="[a-zA-Z ]+" title="Please enter only letters" required>
	
<br>
<br>
      <button type="submit" class="signupbtn">Delete</button>
	  
  </div>
</form>
</body>
</html>
