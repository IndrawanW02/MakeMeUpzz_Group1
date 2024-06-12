using MakeMeUpzz_Group1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_Group1.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader Create(int TransactionID, int UserID, DateTime TransactionDate, String Status)
        {
            TransactionHeader newTransactionHeader = new TransactionHeader();
            newTransactionHeader.TransactionID = TransactionID;
            newTransactionHeader.UserID = UserID;
            newTransactionHeader.TransactionDate = TransactionDate;
            newTransactionHeader.Status = Status;
            return newTransactionHeader;
        }

        public static TransactionDetail Create(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionDetail newTransactionDetail = new TransactionDetail();
            newTransactionDetail.TransactionID = TransactionID;
            newTransactionDetail.MakeupID = MakeupID;
            newTransactionDetail.Quantity = Quantity;
            return newTransactionDetail;
        }
    }
}