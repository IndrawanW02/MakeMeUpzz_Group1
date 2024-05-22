using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class UserRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();
        
        public void AddUser(int UserID, String UserName, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword)
        {
            User user = UserFactory.Create(UserID, UserName, UserEmail, UserDOB, UserGender, UserRole, UserPassword);
            db.Users.Add(user);
            db.SaveChanges();
        } 

        public List<User> GetAllUser()
        {
            return (from u in db.Users select u).ToList();
        }

        public User GetUserByID(int id)
        {
            return (from u in db.Users where u.UserID == id select u).FirstOrDefault();
        }

        public User GetUserByUsernameAndPassword(String Username, String Password)
        {
            return (from u 
                    in db.Users 
                    where u.Username.Equals(Username) && u.UserPassword.Equals(Password) 
                    select u).FirstOrDefault();
        }

        public bool DoesUsernameExist(String Username)
        {
            return GetAllUser().Any(u => u.Username == Username);
        }

        public String GetUserPassword(String Username)
        {
            return (from u
                    in db.Users 
                    where u.Username.Equals(Username) 
                    select u.UserPassword).FirstOrDefault();
        }

        public int GetLastUserID()
        {
            return (from u 
                    in db.Users 
                    select u.UserID).ToList().LastOrDefault();
        }
    }
}