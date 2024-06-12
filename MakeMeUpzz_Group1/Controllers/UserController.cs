using MakeMeUpzz_Group1.Handlers;
using MakeMeUpzz_Group1.Model;
using MakeMeUpzz_Group1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Controllers
{
    public class UserController
    {
        public static User GetUserByUsernameAndPassword(String Username, String Password)
        {
            return UserHandler.GetUserByUsernameAndPassword(Username, Password);
        }

        public static User GetUserByID(int UserID)
        {
            return UserHandler.GetUserByID(UserID);
        }

        public static void UpdateUserProfileByID(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            UserHandler.UpdateUserProfileByID(UserID, UserName, UserEmail, UserDOB, UserGender);
        }

        public static bool IsEligibleToUpdate(String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            // mengecek apakah kriteria untuk username, email, DOB, gender yang baru untuk diupdate sudah terpenuhi atau belum.
            if (UserName.Equals("") && UserRegistrationController.CheckEmail(UserEmail).Equals("") && UserRegistrationController.CheckDOB(UserDOB).Equals("") && UserRegistrationController.CheckGender(UserGender).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static List<User> GetAllCustomerUser()
        {
            return UserHandler.GetAllCustomerUser();
        }

        public static String GetUserPasswordById(int UserID)
        {
            return UserHandler.GetUserPasswordById(UserID);
        }

        public static bool ValidateOldPassword(int UserID, string OldPassword)
        {
            return GetUserPasswordById(UserID).Equals(OldPassword);
        }

        public static void UpdateUserPasswordById(int UserID, String NewPassword)
        {
            UserHandler.UpdateUserPasswordById(UserID, NewPassword);
        }
    }
}