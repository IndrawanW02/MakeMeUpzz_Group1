<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.HandleTransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Handle Transaction -</h1>

    <asp:GridView ID="TransactionHistoryList" runat="server" AutoGenerateColumns="false" OnRowEditing="TransactionHistoryList_RowEditing" OnRowDataBound="TransactionHistoryList_RowDataBound">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" ReadOnly="True" SortExpression="TransactionID"></asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" ReadOnly="True" SortExpression="TransactionDate"></asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
            <asp:CommandField ButtonType="Button" EditText="Handle Transaction" HeaderText="Action" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
        </Columns>
    </asp:GridView>


</asp:Content>
