using System.Collections.Generic;

namespace EknowIDModel
{
    public class Profession
    {
        public virtual int ProfessionId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string ShortDesc
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual List<ProfessionPlan> ProfessionPlans
        {
            get;
            set;
        }

        public virtual List<ProfessionReport> ProfessionReports
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
