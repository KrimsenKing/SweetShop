<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalesCheckout.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.SalesCheckout" %>

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

        function getValue() {
            var retVal = prompt("Enter amount paid: $", "0.00");
            document.forms[0].appendChild(retVal);
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
<asp:Content ID="CheckoutPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <h3>Transaction Details</h3>
        <div>
            <table>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td colspan="2" style="text-align:center">Methods of Payment</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="mopAmericanExpress" runat="server" Text="American Express" OnClick="mopAmericanExpress_Click" Width="163px"/>
                                </td>
                                <td>
                                    <asp:Button ID="mopCash" runat="server" Text="Cash" OnClick="mopCash_Click" Width="163px"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="mopDiscover" runat="server" Text="Discover" OnClick="mopDiscover_Click" Width="163px" />
                                </td>
                                <td>
                                    <asp:Button ID="mopCheque" runat="server" Text="Cheque" OnClick="mopCheque_Click" Width="163px"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="mopMasterCard" runat="server" Text="MasterCard" OnClick="mopMasterCard_Click" Width="163px"/>
                                </td>
                                <td>
                                    <asp:Button ID="mopDebit" runat="server" Text="Debit" OnClick="mopDebit_Click" Width="163px"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="mopVisa" runat="server" Text="Visa" OnClick="mopVisa_Click" Width="163px"/>
                                </td>
                                <td>
                                    <asp:Button ID="mopGiftCard" runat="server" Text="Gift Card" OnClick="mopGiftCard_Click" Width="163px"/>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="2">
                        <asp:Table ID="tblTotals" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblTotalInCart" runat="server" Text="Total In Cart:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblTotalInCartAmount" runat="server" Text=""></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblTradeIns" runat="server" Text="Trade-Ins:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblTradeInsAmount" runat="server" Text=""></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblShipping" runat="server" Text="Shipping:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtShippingAmount" runat="server" Text=""></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSubTotal" runat="server" Text="Subtotal:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblSubTotalAmount" runat="server" Text=""></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblGovernment" runat="server" Text="GST:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblGovernmentAmount" runat="server" Text=""></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btnRemoveGov" runat="server" Text="Remove GST" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblProvincial" runat="server" Text="PST:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblProvincialAmount" runat="server" Text=""></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btnRemoveProv" runat="server" Text="Remove PST" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblBalance" runat="server" Text="Balance Due:"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblBalanceAmount" runat="server" Text=""></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvCurrentMOPs" runat="server"></asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCancelSale" runat="server" Text="Cancel Sale" OnClick="btnCancelSale_Click" Width="163px"/>
                    </td>
                    <td>
                        <asp:Button ID="btnReturnToCart" runat="server" Text="Return To Cart" OnClick="btnReturnToCart_Click" Width="163px"/>
                    </td>
                    <td>
                        <asp:Button ID="btnLayaway" runat="server" Text="Layaway" OnClick="btnLayaway_Click" Width="163px"/>
                    </td>
                    <td>
                        <asp:Button ID="btnFinalize" runat="server" Text="Process Sale" OnClick="btnFinalize_Click" Width="163px"/>
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
