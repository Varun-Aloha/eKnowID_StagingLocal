namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProfessionPlan")]
    public partial class ProfessionPlan
    {
        public int ProfessionPlanId { get; set; }

        public int? ProfessionId { get; set; }

        public int? PlanId { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Profession Profession { get; set; }
    }
}
