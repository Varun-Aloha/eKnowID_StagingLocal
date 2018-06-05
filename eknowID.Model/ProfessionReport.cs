
namespace EknowIDModel
{
    public class ProfessionReport
    {
        public virtual int ProfessionReportId
        {
            get;
            set;
        }

        public virtual int ProfessionId
        {
            get;
            set;
        }

        public virtual int ReportId
        {
            get;
            set;
        }

        public virtual Profession Profession
        {
            get;
            set;
        }

        public virtual Report Report
        {
            get;
            set;
        }
    }
}
