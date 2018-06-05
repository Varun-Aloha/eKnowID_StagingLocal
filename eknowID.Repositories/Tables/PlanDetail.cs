namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlanDetail")]
    public partial class PlanDetail
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        [StringLength(300)]
        public string PlanDetails { get; set; }

        public virtual PlanType PlanType { get; set; }
    }
}
