<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="UpdateMakeupPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.UpdateMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Update Makeup <%=Request.QueryString["id"] %> -</h1>
    <div>
        <asp:Button ID="BackBtn" runat="server" Text="< Back to Manage Makeup" OnClick="BackBtn_Click" />
    </div>
    <hr />

    <br />

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
        <asp:Button ID="UpdateMBtn" runat="server" Text="Update" OnClick="UpdateMBtn_Click" />
        <asp:Label ID="UpdateStat" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
