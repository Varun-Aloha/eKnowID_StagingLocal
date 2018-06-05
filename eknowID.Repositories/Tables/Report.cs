namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Report")]
    public partial class Report
    {
        public Report()
        {
            AlacartReports = new HashSet<AlacartReport>();
            OrderOptReports = new HashSet<OrderOptReport>();
            PlanReports = new HashSet<PlanReport>();
            ProfessionReports = new HashSet<ProfessionReport>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ReportTypeID { get; set; }

        public bool IsEmpInfoReq { get; set; }

        public bool IsEduInfoReq { get; set; }

        public bool IsLicInfoReq { get; set; }

        public bool IsRefInfoReq { get; set; }

        public bool IsDrugVerificationReq { get; set; }

        public int CriminalCheckNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(50)]
        public string TurnaroundTime { get; set; }

        public string reportShortDesrript { get; set; }
        
        public bool IsMultipleCheckEnabled { get; set; }

        public bool IsActive { get; set; }

        public int MaxVerificationCount { get; set; }

        public virtual ICollection<AlacartReport> AlacartReports { get; set; }

        public virtual ICollection<OrderOptReport> OrderOptReports { get; set; }

        public virtual ICollection<PlanReport> PlanReports { get; set; }

        public virtual ICollection<ProfessionReport> ProfessionReports { get; set; }

        public virtual ReportType ReportType { get; set; }
    }
}
