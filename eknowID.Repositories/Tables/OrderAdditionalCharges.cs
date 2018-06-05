namespace eknowID.Repositories {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderAdditionalCharges")]
    public class OrderAdditionalCharge {
        [Key]
        public long Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual Order Order { get; set; }
    }
}
