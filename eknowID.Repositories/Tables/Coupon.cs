namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Coupon")]
    public partial class Coupon
    {
        public Coupon()
        {
            Orders = new HashSet<Order>();
        }

        public int CouponId { get; set; }

        [Required]
        [StringLength(20)]
        public string CouponCode { get; set; }

        public int CouponDiscountTypeId { get; set; }

        public decimal DiscountValue { get; set; }

        public virtual CouponDiscountType CouponDiscountType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
