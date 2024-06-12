using MakeMeUpzz_Group1.Handlers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Controllers
{
    public class CartController
    {
        public static void AddCartItem(int UserID, int MakeupID, int Quantity)
        {
            CartHandler.AddCartItem(UserID, MakeupID, Quantity);
        }

        public static void RemoveUserCart(int UserID)
        {
            CartHandler.RemoveUserCart(UserID);
        }


        public static List<Cart> GetUserCart(int UserID)
        {
            return CartHandler.GetUserCart(UserID);
        } 

    }
}