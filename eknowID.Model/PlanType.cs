using System.Collections.Generic;

namespace EknowIDModel
{
    public class PlanType
    {
        public int Id
        {
            get;
            set;
        }

        public string PlanName
        {
            get;
            set;
        }

        public string PlanDescription
        {
            get;
            set;
        }
        public decimal PlanPrice
        {
            get;
            set;
        }

        public virtual List<PlanDetail> PlanDetails
        {
            get;
            set;
        }
    }
}
