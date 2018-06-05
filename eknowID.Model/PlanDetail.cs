
namespace EknowIDModel
{
    public class PlanDetail
    {
        public int Id
        {
            get;
            set;
        }

        public int PlanId
        {
            get;
            set;
        }

        public string PlanDetails
        {
            get;
            set;
        }
        public virtual PlanType PlanType
        {
            get;
            set;
        }
    }
}
