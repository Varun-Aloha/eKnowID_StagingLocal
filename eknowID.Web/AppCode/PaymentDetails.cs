using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eknowID.AppCode
{
    public class PaymentDetails
    {
        public string userName { set; get; }
        public string TransactionID { set; get; }
        public int orderID { set; get; }
        public string totalReportCost { set; get; }
        public decimal discountOffered { set; get; }
        public decimal OtherCharges { set; get; }
        public bool isPaymentNotificationSend { get; set; }
        public int couponID { set; get; }
    }
}