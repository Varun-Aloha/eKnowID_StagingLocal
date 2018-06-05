using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class CouponHelper
    {
        public static Coupon GetCouponByCode(string couponCode)
        {
            //Get Coupon Details By Coupon Code
            IRepository<Coupon> coupon = new Repository<Coupon>("couponCode");
            return coupon.SelectByKey(couponCode.ToString());
        }
    }
}
