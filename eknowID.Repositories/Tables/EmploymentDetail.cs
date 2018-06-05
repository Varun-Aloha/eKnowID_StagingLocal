namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EmploymentDetail")]
    public partial class EmploymentDetail
    {
        public int EmploymentDetailId { get; set; }

        public int OrderId { get; set; }

        public int? StateId { get; set; }

        [StringLength(50)]
        public string OrgName { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(30)]
        public string PositionTitle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public string Description { get; set; }

        public int? StartMonth { get; set; }

        public int? StartYear { get; set; }

        public int? EndMonth { get; set; }

        public int? EndYear { get; set; }

        public bool? IsAttending { get; set; }

        public virtual Order Order { get; set; }

        public virtual State State { get; set; }
    }
}
