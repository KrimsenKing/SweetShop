<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ssInvoicing.aspx.cs" Inherits="WebApplication1.ssInvoicing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body>
 <form id="ssInvoice" runat="server">
    <div>
    <img src="image/SweetSpotLogo.jpg" alt="Sweet Spot Logo" />
        <br />
        <asp:Label ID="lblExist" runat="server"></asp:Label>
        <br />
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
        <br />
        <asp:Label ID="lblUPC" runat="server" Text="Item UPC/SKU: "></asp:Label>
        <asp:TextBox ID="txtUPC" runat="server" Width="265px"></asp:TextBox>
&nbsp;
        <br />
        <asp:Button ID="btnItemLookUp" runat="server" OnClick="btnItemLookUp_Click" Text="Submit" Width="377px" />
    
        <hr />
        <br />
        <a href="Main.aspx">Back to Main Page</a>
    </div>
    </form>
</body>
</html>
