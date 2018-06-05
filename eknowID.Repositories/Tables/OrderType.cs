namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderType")]
    public partial class OrderType
    {
        public OrderType()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderTypeID { get; set; }

        [StringLength(50)]
        public string OrderTypeName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
