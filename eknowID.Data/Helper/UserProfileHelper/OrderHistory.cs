using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDData.Helper.UserProfileHelper
{
    public class OrderHistory
    {
        public int OrderId
        {
            get;
            set;
        }
        public string PurchasedDate
        {
            get;
            set;
        }
        public string Plan
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public int Discount
        {
            get;
            set;
        }
        public decimal Paid
        {
            get;
            set;
        }
        public string Report
        {
            get;
            set;
        }
        public string ReportDiscount
        {
            get;
            set;
        }
        public string TransactionId
        {
            get;
            set;
        }
        public int OrderStatusId
        {
            get;
            set;
        }
        public string OrderTypeName
        {
            get;
            set;
        }
        
        public int OrderTypeID
        {
            get;
            set;
        }

        public string ReportStatus
        {
            get;
            set;
        }        
    }
}
