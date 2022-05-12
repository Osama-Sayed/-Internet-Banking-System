<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IBS_Website.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
	<link rel="stylesheet" href="home.css"/>
</head>
<body>
	<form id="form1" runat="server">
	<div id="allbody">
		 
		<header id="top_header">
				<img id="header_img" src="logo3.png" height="100" width="350" />
	            <button id="button1"><strong>Login</strong></button>
			  <button id="button2"><strong>Register</strong></button>
		              <br />
		
		</header>
			
			
	<div id="all_section">
	
			         <img id="section_img" src="Fast-Facts.jpg" />  <hr id="fl" />
		<section>
	           <article id="article">
			         <header>
					    <h1>Welcome To O.L.S </h1>
					 </header>
					 <p id="first_p">
					    The Rashidy family has been in the field of education for over fifty years.<br />
   					    Mr Hussien El Rashidy started the Orouba educational institutions in 1960 with <br /> 
						Orouba Language School in Dokki.IGCSE was added in 1992.<br /> 
						Orouba Language Schools use the Egyptian curriculum.<br />
					    We follow the Egyptian Ministry of Education in all subjects from Nursery to grade 12.<br />
					    Moreover, high level English is given starting from nursery whereas high level <br />
						French is given starting from 2nd Primary.
					 </p>
			   </article>
                <hr id="sl" />
               
		</section>
		
		<footer id="footer">
							<p id="f1">Internet Banking System (2022)</p>
	<asp:GridView ID="gridService" runat="server">  
		<Columns>

                    <asp:TemplateField HeaderText="FirstName">

                        <ItemTemplate>

                            <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server" />

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtFirstNameFooter" runat="server" />

                        </FooterTemplate>

                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="LastName">

                        <ItemTemplate>

                            <asp:Label Text='<%# Eval("LastName") %>' runat="server" />

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" />

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtLastNameFooter" runat="server" />

                        </FooterTemplate>

                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="ContactName">

                        <ItemTemplate>

                            <asp:Label Text='<%# Eval("ContactName") %>' runat="server" />

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:TextBox ID="txtContact" Text='<%# Eval("ContactName") %>' runat="server" />

                        </EditItemTemplate>

                        <FooterTemplate>

                            <asp:TextBox ID="txtContactFooter" runat="server" />

                        </FooterTemplate>

                    </asp:TemplateField>

                </Columns>
</asp:GridView>  
                        
		</footer>
	
	</div>	
	</div>
	
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="45px" OnTextChanged="TextBox1_TextChanged" Width="416px"></asp:TextBox>
        </p>
        <p>
            <input id="Text1" type="text" /></p>
        <p>
            <input id="Password1" type="password" /></p>
        
    </form>
	
</body>
</html>
