<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h1>LOGIN PAGE </h1>

            <div class="InputUsername">
                <asp:Label ID="UsernameLbl" runat="server" Text="Username  "></asp:Label>
                <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
            </div>
            <div class="InputPassword">
                <asp:Label ID="PasswordLbl" runat="server" Text="Password  "></asp:Label>
                <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="RememberMe">
                <asp:CheckBox ID="RememberMeCB" runat="server" />
                <asp:Label ID="RememberMeLbl" runat="server" Text="Remember Me"></asp:Label>
            </div>

            <div>
                <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
            </div>
            
            <div>
                <asp:Label ID="Label1" runat="server" Text="Don't Have an account?"></asp:Label>
                <asp:LinkButton ID="RegisterNav" runat="server" OnClick="RegisterNav_Click">Register Now</asp:LinkButton>
            </div>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
        </div>
    </form>
</body>
</html>
