<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #SweetSpot {
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
       <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
        <img src="image/SweetSpotLogo.jpg" alt="SweetspotLogo" runat="server" id="SweetSpot"/>

        <hr />
       <div id="CompanyInfo">
            <p>The Sweet Spot Discount Golf, Inc.   
            <br />644 Main St N
            <br />Moose Jaw, Saskatchewan
            <br />Canada S6H 7S2
            <br />Phone: 3069724653</p>
           
        </div>
        <hr />
        <br />
             <h3>Invoice</h3>
           <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  >
               <AlternatingRowStyle BackColor="White" />
               <EditRowStyle BackColor="#7C6F57" />
               <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#E3EAEB" />
               <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
               <SortedAscendingCellStyle BackColor="#F8FAFA" />
               <SortedAscendingHeaderStyle BackColor="#246B61" />
               <SortedDescendingCellStyle BackColor="#D4DFE1" />
               <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
           <asp:ObjectDataSource ID="InvoiceDataSource" runat="server"></asp:ObjectDataSource>
        <hr />
        <br />
        <h3>Customer</h3><a href="addCustomer.aspx">Add a Customer</a><br /><a href="WebForm1.aspx">Find a Customer</a>
        <p>First Name:
            <asp:Label ID="txtFirstName" runat="server" Text=""></asp:Label>
            <br />
            Last Name:
            <asp:Label ID="txtLastName" runat="server" Text=""></asp:Label>
            <br />
            Email:
            <asp:Label ID="txtEmail" runat="server" Text=""></asp:Label>
            <br />
            Address:
            <asp:Label ID="txtAddress" runat="server" Text=""></asp:Label>
            <br />
            City:
            <asp:Label ID="txtCity" runat="server" Text=""></asp:Label>
            <br />
            State:
            <asp:Label ID="txtState" runat="server" Text=""></asp:Label>
            <br />
            Country:
            <asp:Label ID="txtCountry" runat="server" Text=""></asp:Label>
            <br />
            ZipCode:
            <asp:Label ID="txtZipCode" runat="server" Text=""></asp:Label>
            <br />
            Phone Number: 
            <asp:Label ID="txtPhoneNumber" runat="server" Text=""></asp:Label>
            <br />
            Ebay User Name: 
            <asp:Label ID="txtEbayUser" runat="server" Text=""></asp:Label>

        </p>
        <%--  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="CustomerDataSource" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="EbayUserName" HeaderText="EbayUserName" SortExpression="EbayUserName" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:ObjectDataSource ID="CustomerDataSource" runat="server" SelectMethod="getCustomer" TypeName="SweetSpot1.CustomerDataUtilities"></asp:ObjectDataSource>--%>

        <hr />
        <br />
        <h3>Product</h3>
        <p>
            <asp:TextBox ID="txtUPC" runat="server" Height="17px" Width="294px"></asp:TextBox>
            <asp:Button ID="btnItemLookUp" runat="server" OnClick="btnItemLookUp_Click" Text="Submit" />
        </p>
        <p>
            <asp:Label ID="lblExist" runat="server"></asp:Label>
        </p>
        <p>
            <asp:GridView ID="grdItems" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </p>
        <hr />
        <br />
        <h3>Payment and Shipping Details</h3>
        <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:ObjectDataSource ID="PaymentDataSource" runat="server"></asp:ObjectDataSource>
        <hr />
        <br />
        <h4>Customer's Notes</h4>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
        <hr />
        <p>Thanks!</p>
        <p>PLEASE NOTE: All used equipment is sold "AS-|S' and is understood that its condition and usability may reflect
        prior use. The Sweet Spot Discount Golf assumes no responsibility beyond the point of sale. ALL SALES FINAL
        Thank you for shopping at The Sweet Spot!</p>

        <hr />

        <asp:Button ID="btnSave" runat="server" Text="Save Info" OnClick="btnSave_Click" />
        <hr />
        <br />
        <a href="Main.aspx">Back to Main Page</a>
    </div>
    </form>
</body>
</html>
