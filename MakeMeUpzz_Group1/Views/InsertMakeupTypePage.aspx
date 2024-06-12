<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="InsertMakeupTypePage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.InsertMakeupTypePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Insert Makeup Type -</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back to Manage Makeup" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <br />

    <div>
        <asp:Label ID="MTNameLbl" runat="server" Text="Makeup Type Name: "></asp:Label>
        <asp:TextBox ID="MTNameTB" runat="server"></asp:TextBox>
        <asp:Label ID="MTNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="InsertMTBtn" runat="server" Text="Insert" OnClick="InsertMTBtn_Click" />
        <asp:Label ID="InsertMTStat" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
