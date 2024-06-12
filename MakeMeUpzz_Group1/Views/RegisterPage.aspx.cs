using MakeMeUpzz_Group1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            } 
        }

        protected void DOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            DOBTB.Text = DOBCalendar.SelectedDate.ToString("dd MMMM yyyy");
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String Username = UsernameTB.Text;
            String UserEmail = EmailTB.Text;
            DateTime UserDOB = DOBCalendar.SelectedDate;
            String UserGender = GenderRbl.SelectedValue;
            String UserPassword = PasswordTB.Text;
            String ConfirmationPassword = ConfirmationPassTB.Text;

            UsernameErrLbl.Text = UserRegistrationController.CheckUsername(Username);
            EmailErrLbl.Text = UserRegistrationController.CheckEmail(UserEmail);
            DOBErrLbl.Text = UserRegistrationController.CheckDOB(UserDOB);
            GenderErrLbl.Text = UserRegistrationController.CheckGender(UserGender);
            PasswordErrLbl.Text = UserRegistrationController.CheckPassword(UserPassword);
            ConfirmationPassErrLbl.Text = UserRegistrationController.CheckConfirmationPassword(UserPassword, ConfirmationPassword);

            if (UserRegistrationController.IsEligible(Username, UserEmail, UserGender, UserPassword, ConfirmationPassword, UserDOB))
            {
                UserRegistrationController.Registrate(Username, UserEmail, UserGender, UserPassword, UserDOB);
                String script = "alert('Akun berhasil dibuat !'); window.location.href='" + ResolveUrl("~/Views/LoginPage.aspx") + "';";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
            }
        }

        protected void LoginNav_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}