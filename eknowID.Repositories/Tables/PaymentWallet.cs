namespace eknowID.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentWalletHistory")]
    public partial class PaymentWalletHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Deposite { get; set; }

        [Column(TypeName = "money")]
        public decimal? Withdrawal { get; set; }

        public string TransactionId { get; set; }        

        public DateTime InsertedDate { get; set; }

        public virtual User User { get; set; }
    }
}
