using MakeMeUpzz_Group1.Factories;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Repositories
{
    public class TransactionHeaderRepository
    {
        private static MakeMeUpzzDatabseEntities1 db = DatabaseSingleton.GetInstance();

        public void AddTransactionHeader(int TransactionID, int UserID, DateTime TransactionDate, String Status)
        {
            TransactionHeader newTransactionHeader = TransactionFactory.Create(TransactionID, UserID, TransactionDate, Status);
            db.TransactionHeaders.Add(newTransactionHeader);
            db.SaveChanges();
        }

        public void HandleTransaction(int TransactionID)
        {
            TransactionHeader updateTransaction = GetTransactionHeaderById(TransactionID);
            updateTransaction.Status = "handled";
            db.SaveChanges();
        }

        public int GetLastTransactionHeaderId()
        {
            return (from th 
                    in db.TransactionHeaders 
                    select th.TransactionID).ToList().LastOrDefault();
        }

        public List<TransactionHeader> GetAllTransactionHeader()
        {
            return (from th 
                    in db.TransactionHeaders 
                    select th).ToList();
        }

        public List<TransactionHeader> GetUserTransactionHeader(int UserID)
        {
            return (from th 
                    in db.TransactionHeaders 
                    where th.UserID == UserID 
                    select th).ToList();
        }

        public TransactionHeader GetTransactionHeaderById(int TransactionID)
        {
            return (from th 
                    in db.TransactionHeaders 
                    where th.TransactionID == TransactionID 
                    select th).FirstOrDefault();
        }
    }
}