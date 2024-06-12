<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupBrandPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.UpdateMakeupBrandPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Update Makeup Brand <%=Request.QueryString["id"] %> -</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back to Manage Makeup" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <div>
        <asp:Label ID="MBNameLbl" runat="server" Text="Makeup Brand Name: "></asp:Label>
        <asp:TextBox ID="MBNameTB" runat="server"></asp:TextBox>
        <asp:Label ID="MBNameLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Label ID="MBRatingLbl" runat="server" Text="Makeup Brand Rating: "></asp:Label>
        <asp:TextBox ID="MBRatingTB" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Label ID="MBRatingLblError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    <div>
        <asp:Button ID="UpdateMBBtn" runat="server" Text="Insert" OnClick="UpdateMBBtn_Click" />
        <asp:Label ID="UpdateMBStat" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
