namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AlacartReport")]
    public partial class AlacartReport
    {
        [Key]
        public int AlacartId { get; set; }

        public int? OrderId { get; set; }

        public int? ReportId { get; set; }

        public int Qty { get; set; }

        public string StatesSelected { get; set; }

        public string Couty_DistrictsSelected { get; set; }

        public virtual Order Order { get; set; }

        public virtual Report Report { get; set; }
    }
}
