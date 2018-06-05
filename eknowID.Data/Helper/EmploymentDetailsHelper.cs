using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper
{
    public class EmploymentDetailsHelper
    {
        public static List<EmploymentDetail> GetEmpDetailsListByOrderId(int OrderId)
        {
            ISpecification<EmploymentDetail> specification = new Specification<EmploymentDetail>(u => u.OrderId == OrderId);
            Repository<EmploymentDetail> repository = new Repository<EmploymentDetail>();
            IList<EmploymentDetail> empDetailsList = repository.SelectAll(specification);
            return (List<EmploymentDetail>)empDetailsList; 
        }
    }
}
