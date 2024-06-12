<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Homepage -</h1>
    <asp:Label ID="RoleLbl" runat="server" Text=""></asp:Label>
    <asp:Label ID="UsernameLbl" runat="server" Text=""></asp:Label>

    <hr />

    <asp:Label ID="CustomerListLbl" runat="server" Text="Customer List" Visible="false"></asp:Label>
    <asp:GridView ID="CustomerList" runat="server" AutoGenerateColumns="false" Visible="false">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID"></asp:BoundField>
            <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username"></asp:BoundField>
            <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" ReadOnly="True" SortExpression="UserEmail"></asp:BoundField>
            <asp:BoundField DataField="UserDOB" HeaderText="UserDOB" ReadOnly="True" SortExpression="UserDOB"></asp:BoundField>
            <asp:BoundField DataField="UserGender" HeaderText="UserGender" ReadOnly="True" SortExpression="UserGender"></asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
