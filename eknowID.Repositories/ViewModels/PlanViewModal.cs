using System.Collections.Generic;
using System.Linq;

namespace eknowID.Repositories.ViewModels
{
    public class ReportViewModal
    {
        public string ReportName { get; set; }
        public int? PlanId { get; set; }
    }

    public class AlacartViewModal
    {
        public string statesSelected { get; set; }
        public string AlacartReprtName { get; set; }
        public int Qty { get; internal set; }
        public decimal? Rate { get; set; }
    }

    public class OrderAdditionalChargeViewModel {
        public long Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }        
    }

    public class PlanViewModal
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal? Rate { get; set; }
        public decimal? DiscountAmt { get; set; }
        //public decimal? AccessFees { get; set; }
        public IQueryable<ReportViewModal> ReportViewModal { get; set; }
        public IQueryable<AlacartViewModal> AlacartViewModal { get; set; }        
        public IQueryable<OrderAdditionalChargeViewModel> AdditionalCharges { get; set; }  
    }
}
