using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Factories
{
    public class MakeupFactory
    {
        public static Makeup CreateMakeup (int MakeupID, String MakeupName, int MakeupPrice, int MakeupWeight, int MakeupTypeID, int MakeupBrandID, bool IsDeleted)
        {
            Makeup newMakeup = new Makeup();
            newMakeup.MakeupID = MakeupID;  
            newMakeup.MakeupName = MakeupName;
            newMakeup.MakeupPrice = MakeupPrice;
            newMakeup.MakeupWeight = MakeupWeight;
            newMakeup.MakeupTypeID = MakeupTypeID;
            newMakeup.MakeupBrandID = MakeupBrandID;
            newMakeup.IsDeleted = IsDeleted;
            return newMakeup;
        }

        public static MakeupType CreateMakeupType(int MakeupTypeID, String MakeupTypeName, bool IsDeleted)
        {
            MakeupType newMakeupType = new MakeupType();
            newMakeupType.MakeupTypeID = MakeupTypeID;
            newMakeupType.MakeupTypeName = MakeupTypeName;
            newMakeupType.IsDeleted = IsDeleted;
            return newMakeupType;
        }

        public static MakeupBrand CreateMakeupBrand(int MakeupBrandID, String MakeupBrandName, int MakeupBrandRating, bool IsDeleted)
        {
            MakeupBrand newMakeupBrand = new MakeupBrand();
            newMakeupBrand.MakeupBrandID = MakeupBrandID;
            newMakeupBrand.MakeupBrandName = MakeupBrandName;
            newMakeupBrand.MakeupBrandRating = MakeupBrandRating;
            newMakeupBrand.IsDeleted = IsDeleted;
            return newMakeupBrand;
        }
    }
}