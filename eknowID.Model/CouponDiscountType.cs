using System.Collections.Generic;

namespace EknowIDModel
{
    public class CouponDiscountType
    {
        public int CouponDiscountTypeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public virtual List<Coupon> Coupons
        {
            get;
            set;
        }
    }
}
