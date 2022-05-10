<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientProfilenavbar.aspx.cs" Inherits="IBS_Website.ClientProfilenavbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>navigation bar</title>
	<link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">

	<meta charset="utf-8">
	<meta name="description" content="This page has the navigation bar of the bank">
								
										<!-- CSS-->
	<link rel="stylesheet" type="text/css" href="Resources/CSS/clientprofilenavbar.css">

</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>

    <div id="allbody">
		 
		<header id="top_header">
				<a class="logolink" href="Home.aspx" target="_top"><img id="header_img" src="Resources/Images/ib.png" /></a>

			<h2 id="logoname">Internet Banking System</h2>
	      <form id="login">
		        <button id="buttonlogout"><strong>Logout</strong></button>
			   
	      </form>
		</header>
		</div>
</body>
</html>
