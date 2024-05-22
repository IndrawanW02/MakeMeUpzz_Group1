using MakeMeUpzz_Group1.Model;
using MakeMeUpzz_Group1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Handlers
{
    public class UserHandler
    {
        public static User GetUserByUsernameAndPassword(String Username, String Password)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.GetUserByUsernameAndPassword(Username, Password);
        }

        public static User GetUserByID(int UserID)
        {
            UserRepository userRepo = new UserRepository();
            return userRepo.GetUserByID(UserID);
        }
    }
}