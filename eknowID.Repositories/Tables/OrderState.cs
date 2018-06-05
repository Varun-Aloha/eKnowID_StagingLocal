namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderState")]
    public partial class OrderState
    {
        [Key]
        public int OrderStatusId { get; set; }

        public int OrderId { get; set; }

        public int TazWorksOrderId { get; set; }

        public int? TazWorksStatus { get; set; }

        [StringLength(300)]
        public string URL { get; set; }

        public DateTime InsertTime { get; set; }

        public virtual Order Order { get; set; }
    }
}
