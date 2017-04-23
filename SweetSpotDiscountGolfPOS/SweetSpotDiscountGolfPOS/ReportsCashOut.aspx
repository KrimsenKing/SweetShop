<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportsCashOut.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.ReportsCashOut" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="ReportsCashOutPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="CashOut">
        <h2>Cash Out</h2>
        <hr />

        <%--Payment Breakdown--%>
        <div class="yesPrint" id="pmt_header">
            <h3>Sales</h3>
        </div>
        <div class="yesPrint" id="pmt_grid">
            <asp:Table ID="tblPmtBreakdown" runat="server" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Width="100px" Text="Trade-In"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Gift Cert."></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Cash"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Cheque"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Debit"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="MasterCard"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Visa"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Amex"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="100px" Text="Total"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell ID="clTradeIn"></asp:TableCell>
                    <asp:TableCell ID="clGiftCert2"></asp:TableCell>
                    <asp:TableCell ID="clCash"></asp:TableCell>
                    <asp:TableCell ID="clCheque"></asp:TableCell>
                    <asp:TableCell ID="clDebit"></asp:TableCell>
                    <asp:TableCell ID="clMasterCard"></asp:TableCell>
                    <asp:TableCell ID="clVisa"></asp:TableCell>
                    <asp:TableCell ID="clAmex"></asp:TableCell>
                    <asp:TableCell ID="clTotalReceipts"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <%--Receipts--%>
        <div class="yesPrint" id="receipt_header">
            <h3>Receipts</h3>
        </div>
        <div class="yesPrint" id="receipt_grid">
            <asp:Table ID="tblReceipts" runat="server" GridLines="Both">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Trade-In"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Gift Cert."></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Cash"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Cheque"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Debit"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="MasterCard"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Visa"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Amex"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell ID="clChkTI">
                        <asp:TextBox ID="txtTrade" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkGC">
                        <asp:TextBox ID="txtGC" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkCash">
                        <asp:TextBox ID="txtCash" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkCheq">
                        <asp:TextBox ID="txtCheque" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkDeb">
                        <asp:TextBox ID="txtDebit" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkMC">
                        <asp:TextBox ID="txtMasterCard" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkVisa">
                        <asp:TextBox ID="txtVisa" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell ID="clChkAmex">
                        <asp:TextBox ID="txtAmex" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button class="noPrint" ID="btnCalculate" runat="server" Text="Calculate" Width="100px" OnClick="btnCalculate_Click" /><asp:Button class="noPrint" ID="btnClear" runat="server" Width="100" Text="Clear" OnClick="btnClear_Click" />
        </div>
        <div class="yesPrint" id="summary_header">
            <h2>Cash Out Summary</h2>
        </div>
        <div class="yesPrint" id="summary">
            <asp:Table ID="tblSumm" runat="server" GridLines="none" CellSpacing="10">
                <asp:TableRow>
                    <asp:TableCell Text="Total Sales:"></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblTotal" CssClass="Underline" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="Less Receipts:"></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblReceipts" CssClass="Underline" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Text="Over(Short):"></asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblOverShort" CssClass="Underline2" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Button class="noPrint" ID="btnPostReport" runat="server" Text="Post Report" Width="100px" OnClientClick="return validatePost()" OnClick="btnPostReport_Click" /><asp:Button class="noPrint" ID="btnPrint" runat="server" Text="Print Report" Width="100px" OnClientClick="printReport()" />
        </div>
    </div>
</asp:Content>
