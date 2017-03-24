<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <img src="image/SweetSpotLogo.jpg" alt="Sweet Spot Logo"/>
        <hr />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:Label ID="lblExist" runat="server" ForeColor="#CC0000"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" DataKeyNames="CustomerId" runat="server" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" Height="140px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="312px" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" BorderStyle="Groove" />
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
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <hr />
        <a href="Main.aspx">Back to Main Page</a>
    
    </div>
    </form>
</body>
</html>
