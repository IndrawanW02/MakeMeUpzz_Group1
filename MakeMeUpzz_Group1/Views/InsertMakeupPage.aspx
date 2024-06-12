<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.InsertMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Insert Makeup -</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back to Manage Makeup" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <br />

    <div style="display: flex; flex-direction: row; gap: 100px">
        <div>
            <div>
                <asp:Label ID="MNameLbl" runat="server" Text="Makeup Name: "></asp:Label>
                <asp:TextBox ID="MNameTB" runat="server"></asp:TextBox>
                <asp:Label ID="MNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="MPriceLbl" runat="server" Text="Makeup Price: "></asp:Label>
                <asp:TextBox ID="MPriceTB" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="MPriceLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="MWeightLbl" runat="server" Text="Makeup Weight: "></asp:Label>
                <asp:TextBox ID="MWeightTB" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="MWeightLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="MTypeIdLbl" runat="server" Text="Makeup Type Id: "></asp:Label>
                <asp:TextBox ID="MTypeIdTB" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="MTypeIdLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="MBrandIdLbl" runat="server" Text="Makeup Brand Id: "></asp:Label>
                <asp:TextBox ID="MBrandIdTB" runat="server" TextMode="Number"></asp:TextBox>
                <asp:Label ID="MBrandLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Button ID="InsertMBtn" runat="server" Text="Insert" OnClick="InsertMBtn_Click" />
                <asp:Label ID="InsertStat" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>

        <div>
            <h2 style="margin-top: 0;">MakeupType Data Table</h2>
            <asp:GridView ID="MakeupTGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                    <asp:BoundField DataField="MakeupTypeName" HeaderText="Name" SortExpression="MakeupTypeName" />
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <h2 style="margin-top: 0;">MakeupTypeBrand Data Table</h2>
            <asp:GridView ID="MakeupBGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                    <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                    <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
