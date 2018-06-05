namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReportType")]
    public partial class ReportType
    {
        public ReportType()
        {
            Reports = new HashSet<Report>();
        }

        public int ReportTypeID { get; set; }

        [StringLength(50)]
        public string ReportTypeName { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
