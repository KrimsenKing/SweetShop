<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashOut.aspx.cs" Inherits="WebApplication1.CashOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> Sweet Spot Discount Golf Cash Out Sheet</h1>
    <hr />
    Date:
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
    <hr />
    

    </div>
        <div id="sales">
            <h3><u>Sales Recap</u></h3>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:DynamicField HeaderText="TradeIn" />
                <asp:DynamicField HeaderText="Gift Certificate" />
                  <asp:TemplateField HeaderText="Merchandise (new)">
                    <ItemTemplate>
                        <asp:Label ID="newMerch" runat="server" Text='<%#Eval("Merchandise (new)") %> '></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Clubs (used)">
                    <ItemTemplate>
                        <asp:Label ID="giftCert" runat="server" Text='<%#Eval("Gift Certificate") %> '></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Simulator Time">
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="GST">
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="PST"></asp:TemplateField>
                <asp:TemplateField HeaderText="Total Sales"></asp:TemplateField>


            </Columns>
        </asp:GridView>
            </div>
        
        <div id="receipts">
            <h3><u>Receipts</u></h3>
            <asp:GridView ID="GridView2" runat="server">
                <Columns>

                    <asp:TemplateField HeaderText="Trade In"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Gift Certificates"></asp:TemplateField>
                    <asp:TemplateField HeaderText="DEBIT"></asp:TemplateField>
                    <asp:TemplateField HeaderText="MASTERCARD"></asp:TemplateField>
                    <asp:TemplateField HeaderText="VISA"></asp:TemplateField>
                    <asp:TemplateField HeaderText="CASH"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Cheque"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Receipts"></asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

        <hr />
        <div id="daysTotal">
            <b><u>Total Sales: </u></b>
            <asp:Label ID="lblTotalSales" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <b><u>Total Receipts:</u></b>
            <asp:Label ID="lblTotalReceipts" runat="server" Text=""></asp:Label>
            <br />
            
            <br />
            <b><u>Over(Short):</u></b>
            <asp:Label ID="lblOverShort" runat="server" Text=""></asp:Label>
        </div>
        <br />

        <asp:Button ID="btnPost" runat="server" Text="Post" />

    </form>
</body>
</html>
