namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Profession")]
    public partial class Profession
    {
        public Profession()
        {
            Orders = new HashSet<Order>();
            ProfessionPlans = new HashSet<ProfessionPlan>();
            ProfessionReports = new HashSet<ProfessionReport>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProfessionId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(200)]
        public string ShortDesc { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ProfessionPlan> ProfessionPlans { get; set; }

        public virtual ICollection<ProfessionReport> ProfessionReports { get; set; }
    }
}
