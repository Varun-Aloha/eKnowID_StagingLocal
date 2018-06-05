using System.Collections.Generic;

namespace EknowIDModel
{
    public class Coupon
    {
        public int CouponId
        {
            get;
            set;
        }

        public string CouponCode
        {
            get;
            set;
        }

        public int CouponDiscountTypeId
        {
            get;
            set;
        }

        public decimal DiscountValue
        {
            get;
            set;
        }

        public virtual List<Order> Orders
        {
            get;
            set;
        }

        public virtual CouponDiscountType CouponDiscountType
        {
            get;
            set;
        }

    }
}
