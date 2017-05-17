<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InventoryAddNew.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.InventoryAddNew" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="InventoryAddNewPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="NewInventory">
        <%--Textboxes and Labels for user to enter inventory info--%>
        <h2>Inventory Management</h2>


        <asp:Table ID="Table1" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell Width="25%">
                    <asp:Label ID="lblSKU" runat="server" Text="SKU: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="25%">
                    <asp:Label ID="lblSKUDisplay" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="25%">
                    <asp:Label ID="lblCost" runat="server" Text="Cost: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell Width="25%">
                    <asp:TextBox ID="txtCost" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblCostDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBrand" runat="server" Text="Brand Name: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ddlBrand" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblBrandDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPrice" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblPriceDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblQuantityDisplay" runat="server" Text=""></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPremium" runat="server" Text="Premium: " Visible="false"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtPremium" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblPremiumDisplay" runat="server" Text="" Visible="false"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4"><hr /></asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblClubType" runat="server" Text="Club Type: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtClubType" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblClubTypeDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblModel" runat="server" Text="Model: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="ddlModel" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblModelDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblShaft" runat="server" Text="Shaft: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtShaft" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblShaftDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblNumberofClubs" runat="server" Text="Number of Clubs: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtNumberofClubs" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblNumberofClubsDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblClubSpec" runat="server" Text="Club Spec: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtClubSpec" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblClubSpecDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblShaftSpec" runat="server" Text="Shaft Spec: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtShaftSpec" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblShaftSpecDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblShaftFlex" runat="server" Text="ShaftFlex: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtShaftFlex" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblShaftFlexDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDexterity" runat="server" Text="Dexterity: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtDexterity" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label ID="lblDexterityDisplay" runat="server" Text="" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4"><hr /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblComments" runat="server" Text="Comments: "></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:CheckBox ID="chkUsed" runat="server" Text="Used"></asp:CheckBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4">
                    <asp:TextBox Height="30px" Width="100%" ID="txtComments" runat="server" Visible="false"></asp:TextBox>
                    <asp:Label Height="30px" Width="100%" ID="lblComentsDisplay" runat="server" Visible="true"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="4"><hr /></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button ID="btnAddCustomer" runat="server" Text="Add Customer" OnClick="btnAddCustomer_Click" Visible="false" />
                    <asp:Button ID="btnEditCustomer" runat="server" Text="Edit Customer" OnClick="btnEditCustomer_Click" Visible="true" />
                    <asp:Button ID="btnSaveCustomer" runat="server" Text="Save Changes" OnClick="btnSaveCustomer_Click" Visible="false" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Button ID="btnBackToSearch" runat="server" Text="Exit Customer" OnClick="btnBackToSearch_Click" Visible="true" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Visible="false" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </div>
</asp:Content>
