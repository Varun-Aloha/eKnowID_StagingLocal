using System.Collections.Generic;

namespace EknowIDModel
{
    public class Plan
    {
        public int PlanId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public int RateOff
        {
            get;
            set;
        }

        public bool? HasProfessionRelationship
        {
            get;
            set;
        }

        public virtual List<ProfessionPlan> ProfessionPlans
        {
            get;
            set;
        }

        public virtual List<PlanReport> PlanReports
        {
            get;
            set;
        }

        public virtual List<Order> Orders
        {
            get;
            set;
        }
    }
}
