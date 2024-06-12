using MakeMeUpzz_Group1.Controllers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Master
{
    public partial class NavigationBar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Master Page_Load");

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
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
                    OrderMakeupNav.Visible = false;
                    HistoryNav.Visible = false;
                }

                if (user.UserRole.Equals("Customer"))
                {
                    ManageMakeupNav.Visible = false;
                    OrderQueueNav.Visible = false;
                    TransactionReportNav.Visible = false;
                }

            }


        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            String[] cookies = Request.Cookies.AllKeys;
            foreach (var cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Remove("user");
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}