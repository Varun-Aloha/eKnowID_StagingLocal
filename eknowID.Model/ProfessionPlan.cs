
namespace EknowIDModel
{
    public class ProfessionPlan
    {
        public virtual int ProfessionPlanId
        {
            get;
            set;
        }
        public virtual int ProfessionId
        {
            get;
            set;
        }
        public virtual int PlanId
        {
            get;
            set;
        }

        public virtual Plan Plan
        {
            get;
            set;
        }

        public virtual Profession Profession
        {
            get;
            set;
        }
    }
}
