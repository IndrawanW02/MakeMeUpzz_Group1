using MakeMeUpzz_Group1.Handlers;
using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using TransactionHandler = MakeMeUpzz_Group1.Handlers.TransactionHandler;

namespace MakeMeUpzz_Group1.Controllers
{
    public class TransactionController
    {
        public static void AddTransactionHeader(int UserID)
        {
            TransactionHandler.AddTransactionHeader(UserID);
        }

        public static int GenerateTransactionHeaderId()
        {
            return TransactionHandler.GenerateTransactionHeaderId();
        }

        public static List<TransactionHeader> GetAllTransactionHeader()
        {
            return TransactionHandler.GetAllTransactionHeader();
        }

        public static List<TransactionHeader> GetUserTransactionHeader(int UserID)
        {
            return TransactionHandler.GetUserTransactionHeader(UserID);
        }

        public static TransactionHeader GetTransactionHeaderById(int TransactionID)
        {
            return TransactionHandler.GetTransactionHeaderById(TransactionID);
        }


        public static void AddTransactionDetail(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionHandler.AddTransactionDetail(TransactionID, MakeupID, Quantity);
        }

        public static List<TransactionDetail> GetTransactionDetailById(int TransactionID)
        {
            return TransactionHandler.GetTransactionDetailById(TransactionID);
        }

        public static void HandleTransaction(int TransactionID)
        {
            TransactionHandler.HandleTransaction(TransactionID);
        }

    }
}