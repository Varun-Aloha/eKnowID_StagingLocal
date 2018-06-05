using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace eknowID.Repositories.Tables
{
    [Table("WalletBalance")]
    public partial class WalletBalance
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Column("Balance", TypeName = "money")]
        public decimal Balance { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual User User { get; set; }
    }
}
