namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanType")]
    public partial class PlanType
    {
        public PlanType()
        {
            PlanDetails = new HashSet<PlanDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string PlanName { get; set; }

        [Required]
        [StringLength(100)]
        public string PlanDescription { get; set; }

        [Column(TypeName = "money")]
        public decimal PlanPrice { get; set; }

        public virtual ICollection<PlanDetail> PlanDetails { get; set; }
    }
}
