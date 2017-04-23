<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InventoryHomePage.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.InventoryHomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="InventoryPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Inventory">
        <h2>Inventory Information</h2>
        <hr />
        <asp:Label ID="lblInventoryType" runat="server" Text="Inventory Type"></asp:Label>
        <div class="divider" />
        <asp:DropDownList ID="ddlInventoryType" runat="server" DataSourceID="sqlInventoryTypes" DataTextField="typeDescription" DataValueField="typeID"></asp:DropDownList>
            <asp:SqlDataSource ID="sqlInventoryTypes" runat="server" ConnectionString="<%$ ConnectionStrings:SweetSpotDevConnectionString %>" SelectCommand="SELECT [typeID], [typeDescription] FROM [tbl_itemType]"></asp:SqlDataSource>
        <hr />
        <%--Enter search text to find matching Inventory information--%>
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <hr />
        <asp:Button ID="btnInventorySearch" runat="server" Width="150" Text="Inventory Search" OnClick="btnInventorySearch_Click"/>
        <div class="divider" />
        <asp:Button ID="btnAddNewInventory" runat="server" Width="150" Text="Add New Inventory" OnClick="btnAddNewInventory_Click"/>
        <hr />
        <asp:GridView ID="grdInventorySearched" runat="server" AutoGenerateSelectButton="true"></asp:GridView>
    </div>
</asp:Content>
