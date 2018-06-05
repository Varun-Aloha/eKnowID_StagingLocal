using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eknowID.Repositories.ViewModels
{
    public class PaymentWalletModal
    {
        public string CardType { set; get; }
        public string CardNumber { set; get; }
        public string ExpMonth { set; get; }
        public string ExpYear { set; get; }
        public string SecurityCode { set; get; }
        public string Amount { get; set; }
    }


    public class RefundWalletModel {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int OrderStatus { get; set; }
        public string BuyerNote { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
