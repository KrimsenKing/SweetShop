<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication1.HomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="homePageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <h2>Today's Transactions</h2>
    <hr />
    <asp:GridView ID="grdSameDaySales" runat="server"></asp:GridView>
</asp:Content>
