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
    public partial class ManageMakeupPage : System.Web.UI.Page
    {
        public List<Makeup> makeups = null;
        public List<MakeupType> makeupsType = null;
        public List<MakeupBrand> makeupsBrand = null;
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

                // Memastikan hanya Admin yang bisa mengakses page ini
                if (user.UserRole.Equals("Customer"))
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

                if (!IsPostBack)
                {
                    BindMakeupGV();
                    BindMakeupTGV();
                    BindMakeupBGV();
                }
            }
        }

        private void BindMakeupGV()
        {
            makeups = MakeupController.GetAllMakeup();
            MakeupGV.DataSource = makeups;
            MakeupGV.DataBind();
        }

        private void BindMakeupTGV()
        {
            makeupsType = MakeupController.GetAllMakeupType();
            MakeupTGV.DataSource = makeupsType;
            MakeupTGV.DataBind();
        }

        private void BindMakeupBGV()
        {
            makeupsBrand = MakeupController.GetAllMakeupBrand();
            MakeupBGV.DataSource = makeupsBrand.OrderByDescending(makeupsBrand => makeupsBrand.MakeupBrandRating);
            MakeupBGV.DataBind();
        }

        protected void MakeupGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupGV.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupPage.aspx?id=" + id);
        }

        protected void MakeupGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            
            GridViewRow row = MakeupGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            MakeupController.RemoveMakeupByID(id);
            BindMakeupGV();
        }

        protected void MInsrtBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupPage.aspx");
        }

        protected void MakeupTGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupTGV.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupTypePage.aspx?id=" + id);
        }

        protected void MakeupTGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupTGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            MakeupController.RemoveMakeupTypeById(id);
            BindMakeupTGV();
        }

        protected void MTInsrtBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupTypePage.aspx");
        }

        protected void MakeupBGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = MakeupBGV.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;
            Response.Redirect("~/Views/UpdateMakeupBrandPage.aspx?id=" + id);
        }

        protected void MakeupBGV_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MakeupBGV.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            MakeupController.RemoveMakeupBrandById(id);
            BindMakeupBGV();
        }

        protected void MBInsrtBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/InsertMakeupBrandPage.aspx");
        }
    }
}