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
    public partial class UpdateMakeupPage : System.Web.UI.Page
    {
        private Makeup currMakeup = null;
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
                    BindMakeupData();
                }
            }
        }

        private void BindMakeupData()
        {
            int MakeupId = Convert.ToInt32(Request.QueryString["id"]);
            currMakeup = MakeupController.GetMakeupById(MakeupId);

            MNameTB.Text = currMakeup.MakeupName;
            MPriceTB.Text = currMakeup.MakeupPrice.ToString();
            MWeightTB.Text = currMakeup.MakeupWeight.ToString();
            MTypeIdTB.Text = currMakeup.MakeupTypeID.ToString();
            MBrandIdTB.Text = currMakeup.MakeupBrandID.ToString();
        }

        protected void UpdateMBtn_Click(object sender, EventArgs e)
        {
            int updateMakeupId = Convert.ToInt32(Request.QueryString["id"]);
            String name = MNameTB.Text;

            int price = int.TryParse(MPriceTB.Text, out int priceResult) ? priceResult : 0;
            int weight = int.TryParse(MWeightTB.Text, out int weightResult) ? weightResult : 0;
            int typeId = int.TryParse(MTypeIdTB.Text, out int typeIdResult) ? typeIdResult : 0;
            int brandId = int.TryParse(MBrandIdTB.Text, out int brandIdResult) ? brandIdResult : 0;

            MNameLblError.Text = MakeupController.CheckName(name);
            MPriceLblError.Text = MakeupController.CheckPrice(price);
            MWeightLblError.Text = MakeupController.CheckWeight(weight);
            MTypeIdLblError.Text = MakeupController.CheckTypeID(typeId);
            MBrandLblError.Text = MakeupController.CheckBrandID(brandId);

            if (MakeupController.CheckMakeupInput(name, price, weight, typeId, brandId))
            {
                MakeupController.UpdateMakeupById(updateMakeupId, name, price, weight, typeId, brandId);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Updated!');", true);
                BindMakeupData();
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }
    }
}