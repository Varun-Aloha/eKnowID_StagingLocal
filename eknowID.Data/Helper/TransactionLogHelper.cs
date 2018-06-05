using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDData.Implementations;
using EknowIDModel;

namespace EknowIDData.Helper
{
   public class TransactionLogHelper
    {
       public static void SaveError(int OrderId, string Description, string Request, string Response)
       {

           TransactionLog transactionLog = new TransactionLog();
           try
           {
               transactionLog.OrderId = OrderId;
               transactionLog.Description = Description;
               transactionLog.Request = Request;
               transactionLog.Response = Response;
               transactionLog.LogDate = DateTime.Now;

               Repository<TransactionLog> userRep = new Repository<TransactionLog>();
               userRep.Add(transactionLog);
               userRep.Save();

           }
           catch { }
           
       }
    }
}
