using MakeMeUpzz_Group1.Handlers;
using MakeMeUpzz_Group1.Model;
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

        public static User GetUserByID (int UserID)
        {
            return UserHandler.GetUserByID(UserID);
        }
    }
}