using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class CouponDiscountTypeHelper
    {
        public static CouponDiscountType GetCouponTypeById(int couponTypeId)
        {
            IRepository<CouponDiscountType> repository =new  Repository<CouponDiscountType>("CouponDiscountTypeId");
            return repository.SelectByKey(couponTypeId.ToString());
        }
    }
}
