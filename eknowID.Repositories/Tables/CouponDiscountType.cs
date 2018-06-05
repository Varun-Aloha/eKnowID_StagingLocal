namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CouponDiscountType")]
    public partial class CouponDiscountType
    {
        public CouponDiscountType()
        {
            Coupons = new HashSet<Coupon>();
        }

        public int CouponDiscountTypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
