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
    public partial class UpdateMakeupTypePage : System.Web.UI.Page
    {
        private MakeupType currMakeupType = null;
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
                    BindMakeupTypeData();
                }
            }
        }

        private void BindMakeupTypeData()
        {
            int makeupTypeId = Convert.ToInt32(Request.QueryString["id"]);
            currMakeupType = MakeupController.GetMakeupTypeById(makeupTypeId);
            MTNameTB.Text = currMakeupType.MakeupTypeName;
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ManageMakeupPage.aspx");
        }

        protected void UpdateMTBtn_Click(object sender, EventArgs e)
        {
            int makeupTypeId = Convert.ToInt32(Request.QueryString["id"]);
            
            String makeupTypeName = MTNameTB.Text;
            MTNameLblError.Text = MakeupController.CheckName(makeupTypeName);

            if (MakeupController.CheckMakeupTypeInput(makeupTypeName))
            {
                MakeupController.UpdateMakeupTypeById(makeupTypeId, makeupTypeName);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('MakeupType Updated!');", true);
                BindMakeupTypeData();
            }
        }
    }
}