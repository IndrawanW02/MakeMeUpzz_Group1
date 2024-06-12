using MakeMeUpzz_Group1.Controllers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Views
{
    public partial class InsertMakeupPage : System.Web.UI.Page
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

                BindMakeupTGV();
                BindMakeupBGV();
            }
        }

        private void BindMakeupTGV()
        {
            List<MakeupType> makeupsType = MakeupController.GetAllMakeupType();
            MakeupTGV.DataSource = makeupsType;
            MakeupTGV.DataBind();
        }

        private void BindMakeupBGV()
        {
            List<MakeupBrand> makeupsBrand = MakeupController.GetAllMakeupBrand();
            MakeupBGV.DataSource = makeupsBrand;
            MakeupBGV.DataBind();
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void InsertMBtn_Click(object sender, EventArgs e)
        {
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
                MakeupController.AddMakeup(name, price, weight, typeId, brandId);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Makeup Added!');", true);

                // reset isi textbox
                MNameTB.Text = "";
                MPriceTB.Text = "";
                MWeightTB.Text = "";
                MTypeIdTB.Text = "";
                MBrandIdTB.Text = "";
            }
        }
    }
}