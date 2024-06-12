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

        public static void UpdateUserProfileByID(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.UpdateUserProfileByID(UserID, UserName, UserEmail, UserDOB, UserGender);
        }

        public static List<User> GetAllCustomerUser()
        {
            UserRepository customerRepo = new UserRepository();
            return customerRepo.GetAllCustomerUser();
        }

        public static String GetUserPasswordById(int UserID)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetUserPasswordById(UserID);
        }

        public static void UpdateUserPasswordById(int UserID, String NewPassword)
        {
            UserRepository userRepository = new UserRepository();
            userRepository.UpdateUserPasswordById(UserID, NewPassword);
        }
    }
}