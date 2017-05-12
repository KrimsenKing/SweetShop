<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalesCart.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.SalesCart" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="NonActive" ContentPlaceHolderID="SPMaster" runat="server">

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Leaving page will remove all items from cart. Continue?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>


    <div id="menu_simple">
        <ul>
            <li><a>HOME</a></li>
            <li><a>CUSTOMERS</a></li>
            <li><a>SALES</a></li>
            <li><a>INVENTORY</a></li>
            <li><a>REPORTS</a></li>
            <li><a>SETTINGS</a></li>
        </ul>
    </div>
    <div id="image_simple">
        <img src="Images/SweetSpotLogo.jpg" />
    </div>
    <link rel="stylesheet" type="text/css" href="CSS/MainStyleSheet.css" />
</asp:Content>
<asp:Content ID="CartPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Cart">
        <asp:Label ID="lblCustomer" runat="server" Text="Customer Name:"></asp:Label>
        <asp:TextBox ID="txtCustomer" ReadOnly="true" runat="server"></asp:TextBox>
        <asp:Button ID="btnCustomerSelect" runat="server" Text="Select Different Customer" OnClick="btnCustomerSelect_Click" />
        <div style="text-align: right">
            <asp:Label ID="lblInvoiceNumber" runat="server" Text="Invoice No:"></asp:Label>
            <asp:TextBox ID="txtInvoiceNumber" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
            <asp:Label ID="lblExists" runat="server" Text="Label" Visible="True"></asp:Label>
            <hr />
        </div>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnInventorySearch" runat="server" Width="150" Text="Inventory Search" OnClick="btnInventorySearch_Click" />
        <hr />
        <asp:GridView ID="grdInventorySearched" runat="server" AutoGenerateColumns="False">

            <Columns>

                <asp:BoundField DataField="sku" HeaderText="SKU" />

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:Label ID="QuantityInOrder" Text='<%#Eval("quantityInOrder")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="price" HeaderText="Prc" />


            </Columns>

        </asp:GridView>

        <%--//Radio button for InStore or Shipping--%>
        <asp:RadioButton ID="rdStore" runat="server" Text="In Store" Checked="True" GroupName="rgSales" />
        <asp:RadioButton ID="rdShipping" runat="server" Text="Shipping" GroupName="rgSales" />
        <hr />
        <h3>Cart</h3>
        <hr />
        <asp:GridView ID="grdCartItems" runat="server"></asp:GridView>
        <hr />
        <asp:Label ID="lblSubtotal" runat="server" Text="Subtotal:"></asp:Label>
        <asp:TextBox ID="txtSubtotal" ReadOnly="true" runat="server"></asp:TextBox>
        <hr />
        <asp:Button ID="btnCancelSale" runat="server" Text="Cancel Sale" OnClick="btnCancelSale_Click" OnClientClick="Confirm()" />
        <asp:Button ID="btnProceedToCheckout" runat="server" Text="Proceed to Checkout" OnClick="btnProceedToCheckout_Click" />
    </div>
</asp:Content>
