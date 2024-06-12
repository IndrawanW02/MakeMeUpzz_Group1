using MakeMeUpzz_Group1.Controllers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Views
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
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

                if (user.UserRole.Equals("Admin"))
                {
                    BindTransactionHistory(TransactionController.GetAllTransactionHeader());
                }
                else
                {
                    BindTransactionHistory(TransactionController.GetUserTransactionHeader(user.UserID));
                    TransactionHistoryList.Columns[1].Visible = false;
                }

            }
        }

        private void BindTransactionHistory(List<TransactionHeader> transactionList)
        {
            TransactionHistoryList.DataSource = transactionList;
            TransactionHistoryList.DataBind();
        }

        protected void TransactionHistoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int transactionId = Convert.ToInt32(TransactionHistoryList.SelectedRow.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?id=" + transactionId);
        }
    }
}