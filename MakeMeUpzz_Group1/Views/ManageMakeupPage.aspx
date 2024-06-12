<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="ManageMakeupPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.ManageMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Manage Makeup -</h1>
    <hr />

    <div style="display: flex; flex-direction: row; gap: 100px;">
        <div>
            <h2>Makeup Data Table</h2>
            <div>
                <asp:Button ID="MInsrtBtn" runat="server" Text="Insert Makeup" Width="155px" OnClick="MInsrtBtn_Click" />
            </div>
            <asp:GridView ID="MakeupGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupGV_RowDeleting" OnRowEditing="MakeupGV_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
                    <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                    <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                    <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                    <asp:BoundField DataField="MakeupTypeID" HeaderText="Type ID" SortExpression="MakeupTypeID" />
                    <asp:BoundField DataField="MakeupBrandID" HeaderText="Brand ID" SortExpression="MakeupBrandID" />
                    <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <h2>MakeupType Data Table</h2>
            <div>
                <asp:Button ID="MTInsrtBtn" runat="server" Text="Insert Makeup Type" Width="208px" OnClick="MTInsrtBtn_Click" />
            </div>
            <asp:GridView ID="MakeupTGV" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupTGV_RowEditing" OnRowDeleting="MakeupTGV_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                    <asp:BoundField DataField="MakeupTypeName" HeaderText="Name" SortExpression="MakeupTypeName" />
                    <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <h2>MakeupTypeBrand Data Table</h2>
            <div>
                <asp:Button ID="MBInsrtBtn" runat="server" Text="Insert Makeup Brand" Width="208px" OnClick="MBInsrtBtn_Click" />
            </div>
            <asp:GridView ID="MakeupBGV" runat="server" AutoGenerateColumns="False" OnRowEditing="MakeupBGV_RowEditing" OnRowDeleting="MakeupBGV_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                    <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                    <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
                    <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </div>
    </div>


</asp:Content>
