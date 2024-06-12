using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class MakeupTypeRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();

        public void AddNewMakeupType(int MakeupTypeID, String MakeupName, bool IsDeleted)
        {
            MakeupType newMakeupType = MakeupFactory.CreateMakeupType(MakeupTypeID, MakeupName, IsDeleted);
            db.MakeupTypes.Add(newMakeupType);
            db.SaveChanges();
        }

        public void UpdateMakeupTypeById(int MakeupTypeID, String MakeupTypeName)
        {
            MakeupType updateMakeupType = GetMakeupTypeById(MakeupTypeID);
            updateMakeupType.MakeupTypeName = MakeupTypeName;
            db.SaveChanges();
        }

        public void RemoveMakeupTypeById(int id)
        {
            MakeupType makeupType = db.MakeupTypes.Find(id);
            makeupType.IsDeleted = true;
            db.SaveChanges();
        }

        public bool IsTypeAvailable(int MakeupTypeID)
        {
            return db.MakeupTypes.Any(mb => mb.MakeupTypeID == MakeupTypeID);
        }

        public List<MakeupType> GetAllMakeupType()
        {
            return (from mt 
                    in db.MakeupTypes 
                    where mt.IsDeleted == false 
                    select mt).ToList();
        }

        public MakeupType GetMakeupTypeById(int MakeupTypeID)
        {
            return db.MakeupTypes.Find(MakeupTypeID);
        }

        public int GetLastMakeupTypeId()
        {
            return (from mt 
                    in db.MakeupTypes 
                    select mt.MakeupTypeID).ToList().LastOrDefault();
        }

    }
}