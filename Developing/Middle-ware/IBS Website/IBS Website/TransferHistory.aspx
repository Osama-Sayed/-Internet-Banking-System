<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferHistory.aspx.cs" Inherits="IBS_Website.TransferHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transfer History</title>
    <link rel="icon" href="Resources/Images/ib.png" type="image/x-icon">
    <meta charset="utf-8">
    <link rel="stylesheet" href="Resources/CSS/TransferHistory.css">
</head>
<body>
    <form id="TransferHistoryForm" runat="server">
    <h2>Transfer History Table</h2>
    <asp:Table ID="TransferTable" runat="server">  
        <asp:TableHeaderRow 
                runat="server" 
                Font-Bold="true"
                >
                <asp:TableHeaderCell>Source Account Number</asp:TableHeaderCell>
                <asp:TableHeaderCell>Destination Account Number</asp:TableHeaderCell>
                <asp:TableHeaderCell>Amount</asp:TableHeaderCell>
             <asp:TableHeaderCell>Currency</asp:TableHeaderCell>
             <asp:TableHeaderCell>Date</asp:TableHeaderCell>
       </asp:TableHeaderRow>
    <asp:TableRow runat="server">  
        <asp:TableCell runat="server"></asp:TableCell>  
        <asp:TableCell runat="server"></asp:TableCell>  
        <asp:TableCell runat="server"></asp:TableCell> 
        <asp:TableCell runat="server"></asp:TableCell> 
        <asp:TableCell runat="server"></asp:TableCell> 
    </asp:TableRow>   
    </asp:Table>
    </form>

</body>
</html>
