using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class MakeupRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();

        public void AddNewMakeup (int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID, bool IsDeleted)
        {
            Makeup newMakeup = MakeupFactory.CreateMakeup(MakeupID, MakeupName, MakeupPrice, MakeupWeight, MakeupTypeID, MakeupBrandID, IsDeleted);
            db.Makeups.Add(newMakeup);
            db.SaveChanges();
        }

        public void UpdateMakeupById(int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID)
        {
            Makeup updateMakeup = GetMakeupById(MakeupID);
            updateMakeup.MakeupName = MakeupName;
            updateMakeup.MakeupPrice = MakeupPrice;
            updateMakeup.MakeupWeight = MakeupWeight;
            updateMakeup.MakeupTypeID = MakeupTypeID;
            updateMakeup.MakeupBrandID = MakeupBrandID;
            db.SaveChanges();
        }

        public void RemoveMakeupByID(int id)
        {
            Makeup makeup = db.Makeups.Find(id);
            makeup.IsDeleted = true;
            db.SaveChanges();
        }

        public int GetLastMakeupID()
        {
            return (from m 
                    in db.Makeups 
                    select m.MakeupID).ToList().LastOrDefault();
        }

        public List<Makeup> GetAllMakeup()
        {
            return (from m 
                    in db.Makeups 
                    where m.IsDeleted == false
                    select m).ToList();
        }

        public Makeup GetMakeupById(int MakeupId)
        {
            return db.Makeups.Find(MakeupId);
        }
    }
}