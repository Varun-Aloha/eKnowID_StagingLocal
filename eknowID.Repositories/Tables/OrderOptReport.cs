namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderOptReport")]
    public partial class OrderOptReport
    {
        public int OrderOptReportId { get; set; }

        public int OrderId { get; set; }

        public int ReportId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Report Report { get; set; }
    }
}
