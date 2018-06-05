namespace eknowID.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            AlacartReports = new HashSet<AlacartReport>();
            DrugVerificationDetails = new HashSet<DrugVerificationDetail>();
            EducationalDetails = new HashSet<EducationalDetail>();
            EmploymentDetails = new HashSet<EmploymentDetail>();
            LicenseInfoes = new HashSet<LicenseInfo>();
            TransactionLogs = new HashSet<TransactionLog>();
            OrderOptReports = new HashSet<OrderOptReport>();
            OrderStates = new HashSet<OrderState>();
            ReferenceInfoes = new HashSet<ReferenceInfo>();
            Candidates = new HashSet<Candidate>();
            OrderAdditionalCharges = new HashSet<OrderAdditionalCharge>();
        }

        public int OrderId { get; set; }

        public int UserId { get; set; }

        public int ProfessionId { get; set; }

        public int PlanId { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [StringLength(300)]
        public string PendingNotes { get; set; }

        [StringLength(50)]
        public string CorrelationId { get; set; }

        [StringLength(50)]
        public string TransactionId { get; set; }

        public int? CouponId { get; set; }

        public DateTime PurchasedDate { get; set; }

        public Guid AssessmentId { get; set; }

        public int Status { get; set; }

        [Column(TypeName = "money")]
        public decimal? DiscountAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaidAmt { get; set; }

        [Column(TypeName = "money")]
        public decimal? RefundAmt { get; set; }        

        public int? OrderTypeID { get; set; }

        public bool? IsResendEmail { get; set; }

        public int? ResendEmailCount { get; set; }

        public virtual ICollection<AlacartReport> AlacartReports { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual ICollection<DrugVerificationDetail> DrugVerificationDetails { get; set; }

        public virtual ICollection<EducationalDetail> EducationalDetails { get; set; }

        public virtual ICollection<EmploymentDetail> EmploymentDetails { get; set; }

        public virtual ICollection<LicenseInfo> LicenseInfoes { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }

        public virtual OrderType OrderType { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Profession Profession { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<TransactionLog> TransactionLogs { get; set; }

        public virtual ICollection<OrderOptReport> OrderOptReports { get; set; }

        public virtual ICollection<OrderState> OrderStates { get; set; }

        public virtual ICollection<ReferenceInfo> ReferenceInfoes { get; set; }

        public virtual ICollection<OrderAdditionalCharge> OrderAdditionalCharges { get; set; }
    }
}
