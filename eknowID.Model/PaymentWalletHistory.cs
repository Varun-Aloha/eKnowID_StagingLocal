using System;

namespace EknowIDModel
{
    public class PaymentWalletHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal? Deposite { get; set; }

        public decimal? Withdrawal { get; set; }

        public string TransactionId { get; set; }        

        public DateTime InsertedDate { get; set; }

        public virtual User User { get; set; }
    }
}
