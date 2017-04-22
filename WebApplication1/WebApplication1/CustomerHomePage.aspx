<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CustomerHomePage.aspx.cs" Inherits="WebApplication1.CustomerHomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="customerHomePageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Customer">
        <h2>Customer Information</h2>
        <hr />
        <%--Enter search text to find matching customer information--%>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <hr />
        <asp:Button ID="btnCustomerSearch" runat="server" Width="150" Text="Customer Search" OnClick="btnCustomerSearch_Click" />
        <div class="divider" />
        <asp:Button ID="btnAddNewCustomer" runat="server" Width="150" Text="Add New Customer" OnClick="btnAddNewCustomer_Click" />
        <hr />
        <asp:GridView ID="grdCusomersSearched" runat="server" AutoGenerateSelectButton="true"></asp:GridView>
    </div>
</asp:Content>
