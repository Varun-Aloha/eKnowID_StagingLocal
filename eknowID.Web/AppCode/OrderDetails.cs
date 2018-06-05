using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EknowIDModel;

namespace eknowID.AppCode
{
    public class OrderDetails
    {
        public int ProfessionId
        {
            get;
            set;
        }
        public int PlanId
        {
            get;
            set;
        }

        public List<int> OptionalReportIds
        {
            get;
            set;
        }
        public List<ReferenceInfo> ReferenceInfoes
        {
            get;
            set;
        }
        public EducationalDetail EducationalDetail
        {
            get;
            set;
        }
        public LicenseInfo LicenseInfo
        {
            get;
            set;
        }
        public List<EmploymentDetail> EmploymentDetailes
        {
            get;
            set;
        }
        //public bool updatedUserDetails
        //{
        //    get;
        //    set;
        //}

        public DrugVerificationDetail DrugVerificationDetail
        {
            get;
            set;
        }
        public List<Report> ReportList
        {
            get;
            set;
        }
    }
}