using System;
using System.Collections.Generic;

namespace EknowIDModel
{
    public class Report
    {
        public virtual int ReportId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual bool IsActive {
            get;
            set;
        }

        public virtual bool IsEmpInfoReq
        {
            get;
            set;
        }
        public virtual bool IsEduInfoReq
        {
            get;
            set;
        }
        public virtual bool IsLicInfoReq
        {
            get;
            set;
        }
        public virtual bool IsRefInfoReq
        {
            get;
            set;
        }
        public virtual bool IsDrugVerificationReq
        {
            get;
            set;
        }
        public virtual int CriminalCheckNumber
        {
            get;
            set;
        }
        public virtual int ReportTypeID { get; set; }
        public virtual ReportType ReportType { get; set; } 
        public virtual Decimal? Price
        {
            get;
            set;
        }

        public virtual List<ProfessionReport> ProfessionReports
        {
            get;
            set;
        }

        public virtual List<PlanReport> PlanReports
        {
            get;
            set;
        }

        public virtual List<OrderOptReport> OrderOptReports
        {
            get;
            set;
        }
        public virtual List<AlacartReport> AlacartReports
        {
            get;
            set;
        }
        public virtual string TurnaroundTime
        {
            get;
            set;
        }
        public virtual string reportShortDesrript
        {
            get;
            set;
        }        
        public virtual bool IsMultipleCheckEnabled {
            get;
            set;
        }

        public virtual int MaxVerificationCount {
            get;
            set;
        }

        public virtual int qty {
            get;
            set;
        }
    }
}
