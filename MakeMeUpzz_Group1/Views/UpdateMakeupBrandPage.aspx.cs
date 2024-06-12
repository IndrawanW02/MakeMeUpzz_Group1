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
    public partial class UpdateMakeupBrandPage : System.Web.UI.Page
    {
        private MakeupBrand currMakeupBrand = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null || Request.QueryString["id"] == null)
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

                if (!IsPostBack)
                {
                    BindMakeupBrandData();
                }
            }
        }

        private void BindMakeupBrandData()
        {
            int MakeupBrandId = Convert.ToInt32(Request.QueryString["id"]);
            currMakeupBrand = MakeupController.GetMakeupBrandById(MakeupBrandId);

            MBNameTB.Text = currMakeupBrand.MakeupBrandName;
            MBRatingTB.Text = currMakeupBrand.MakeupBrandRating.ToString();
        }

        protected void UpdateMBBtn_Click(object sender, EventArgs e)
        {
            int updateMakeupBrandId = Convert.ToInt32(Request.QueryString["id"]);
            String makeupBrandName = MBNameTB.Text;
            int makeupBrandRating = int.TryParse(MBRatingTB.Text, out int ratingResult) ? ratingResult : -1;

            MBNameLblError.Text = MakeupController.CheckName(makeupBrandName);
            MBRatingLblError.Text = MakeupController.CheckRating(makeupBrandRating);

            if (MakeupController.CheckMakeupBrandInput(makeupBrandName, makeupBrandRating))
            {
                MakeupController.UpdateMakeupBrandById(updateMakeupBrandId, makeupBrandName, makeupBrandRating);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Brand Updated!');", true);
                BindMakeupBrandData();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

    }
}