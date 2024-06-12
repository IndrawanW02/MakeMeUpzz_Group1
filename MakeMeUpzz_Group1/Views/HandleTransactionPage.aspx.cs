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
    public partial class HandleTransactionPage : System.Web.UI.Page
    {
        private List<TransactionHeader> transactionList = null;
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
                    user = UserController.GetUserByID(int.Parse(id));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

                // Memastikan hanya Admin yang bisa mengakses page ini
                if (user.UserRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

                BindTransactionList();
            }
        }

        private void BindTransactionList()
        {
            transactionList = TransactionController.GetAllTransactionHeader();
            TransactionHistoryList.DataSource = transactionList;
            TransactionHistoryList.DataBind();
        }

        protected void TransactionHistoryList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = TransactionHistoryList.Rows[e.NewEditIndex];
            int transactionId = Convert.ToInt32(row.Cells[0].Text);
            TransactionController.HandleTransaction(transactionId);
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Transaction Handled!');", true);

            BindTransactionList();

        }

        protected void TransactionHistoryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Button handleButton = e.Row.Cells[4].Controls[0] as Button;

                if (status.Equals("handled"))
                {
                    handleButton.Visible = false;
                }
            }

        }
    }
}