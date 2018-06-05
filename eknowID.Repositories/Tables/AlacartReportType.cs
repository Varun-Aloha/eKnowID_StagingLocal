namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AlacartReportType")]
    public partial class AlacartReportType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ReportType { get; set; }

        [Column(TypeName = "money")]
        public decimal ReportPrice { get; set; }
    }
}
