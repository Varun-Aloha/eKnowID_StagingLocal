namespace eknowID.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EducationalDetail")]
    public partial class EducationalDetail
    {
        public EducationalDetail()
        {
            PostGraduationDetails = new HashSet<PostGraduationDetail>();
        }

        public int EducationalDetailId { get; set; }

        public int OrderId { get; set; }

        [StringLength(100)]
        public string Basic { get; set; }

        [StringLength(100)]
        public string Specialization { get; set; }

        [StringLength(100)]
        public string University { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? StateId { get; set; }

        [StringLength(50)]
        public string Municipality { get; set; }

        public int? StartMonth { get; set; }

        public int? StartYear { get; set; }

        public int? EndMonth { get; set; }

        public int? EndYear { get; set; }

        public bool? IsAttending { get; set; }

        public virtual Order Order { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<PostGraduationDetail> PostGraduationDetails { get; set; }
    }
}
