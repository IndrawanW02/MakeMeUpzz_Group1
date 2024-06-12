<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>- Profile -</h1>

    <div style="display: flex; flex-direction: row; gap: 50px;">
        <div>
            <h2>Update Profile</h2>

            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:Label ID="usernameErr" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:Label ID="emailErr" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblDob" runat="server" Text="Date of Birth"></asp:Label>
                <asp:Calendar ID="UserDOBCalendar" runat="server" OnSelectionChanged="UserDOBCalendar_SelectionChanged"></asp:Calendar>
                <asp:TextBox ID="txtDob" runat="server" Enabled="false"></asp:TextBox>
                <asp:Label ID="DOBErr" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                <asp:RadioButtonList ID="GenderRB" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="genderErr" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>

            <div>
                <asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label>
                <asp:TextBox ID="txtRole" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" OnClick="btnUpdateProfile_Click" />
        </div>

        <div>
            <h2>Change Password</h2>
            <div>
                <asp:Label ID="lblOldPassword" runat="server" Text="Old Password"></asp:Label>
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Label ID="oldPasswordErr" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblNewPassword" runat="server" Text="New Password"></asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnUpdatePassword" runat="server" Text="Update Password" OnClick="btnUpdatePassword_Click" />
            </div>
        </div>
    </div>
</asp:Content>
