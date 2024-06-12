using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using MakeMeUpzz_Group1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Handlers
{
    public class CartHandler
    {
        public static void AddCartItem(int UserID, int MakeupID, int Quantity)
        {
            CartRepository cartRepository = new CartRepository();

            if (cartRepository.IsItemInCart(UserID, MakeupID))
            {
                Cart currCart = cartRepository.GetCartByUserIDMakeupID(UserID, MakeupID);
                int newQuantity = currCart.Quantity + Quantity;
                cartRepository.UpdateCartQuantity(UserID, MakeupID, newQuantity);
            }
            else
            {
                cartRepository.AddCartItem(GenerateCartId(), UserID, MakeupID, Quantity);
            }
        }

        public static void RemoveUserCart(int UserID)
        {
            CartRepository cartRepository = new CartRepository();
            cartRepository.RemoveUserCart(UserID);
        }

        public static int GenerateCartId()
        {
            CartRepository cartRepository = new CartRepository();
            int lastId = cartRepository.GetLastCartId();
            if (lastId == 0) lastId = 1;
            else lastId++;
            return lastId;
        }

        public static List<Cart> GetUserCart(int UserID)
        {
            CartRepository cartRepository = new CartRepository();
            return cartRepository.GetUserCart(UserID);
        }
    }
}