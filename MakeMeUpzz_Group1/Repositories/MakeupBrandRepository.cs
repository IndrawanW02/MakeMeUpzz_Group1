using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class MakeupBrandRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();

        public void AddNewMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating, bool IsDeleted)
        {
            MakeupBrand newMakeupBrand = MakeupFactory.CreateMakeupBrand(MakeupBrandID, MakeupBrandName, MakeupBrandRating, IsDeleted);
            db.MakeupBrands.Add(newMakeupBrand);
            db.SaveChanges();
        }

        public void UpdateMakeupBrandById(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating)
        {
            MakeupBrand updateMakeupBrand = GetMakeupBrandById(MakeupBrandID);
            updateMakeupBrand.MakeupBrandName = MakeupBrandName;
            updateMakeupBrand.MakeupBrandRating = MakeupBrandRating;
            db.SaveChanges();
        }

        public void RemoveMakeupBrandByID(int id)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(id);
            makeupBrand.IsDeleted = true;
            db.SaveChanges();
        }

        public bool IsBrandAvailable(int MakeupBrandID)
        {
            return db.MakeupBrands.Any(mb => mb.MakeupBrandID == MakeupBrandID);
        }

        public List<MakeupBrand> GetAllMakeupBrand()
        {
            return (from mb 
                    in db.MakeupBrands 
                    where mb.IsDeleted == false 
                    select mb).ToList();
        }


        public int GetLastMakeupBrandID()
        {
            return (from mb 
                    in db.MakeupBrands 
                    select mb.MakeupBrandID).ToList().LastOrDefault();
        }

        public MakeupBrand GetMakeupBrandById(int MakeupBrandID)
        {
            return db.MakeupBrands.Find(MakeupBrandID);
        }
    }
}