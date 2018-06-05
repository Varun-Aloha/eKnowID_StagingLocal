using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
    public class ReferenceInfoHelper
    {
        public static ReferenceInfo GetReferenceInfoByOrderId(int orderId)
        {
            ReferenceInfo referenceInfo = new ReferenceInfo();
            Repository<ReferenceInfo> referenceInfoRepository = new Repository<ReferenceInfo>("OrderId");
            referenceInfo = referenceInfoRepository.SelectByKey(orderId.ToString());
            return referenceInfo;
        }

        public static List<ReferenceInfo> GetReferenceInfoListByOrderId(int OrderId)
        {
            ISpecification<ReferenceInfo> spc = new Specification<ReferenceInfo>(u => u.OrderId == OrderId);
            Repository<ReferenceInfo> repository = new Repository<ReferenceInfo>();
            IList<ReferenceInfo> referenceInfoList = repository.SelectAll(spc);
            return (List<ReferenceInfo>) referenceInfoList;
        }
    }
}
