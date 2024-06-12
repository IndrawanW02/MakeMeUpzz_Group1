using MakeMeUpzz_Group1.Handlers;
using MakeMeUpzz_Group1.Model;
using MakeMeUpzz_Group1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Controllers
{
    public class MakeupController
    {
        public static String CheckName(String name)
        {
            String response = "";
            if (name.Length < 1 || name.Length > 99) response = "Name length must be between 1 - 99 characters";
            return response;
        }

        public static String CheckPrice(int price)
        {
            String response = "";
            if (price < 1) response = "Price must be greater than or equals to 1";
            return response;
        }

        public static String CheckWeight(int weight)
        {
            String response = "";
            if (weight < 1) response = "Please enter a valid weight";
            if (weight > 1500) response = "Weight cannot be greater than 1500";
            return response;
        }

        public static String CheckTypeID(int typeID)
        {
            String response = "";
            if (typeID == 0) response = "Please enter a valid MakeupTypeID ";
            else response = MakeupHandler.IsTypeAvaiable(typeID) ? "" : "MakeupType does not exist";
            return response;
        }

        public static String CheckBrandID(int brandID)
        {
            String response = "";
            if (brandID == 0) response = "Please enter a valid MakeupBrandID";
            else response = MakeupHandler.IsBrandAvailable(brandID) ? "" : "MakeupBrand does not exist";
            return response;
        }

        public static String CheckRating(int rating)
        {
            String response = "";
            if (rating < 0 || rating > 100) response = "Rating must be between 0 - 100";
            return response;
        }

        public static bool CheckMakeupInput(String name, int price, int weight, int typeId, int brandId)
        {
            if (CheckName(name).Equals("") && CheckPrice(price).Equals("") && CheckWeight(weight).Equals("") && CheckTypeID(typeId).Equals("") && CheckBrandID(brandId).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static bool CheckMakeupTypeInput(String name)
        {
            if (CheckName(name).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static bool CheckMakeupBrandInput(String name, int rating)
        {
            if (CheckName(name).Equals("") && CheckRating(rating).Equals(""))
            {
                return true;
            }
            return false;
        }

        public static void AddMakeup(String name, int price, int weight, int typeId, int brandId)
        {
            MakeupHandler.AddNewMakeup(name, price, weight, typeId, brandId);
        }

        public static void AddNewMakeupType(String MakeupName)
        {
            MakeupHandler.AddNewMakeupType(MakeupName);
        }

        public static void AddNewMakeupBrand(String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupHandler.AddNewMakeupBrand(MakeupBrandName, MakeupBrandRating);
        }

        public static List<Makeup> GetAllMakeup()
        {
            return MakeupHandler.GetAllMakeup();
        }

        public static Makeup GetMakeupById(int MakeupId)
        {
            return MakeupHandler.GetMakeupById(MakeupId);
        }

        public static List<MakeupType> GetAllMakeupType()
        {
            return MakeupHandler.GetAllMakeupType();
        }

        public static MakeupType GetMakeupTypeById(int MakeupTypeID)
        {
            return MakeupHandler.GetMakeupTypeById(MakeupTypeID);
        }

        public static List<MakeupBrand> GetAllMakeupBrand()
        {
            return MakeupHandler.GetAllMakeupBrand();
        }

        public static MakeupBrand GetMakeupBrandById(int MakeupBrandID)
        {
            return MakeupHandler.GetMakeupBrandById(MakeupBrandID);
        }


        public static void UpdateMakeupById(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            MakeupHandler.UpdateMakeupById(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID);
        }

        public static void UpdateMakeupTypeById(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupHandler.UpdateMakeupTypeById(MakeupTypeID, MakeupTypeName);
        }

        public static void UpdateMakeupBrandById(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupHandler.UpdateMakeupBrandById(MakeupBrandID, MakeupBrandName, MakeupBrandRating);
        }


        public static void RemoveMakeupByID(int id)
        {
            MakeupHandler.RemoveMakeupByID(id);
        }

        public static void RemoveMakeupTypeById(int id)
        {
            MakeupHandler.RemoveMakeupTypeById(id);
        }

        public static void RemoveMakeupBrandById(int id)
        {
            MakeupHandler.RemoveMakeupBrandById(id);
        }
    }
}