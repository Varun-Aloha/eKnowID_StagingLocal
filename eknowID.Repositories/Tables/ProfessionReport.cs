namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProfessionReport")]
    public partial class ProfessionReport
    {
        public int ProfessionReportId { get; set; }

        public int? ProfessionId { get; set; }

        public int? ReportId { get; set; }

        public virtual Profession Profession { get; set; }

        public virtual Report Report { get; set; }
    }
}
