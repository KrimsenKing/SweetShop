<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalesHomePage.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.SalesHomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="salesPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Sales">
        <%--REMEMBER TO SET DEFAULT BUTTON--%>
        <asp:Panel ID="pnlDefaultButton" runat="server" DefaultButton="btnQuickSale">
            <h2>Sales</h2>
            <hr />
            <asp:Button ID="btnQuickSale" runat="server" Width="150" Text="Quick Sale" OnClick="btnQuickSale_Click" />
            <div class="divider" />
            <asp:Button ID="btnReturn" runat="server" Width="150" Text="Return" OnClick="btnReturn_Click" />
        </asp:Panel>
    </div>
</asp:Content>
