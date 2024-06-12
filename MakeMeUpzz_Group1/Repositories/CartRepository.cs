using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class CartRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();
        
        public void AddCartItem(int CartID, int UserID, int MakeupID, int Quantity)
        {
            Cart newCart = CartFactory.Create(CartID, UserID, MakeupID, Quantity);
            db.Carts.Add(newCart);
            db.SaveChanges();
        }

        public void UpdateCartQuantity(int UserID, int MakeupID, int newQty)
        {
            Cart updateCart = GetCartByUserIDMakeupID(UserID, MakeupID);
            updateCart.Quantity = newQty;
            db.SaveChanges();
        }

        public void RemoveUserCart(int UserID)
        {
            List<Cart> toRemove = GetUserCart(UserID);
            foreach (Cart item in toRemove)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();
        }

        public int GetLastCartId()
        {
            return (from c 
                    in db.Carts 
                    select c.CartID).ToList().LastOrDefault();
        }

        public bool IsItemInCart(int UserID, int MakeupID)
        {
            return db.Carts.Any(cart => cart.UserID.Equals(UserID) && cart.MakeupID.Equals(MakeupID));
        }

        public Cart GetCartByUserIDMakeupID(int UserID, int MakeupID)
        {
            return (from c in db.Carts where c.UserID.Equals(UserID) && c.MakeupID.Equals(MakeupID) select c).FirstOrDefault();
        }

        public List<Cart> GetUserCart(int UserID)
        {
            return (from c in db.Carts where c.UserID.Equals(UserID) select c).ToList();
        }
    }
}