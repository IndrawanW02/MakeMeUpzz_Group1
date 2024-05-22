using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class DatabaseSingleton
    {
        private static MakeMeUpzzDatabseEntities1 db = null;
        public static MakeMeUpzzDatabseEntities1 GetInstance()
        {
            if(db == null)
            {
                db = new MakeMeUpzzDatabseEntities1();
            }
            return db;
        } 
    }
}