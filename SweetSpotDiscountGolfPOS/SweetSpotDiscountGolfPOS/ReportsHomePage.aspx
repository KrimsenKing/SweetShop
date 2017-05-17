<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportsHomePage.aspx.cs" Inherits="SweetSpotDiscountGolfPOS.ReportsHomePage" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SPMaster" runat="server">
</asp:Content>--%>

<asp:Content ID="ReportsPageContent" ContentPlaceHolderID="IndividualPageContent" runat="server">
    <div id="Reports">
        <h2>Reports Selection</h2>
        <hr />

        <asp:Table runat="server" Width="100%">
            <asp:TableRow Width="100%">
                <asp:TableCell HorizontalAlign="Center" Width ="50%">
                    <%--Start Calendar--%>
                    <%--<div id="calStart" runat="server">--%>
                    <asp:TextBox ID="txtStartDate" ReadOnly="true" Width="195px" placeholder="Please select a starting date." Text="" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell HorizontalAlign="Center" Width ="50%">
                    <asp:TextBox ID="txtEndDate" ReadOnly="true" Width="195px" placeholder="Please select a ending date." Text="" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <%--<hr />--%>
                <asp:TableCell HorizontalAlign="Center" Width ="50%">
                    <asp:Calendar ID="calStartDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="184px" Width="200px" OnSelectionChanged="calStart_SelectionChanged">
                        <DayHeaderStyle BackColor="#5FD367" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#005555" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </asp:TableCell>
                <%--</div>--%>
                <%--<hr />--%>
                <%--End Calendar--%>
                <%--<div id="calEnd" runat="server">--%>

                <%--<hr />--%>
                <asp:TableCell HorizontalAlign="Center" Width ="50%">
                    <asp:Calendar ID="calEndDate" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="calEnd_SelectionChanged">
                        <DayHeaderStyle BackColor="#5FD367" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#005555" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </asp:TableCell>
                <%--</div>--%>
            </asp:TableRow>
        </asp:Table>
        <hr />
        <asp:Button ID="btnRunReport" runat="server" Text="Run Report" Width="200px" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
