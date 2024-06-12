<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>REGISTER PAGE </h1>

            <div>
                <asp:Label ID="UsernameLbl" runat="server" Text="Username : "></asp:Label>
                <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
                <asp:Label ID="UsernameErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="EmailLbl" runat="server" Text="Email : "></asp:Label>
                <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
                <asp:Label ID="EmailErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="GenderLbl" runat="server" Text="Gender : "></asp:Label>
                <asp:RadioButtonList ID="GenderRbl" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="GenderErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="PasswordLbl" runat="server" Text="Password : "></asp:Label>
                <asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
                <asp:Label ID="PasswordErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="ConfirmationPassLbl" runat="server" Text="Confirmation Password : "></asp:Label>
                <asp:TextBox ID="ConfirmationPassTB" runat="server"></asp:TextBox>
                <asp:Label ID="ConfirmationPassErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth : "></asp:Label>
                <asp:Calendar ID="DOBCalendar" runat="server" OnSelectionChanged="DOBCalendar_SelectionChanged"></asp:Calendar>
                <asp:TextBox ID="DOBTB" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:Label ID="DOBErrLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div>
                <asp:Label ID="haveAccLbl" runat="server" Text="Already Have an account?"></asp:Label>
                <asp:LinkButton ID="LoginNav" runat="server" OnClick="LoginNav_Click">Login Now</asp:LinkButton>
            </div>
            <div>
                <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
            </div>


        </div>
    </form>
</body>
</html>
