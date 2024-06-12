using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Factories
{
    public class CartFactory
    {
        public static Cart Create(int CartID, int UserID, int MakeupID, int Quantity)
        {
            Cart newCart = new Cart();
            newCart.CartID = CartID;
            newCart.UserID = UserID;
            newCart.MakeupID = MakeupID;
            newCart.Quantity = Quantity;
            return newCart;
        }
    }
}