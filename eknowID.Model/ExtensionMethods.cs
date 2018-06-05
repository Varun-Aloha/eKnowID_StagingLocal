using System;
using System.Collections.Generic;
using System.Linq;

namespace EknowIDModel
{
    public static class ExtensionMethods
    {
        public static Boolean IsEmpInfoRequired(this List<Report> reports)
        {
            var infoRequiredReports = from report in reports
                                      where report.IsEmpInfoReq == true
                                      select report;
            if (infoRequiredReports != null && infoRequiredReports.Count() > 0)
                return true;
            return false;
        }

        public static Boolean IsEduInfoRequired(this List<Report> reports)
        {
            var eduRequiredReports = from report in reports
                                      where report.IsEduInfoReq == true
                                      select report;
            if (eduRequiredReports != null && eduRequiredReports.Count() > 0)
                return true;
            return false;
        }

        public static Boolean IsLicInfoRequired(this List<Report> reports)
        {
            var licRequiredReports = from report in reports
                                      where report.IsLicInfoReq == true
                                      select report;
            if (licRequiredReports != null && licRequiredReports.Count() > 0)
                return true;
            return false;
        }

        public static Boolean IsRefInfoRequired(this List<Report> reports)
        {
            var refRequiredReports = from report in reports
                                     where report.IsRefInfoReq == true
                                     select report;
            if (refRequiredReports != null && refRequiredReports.Count() > 0)
                return true;
            return false;
        }

        public static Boolean IsDrugVerificationRequired(this List<Report> reports)
        {
            var refRequiredReports = from report in reports
                                     where report.IsDrugVerificationReq == true
                                     select report;
            if (refRequiredReports != null && refRequiredReports.Count() > 0)
                return true;
            return false;
        }
    }
}
