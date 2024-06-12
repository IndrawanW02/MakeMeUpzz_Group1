<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.TransactionHistoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Transaction History -</h1>

    <asp:GridView ID="TransactionHistoryList" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="TransactionHistoryList_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" ReadOnly="True" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" ReadOnly="True" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" ShowHeader="True" HeaderText="View Detail"></asp:CommandField>
        </Columns>
    </asp:GridView>

</asp:Content>
