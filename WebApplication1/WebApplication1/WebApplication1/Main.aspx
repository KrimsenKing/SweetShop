<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="MainStyleSheet.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 
     
    <%--    <a href="WebForm1.aspx">-Find a Customer</a>
        <br />
        <a href="WebForm2.aspx">-View Transactions</a>
        <br />
        <a href="addCustomer.aspx">-Add a Customer</a>
        <br />--%>
        <%--<a href="">- View Sales</a>--%>
<div class="menu_simple">
<ul>
<li><a href="Main.aspx">Home</a></li>
<li><a href="WebForm2.aspx">New Sale</a></li>
 <li><a href="#">Cash Out</a></li>
<li><a href="WebForm1.aspx">Search Customer</a></li>
<li><a href="ssInvoicing.aspx">Search Inventory</a></li>
<li><a href="#">Reports</a></li>
<li><a href="#">Taxes</a></li>

<%--<li>&nbsp;</li>
    <li>&nbsp;</li>
    <li>&nbsp;</li>
    <li>&nbsp;</li>
    <li>&nbsp;</li>
    <li>&nbsp;</li>--%>
<%--<li><a href="#">Link 5</a></li>--%>
</ul>
</div>   
<div class="image_simple">
    <img src="image/SweetSpotLogo.jpg" />
        <br />
        <h2>Today's Transactions: </h2>
        <br />
 </div>
   
    </form>
</body>
</html>
