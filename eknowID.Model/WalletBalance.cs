using System;

namespace EknowIDModel
{    
    public class WalletBalance
    {
        public int Id { get; set; }

        public int UserId { get; set; }
 
        public decimal Balance { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual User User { get; set; }
    }
}
