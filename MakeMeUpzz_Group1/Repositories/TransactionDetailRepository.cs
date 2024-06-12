using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class TransactionDetailRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();

        public void AddTransactionDetail(int TransasctionID, int MakeupID, int Quantity)
        {
            TransactionDetail newTransactionDetail = TransactionFactory.Create(TransasctionID, MakeupID, Quantity);
            db.TransactionDetails.Add(newTransactionDetail);
            db.SaveChanges();
        }

        public List<TransactionDetail> GetTransactionDetailById(int TransactionID)
        {
            return (from td 
                    in db.TransactionDetails 
                    where td.TransactionID == TransactionID 
                    select td).ToList();
        }
    }
}