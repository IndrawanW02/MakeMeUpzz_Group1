using MakeMeUpzz_Group1.Controllers;
using MakeMeUpzz_Group1.Dataset;
using MakeMeUpzz_Group1.Model;
using MakeMeUpzz_Group1.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Views
{
    public partial class TransactionReportPage : System.Web.UI.Page
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

                CrystalReport1 report = new CrystalReport1();
                CrystalReportViewer1.ReportSource = report;
                DataSet1 data = GetData(TransactionController.GetAllTransactionHeader());
                report.SetDataSource(data);
            }
        }

        private DataSet1 GetData(List<TransactionHeader> transactions)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.transactions;
            var detailTable = data.transaction_details;
            foreach (TransactionHeader th in transactions)
            {
                var grandTotal = th.TransactionDetails.Sum(td => td.Quantity * td.Makeup.MakeupPrice);
                var hRow = headerTable.NewRow();
                hRow["transaction_id"] = th.TransactionID;
                hRow["user_id"] = th.UserID;
                hRow["transaction_date"] = th.TransactionDate;
                hRow["grand_total"] = grandTotal;
                headerTable.Rows.Add(hRow);
                
                foreach (TransactionDetail td in th.TransactionDetails)
                {
                    var subTotal = td.Quantity * td.Makeup.MakeupPrice;
                    var dRow = detailTable.NewRow();
                    dRow["transaction_id"] = td.TransactionID;
                    dRow["item_id"] = td.MakeupID;
                    dRow["quantity"] = td.Quantity;
                    dRow["item_price"] = td.Makeup.MakeupPrice;
                    dRow["sub_total"] = subTotal;
                    detailTable.Rows.Add(dRow);
                }
            }

            return data;
        }
    }
}