<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartTemplate.aspx.cs" Inherits="sweetspotTestSite.CartTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" class="sku" runat="server" Height="112px">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Height="76px" Width="272px"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Width="80px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server" Width="103px"></asp:TextBox>
        </asp:Panel>
    </form>
</body>
</html>
