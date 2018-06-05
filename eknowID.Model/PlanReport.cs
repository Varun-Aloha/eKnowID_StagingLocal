
namespace EknowIDModel
{
    public class PlanReport
    {
        public virtual int PlanReportId
        {
            get;
            set;
        }
        public virtual int ReportId
        {
            get;
            set;
        }
        public virtual int PlanId
        {
            get;
            set;
        }

        public virtual Report Report
        {
            get;
            set;
        }

        public virtual Plan Plan
        {
            get;
            set;
        }
    }
}
