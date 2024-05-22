using MakeMeUpzz_Group1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Handlers
{
    public class UserRegistrationHandler
    {
        public static bool DoesUsernameExist(string Username)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.DoesUsernameExist(Username);
        }

        public static int GetLastUserID()
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.GetLastUserID();
        }

        public static void RegistrateUser(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword)
        {
            UserRepository userRepo = new UserRepository();
            userRepo.AddUser(UserID, UserName, UserEmail, UserDOB, UserGender, UserRole, UserPassword);
        }
    }
}