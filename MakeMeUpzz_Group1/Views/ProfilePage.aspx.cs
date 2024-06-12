using MakeMeUpzz_Group1.Controllers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MakeMeUpzz_Group1.Views
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                if (!IsPostBack)
                {
                    txtUsername.Text = user.Username;
                    txtEmail.Text = user.UserEmail;
                    UserDOBCalendar.SelectedDate = user.UserDOB;
                    txtDob.Text = user.UserDOB.ToString("dd MMMM yyyy");
                    GenderRB.SelectedValue = user.UserGender;
                    txtRole.Text = user.UserRole;
                }
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            String newUsername = txtUsername.Text;
            String newEmail = txtEmail.Text;
            DateTime newDOB = UserDOBCalendar.SelectedDate;
            String newGender = GenderRB.SelectedValue;

            if (newUsername.Equals(user.Username) == false)
            {
                usernameErr.Text = UserRegistrationController.CheckUsername(newUsername);
            }
            emailErr.Text = UserRegistrationController.CheckEmail(newEmail);
            DOBErr.Text = UserRegistrationController.CheckDOB(newDOB);
            genderErr.Text = UserRegistrationController.CheckGender(newGender);

            if (UserController.IsEligibleToUpdate(usernameErr.Text, newEmail, newDOB, newGender))
            {
                UserController.UpdateUserProfileByID(user.UserID, newUsername, newEmail, newDOB, newGender);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Profile Updated!');", true);
            }
        }
        protected void UserDOBCalendar_SelectionChanged(object sender, EventArgs e)
        {
            txtDob.Text = UserDOBCalendar.SelectedDate.ToString("dd MMMM yyyy");
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];

            String oldPassword = txtOldPassword.Text;
            String newPassword = txtNewPassword.Text;

            if (UserController.ValidateOldPassword(user.UserID, oldPassword) == false)
            {
                oldPasswordErr.Text = "Old Password Incorrect";
            }
            else
            {
                UserController.UpdateUserPasswordById(user.UserID, newPassword);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Password Updated!');", true);

            }
        }

    }
}