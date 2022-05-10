<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IBS_Website.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
	<link rel="stylesheet" href="Resources/CSS/Home.css"/>
	<link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
</head>
<body>
    <form id="HomeForm" runat="server">
        <div>
        </div>
    
	<div id="allbody">
		 
		<header id="top_header">
				<a class="logolink" href="Home.aspx"><img id="header_img" src="Resources/Images/ib.png" /></a>

			<h2 id="logoname">Internet Banking System</h2>
	      <div id="login">
		        <asp:Button id="LoginH" runat="server" Text="Login" class="ButtonL" OnClick="LoginH_Click"></asp:Button>
			    <asp:Button id="RegisterH" runat="server" Text="Register" class="ButtonR" OnClick="RegisterH_Click"></asp:Button>
		              <br />
	      </div>
		
		</header>
	
			
	<div id="all_section">
	
			         <img id="section_img" src="Resources/Images/bank.jpg" /> 
		<section>
	           <article id="article">
			         <header>
					    <h1>Welcome To QB BANK </h1>
					 </header>
					 <p id="first_p">
					     QB Bank (QB Group) (Arabic: بنكى العربى) is a
						 Arabic multinational commercial bank headquartered in Egypt, Doha, Qatar. 
						 It was founded in 2021 and currently has subsidiaries<br /> and associates
						 in 31 countries spanning three continents. The bank's ownership is evenly divided 
						 between the Egypt Investment Authority and members of the public.
						 <br />QB was founded on 6 June 1964 as the country' first domestically-owned commercial bank. 
						 It had 35 employees in its first year and was initially headquartered in
						 a government-owned<br /> building in Qatar's capital city, Doha.
						 The two currencies in circulation at the time were the 
						 Indian rupee and British pound. <br /> As Qatar's population continued increasing 
						 throughout the century, QB started establishing branches in other parts of the country.

						<br />In 2020, the first branches outside of Doha were opened in Al Khor and Mesaieed. 
						 The bank installed its first ATMs in 2021 in its Doha branches 
						 and in the next year, <br />introduced VISA cards for its clients.
						 By 2021, it had established 76 branches in Qatar.<br />
						 Qatar National Bank (QB) controls an 82.59 percent stake in Bank QNB Indonesia.
					 </p>
			   </article>
               
		</section>
		<footer id="footer">
							<p id="f1">Internet Banking System (2022)</p>
		</footer>
	</div>	
	</div>
	</form>
</body>
</html>
