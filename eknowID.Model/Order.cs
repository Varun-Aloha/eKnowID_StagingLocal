using eknowID.Model;
using System;
using System.Collections.Generic;

namespace EknowIDModel
{
    public class Order
    {
        public int OrderId
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public int ProfessionId
        {
            get;
            set;
        }
        public int PlanId
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }

        public string PendingNotes {
            get;
            set;
        }


        public Guid AssessmentId
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public bool? IsResendEmail
        {
            get;
            set;
        }

        public int? ResendEmailCount
        {
            get;
            set;
        }
        
        public virtual Plan Plan
        {
            get;
            set;
        }

        public virtual Profession Profession
        {
            get;
            set;
        }

        public virtual User User
        {
            get;
            set;
        }

        public virtual List<Candidate> Candidates
        {
            get;
            set;
        }
        public virtual List<EducationalDetail> EducationalDetails
        {
            get;
            set;
        }

        public virtual List<LicenseInfo> LicenseInfoes
        {
            get;
            set;
        }

        public virtual List<OrderOptReport> OrderOptReports
        {
            get;
            set;
        }

        public virtual List<ReferenceInfo> ReferenceInfoes
        {
            get;
            set;
        }

        public virtual List<OrderState> OrderStates
        {
            get;
            set;
        }

        public string CorrelationId
        {
            get;
            set;
        }
        public string TransactionId
        {
            get;
            set;
        }

        public int? CouponId
        {
            get;
            set;
        }

        public virtual Coupon Coupon
        {
            get;
            set;
        }
        public DateTime PurchasedDate
        {
            get;
            set;
        }
        public virtual List<EmploymentDetail> EmploymentDetails
        {
            get;
            set;
        }
        public virtual List<DrugVerificationDetail> DrugVerificationDetails
        {
            get;
            set;
        }
        public decimal? DiscountAmt
        {
            get;
            set;
        }
        public decimal PaidAmt
        {
            get;
            set;
        }
        public decimal? RefundAmt {
            get;
            set;
        }
        public int OrderTypeID
        {
            get;
            set;
        }
        public virtual OrderType OrderType
        {
            get;
            set;
        }
        public virtual List<TransactionLog> TransactionLogs
        {
            get;
            set;
        }
        public virtual List<AlacartReport> AlacartReports
        {
            get;
            set;
        }

        public virtual List<OrderAdditionalCharge> OrderAdditionalCharges {
            get;
            set;
        }
    }

    public class OrderAdditionalCharge {
        public long Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual Order Order { get; set; }
    }
}
