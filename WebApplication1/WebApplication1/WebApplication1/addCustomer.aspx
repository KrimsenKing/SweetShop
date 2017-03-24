<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCustomer.aspx.cs" Inherits="WebApplication1.addCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img src="image/SweetSpotLogo.jpg" alt="Sweet Spot Logo" />
        <hr />
        <h1 style="text-align:center;"><u>Add a Customer</u></h1>
        <br />
        <br />
        <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblAddress" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <br />
        <br />

         <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblCountry" runat="server" Text="Country: "></asp:Label>
        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblZipCode" runat="server" Text="ZipCode: "></asp:Label>
        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: "></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:Label ID="lblEbayUserName" runat="server" Text="Ebay User Name: "></asp:Label>
        <asp:TextBox ID="txtEbayUserName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add Customer" OnClick="btnAdd_Click" />
        <br />
        <br />
        <asp:Label ID="lblFirstNameCus" runat="server" Text="First Name: "></asp:Label>
        <asp:Label ID="lblCustFirst" runat="server" Text=""></asp:Label>
        <br />
        
         <asp:Label ID="lblLastNameCus" runat="server" Text="Last Name: "></asp:Label>
        <asp:Label ID="lblCustLast" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblEmailCus" runat="server" Text="Email: "></asp:Label>
        <asp:Label ID="lblCustEmail" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblAddressCus" runat="server" Text="Address: "></asp:Label>
        <asp:Label ID="lblCustAddress" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblCityCus" runat="server" Text="City: "></asp:Label>
        <asp:Label ID="lblCustCity" runat="server"></asp:Label>
        <br />

         <asp:Label ID="lblStateCus" runat="server" Text="State: "></asp:Label>
        <asp:Label ID="lblCustState" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblCountryCus" runat="server" Text="Country: "></asp:Label>
        <asp:Label ID="lblCustCountry" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblZipCodeCus" runat="server" Text="ZipCode: "></asp:Label>
        <asp:Label ID="lblCustZipCode" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblPhoneNumCus" runat="server" Text="Phone Number: "></asp:Label>
        <asp:Label ID="lblCustPhoneNum" runat="server"></asp:Label>
        <br />
         <asp:Label ID="lblEbayCus" runat="server" Text="Ebay User Name: "></asp:Label>
        <asp:Label ID="lblCustEbay" runat="server"></asp:Label>

        <hr />
        <a href="Main.aspx">Back to Main Page</a>

    </div>
    </form>
</body>
</html>
