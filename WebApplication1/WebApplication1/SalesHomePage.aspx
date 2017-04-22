<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalesHomePage.aspx.cs" Inherits="WebApplication1.SalesHomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="salesPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Sales">
        <h2>Sales</h2>
        <hr />
        <asp:Button ID="btnNewSale" runat="server" Width="150" Text="New Sale" OnClick="btnNewSale_Click" />
        <div class="divider" />
        <asp:Button ID="btnReturn" runat="server" Width="150" Text="Return" OnClick="btnReturn_Click" />
    </div>
</asp:Content>
