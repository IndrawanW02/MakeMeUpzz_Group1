using MakeMeUpzz_Group1.Controllers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Views
{
    public partial class OrderMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                User user;
                if (Session["user"] == null)
                {
                    var id = Request.Cookies["user_cookie"].Value;
                    user = UserController.GetUserByID(Convert.ToInt32(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                // Memastikan hanya Customer yang bisa mengakses page ini
                if (user.UserRole.Equals("Admin"))
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

                if (!IsPostBack)
                {
                    BindMakeupList();
                }

                BindShoppingSummary(user.UserID);
            }
        }

        private void BindMakeupList()
        {
            List<Makeup> makeupList = MakeupController.GetAllMakeup();
            MakeupList.DataSource = makeupList;
            MakeupList.DataBind();

            MakeupList.Columns[0].Visible = false;
        }

        private void BindShoppingSummary(int UserID)
        {
            List<Cart> userCartSummary = CartController.GetUserCart(UserID);
            ShoppingSummary.DataSource = userCartSummary;
            ShoppingSummary.DataBind();
        }

        protected void MakeupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIdx = Convert.ToInt32(e.CommandArgument);
            TextBox quantityTb = (TextBox)MakeupList.Rows[rowIdx].FindControl("QuantityTB");
            Label errLabel = (Label)MakeupList.Rows[rowIdx].FindControl("QuantityErrLbl");

            GridViewRow row = MakeupList.Rows[rowIdx];
            if (quantityTb.Text.Equals(""))
            {
                errLabel.Visible = true;
                errLabel.Text = "Quantity cannot be empty";
            }
            else
            {
                int quantity = Convert.ToInt32(quantityTb.Text);
                if (quantity < 1)
                {
                    errLabel.Visible = true;
                    errLabel.Text = "Quantity must be bigger than 0";
                }
                else
                {
                    errLabel.Visible = false;

                    User currUser = (User)Session["user"];
                    int userId = currUser.UserID;
                    int choosenMakeupId = Convert.ToInt32(row.Cells[0].Text);

                    CartController.AddCartItem(userId, choosenMakeupId, quantity);
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Item(s) added to cart!');", true);

                    quantityTb.Text = "";
                    BindShoppingSummary(userId);
                }
            }
        }

        protected void ClearCartBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int userID = user.UserID;

            CartController.RemoveUserCart(userID);
            BindShoppingSummary(userID);
        }

        protected void CheckOutBtn_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            int userID = user.UserID;

            int transactionId = TransactionController.GenerateTransactionHeaderId();
            List<Cart> userCart = CartController.GetUserCart(userID);

            // create new transaction
            TransactionController.AddTransactionHeader(userID);
            foreach (Cart item in userCart)
            {
                TransactionController.AddTransactionDetail(transactionId, item.MakeupID, item.Quantity);
            }

            CartController.RemoveUserCart(userID);
            BindShoppingSummary(userID);

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Order Created!');", true);
        }
    }
}