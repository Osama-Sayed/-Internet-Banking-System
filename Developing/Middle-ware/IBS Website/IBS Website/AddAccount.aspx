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
    background-size: cover;
}
    </style>
</head>
<body class="bg">
    
    <form id="AddAccountForm" runat="server" target="_top" method="post" autocomplete="off" >
  <div class="container">
    <h1><center>Add Account</center></h1>
	<br>
    <asp:TextBox ID="ClientUsernameAA" runat="server" placeholder="Client Username*" name="name" pattern="[a-zA-Z0-9 ]+" title="Please enter only letters" required OnTextChanged="ClientUsernameAA_TextChanged" ></asp:TextBox>
    <br>
    <asp:TextBox ID="NewAccountNumAA" runat="server" type="text" placeholder="New Account Number*"  pattern="[0-9]+" title="An Account Number can't include character or special character" name="accountnumber" required OnTextChanged="NewAccountNumAA_TextChanged"></asp:TextBox>
    <br>
    <asp:DropDownList ID="SaveCurrentAA" runat="server" class="savcur" name="AccType" OnSelectedIndexChanged="SaveCurrentAA_SelectedIndexChanged">
    <asp:ListItem Value="">Account Type</asp:ListItem>
    <asp:ListItem value="save">Saving</asp:ListItem>
    <asp:ListItem value="current">Current</asp:ListItem>    
    </asp:DropDownList>
    <br>
	  <asp:Button ID="AddClientBtn" runat="server" Text="Add Account" class="AddA" OnClick="AddClientBtn_Click"></asp:Button>
  </div>
</form>
</body>
</html>
