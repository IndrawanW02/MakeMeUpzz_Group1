using MakeMeUpzz_Group1.Model;
using MakeMeUpzz_Group1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Handlers
{
    public class UserAuthenticationHandler
    {
        public static String AuthenticateLogin(String Username, String Password)
        {
            String response = "";
            UserRepository userRepo = new UserRepository();
            User user = userRepo.GetUserByUsernameAndPassword(Username, Password);

            if (userRepo.DoesUsernameExist(Username) == false)
            {
                response = "Username does not exist";
            }
            else if (!(userRepo.GetUserPassword(Username).Equals(Password)))
            {
                response = "Password Incorrect";
            }
            else if (user == null)
            {
                response = "Login Failed";
            }
            else
            {
                response = "Login Success";
            }
            return response;

        }
    }
}