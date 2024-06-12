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
    public partial class InsertMakeupBrandPage : System.Web.UI.Page
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
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void InsertMBBtn_Click(object sender, EventArgs e)
        {
            String makeupBrandName = MBNameTB.Text;
            int makeupBrandRating = int.TryParse(MBRatingTB.Text, out int priceResult) ? priceResult : -1;

            MBNameLblError.Text = MakeupController.CheckName(makeupBrandName);
            MBRatingLblError.Text = MakeupController.CheckRating(makeupBrandRating);

            if (MakeupController.CheckMakeupBrandInput(makeupBrandName, makeupBrandRating))
            {
                MakeupController.AddNewMakeupBrand(makeupBrandName, makeupBrandRating);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Brand Added!');", true);

                MBNameTB.Text = "";
                MBRatingTB.Text = "";
            }
        }
    }
}