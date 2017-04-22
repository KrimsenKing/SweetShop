<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SettingsHomePage.aspx.cs" Inherits="WebApplication1.SettingsHomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="SettingsPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Settings">
        <h2>Employee Management</h2>
        <hr />
         <%--Enter search text to find matching Employees information--%>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <hr />
        <asp:Button ID="btnEmployeeSearch" runat="server" Width="150" Text="Employee Search" OnClick="btnEmployeeSearch_Click"/>
        <div class="divider" />
        <asp:Button ID="btnAddNewEmployee" runat="server" Width="150" Text="Add New Employee" OnClick="btnAddNewEmployee_Click"/>
        <hr />
        <asp:GridView ID="grdEmployeesSearched" runat="server" AutoGenerateSelectButton="true"></asp:GridView>
        <br />
        <hr />
        <h2>Taxes</h2>
        <hr />

    </div>
</asp:Content>
