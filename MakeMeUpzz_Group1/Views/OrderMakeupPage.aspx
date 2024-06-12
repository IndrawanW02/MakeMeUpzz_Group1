<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/NavigationBar.Master" AutoEventWireup="true" CodeBehind="OrderMakeupPage.aspx.cs" Inherits="MakeMeUpzz_Group1.Views.OrderMakeupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>- Order Makeup -</h1>

    <section style="display: flex; flex-direction: row; gap: 100px;">
        <div>
            <h2>Makeup Catalogue</h2>

            <asp:GridView ID="MakeupList" runat="server" AutoGenerateColumns="false" OnRowCommand="MakeupList_RowCommand">
                <Columns>
                    <asp:BoundField DataField="MakeupID" ReadOnly="True" SortExpression="MakeupID"></asp:BoundField>
                    <asp:BoundField DataField="MakeupName" HeaderText="Name" ReadOnly="True" SortExpression="MakeupName"></asp:BoundField>
                    <asp:BoundField DataField="MakeupPrice" HeaderText="Price" ReadOnly="True" SortExpression="MakeupPrice"></asp:BoundField>
                    <asp:BoundField DataField="MakeupWeight" HeaderText="Weight in grams" ReadOnly="True" SortExpression="MakeupWeight"></asp:BoundField>
                    <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" ReadOnly="True" SortExpression="MakeupType.MakeupTypeName"></asp:BoundField>
                    <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" ReadOnly="True" SortExpression="MakeupBrand.MakeupBrandName"></asp:BoundField>
                    <asp:TemplateField HeaderText="OrderQuantity">
                        <ItemTemplate>
                            <asp:TextBox ID="QuantityTB" runat="server" TextMode="Number"></asp:TextBox>
                            <asp:Label ID="QuantityErrLbl" runat="server" Text="Label" ForeColor="Red" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="OrderBtn" runat="server" Text="Order" CommandName="AddToCart" CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div>
            <h2>Shopping Summary</h2>

            <asp:Repeater ID="ShoppingSummary" runat="server">
                <ItemTemplate>
                    <p><%# Eval("Makeup.MakeupType.MakeupTypeName") %>, <%# Eval("Quantity") %> Item(s)</p>
                </ItemTemplate>
            </asp:Repeater>

            <div>
                <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" OnClientClick="return confirm('Do you want to clear the cart item(s) ?')"/>
            </div>
            <div>
                <asp:Button ID="CheckOutBtn" runat="server" Text="Checkout" OnClick="CheckOutBtn_Click"/>
            </div>
        </div>
    </section>

</asp:Content>
