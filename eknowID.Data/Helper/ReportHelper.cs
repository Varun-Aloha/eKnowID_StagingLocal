using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;

namespace EknowIDData.Helper
{
    public class ReportHelper
    {

        public static List<Report> GetReports(List<int> reportIds)
        {
            ISpecification<Report> repSpec = new Specification<Report>(r=>reportIds.Contains(r.ReportId));
            IRepository<Report> repRepository = new Repository<Report>();
            return repRepository.SelectAll(repSpec).ToList<Report>();
        }

        public static bool IsEducationInfoReq(int ReportID)
        {
            Repository<Report> reportRepository = new Repository<Report>("ReportId");
            Report report = reportRepository.SelectByKey(ReportID.ToString());
            return report.IsEduInfoReq;
        }

        public static bool IsReferenceInfoReq(int ReportID)
        {
            Repository<Report> reportRepository = new Repository<Report>("ReportId");
            Report report = reportRepository.SelectByKey(ReportID.ToString());
            return report.IsRefInfoReq;
        }

        public static bool IsLicenseInfoReq(int ReportID)
        {
            Repository<Report> reportRepository = new Repository<Report>("ReportId");
            Report report = reportRepository.SelectByKey(ReportID.ToString());
            return report.IsLicInfoReq;
        }
        public static bool IsEmploymentDetailsReq(int ReportID)
        {
            Repository<Report> reportRepository = new Repository<Report>("ReportId");
            Report report = reportRepository.SelectByKey(ReportID.ToString());
            return report.IsEmpInfoReq;
        }
    }
}
