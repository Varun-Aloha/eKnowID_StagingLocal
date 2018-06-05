namespace eknowID.Repositories
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserPostGraduation")]
    public partial class UserPostGraduation
    {
        public int UserPostGraduationId { get; set; }

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

        public int UserId { get; set; }

        public int? StartMonth { get; set; }

        public int? StartYear { get; set; }

        public int? EndMonth { get; set; }

        public int? EndYear { get; set; }

        public bool? IsAttending { get; set; }

        public virtual User User { get; set; }
    }
}
