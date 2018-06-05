namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Plan")]
    public partial class Plan
    {
        public Plan()
        {
            Orders = new HashSet<Order>();
            PlanReports = new HashSet<PlanReport>();
            ProfessionPlans = new HashSet<ProfessionPlan>();
        }

        public int PlanId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal? Rate { get; set; }

        public int? RateOff { get; set; }

        public bool? HasProfessionRelationship { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<PlanReport> PlanReports { get; set; }

        public virtual ICollection<ProfessionPlan> ProfessionPlans { get; set; }
    }
}
