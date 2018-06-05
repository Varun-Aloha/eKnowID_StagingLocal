
namespace EknowIDModel
{
    public class OrderOptReport
    {
        public int OrderOptReportId
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        public int ReportId
        {
            get;
            set;
        }

        public virtual Order Order
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
