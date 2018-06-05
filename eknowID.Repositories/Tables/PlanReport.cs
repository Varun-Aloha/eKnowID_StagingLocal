namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanReport")]
    public partial class PlanReport
    {
        public int PlanReportId { get; set; }

        public int? PlanId { get; set; }

        public int? ReportId { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Report Report { get; set; }
    }
}
