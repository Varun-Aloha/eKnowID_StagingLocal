namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PostGraduationDetail")]
    public partial class PostGraduationDetail
    {
        [Key]
        public int PostGraduationId { get; set; }

        public int EducationalDetailId { get; set; }

        [StringLength(50)]
        public string PostGraduation { get; set; }

        [StringLength(50)]
        public string Specialization { get; set; }

        [StringLength(50)]
        public string University { get; set; }

        [StringLength(50)]
        public string Municipality { get; set; }

        public int StateId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public int? StartMonth { get; set; }

        public int? StartYear { get; set; }

        public int? EndMonth { get; set; }

        public int? EndYear { get; set; }

        public bool? IsAttending { get; set; }

        public virtual EducationalDetail EducationalDetail { get; set; }

        public virtual State State { get; set; }
    }
}
