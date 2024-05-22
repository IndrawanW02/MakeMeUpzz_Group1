using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Factories
{
    public class UserFactory
    {
        public static User Create(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword)
        {
            User user = new User();
            user.UserID = UserID;
            user.Username = UserName;
            user.UserEmail = UserEmail;
            user.UserDOB = UserDOB;
            user.UserGender = UserGender;
            user.UserRole = UserRole;
            user.UserPassword = UserPassword;
            return user;


        }
    }
}